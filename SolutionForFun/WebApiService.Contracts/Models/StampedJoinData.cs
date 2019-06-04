using Models.BetRadarFeed;
using System;

namespace WebApiService.Contracts.Models
{
    public class StampedJoinData
    {
        public DateTime TimeStamp { get; set; }

        public BetradarStatisticsMatchSourceJoinData JoinData { get; set; }
    }
}
