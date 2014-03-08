using System.Collections.Generic;

namespace GoSearcher.Business.Models
{
    public interface ISkinTransformer
    {
        List<Skin> Execute(IEnumerable<Skin> data);
    }
}
