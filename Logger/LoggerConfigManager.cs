using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggerProyecto
{
    public static class LoggerConfigManager
    {
        public static bool LogArchivo { get { return bool.Parse(ConfigurationManager.AppSettings["logArchivo"] ?? "false"); } }
        public static string LogArchivoPath { get { return ConfigurationManager.AppSettings["logArchivoPath"]; } }
        public static string LogArchivoNombre { get { return ConfigurationManager.AppSettings["logArchivoNombre"]; } }

        public static bool LogDB { get { return bool.Parse(ConfigurationManager.AppSettings["logDB"] ?? "false"); } }
        public static string LogDataDirectory { get { return ConfigurationManager.AppSettings["logDataDirectory"]; } }

        public static bool LogConsola { get { return bool.Parse(ConfigurationManager.AppSettings["logConsola"] ?? "false"); } }

        public static bool LogError { get { return bool.Parse(ConfigurationManager.AppSettings["logError"] ?? "false"); } }
        public static bool LogWarning { get { return bool.Parse(ConfigurationManager.AppSettings["logWarning"] ?? "false"); } }
        public static bool LogMensaje { get { return bool.Parse(ConfigurationManager.AppSettings["logMensaje"] ?? "false"); } }

    }
}
