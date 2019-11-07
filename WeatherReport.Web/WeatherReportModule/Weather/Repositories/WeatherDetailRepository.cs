using WeatherReportModule.Weather.Repositories.Gateways;

namespace WeatherReportModule.Weather.Repositories
{
   public class WeatherDetailRepository : IWeatherDetailRepository
    {
        public string FetchWeatherDetailByCity(int cityId)
        {
            return new WeatherDetailGateway().FetchWeatherDetailByCity(cityId);
        }
    }
}
