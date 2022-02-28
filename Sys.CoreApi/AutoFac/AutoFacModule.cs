using Autofac;
using System.Reflection;

namespace Sys.CoreApi.AutoFuc
{
    public class AutoFacModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //注册Service
            var assemblysServices = Assembly.Load("Sys.Service");
            builder.RegisterAssemblyTypes(assemblysServices)
                .InstancePerDependency()
               .AsImplementedInterfaces();

            //注册Repository
            var assemblysRepository = Assembly.Load("Sys.Repository");
            builder.RegisterAssemblyTypes(assemblysRepository)
                .InstancePerDependency()
               .AsImplementedInterfaces();
        }
    
    }
}
