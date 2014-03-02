using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GoSearcher.Api.Market;
using GoSearcher.Business.Html;
using Newtonsoft.Json;

namespace GoSearcher.Controllers
{
    public class SearchController : Controller
    {
        private readonly IMarketApi market;

        public SearchController(IMarketApi market)
        {
            this.market = market;
        }

        [OutputCache(Duration = 120, VaryByParam = "query")]
        public ActionResult Index(string query)
        {
            MarketResult search = market.Search(query);
            SteamMarketParser parser = new SteamMarketParser();

            var results = parser.Parse(search.ResultsHtml).OrderBy(x => x.Name);

            string json = JsonConvert.SerializeObject(results);

            return Content(json, "application/json");
        }
	}
}