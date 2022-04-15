using Sys.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sys.IService
{
    public interface IStatsDataService
    {
        Task<FiledCountDto> FiledStatsData();
    }
}
