using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using WebApiService.Contracts.Models;

namespace WebApiService.HubConfig
{
    public class ChartHub : Hub
    {
        public async Task SendChartData(List<ChartModel> data) => await Clients.All.SendAsync("receivechartdata", data);
    }
}
