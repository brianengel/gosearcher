using System.Xml.Serialization;

namespace GoSearcher.Models
{
    [XmlRoot(Namespace = "http://a9.com/-/spec/opensearch/1.1/")]
    public class OpenSearchDescription
    {
        public string ShortName { get; set; }
        public string Description { get; set; }
        public OpenSearchDescriptionUrl Url { get; set; }
        public string InputEncoding { get; set; }
        public string SearchForm { get; set; }
    }
}