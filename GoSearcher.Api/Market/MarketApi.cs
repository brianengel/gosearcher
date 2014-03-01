using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;

namespace GoSearcher.Api.Market
{
    public class MarketApi : IMarketApi
    {
        private readonly RestClient client;

        public MarketApi()
        {
            client = new RestClient("http://steamcommunity.com");
        }

        public MarketResult Search(string query)
        {
            RestRequest request = new RestRequest("market/search/render", Method.GET);
            request.AddParameter("query", buildQuery(query), ParameterType.QueryString);
            request.AddParameter("start", "0", ParameterType.QueryString);
            request.AddParameter("count", "100000", ParameterType.QueryString);

            var response = client.Execute(request);

            var result = JsonConvert.DeserializeObject<MarketResult>(response.Content);

            return result;
        }

        private string buildQuery(string query)
        {
            return "appid:730 " + query;
        }
    }
}
