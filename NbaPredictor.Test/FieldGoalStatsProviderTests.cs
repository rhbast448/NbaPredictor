using FluentAssertions;
using NBAPredictor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace NbaPredictor.Test
{
    public class FieldGoalStatsProviderTests
    {
        [Fact]
        public async Task GetStatsReturnsStatsFromWebProvider()
        {
            var httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://www.teamrankings.com/nba/stat/effective-field-goal-pct")
            };
            var statsProvider = new FieldGoalStatsProvider(httpClient);
            var teamStats = new Dictionary<string, TeamStats>();
            await statsProvider.GetStatsAsync(teamStats);

            teamStats.Should().HaveCount(30);
            teamStats.Select(x => x.Value.Name).Should().BeEquivalentTo("San Antonio", "Orlando", "Dallas", "Portland", "Indiana", "Okla City", "Boston", "Denver", "Washington", "Philadelphia", "New York", "Sacramento", "Toronto", "Charlotte", "Houston", "LA Clippers", "Utah", "Golden State", "Milwaukee", "Miami", "Phoenix", "LA Lakers", "Memphis", "Detroit", "Minnesota", "Chicago", "Brooklyn", "Atlanta", "New Orleans", "Cleveland");

        }
    }
}
