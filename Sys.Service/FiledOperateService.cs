using Sys.IRepository;
using Sys.IService;
using Sys.Model;
using Sys.Model.DBModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sys.Service
{
    public class FiledOperateService : IFiledOperateService
    {
        private readonly IFiledOperateRepository _filedOperate;
        public FiledOperateService(IFiledOperateRepository filedOperate)
        {
            _filedOperate = filedOperate;
        }
        public async Task<bool> AddFiled(Sys_FiledList filed)
        {
            return await _filedOperate.InsertAsync(filed);
        }
        public async Task<List<Sys_FiledList>> GetFiledById(int id)
        {
            var list = await _filedOperate.AsQueryable().Where(i => i.FiledUserID == id).ToListAsync();
            return list;
        }
        public async Task<FiledList> GetAllFiled(int pageIndex, int pageSize)
        {
            var list = await _filedOperate.GetFileds(pageIndex, pageSize);
            return list;
        }
        public async Task<FiledStats> Getstats()
        {
            var list=await _filedOperate.Getstats();
            return list;
        }

        public async Task<bool> UpdataFiled(Sys_FiledList filed)
        {
            return await _filedOperate.UpdateAsync(filed);
        }
    }
}
