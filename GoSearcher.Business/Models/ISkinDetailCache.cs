using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoSearcher.Business.Models
{
    public interface ISkinDetailCache
    {
        SkinDetail Get(string name);
    }
}
