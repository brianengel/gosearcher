using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using GoSearcher.Api.Market;
using GoSearcher.Business.Html;
using GoSearcher.Business.Models;
using Newtonsoft.Json;

namespace GoSearcher.Controllers
{
    public class SearchController : Controller
    {
        private readonly IMarketApi market;
        private readonly ISkinDetailCache cache;

        public SearchController(IMarketApi market, ISkinDetailCache cache)
        {
            this.market = market;
            this.cache = cache;
        }

        [OutputCache(Duration = 120, VaryByParam = "query")]
        public ActionResult Index(string query)
        {
            MarketResult search = market.Search(query);
            SteamMarketParser parser = new SteamMarketParser();

            var results = parser.Parse(search.ResultsHtml).OrderBy(x => x.Name);

            SkinProcessor processor = new SkinProcessor(results);
            processor.AddTransform(new MetaDataSkinTransformer(cache));

            List<Skin> skins = processor.Run();

            string json = JsonConvert.SerializeObject(skins);

            return Content(json, "application/json");
        }
    }
}