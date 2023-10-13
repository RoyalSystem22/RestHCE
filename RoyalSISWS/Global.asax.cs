using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace RoyalSISWS
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801d
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //var scriptSerializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            //var serializerMaxJsonLengthField = scriptSerializer.GetType().GetField("_maxJsonLength",
            //    System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
            //if (serializerMaxJsonLengthField != null)
            //{
            //    serializerMaxJsonLengthField.SetValue(scriptSerializer, Int32.MaxValue); // O el valor deseado
            //}

            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);


        }
    }
}