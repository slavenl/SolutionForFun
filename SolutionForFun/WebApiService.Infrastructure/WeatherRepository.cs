using System;
using System.Collections.Generic;
using System.Linq;
using WebApiService.Contracts.Interfaces;
using WebApiService.Contracts.Models;

namespace WebApiService.Infrastructure
{
    public class WeatherRepository : IWeatherRepository
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
        public List<ChartModel> GetData()
        {
            Random r = new Random();
            return new List<ChartModel>()
            {
                new ChartModel { Data = new List<int> { r.Next(1, 40) }, Label = "Data1" },
                new ChartModel { Data = new List<int> { r.Next(1, 40) }, Label = "Data2" },
                new ChartModel { Data = new List<int> { r.Next(1, 40) }, Label = "Data3" },
                new ChartModel { Data = new List<int> { r.Next(1, 40) }, Label = "Data4" }
            };
        }

        public List<WeatherForecastModel> GetWeatherData()
        {
            Random rng = new Random();
            return Enumerable.Range(1, 20).Select(index => new WeatherForecastModel
            {
                DateFormatted = DateTime.Now.AddDays(index).ToString("d"),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            }).ToList();
        }
    }
}
