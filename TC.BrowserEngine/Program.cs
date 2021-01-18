using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NLog.Fluent;
using System;
using TC.BrowserEngine.AdminPanel;
using TC.BrowserEngine.AdminPanel.DataAccess;

namespace TC.BrowserEngine
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Log.Info("Application Startup");

            IServiceCollection services = new ServiceCollection();
            var startup = new Startup();
            startup.ConfigureServices(services);
            IServiceProvider serviceProvider = services.BuildServiceProvider();

            var localServer = LocalServer.Instance;

            string token = new LocalUserRepository().GetToken();
            if (token == null)
            {
                localServer.OpenLoginPage();
            }
            var browserEngineManager = serviceProvider.GetService<BrowserEngineManager>();

            browserEngineManager.StartNewInstance();
        }

        public static IConfiguration SetupConfig()
        {
            IConfiguration config = new ConfigurationBuilder()
           .AddJsonFile("appsettings.json", true, true)
           .Build();
            return config;
        }
    }
}
