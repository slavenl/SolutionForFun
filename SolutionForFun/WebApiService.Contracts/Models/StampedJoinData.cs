using System;
using System.Collections.Generic;
using System.Text;
using Models.BetRadarFeed;

namespace WebApiService.Contracts.Models
{
    public class StampedJoinData
    {
        public DateTime TimeStamp { get; set; }

        public BetradarStatisticsMatchSourceJoinData JoinData { get; set; }
    }
}
