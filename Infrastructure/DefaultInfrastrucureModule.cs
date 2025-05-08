using Autofac;
using Core;
using Infrastructure.Data.FullAccess;
using Infrastructure.Data.Readonly;
using ShardKernel.Modules.DB.Repository;
using System.Reflection;
using MediatR;
using MediatR.Pipeline;
using Module = Autofac.Module;

namespace Infrastructure;

public class DefaultInfrastrucureModule : Module
{
    private readonly List<Assembly> _assemblies = [];
    private readonly bool _isDevelopment;

    public DefaultInfrastrucureModule(bool isDevelopment, Assembly? callingAssembly = null) {

        _isDevelopment = isDevelopment;

        var coreAssembly = Assembly.GetAssembly(typeof(DefaultCoreModule));
        var infrastructureAssembly = Assembly.GetAssembly(typeof(StartupSetup));

        if (coreAssembly != null) _assemblies.Add(coreAssembly);

        if (infrastructureAssembly != null) _assemblies.Add(infrastructureAssembly);

        if (callingAssembly != null) _assemblies.Add(callingAssembly);
    }
    protected override void Load(ContainerBuilder builder)
    {
        if (_isDevelopment)
            RegisterDevelopmentOnlyDependencies(builder);
        else
            RegisterProductionOnlyDependencies(builder);

        RegisterCommonDependencies(builder);
    }

    private void RegisterCommonDependencies(ContainerBuilder builder)
    {

        builder.RegisterGeneric(typeof(ReadonlyRepository<>)).As(typeof(IReadRepository<>)).InstancePerLifetimeScope();
        builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();

        builder.RegisterType<Mediator>().As<IMediator>().InstancePerLifetimeScope();

        var mediatrOpenTypes = new[]
        {
            typeof(IRequestHandler<,>),
            typeof(IRequestExceptionHandler<,,>),
            typeof(IRequestExceptionAction<,>),
            typeof(INotificationHandler<>),
        };
        foreach (var mediatrOpenType in mediatrOpenTypes)
            builder.RegisterAssemblyTypes(_assemblies.ToArray()).AsClosedTypesOf(mediatrOpenType).AsImplementedInterfaces();
    }

    private void RegisterDevelopmentOnlyDependencies(ContainerBuilder builder)
    {
        // NOTE: Add any development only services here
    }

    private void RegisterProductionOnlyDependencies(ContainerBuilder builder)
    {
        // NOTE: Add any production only services here
    }
}