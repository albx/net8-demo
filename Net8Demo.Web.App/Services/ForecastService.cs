using Net8Demo.Web.App.Models;

namespace Net8Demo.Web.App.Services;

public class ForecastService
{
    public async Task<IEnumerable<WeatherForecastModel>> GetWeatherForecastsAsync()
    {
        await Task.Delay(10000);

        return Enumerable.Range(0, 10)
            .Select(r => new WeatherForecastModel(DateTime.Now, r, $"Temperature is {r} °C"));
    }
}
