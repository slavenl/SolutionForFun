using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Models.BetRadarFeed;
using Serilog;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using WebApiService.Contracts.Models;
using WebApiService.Helpers;

namespace BetradarMatchIDService.Helper
{
    /// <summary>
    /// 
    /// </summary>
    public class DataProcessorService : BackgroundService
    {

        private readonly IConfiguration _config;

        private readonly IMemoryCache _mc;

        private readonly ReaderWriterLockSlim cacheLock = new ReaderWriterLockSlim();


        public DataProcessorService(IConfiguration configuration, IMemoryCache memoryCache)
        {
            _config = configuration;
            _mc = memoryCache;
        }

        private string URL => _config.GetSection("AppSettings").GetValue<string>("BetRadarH2HStats");

        private string CacheKey => _config.GetSection("AppSettings").GetValue<string>("CacheKey");
        private int PingInterval => _config.GetSection("AppSettings").GetValue<int>("BetRadarPingIntervalInMin") * 60 * 1000;

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            Log.Information($"DataProcessorService for url:{URL}, delayInMs:{PingInterval}");

            stoppingToken.Register(() =>
                    Log.Debug($" StartSync background task is stopping."));

            while (!stoppingToken.IsCancellationRequested)
            {

                GetAndProcessData(URL);

                await Task.Delay(PingInterval, stoppingToken);
            }

            Log.Information($"DataProcessorService :: Sync Stopped.");

        }


        private void GetAndProcessData(string url)
        {
            cacheLock.EnterWriteLock();

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    Log.Debug($"GetDataAndProcess for:{url} - started.");

                    HttpResponseMessage response = client.GetAsync(url, HttpCompletionOption.ResponseContentRead).Result;
                    response.EnsureSuccessStatusCode();

                    if (response.IsSuccessStatusCode)
                    {
                        System.IO.Stream content = response.Content.ReadAsStreamAsync().Result;

                        Log.Debug($"GetDataAndProcess - got {content.Length} bytes.");
                        BetradarStatisticsMatchSourceJoinData resultList = XmlDeserializer<BetradarStatisticsMatchSourceJoinData>.DeserializeXmlData(content);
                        Log.Debug($"GetDataAndProcess - deserialized {resultList?.Matches?.Length} number of matches.");

                        _mc.Delete(CacheKey);
                        _mc.Add(CacheKey, new StampedJoinData { TimeStamp = DateTime.Now, JoinData = resultList });
                    }
                }
                catch (Exception exc)
                {
                    Log.Error($"GetDataAndProcess for:{url} threw exception:{Environment.NewLine}{exc}");
                }
                finally
                {
                    cacheLock.ExitWriteLock();
                }
            }
        }
    }
}