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
            //string url = "https://www.covers.com/sports/nba";
            //var webget = new HtmlWeb();
            //var doc = webget.Load(url);

            //var teamFirstPass = new List<string>();
            //var games = new List<Game>();

            //foreach (var cell in doc.DocumentNode.SelectNodes("//table/tr/td"))
            //{                
            //    var tdContent = Regex.Replace(cell.InnerText, @"\s+", string.Empty);
            //    teamFirstPass.Add(tdContent);
            //}

            //var teamSecondPass = teamFirstPass.GetRange(0, 100);
            //for (int i = 0; i < teamSecondPass.Count; i+=10)
            //{
            //    var gameToAdd = new Game
            //    {
            //        DateOfImport = DateTime.Now,
            //        DateOfGame = DateTime.Now,
            //        Visitor = teamSecondPass[0 + i],
            //        Home = teamSecondPass[5 + i],
            //        Spread = decimal.Parse(teamSecondPass[6 + i])
            //    };
            //    games.Add(gameToAdd);
            //}

            //add try parse, if it fails don't add the object
            //limit to games with names in a list
            //how do we get the game day?
            //avoid games in play?
            //if there is a game with the same DateOfGame,Visitor,Home combo don't add the game

            //data importer

            //get data daily from www.teamrankings.com
            //get games with spreads periodically during the day
            //computer scores for each game and make "bets"
            //make sure to update the right game with scores

            //var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            //IConfigurationRoot configuration = builder.Build();

            //Console.WriteLine(configuration.GetConnectionString("Test"));
            //Console.ReadLine();

            var provider = GetServiceProvider();
            using var scope = provider.CreateScope();

            //var statsProvider = scope.ServiceProvider.GetRequiredService<IStatsProvider>();

            var statsImporter = scope.ServiceProvider.GetRequiredService<IStatsImporter>();
            var statsProcessor = scope.ServiceProvider.GetRequiredService<IStatsProcessor>();
            var url = "https://www.teamrankings.com/nba/stat/turnovers-per-game";
            var xpath = "//table/tbody/tr/td";            
            var rawTurnovers = statsImporter.GetRawTurnovers(url, xpath);
            var turnovers = statsProcessor.ProcessRawTurnovers(rawTurnovers);

            // getBlah(url, xpath, { Column = 2, ColumnName = "Team"},{ Column = 3, ColumnName = "TOP"},{ Column = 6, ColumnName = "TOPA"},{ Column = 7, ColumnName = "TOPH"})

            //put urls and xpaths in config            
            //map columns to object properties
            //persist turnovers

            Console.ReadLine();                       

        }

        static IServiceProvider GetServiceProvider()
        {
            var services = new ServiceCollection();
            services.AddScoped<HtmlWeb>();
            services.AddScoped<IStatsImporter, StatsImporter>();
            services.AddScoped<IStatsProcessor, StatsProcessor>();
            return services.BuildServiceProvider();
        }

        

        

    }
}
