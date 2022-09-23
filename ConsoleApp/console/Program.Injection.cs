namespace SharpRepository.Scrutor.ConsoleApp.Client;

using Features.Greeters.Container;
using Microsoft.Extensions.DependencyInjection;

public partial class Program
{
    private static IServiceCollection ConfigureServices()
    {
        var services = new  ServiceCollection();


        var config = LoadAppSettingsConfig();
        services.AddSingleton(config);
        RegisterConsoleDependencies(services);
        services.AddTransient<App>();

        return services;
    }

    private static void RegisterConsoleDependencies(IServiceCollection services)
    {
        services.FeatureGreeterRegistration();
    }
}