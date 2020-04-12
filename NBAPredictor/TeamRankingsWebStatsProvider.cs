using FluentValidation;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace NBAPredictor
{
    public abstract class TeamRankingsWebStatsProvider : WebStatsProvider
    {
        private readonly IValidator _validator;

        public TeamRankingsWebStatsProvider(HttpClient client, IValidator validator) : base(client)
        {
            this._validator = validator;
        }

        public override async Task GetStatsAsync(Dictionary<string, TeamStats> allStats)
        {
            var results = await _client.GetStringAsync(string.Empty);
            var doc = new HtmlDocument();
            doc.LoadHtml(results);
            
            foreach (var node in doc.DocumentNode.SelectNodes("//table/tbody/tr"))
            {
                var columns = node.SelectNodes("td").ToArray();
                var valResult = _validator.Validate(columns);
                if (!valResult.IsValid)
                {
                    var errorMessage = valResult.Errors.Select(y => y.ErrorMessage);
                    throw new InvalidOperationException(String.Join(Environment.NewLine, errorMessage));
                }
                var teamName = columns[1].InnerText;
                if (!allStats.TryGetValue(teamName, out var stats))
                {
                    stats = new TeamStats();
                    allStats.Add(teamName, stats);
                }
                stats.Name = teamName;
                FillStats(stats, columns);
            }

        }

        protected abstract void FillStats(TeamStats stats, HtmlNode[] columns);
    }
}
