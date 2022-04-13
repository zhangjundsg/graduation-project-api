using SqlSugar;
using Sys.IRepository;
using Sys.IService;
using Sys.Model;
using System.Threading.Tasks;

namespace Sys.Service
{
    public class LogService : ILogService
    {
        private readonly ILogRepository _repository;
        public LogService(ILogRepository repository)
        {
            _repository = repository;
        }
        public async Task<LogList> GetLogs(int PageIndex, int PageSize)
        {
            RefAsync<int> total = 0;
            var list = await _repository.AsQueryable().ToPageListAsync(PageIndex, PageSize, total);
            return new LogList { list = list, Count = total };
        }
    }
}
