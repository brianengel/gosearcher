using System.Text;
using System.Web.Mvc;
using System.Xml;
using System.Xml.Serialization;

namespace GoSearcher.ActionResults
{
    public class XmlActionResult : ActionResult
    {
        private readonly object data;
        private readonly XmlWriterSettings settings;

        private static string mimeType = "text/xml";
        private static XmlWriterSettings defaultSettings = new XmlWriterSettings
        {
            Indent = true,
            OmitXmlDeclaration = false,
            Encoding = Encoding.UTF8
        };

        public XmlActionResult(object data) : this(data, defaultSettings) { }

        public XmlActionResult(object data, XmlWriterSettings settings)
        {
            this.data = data;
            this.settings = settings;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            var response = context.HttpContext.Response;

            response.Clear();
            response.ContentType = mimeType;

            using (XmlWriter xmlWriter = XmlWriter.Create(response.OutputStream, settings))
            {
                var serializer = new XmlSerializer(data.GetType());
                serializer.Serialize(xmlWriter, data);
            }
        }
    }
}