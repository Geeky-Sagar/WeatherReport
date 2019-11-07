namespace WeatherReportModule.Weather.Repositories.Datastores
{
    interface IWeatherDetailsDatastore
    {
        string FetchWeatherDetailByCity(int cityId);
    }
}
