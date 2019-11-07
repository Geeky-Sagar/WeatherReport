# WeatherReport
Rest API Project to get Weather Report Data based on City

It has .Net Web API 2 Project "WeatherReport.Service"
- It has HttPost Rest API to upload File with City Id's.
- Test File is in Folder "InputFile" which has comma separated CityId.
- Url: http://localhost:55178/api/Weather/UploadFiles  (Change port name as required)
- In Postman send Body > Form Data > select type as file in dropdown > Select input File.
- Expected Response Status : 200 , 
- Response Message: "File Processed Successfully, For Weather Data Please browse to path: D:\\My Space\\POC\\WR-Git\\WeatherReport.Web\\WeatherReport.Service\\OutputFolder\\"


It Also Has Class Library Project "WeatherReportModule"
- It has actual open source Weather API call.
- It has layered Architecture.
- Design Patterns 
1. Dependecy Injection (IOC)
2. Command Pattern.
3. Repository Pattern.

Peding Task: Unit Test Case (I have experience in Nunit3) - Do you shortage of time
