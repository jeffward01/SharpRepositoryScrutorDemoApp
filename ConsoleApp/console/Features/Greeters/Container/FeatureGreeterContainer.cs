namespace SharpRepository.Scrutor.ConsoleApp.Client.Features.Greeters.Container;

using Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Services;

internal static class FeatureGreeterContainer
{
    public static void FeatureGreeterRegistration(this IServiceCollection services)
    {
        services.AddTransient<IGreeterWelcomeService, GreeterWelcomeService>();
    }
}