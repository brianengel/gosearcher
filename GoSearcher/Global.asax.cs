using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Ninject;
using Ninject.Web.Mvc;

namespace GoSearcher
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            IKernel kernel = new StandardKernel(new GoSearcherModule());
            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));

        }
    }
}
