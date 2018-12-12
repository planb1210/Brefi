using Brefi.WebApi.App_Start;
using System.Web.Http;

namespace Brefi.WebApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            Container.ConfigureContainer();
        }
    }
}
