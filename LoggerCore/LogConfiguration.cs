using Microsoft.Extensions.Configuration;
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

        private bool _IsLoaded;

        private LogConfiguration()
        {
            _IsLoaded = false;
        }

        public void LoadConfiguration(IConfigurationBuilder configBuilder)
        {
            if (!_IsLoaded)
                ReloadConfiguration(configBuilder);
        }

        public void ReloadConfiguration(IConfigurationBuilder configBuilder)
        {
            var appConfig = configBuilder.Build().GetSection("LogConfiguration");
            appConfig.Bind(this);
            _IsLoaded = true;
        }

        public FileConfiguration File { get; set; }

        public DBConfiguration DB { get; set; }

        public ConsoleConfiguration Console { get; set; }

        public bool LogError { get; set; }
        public bool LogWarning { get; set; }
        public bool LogMessage { get; set; }

    }
    public class FileConfiguration
    {
        public bool Active { get; set; }
        public string Path { get; set; }
        public string Name { get; set; }
    }

    public class DBConfiguration
    {
        public bool Active { get; set; }
        public string ConnectionString { get; set; }
    }

    public class ConsoleConfiguration
    {
        public bool Active { get; set; }
    }
}
