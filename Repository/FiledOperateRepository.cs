using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SqlSugar;
using Sys.IRepository;
using Sys.Model;
using Sys.Model.DBModels;

namespace Sys.Repository
{
    public class FiledOperateRepository:BaseRepository<Sys_FiledList>, IFiledOperateRepository
    {
        public async Task<FiledList> GetFileds(int pageIndex, int pageSize)
        {
            RefAsync<int> total = 0;
            var list = await base.Context.Queryable<Sys_FiledList, Sys_User>((f, u)
                       => new JoinQueryInfos(
                           JoinType.Left, f.FiledUserID == u.UserID
                           )
                 ).Select((f, u) => new FiledOper
                 {
                     FiledUser = u.Name,
                     FiledID = f.FiledID,
                     FiledStatus = f.FiledStatus,
                     FiledText = f.FiledText,
                     FiledTime = f.FiledTime,
                     FiledToRoleID = f.FiledToRoleID,
                     FiledType = f.FiledType,
                     FiledTypeName = f.FiledTypeName,
                     FiledUserID = f.FiledUserID
                 }).ToPageListAsync(pageIndex, pageSize, total);
            return new FiledList { fileList = list, totalPage = total };
        }
        public async Task<FiledStats> Getstats()
        {
            var ZgCount = await base.Context.Queryable<Sys_FiledList>().Where(i => i.FiledType == 1 && i.FiledStatus != 1 && i.FiledStatus != 2).CountAsync();
            var QjCount = await base.Context.Queryable<Sys_FiledList>().Where(i => i.FiledType == 2 && i.FiledStatus != 1 && i.FiledStatus != 2).CountAsync();
            var LzCount = await base.Context.Queryable<Sys_FiledList>().Where(i => i.FiledType == 3 && i.FiledStatus != 1 && i.FiledStatus != 2).CountAsync();
            return new FiledStats { ZgCount = ZgCount, QjCount = QjCount, LzCount = LzCount };
        }

    }
}
