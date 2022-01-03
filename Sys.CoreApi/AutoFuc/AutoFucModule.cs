using Autofac;
using Sys.IService;
using Sys.Service;

namespace Sys.CoreApi.AutoFuc
{
    public class AutoFucModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserInfoService>().As<IUserInfoService>();
        }
    }
}
