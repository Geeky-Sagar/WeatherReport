using WeatherReportModule.Registry;

namespace WeatherReportModule.Weather.Repositories.Gateways
{
    public abstract class GatewayBase
    {
        protected T Resolve<T>()
        {
            return RegistryFactory.GetResolver().Resolve<T>();
        }
    }
}
