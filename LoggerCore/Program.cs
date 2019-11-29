using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace LoggerCore
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                //.SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appconfig.json");

            var config = builder.Build();

            var appConfig = config.GetSection("LogConfiguration");
            appConfig.Bind(LogConfiguration.Instance);

            ILogManagerBuilder lmb = new LogManagerBuilderFromConfig();
            lmb.buildLogManager();


            LogManager.Instance.error("Prueba de error!!");
            Console.ReadKey();
            LogManager.Instance.warning("Prueba de warning!!");
            Console.ReadKey();
            LogManager.Instance.message("Prueba de mensaje!!");
            Console.ReadKey();
        }
    }
}
