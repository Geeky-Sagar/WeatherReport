namespace WeatherReportModule.Weather.Repositories
{
    interface IWeatherDetailRepository
    {
        string FetchWeatherDetailByCity(int cityId);
    }
}
