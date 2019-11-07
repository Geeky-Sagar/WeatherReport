namespace WeatherReportModule.Command
{
    public interface ICommand<TResult, TParameter>
    {
        TResult Execute(TParameter parameters);
    }
}
