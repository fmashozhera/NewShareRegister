using Serilog;
using ShareRegister.Application.Interfaces.Common;

namespace ShareRegister.API.AppConfigurationExtensions;

public static class DependencyInjectionModulesAppExtensions
{
    public static IServiceCollection AddDependencyInjectionModules(this IServiceCollection services)
    {
        Log.Information("Configuring dependency injection modules...");
        foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
        {
            List<Type> dependenyModules = assembly.GetTypes().Where(type => typeof(IDependencyModule).IsAssignableFrom(type) && !type.IsInterface).ToList();
            foreach (Type type in dependenyModules)
            {
                IDependencyModule dependencyModule = Activator.CreateInstance(type) as IDependencyModule;
                dependencyModule.RegisterDependecies(services);
            }
        }

        return services;
    }
}
