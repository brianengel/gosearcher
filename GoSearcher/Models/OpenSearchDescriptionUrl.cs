using System.Xml.Serialization;

namespace GoSearcher.Models
{
    public class OpenSearchDescriptionUrl
    {
        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }

        [XmlAttribute(AttributeName = "method")]
        public string Method { get; set; }

        [XmlAttribute(AttributeName = "template")]
        public string Template { get; set; }
    }
}