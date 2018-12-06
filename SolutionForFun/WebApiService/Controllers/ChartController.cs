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
        private IHubContext<ChartHub> _hub;
        private IRepository _repository;

        public ChartController(IHubContext<ChartHub> hub, IRepository repository)
        {
            _hub = hub;
            _repository = repository;
        }

        public IActionResult Get()
        {
            var timerManager = new TimerManager(() => _hub.Clients.All.SendAsync("receivechartdata", _repository.GetData()));

            return Ok(new { Message = "Request Completed" });
        }
    }
}
