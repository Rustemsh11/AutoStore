using AutoStore.Domain.Concrete;
using AutoStore.Domain.Entities;
using AutoStore.WebUI.Infrastructure.Binders;
using System.Data.Entity;
using System.Web.Mvc;
using System.Web.Routing;

namespace AutoStore.WebUI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Database.SetInitializer<AutoContext>(null);
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            ModelBinders.Binders.Add(typeof(Cart), new CartModelBinder());
            
        }
    }
}
