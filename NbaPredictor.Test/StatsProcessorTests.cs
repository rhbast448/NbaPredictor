

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
        public async Task GetDailyStatsAsyncCallsAllProviders()
        {            
            var provider1 = Substitute.For<IStatsProvider>();
            var provider2 = Substitute.For<IStatsProvider>();
            provider1.When(x => x.GetStatsAsync(Arg.Is<Dictionary<string, TeamStats>>(x => x.Keys.Count == 0))).Do(Callback.First(x => x.Arg<Dictionary<string, TeamStats>>().Add("test", null)));              
            var providers = new[] { provider1, provider2 };
            var statsProcessor = new StatsProcessor(providers);
            var results = await statsProcessor.GetDailyStatsAsync();
            await provider1.Received(1).GetStatsAsync(Arg.Is<Dictionary<string, TeamStats>>(x => x.ContainsKey("test")));
        }        
    }
}
