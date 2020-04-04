using System;
using System.IO;
using System.Threading.Tasks;
using HtmlAgilityPack;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace NBAPredictor
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var provider = GetServiceProvider();
            using var scope = provider.CreateScope();
            var statsProcessor = scope.ServiceProvider.GetRequiredService<IStatsProcessor>();

            var teamStats = await statsProcessor.GetDailyStatsAsync();
            //persist the daily stats
        }

        static IServiceProvider GetServiceProvider()
        {
            var services = new ServiceCollection();
            services.AddScoped<HtmlWeb>();            
            return services.BuildServiceProvider();
        }

        

        

    }
}
