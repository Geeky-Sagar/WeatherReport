using WeatherReportModule.Command;
using WeatherReportModule.Weather.Commands.TransferObjects;

namespace WeatherReportModule.Weather.Commands
{
   public interface ICommandFactory
    {
        ICommand<WeatherDataResult, WeatherDataRequest> FetchWeatherDataCommand();
    }
}
