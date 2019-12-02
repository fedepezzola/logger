using Microsoft.Extensions.Configuration;
using System;

namespace LoggerCore
{
    class Program
    {
        static void Main(string[] args)
        {
            LogConfiguration.Instance.LoadConfiguration(new ConfigurationBuilder().AddJsonFile("appconfig.json"));

            ILogManagerBuilder lmb = new LogManagerBuilderFromConfig();
            lmb.BuildLogManager();


            LogManager.Instance.error("Prueba de error!!");
            Console.ReadKey();
            LogManager.Instance.warning("Prueba de warning!!");
            Console.ReadKey();
            LogManager.Instance.message("Prueba de mensaje!!");
            Console.ReadKey();
        }
    }
}
