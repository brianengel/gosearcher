using Newtonsoft.Json;

namespace GoSearcher.Business.Models
{
    public class Skin
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("image")]
        public string ImageUrl { get; set; }

        [JsonProperty("imageThumbnail")]
        public string ImageThumbnail { get { return ImageUrl + "62fx62f"; } }

        [JsonProperty("imageLarge")]
        public string ImageLarge { get { return ImageUrl + "360fx360f"; } }

        [JsonProperty("quantity")]
        public int Quantity { get; set; }

        [JsonProperty("price")]
        public decimal Price { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("color")]
        public string Color { get; set; }

        [JsonProperty("priceDisplay")]
        public string DisplayPrice { get { return Price.ToString("C"); } }
    }
}
