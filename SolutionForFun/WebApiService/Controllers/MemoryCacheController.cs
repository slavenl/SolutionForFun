using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Models.BetRadarFeed;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebApiService.Contracts.Models;

namespace WebApiService.Controllers
{
    [Route("api/[controller]")]
    public class MemoryCacheController : ControllerBase
    {
        private readonly IMemoryCache _cache;
        private readonly IConfiguration _config;

        private readonly ReaderWriterLockSlim cacheLock = new ReaderWriterLockSlim();

        public string CacheKey => _config.GetSection("AppSettings").GetValue<string>("CacheKey");

        public MemoryCacheController(IConfiguration config, IMemoryCache memoryCache)
        {
            _config = config;
            _cache = memoryCache;
        }


        /// <summary>
        /// Check status of cached items
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]")]
        public async Task<IActionResult> GetStatus()
        {
            Log.Information($"GetStatus at :: {DateTime.Now}");

            cacheLock.EnterReadLock();
            StampedJoinData result = _cache.Get<StampedJoinData>(CacheKey);
            cacheLock.ExitReadLock();

            //await Task.Delay(1);
            await Task.CompletedTask;
            ;
            if (result != null)
            {
                return Ok(new { LastSyncDateTime = result?.TimeStamp, NumberOfMappedEvents = result?.JoinData?.Matches.Count() });
            }
            else
            {
                return Ok(new { LastSyncDateTime = "NOT SYNCED", NumberOfMappedEvents = 0 });
            }
        }

        /// <summary>
        /// Get BetRadar Match IDs 
        /// </summary>
        /// <returns>Json List</returns>
        [HttpGet("[action]")]
        public async Task<IActionResult> GetBetRadarMatchIds()
        {
            List<BetradarStatisticsMatchSourceJoinDataMatch> itemList = new List<BetradarStatisticsMatchSourceJoinDataMatch>();
            try
            {
                cacheLock.EnterReadLock();
                StampedJoinData result = _cache.Get<StampedJoinData>(CacheKey);
                cacheLock.ExitReadLock();

                if (result != null)
                {
                    itemList = result?.JoinData.Matches.ToList();
                }
                else
                {
                    Log.Error($"GetBetRadarMatchIds :: CACHE object EMPTY");
                }
            }
            catch (Exception)
            {
                Log.Error(@"Internal error: {ex}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            //   await Task.Delay(1);
            await Task.CompletedTask;

            if (null == itemList)
            {
                return NotFound();
            }

            var jsonList = itemList.Select(n => new { IdOfSource = n.idOfSource, StatisticsMatchId = n.statisticsMatchId });

            return Ok(new { StatisticsMatchList = jsonList });

        }

        /// <summary>
        /// Get BetRadar Match ID for specific HL basicCode
        /// </summary>
        /// <param name="basicCode"></param>
        /// <returns>BetRadar MatchId</returns>        
        //[HttpGet("{basicCode}")]
        [HttpGet("[action]")]
        public async Task<IActionResult> GetBetRadarMatchIdByBasicCode(int basicCode)
        {
            Log.Information($"GetBetRadarMatchIdByBasicCode :: basicCode:{basicCode}");

            uint betRadarMatchId = 0;

            try
            {
                betRadarMatchId = GetFromCacheForBetRadarMatchId(basicCode);

                if (betRadarMatchId > 0)
                {
                    Log.Information($"GetBetRadarMatchIdByBasicCode for basicCode: {basicCode} found statisticsMatchId:{betRadarMatchId}");
                }
                else
                {
                    Log.Information($"GetBetRadarMatchIdByBasicCode for basicCode: {basicCode} has NOT found statisticsMatchId.");
                }
            }
            catch (Exception ex)
            {
                Log.Error($"GetBetRadarMatchIdByBasicCode threw exc.: {ex}");
            }
            await Task.CompletedTask;

            return Ok(new { StatisticsMatchList = new[] { new { IdOfSource = basicCode, StatisticsMatchId = betRadarMatchId } }.ToList() });
        }



        private uint GetFromCacheForBetRadarMatchId(int basicCode)
        {
            uint statisticsMatchId = 0;

            cacheLock.EnterReadLock();
            StampedJoinData result = _cache.Get<StampedJoinData>(CacheKey);
            cacheLock.ExitReadLock();

            foreach (BetradarStatisticsMatchSourceJoinDataMatch item in result.JoinData.Matches)
            {
                if ((basicCode.ToString()).Equals(item.idOfSource))
                {
                    statisticsMatchId = item.statisticsMatchId;
                    break;
                }
            }

            return statisticsMatchId;
        }
    }
}