using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using WebApiService.Contracts.Interfaces;
using WebApiService.HubConfig;
using WebApiService.TimerFeatures;

namespace WebApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChartController : ControllerBase
    {
        private readonly IHubContext<ChartHub> _hub;
        private readonly IWeatherRepository _repository;

        public ChartController(IHubContext<ChartHub> hub, IWeatherRepository repository)
        {
            _hub = hub;
            _repository = repository;
        }
        [HttpGet]
        public IActionResult Get()
        {
            TimerManager timerManager = new TimerManager(() => _hub.Clients.All.SendAsync("receivechartdata", _repository.GetData()));

            return Ok(new { Message = "Request Completed" });
        }
    }
}
