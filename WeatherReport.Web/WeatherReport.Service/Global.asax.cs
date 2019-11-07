using System.Web.Http;
using WeatherReportModule;
using WeatherReportModule.Registry;

namespace WeatherReport.Service
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            // Code that runs on application startup      
            IRegistry registry = RegistryFactory.GetRegistry();
            registry.Register<Module>();

        }
    }
}
