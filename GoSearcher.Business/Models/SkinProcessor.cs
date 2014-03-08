using System.Collections.Generic;

namespace GoSearcher.Business.Models
{
    public class SkinProcessor : ISkinProcessor
    {
        private List<Skin> data;
        private List<ISkinTransformer> transforms;

        public SkinProcessor(IEnumerable<SteamMarketEntry> initialList)
        {
            data = new List<Skin>();
            transforms = new List<ISkinTransformer>();

            foreach (var item in initialList)
            {
                data.Add(new Skin()
                {
                    Color = item.Color,
                    ImageUrl = item.ImageUrl,
                    Name = item.Name,
                    Price = item.Price,
                    Quantity = item.Quantity,
                    Url = item.Url
                });
            }
        }

        public void AddTransform(ISkinTransformer transformer)
        {
            transforms.Add(transformer);
        }

        public List<Skin> Run()
        {
            List<Skin> results = data;
            foreach (var transform in transforms)
            {
                results = transform.Execute(results);
            }

            return results;
        }
    }
}
