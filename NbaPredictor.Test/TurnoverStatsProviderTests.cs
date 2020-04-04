using FluentAssertions;
using NBAPredictor;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace NbaPredictor.Test
{
    public class TurnoverStatsProviderTests
    {
        [Fact]
        public async Task GetStatsReturnsStatsFromWebProvider()
        {
            var httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://www.teamrankings.com/nba/stat/turnovers-per-game")
            };
            var statsProvider = new TurnoverStatsProvider(httpClient);
            var result = await statsProvider.GetStatsAsync();            
            result.Should().HaveCount(30);
            result.Select(x => x["Team"].ToString()).Should().BeEquivalentTo("San Antonio", "Orlando", "Dallas", "Portland", "Indiana", "Okla City", "Boston", "Denver", "Washington", "Philadelphia", "New York", "Sacramento", "Toronto", "Charlotte", "Houston", "LA Clippers", "Utah", "Golden State", "Milwaukee", "Miami", "Phoenix", "LA Lakers", "Memphis", "Detroit", "Minnesota", "Chicago", "Brooklyn", "Atlanta", "New Orleans", "Cleveland");
            result.Select(x => new
            {
                PercentByYear = x["PercentByYear"].GetType(),
                PercentByYearHome = x["PercentByYearHome"].GetType(),
                PercentByYearAway = x["PercentByYearAway"].GetType()
            }).Should().AllBeEquivalentTo(new { PercentByYear = typeof(decimal), 
                PercentByYearHome = typeof(decimal), PercentByYearAway = typeof(decimal) });
        }

    }
}
