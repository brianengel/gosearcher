using System.Collections.Generic;

namespace GoSearcher.Business.Models
{
    public class MetaDataSkinTransformer : ISkinTransformer
    {
        private readonly ISkinDetailCache cache;

        public MetaDataSkinTransformer(ISkinDetailCache cache)
        {
            this.cache = cache;
        }

        public List<Skin> Execute(IEnumerable<Skin> data)
        {
            List<Skin> result = new List<Skin>();

            foreach (var item in data)
            {
                SkinDetail metaData = cache.Get(item.Name);

                if (metaData != null)
                {
                    item.ImageUrl = metaData.ImageUrl;
                }

                result.Add(item);
            }

            return result;
        }
    }
}
