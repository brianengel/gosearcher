using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace GoSearcher.Api.Market
{
    public class MarketResult
    {
        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("results_html")]
        public string ResultsHtml { get; set; }

        [JsonProperty("start")]
        public int Start { get; set; }

        [JsonProperty("pagesize")]
        public string PageSize { get; set; }

        [JsonProperty("total_count")]
        public int TotalCount { get; set; }
    }
}
