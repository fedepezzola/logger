using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggerCore
{
    public class LogConfiguration
    {
        private static object _Lock = new object();
        private static LogConfiguration _LogConfiguration = null;
        public static LogConfiguration Instance
        {
            get
            {
                if (_LogConfiguration == null)
                {
                    lock (_Lock)
                    {
                        if (_LogConfiguration == null)
                        {
                            _LogConfiguration = new LogConfiguration();
                        }
                    }
                }
                return _LogConfiguration;
            }
        }

        private LogConfiguration()
        {

        }

        public bool LogArchivo { get; set; }
        public string LogArchivoPath { get; set; }
        public string LogArchivoNombre { get; set; }

        public bool LogDB { get; set; }
        public string LogDataDirectory { get; set; }

        public bool LogConsola { get; set; }

        public bool LogError { get; set; }
        public bool LogWarning { get; set; }
        public bool LogMessage { get; set; }

    }
}
