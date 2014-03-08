using System.Collections.Generic;

namespace GoSearcher.Business.Models
{
    public interface ISkinProcessor
    {
        List<Skin> Run();
        void AddTransform(ISkinTransformer transformer);
    }
}
