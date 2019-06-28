using Autofac;
using Data.Repositories;
using Data.Repositories.Impl;

namespace Data
{
    public sealed class DataModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<TestProjectDataContext>().As<IDataContext>().InstancePerDependency();
            builder.RegisterType<UserEntityRepository>().As<IUserEntityRepository>().InstancePerDependency();
        }
    }
}
