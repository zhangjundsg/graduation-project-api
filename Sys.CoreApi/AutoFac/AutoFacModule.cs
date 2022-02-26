using Autofac;
using Sys.IRepository;
using Sys.IService;
using Sys.Repository;
using Sys.Service;
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
                .InstancePerDependency()//默认模式，每次调用，都会重新实例化对象；每次请求都创建一个新的对象
               .AsImplementedInterfaces();//是以接口方式进行注入,注入这些类的所有的公共接口作为服务（除了释放资源）
               //.EnableInterfaceInterceptors(); //引用Autofac.Extras.DynamicProxy;应用拦截器

            //注册Repository
            var assemblysRepository = Assembly.Load("Sys.Repository");
            builder.RegisterAssemblyTypes(assemblysRepository)
                .InstancePerDependency()//默认模式，每次调用，都会重新实例化对象；每次请求都创建一个新的对象
               .AsImplementedInterfaces();//是以接口方式进行注入,注入这些类的所有的公共接口作为服务（除了释放资源）
               //.EnableInterfaceInterceptors(); //引用Autofac.Extras.DynamicProxy;应用拦截器
        }
    
    }
}
