

using FluentAssertions;
using NBAPredictor;
using NSubstitute;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace NbaPredictor.Test
{
    public class StatsProcessorTests
    {
        [Fact]
        public async Task GetDailyStatsReturnsTwoTeamStatsFromProviders()
        {
            var provider1 = Substitute.For<IStatsProvider>();
            var houstonStats = new Dictionary<string, object> { ["Team"] = "Houston", ["Turnover"] = 0.5m };
            var newyorkStats = new Dictionary<string, object> { ["Team"] = "New York", ["Turnover"] = 0.6m };            

            var teamStats = new[] { houstonStats, newyorkStats };
            provider1.GetStatsAsync().Returns(Task.FromResult(teamStats));
            var providers = new[] { provider1 };
            var statsProcessor = new StatsProcessor(providers);
            var results = await statsProcessor.GetDailyStatsAsync();
            results.Should().BeEquivalentTo(new { Name = "Houston", Turnover = .5m },
                new { Name = "New York", Turnover = .6m });
                
        }

        [Fact]
        public async Task GetDailyStatsReturnsAllTeamsStatsFromProviders()
        {
            var provider1 = Substitute.For<IStatsProvider>();
            var houstonStats = new Dictionary<string, object> { ["Team"] = "Houston", ["Turnover"] = 0.5m};
            var newyorkStats = new Dictionary<string, object> { ["Team"] = "New York", ["Turnover"] = 0.6m };
            var dallasStats = new Dictionary<string, object> { ["Team"] = "Dallas", ["Turnover"] = 0.7m };

            var teamStats = new[] { houstonStats, newyorkStats, dallasStats };
            provider1.GetStatsAsync().Returns(Task.FromResult(teamStats));
            var providers = new[] { provider1 }; 
            var statsProcessor = new StatsProcessor(providers);
            var results = await statsProcessor.GetDailyStatsAsync();
            results.Should().BeEquivalentTo(new { Name = "Houston", Turnover = .5m },
                new { Name = "New York", Turnover = .6m },
                new { Name = "Dallas", Turnover = .7m });
        }
    }
}
