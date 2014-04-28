using System;
using System.Web;
using System.Web.Mvc;

namespace GoSearcher.Models
{
    public static class HttpContextExtensions
    {
        public static string RootUrl(this HttpContextBase context)
        {
            Uri baseUrl = context.Request.Url;
            string basePath = UrlHelper.GenerateContentUrl("~", context);
            string host = baseUrl.Host;

#if DEBUG
            host = baseUrl.Authority;
#endif

            return String.Format("{0}://{1}{2}", baseUrl.Scheme, host, basePath);
        }
    }
}