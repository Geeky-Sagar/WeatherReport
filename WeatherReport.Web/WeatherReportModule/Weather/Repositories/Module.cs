using WeatherReportModule.Registry;

namespace WeatherReportModule.Weather.Repositories
{
    public class Module : IModule
    {
        public void Configure(IRegistry registry)
        {
            registry.Register<Datastores.Module>();

            registry.Register<IWeatherDetailRepository, WeatherDetailRepository>(ImplementationScope.Shared);
        }
    }
}
