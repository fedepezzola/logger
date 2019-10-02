using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    class LoggerConfigManager
    {
        public bool LogArchivo { get { return bool.Parse(ConfigurationManager.AppSettings["logArchivo"] ?? "false"); } }
        public string LogArchivoPath { get { return ConfigurationManager.AppSettings["logArchivoPath"]; } }
        public string LogArchivoNombre { get { return ConfigurationManager.AppSettings["logArchivoNombre"]; } }

        public bool LogDB { get { return bool.Parse(ConfigurationManager.AppSettings["logDB"] ?? "false"); } }

        public bool LogConsola { get { return bool.Parse(ConfigurationManager.AppSettings["logConsola"] ?? "false"); } }
    }
}
