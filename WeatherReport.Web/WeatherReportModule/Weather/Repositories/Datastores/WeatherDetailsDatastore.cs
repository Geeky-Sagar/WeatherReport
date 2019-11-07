using System;
using System.Configuration;
using System.Net.Http;

namespace WeatherReportModule.Weather.Repositories.Datastores
{
    public class WeatherDetailsDatastore : IWeatherDetailsDatastore
    {
        private static string _weatherUrl = ConfigurationManager.AppSettings["WeatherUrl"];
        private static string _weatherAppId = ConfigurationManager.AppSettings["WeatherAppId"] ;
        private static string _cityUrl = "data/2.5/weather?id={CityID}&appid={WeatherAppId}";
        public string FetchWeatherDetailByCity(int cityId)
        {
            string response = string.Empty;
            using (var client = new HttpClient())
            {
                var weatherCityUrl = _weatherUrl + _cityUrl;
                weatherCityUrl = weatherCityUrl.Replace("{WeatherAppId}", _weatherAppId).Replace("{CityID}",Convert.ToString(cityId));

                //HTTP GET
                var responseTask = client.GetAsync(weatherCityUrl);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsStringAsync();
                    readTask.Wait();
                    response = readTask.Result;
                }
            }
            return response;
        }
    }
}
