using System.Collections.Generic;
using WebApiService.Contracts.Models;

namespace WebApiService.Contracts.Interfaces
{
    public interface IWeatherRepository
    {
        List<ChartModel> GetData();
        List<WeatherForecastModel> GetWeatherData();
    }
}
