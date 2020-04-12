using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace NBAPredictor
{    
    public class FieldGoalStatsProvider : WebStatsProvider
    {
        public FieldGoalStatsProvider(HttpClient client) : base(client)
        {
        }

        public override async Task GetStatsAsync(Dictionary<string, TeamStats> allStats)
        {
            var results = await _client.GetStringAsync(string.Empty);
            var doc = new HtmlDocument();
            doc.LoadHtml(results);
            var fieldGoalValidator = new FieldGoalStatsValidator();
            foreach (var node in doc.DocumentNode.SelectNodes("//table/tbody/tr"))
            {
                var columns = node.SelectNodes("td").ToArray();
                var valResult = fieldGoalValidator.Validate(columns);
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
                stats.FieldGoal = decimal.Parse(columns[2].InnerText.TrimEnd('%'), CultureInfo.InvariantCulture);
                stats.FieldGoalHome = decimal.Parse(columns[5].InnerText.TrimEnd('%'), CultureInfo.InvariantCulture);
                stats.FieldGoalAway = decimal.Parse(columns[6].InnerText.TrimEnd('%'),CultureInfo.InvariantCulture);
            }

        }
    }
}
