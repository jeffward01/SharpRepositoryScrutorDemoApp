namespace SharpRepository.Scrutor.ConsoleApp.Client;

using Config;
using global::Config.Net;

public partial class Program
{
    private static IAppSettings LoadAppSettingsConfig()
    {
        return  new ConfigurationBuilder<IAppSettings>().UseJsonFile("appsettings.json")
            .Build();

        // For environments with DEV, QA, UAT, PROD
        //UseJsonFile($"appsettings.{environment}.json", //optional: true)
    }
}