using System;

namespace WeatherReportModule.Registry
{
    public interface IResolver : IDisposable
    {
        TContract Resolve<TContract>();
    }
}
