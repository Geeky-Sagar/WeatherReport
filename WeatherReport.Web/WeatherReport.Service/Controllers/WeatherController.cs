using System;
using System.IO;
using System.Text;
using System.Web.Http;
using WeatherReportModule.Registry;
using WeatherReportModule.Weather.Commands;
using WeatherReportModule.Weather.Commands.TransferObjects;

namespace WeatherReport.Service.Controllers
{
    public class WeatherController : ApiController
    {
        [HttpPost]
        public string UploadFiles()
        {
            try
            {
                // DEFINE THE PATH WHERE WE WANT TO SAVE THE FILES.
                string sPath = System.Web.Hosting.HostingEnvironment.MapPath("~/InputFolder/");
                string outputSPath = System.Web.Hosting.HostingEnvironment.MapPath("~/OutputFolder/");
                string fileName = "";

                System.Web.HttpFileCollection hfc = System.Web.HttpContext.Current.Request.Files;
                
                for (int iCnt = 0; iCnt <= hfc.Count - 1; iCnt++)
                {
                    System.Web.HttpPostedFile hpf = hfc[iCnt];
                    fileName = hpf.FileName;
                    if (hpf.ContentLength > 0)
                    {
                        // CHECK IF THE SELECTED FILE(S) ALREADY EXISTS IN FOLDER. (AVOID DUPLICATE)
                        if (!File.Exists(sPath + Path.GetFileName(hpf.FileName)))
                        {
                            // SAVE THE FILE IN THE FOLDER.
                            hpf.SaveAs(sPath + Path.GetFileName(hpf.FileName));
                        }
                    }
                }
                // Read entire text file content in one string  
                string text = File.ReadAllText(sPath + fileName);
                var cityIdList = text.Split(',');

                foreach (var cityId in cityIdList)
                {
                    var factory = RegistryFactory.GetResolver().Resolve<ICommandFactory>();

                    var weatherDataRequest = new WeatherDataRequest();
                    weatherDataRequest.CityID = Convert.ToInt32(cityId);
                    var command = factory.FetchWeatherDataCommand();
                    WeatherDataResult results = command.Execute(weatherDataRequest);

                    // File name with City Id and Date 
                    var outputFileName = "CityId_" + cityId + "_" + DateTime.Now.Date.ToShortDateString();
                    if (File.Exists(outputSPath + outputFileName))
                    {
                        File.Delete(outputSPath + outputFileName);
                    }

                    // Create a Response Weather Data City Wise   
                    using (FileStream fs = File.Create(outputSPath + outputFileName))
                    {
                        // Add some text to file    
                        Byte[] weatherData = new UTF8Encoding(true).GetBytes(results.WeatherData);
                        fs.Write(weatherData, 0, weatherData.Length);
                    }
                }

                // Delete File in the Input Folder (Request File)
                if (File.Exists(sPath + fileName))
                {
                    File.Delete(sPath + fileName);
                }

                return $"File Processed Successfully, For Weather Data Please browse to path: {outputSPath}";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return $"File Processing Failed with error: {ex.Message} and stack trace: {ex.StackTrace}";
            }
        }
    }
}
