using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;


namespace NBAPredictor
{
    public class TurnoverStatsProvider : WebStatsProvider
    {
        public TurnoverStatsProvider(HttpClient client) : base(client)
        {            
        }
        public override async Task<Dictionary<string, object>[]> GetStatsAsync()
        {
            var results = await _client.GetStringAsync(string.Empty);
            var doc = new HtmlDocument();
            doc.LoadHtml(results);
            var turnoverValidator = new TurnoverStatsValidator();
            var rows = doc.DocumentNode.SelectNodes("//table/tbody/tr").Select(x =>
            {
                var columns = x.SelectNodes("td").ToArray();
                var valResult = turnoverValidator.Validate(columns);
                if (!valResult.IsValid)
                {
                    var errorMessage = valResult.Errors.Select(y => y.ErrorMessage);
                    throw new InvalidOperationException(String.Join(Environment.NewLine, errorMessage));
                }
                return new Dictionary<string, object>
                {
                    ["Team"] = columns[1].InnerText,
                    ["PercentByYear"] = Decimal.Parse(columns[2].InnerText),
                    ["PercentByYearHome"] = Decimal.Parse(columns[5].InnerText),
                    ["PercentByYearAway"] = Decimal.Parse(columns[6].InnerText)
                };
            }).ToArray();           
            return rows.ToArray();
        }
    }
}
