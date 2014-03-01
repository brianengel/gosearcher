using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GoSearcher.Api.Market;
using Ninject.Modules;

namespace GoSearcher
{
    public class GoSearcherModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IMarketApi>().To<MarketApi>();
        }
    }
}