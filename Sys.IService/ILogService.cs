using Sys.Model;
using System.Threading.Tasks;

namespace Sys.IService
{
    public interface ILogService
    {
        Task<LogList> GetLogs(int PageIndex, int PageSize);
    }
}
