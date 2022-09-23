namespace SharpRepository.Scrutor.ConsoleApp.Client;

using Microsoft.Extensions.DependencyInjection;

public partial class Program
{
    public static void Main(string[] args)
    {
        _startAndRunConsoleApp();
    }

    private static void _startAndRunConsoleApp()
    {
        var services = ConfigureServices();

        var serviceProvider = services.BuildServiceProvider();

        serviceProvider.GetService<App>()
            ?.RunAsync()
            .GetAwaiter()
            .GetResult();
    }
}