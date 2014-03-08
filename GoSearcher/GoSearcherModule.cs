using GoSearcher.Api.Market;
using GoSearcher.Business.Models;
using Ninject.Modules;

namespace GoSearcher
{
    public class GoSearcherModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IMarketApi>().To<MarketApi>();
            Bind<ISkinDetailCache>().ToConstant<SkinDetailCache>(SkinDetailCache.Current);
            Bind<ISkinProcessor>().To<SkinProcessor>();
        }
    }
}