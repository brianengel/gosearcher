using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using GoSearcher.Api.Market;
using GoSearcher.Business.Models;

namespace GoSearcher.ApiControllers
{
    [RoutePrefix("api/items")]
    public class ItemsController : ApiController
    {
        private readonly IMarketApi market;
        private readonly ISkinDetailCache cache;

        public ItemsController(IMarketApi market, ISkinDetailCache cache)
        {
            this.market = market;
            this.cache = cache;
        }

        [Route]
        public IHttpActionResult GetItems()
        {
            return Ok("yay");
        }
    }
}