using System;
using System.Collections.Generic;
using System.Text;
using WebApiService.Contracts.Models;

namespace WebApiService.Contracts.Interfaces
{
    public interface IRepository
    {
        List<ChartModel> GetData();
    }
}
