using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoSearcher.Api.Market
{
    public interface IMarketApi
    {
        MarketResult Search(string query);
    }
}
