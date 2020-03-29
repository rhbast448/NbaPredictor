using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Text;

namespace NBAPredictor
{
    public class StatsImporter : IStatsImporter
    {
        private readonly HtmlWeb _htmlWeb;

        public StatsImporter(HtmlWeb htmlWeb )
        {
            _htmlWeb = htmlWeb;
        }

        public List<string> GetRawTurnovers(string url, string xpath)
        {
            var webget = _htmlWeb;
            var doc = webget.Load(url);            
            var stats = new List<string>();

            foreach (var cell in doc.DocumentNode.SelectNodes(xpath))
            {
                stats.Add(cell.InnerText);
            }
            return stats;
        }
    }
}
