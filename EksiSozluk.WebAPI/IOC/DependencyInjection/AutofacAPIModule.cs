using Autofac;
using EksiSozluk.Application.Interfaces;
using EksiSozluk.Application.Interfaces.AuthInterfaces;
using EksiSozluk.Application.Interfaces.EntryInterfaces;
using EksiSozluk.Application.Interfaces.EntryTransactionRelationInterfaces;
using EksiSozluk.Application.Interfaces.FollowChannelInterfaces;
using EksiSozluk.Application.Interfaces.TopicInterfaces;
using EksiSozluk.Persistence.Repositories;
using EksiSozluk.Persistence.Repositories.AuthRepositories;
using EksiSozluk.Persistence.Repositories.EntryRepositories;
using EksiSozluk.Persistence.Repositories.EntryTransactionRelationRepositories;
using EksiSozluk.Persistence.Repositories.FollowChannelRepositories;
using EksiSozluk.Persistence.Repositories.TopicRepositories;

namespace EksiSozluk.WebAPI.IOC.DependencyInjection
{
    public class AutofacAPIModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();

            builder.RegisterType<AuthRepository>().As<IAuthRepository>().InstancePerLifetimeScope();
            builder.RegisterType<TopicRepository>().As<ITopicRepository>().InstancePerLifetimeScope();
            builder.RegisterType<EntryRepository>().As<IEntryRepository>().InstancePerLifetimeScope();
            builder.RegisterType<EntryTransactionRelationRepository>().As<IEntryTransactionRelationRepository>().InstancePerLifetimeScope();
            builder.RegisterType<FollowChannelRepository>().As<IFollowChannelRepository>().InstancePerLifetimeScope();

            // adscope alternative
        }
    }
}