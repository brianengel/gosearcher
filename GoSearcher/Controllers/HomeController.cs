using System;
using System.IO;
using System.Text;
using System.Web.Mvc;
using System.Xml;
using System.Xml.Serialization;
using GoSearcher.Models;
using GoSearcher.ViewModels.Home;

namespace GoSearcher.Controllers
{
    public class HomeController : Controller
    {
        [OutputCache(Duration = 60)]
        public ActionResult Index()
        {
            return View(new HomeIndexViewModel());
        }

        [Route("opensearch.xml")]
        public ActionResult OpenSearch()
        {
            string template = String.Format("{0}?q={{searchTerms}}", HttpContext.RootUrl());

            OpenSearchDescription osd = new OpenSearchDescription()
            {
                ShortName = "CS:GO Searcher",
                Description = "Quickly search the CS:GO Steam market.",
                Url = new OpenSearchDescriptionUrl()
                {
                    Method = "get",
                    Type = "text/html",
                    Template = template
                },
                InputEncoding = "UTF-8"
            };

            string xml;
            XmlWriterSettings xmlWriterSettings = new XmlWriterSettings
            {
                Indent = true,
                OmitXmlDeclaration = false,
                Encoding = Encoding.UTF8
            };

            using (MemoryStream ms = new MemoryStream())
            using (XmlWriter xmlWriter = XmlWriter.Create(ms, xmlWriterSettings))
            {
                StreamReader sr = new StreamReader(ms, Encoding.UTF8);
                var x = new XmlSerializer(typeof(OpenSearchDescription));
                x.Serialize(xmlWriter, osd);

                xmlWriter.Flush();

                ms.Seek(0, SeekOrigin.Begin);
                xml = sr.ReadToEnd();
            }

            return Content(xml, "text/xml");
        }

    }
}