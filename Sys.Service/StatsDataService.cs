using Sys.IRepository;
using Sys.IService;
using Sys.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sys.Service
{
    public class StatsDataService: IStatsDataService
    {
        private readonly IFiledOperateRepository _filed;
        private readonly IUserRepository _user;
        public StatsDataService(IFiledOperateRepository filed, IUserRepository user)
        {
            _filed = filed;
            _user = user;
        }
        public async Task<FiledCountDto> FiledStatsData()
        {
            var NotAudited = await _filed.AsQueryable().Where(i => i.FiledStatus == 0).CountAsync();
            var Passed = await _filed.AsQueryable().Where(i => i.FiledStatus == 1).CountAsync();
            var Rejected = await _filed.AsQueryable().Where(i => i.FiledStatus == 2).CountAsync();
            var NewUser=await _user.AsQueryable().Where(i => i.RegisterTime >= DateTime.Now.AddDays(-30) && i.RegisterTime <= DateTime.Now).CountAsync();
            var Dimission = await _filed.AsQueryable().Where(i => i.FiledTime >= DateTime.Now.AddDays(-30) && i.FiledTime <= DateTime.Now).Where(o=>o.FiledType==3).CountAsync();
            return new FiledCountDto { Passed = Passed, NotAudited = NotAudited, Rejected = Rejected, NewUserAdd = NewUser, Dimission = Dimission };
        }
       
    }
}
