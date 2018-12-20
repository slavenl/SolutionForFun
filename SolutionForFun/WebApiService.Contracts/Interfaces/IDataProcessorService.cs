using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace WebApiService.Contracts.Interfaces
{
    public interface IDataProcessorService
    {
        void StartSync(string url, int delayInMs, CancellationToken ct);
        void StopSync();

        object GetCache();
        uint GetFromCacheForBetRadarMatchId(int basicCode);
    }
}
