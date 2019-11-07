using WeatherReportModule.Command;
using WeatherReportModule.Registry;
using WeatherReportModule.Weather.Commands.TransferObjects;
using WeatherReportModule.Weather.Repositories;

namespace WeatherReportModule.Weather.Commands.Impl
{
    public class FetchWeatherDataCommand : ICommand<WeatherDataResult, WeatherDataRequest>
    {
        public WeatherDataResult Execute(WeatherDataRequest parameters)
        {
            IResolver resolver = RegistryFactory.GetResolver();
            var weatherRepository = resolver.Resolve<IWeatherDetailRepository>();

            string weatherData = weatherRepository.FetchWeatherDetailByCity(parameters.CityID);
            
            WeatherDataResult result = new WeatherDataResult();
            result.WeatherData = weatherData;

            return result;
        }
    }
}
