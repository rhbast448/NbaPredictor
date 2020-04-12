using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace NBAPredictor
{
    public abstract class WebStatsProvider : IStatsProvider
    {
        
        protected readonly HttpClient _client;

        public WebStatsProvider(HttpClient client)
        {            
            this._client = client;
        } 

        public abstract Task GetStatsAsync(Dictionary<string, TeamStats> allStats);
        
    }
}
