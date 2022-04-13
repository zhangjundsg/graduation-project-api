using Sys.IRepository;
using Sys.IService;
using Sys.Model.DBModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sys.Service
{
    public class OptionsService: IOptionsService
    {
        private readonly IOptionsRepository _options;
        public OptionsService(IOptionsRepository options)
        {
            _options = options;
        }
        public async Task<List<Sys_Options>> GetAllOptions()
        {
            return await _options.GetListAsync();
        }
        public async Task<bool> UpdateOptions(Sys_Options options)
        {
            return await _options.AsUpdateable(options).WhereColumns(i => new { i.OptionName }).ExecuteCommandAsync() > 0;
        }
    }
}
