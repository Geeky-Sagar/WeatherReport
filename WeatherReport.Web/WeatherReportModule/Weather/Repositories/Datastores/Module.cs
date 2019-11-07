using WeatherReportModule.Registry;

namespace WeatherReportModule.Weather.Repositories.Datastores
{
    public class Module : IModule
    {
        public void Configure(IRegistry registry)
        {
            registry.Register<IWeatherDetailsDatastore, WeatherDetailsDatastore>(ImplementationScope.Shared);
        }
    }
}
