using System.Collections.Generic;
using WebApiService.Contracts.Models;

namespace WebApiService.Contracts.Interfaces
{
    public interface IRepository
    {
        List<ChartModel> GetData();
        List<WeatherForecastModel> GetWeatherData();
    }
}
