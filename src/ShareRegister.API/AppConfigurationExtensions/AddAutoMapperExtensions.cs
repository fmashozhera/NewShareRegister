using AutoMapper;
using Serilog;

namespace ShareRegister.API.AppConfigurationExtensions;

public static class AddAutoMapperExtensions
{
    public static IServiceCollection AddAutoMapperConfigs(this IServiceCollection services)
    {
        Log.Information("Configuring automapper mappings ...");
        var config = new MapperConfiguration(cfg =>
        {
            ConfigureAutomapper(cfg);
        });

        IMapper mapper = config.CreateMapper();
        services.AddSingleton(mapper);
        return services;
    }

    private static void ConfigureAutomapper(IMapperConfigurationExpression cfg)
    {
        foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies().Where(a => a.FullName.Contains("ShareRegister")))
        {
            List<Type> automapperConfigurations = assembly.GetTypes().Where(type => typeof(Profile).IsAssignableFrom(type) && !type.IsInterface).ToList();

            foreach (Type type in automapperConfigurations)
            {
                cfg.AddProfile(type);
            }
        }
    }
}
