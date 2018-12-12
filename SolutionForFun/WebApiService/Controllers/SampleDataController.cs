using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApiService.Contracts.Interfaces;
using WebApiService.Contracts.Models;

namespace WebApiService.Controllers
{
    [Route("api/[controller]")]
    public class SampleDataController : ControllerBase
    {
        private IRepository _repository;

        public SampleDataController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("[action]")]
        public IEnumerable<WeatherForecastModel> WeatherForecasts()
        {
            return _repository.GetWeatherData();
        }


    }
}