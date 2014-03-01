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
    public class HomeController : Controller
    {
        private readonly IMarketApi market;

        public HomeController(IMarketApi market)
        {
            this.market = market;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Search(string query)
        {
            MarketResult search = market.Search(query);
            SteamMarketParser parser = new SteamMarketParser();

            var results = parser.Parse(search.ResultsHtml);

            string json = JsonConvert.SerializeObject(results);

            return Content(json, "application/json");
        }
	}
}