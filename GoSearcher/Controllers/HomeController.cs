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
        [OutputCache(Duration=60)]
        public ActionResult Index()
        {
            return View();
        }

	}
}