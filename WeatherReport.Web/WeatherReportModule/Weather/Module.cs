using WeatherReportModule.Registry;

namespace WeatherReportModule.Weather
{
    public class Module : IModule
    {
        #region IModule Members

        /// <summary>
        /// Add pertinent interfaces and impelementing classes to the registry.
        /// </summary>
        public void Configure(IRegistry registry)
        {
            registry.Register<Commands.Module>();
            registry.Register<Repositories.Module>();
        }
        #endregion
    }
}
