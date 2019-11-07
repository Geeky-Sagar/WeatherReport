using WeatherReportModule.Weather.Repositories.Datastores;

namespace WeatherReportModule.Weather.Repositories.Gateways
{
    public class WeatherDetailGateway : GatewayBase
    {
        public string FetchWeatherDetailByCity(int cityId)
        {
            var datastore = Resolve<IWeatherDetailsDatastore>();

            string weatherData = datastore.FetchWeatherDetailByCity(cityId);

            return weatherData;
        }
    }
}
