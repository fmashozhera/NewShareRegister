using Serilog;
using ShareRegister.Application.Interfaces.Common;
using System.Reflection;

namespace ShareRegister.API.AppConfigurationExtensions;

public static class MediatrAppExtenstions
{
    public static IServiceCollection AddMediator(this IServiceCollection services)
    {
        Log.Information("Configuring mediator...");
        services.AddMediatR((config) => {
            config.RegisterServicesFromAssembly(typeof(ICommand).Assembly);
            RegisterMediatrBehaviours(config);
        });

        return services;
    }

    private static void RegisterMediatrBehaviours(MediatRServiceConfiguration config)
    {
        Assembly assembly = typeof(ICommand).Assembly;
        List<Type> registers = assembly.GetTypes().Where(type => typeof(IPipelineBehaviourRegister).IsAssignableFrom(type) && !type.IsInterface).ToList();
        foreach (Type type in registers)
        {
            IPipelineBehaviourRegister registerInstance = Activator.CreateInstance(type) as IPipelineBehaviourRegister;
            registerInstance.RegisterBehaviours(config);
        }
    }
}
