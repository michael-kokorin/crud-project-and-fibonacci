using Autofac;
using Business.Services;
using Business.Services.Impl;

namespace Business
{
    public sealed class BusinessModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserService>().As<IUserService>().InstancePerDependency();
        }
    }
}
