using System;
using System.IO;
using HtmlAgilityPack;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace NBAPredictor
{
    class Program
    {
        static void Main(string[] args)
        {
            var provider = GetServiceProvider();
            using var scope = provider.CreateScope();
            var statsProvider = scope.ServiceProvider.GetRequiredService<IStatsProvider>();                                

        }

        static IServiceProvider GetServiceProvider()
        {
            var services = new ServiceCollection();
            services.AddScoped<HtmlWeb>();            
            return services.BuildServiceProvider();
        }

        

        

    }
}
