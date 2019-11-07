using WeatherReportModule.Registry;
using WeatherReportModule.Weather.Commands.Impl;

namespace WeatherReportModule.Weather.Commands
{
    public class Module : IModule
    {
        #region IModule Members

        /// <summary>
        /// Add pertinent interfaces and impelementing classes to the registry.
        /// </summary>
        public void Configure(IRegistry registry)
        {
            registry.Register<ICommandFactory, CommandFactory>(ImplementationScope.Shared);
        }
        #endregion
    }
}
