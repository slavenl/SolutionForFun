using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiService.Contracts.Models;

namespace WebApiService.HubConfig
{
    public class ChartHub : Hub
    {
        public async Task SendChartData(List<ChartModel> data)
        {
            await Clients.All.SendAsync("receivechartdata", data);
        }
    }
}
