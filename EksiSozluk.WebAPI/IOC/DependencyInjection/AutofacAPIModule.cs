using Autofac;
using EksiSozluk.Application.Interfaces;
using EksiSozluk.Application.Interfaces.AuthInterfaces;
using EksiSozluk.Persistence.Repositories;
using EksiSozluk.Persistence.Repositories.AuthRepositories;

namespace EksiSozluk.WebAPI.IOC.DependencyInjection
{
    public class AutofacAPIModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();

            builder.RegisterType<AuthRepository>().As<IAuthRepository>().InstancePerLifetimeScope();
            // adscope alternative
        }
    }
}