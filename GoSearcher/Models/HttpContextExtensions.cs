using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
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

            return String.Format("{0}://{1}{2}", baseUrl.Scheme, baseUrl.Authority, basePath);
        }
    }
}