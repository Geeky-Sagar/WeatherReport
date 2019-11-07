using System;
using WeatherReportModule.Command;
using WeatherReportModule.Weather.Commands.TransferObjects;

namespace WeatherReportModule.Weather.Commands.Impl
{
   public class CommandFactory : ICommandFactory
    {
        public ICommand<WeatherDataResult, WeatherDataRequest> FetchWeatherDataCommand()
        {
            return new FetchWeatherDataCommand();
        }
    }
}
