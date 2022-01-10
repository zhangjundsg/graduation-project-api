using Autofac;
using Sys.IService;
using Sys.Service;

namespace Sys.CoreApi.AutoFuc
{
    public class AutoFacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserInfoService>().As<IUserInfoService>(); 
            builder.RegisterType<AuthenticateService>().As<IAuthenticateService>(); 
            builder.RegisterType<Captcha>().As<ICaptcha>(); 
        }
    }
}
