using System;
using System.Collections.Generic;
using System.Text;

namespace LoggerCore
{
    class LogManagerBuilderFromConfig : ILogManagerBuilder
    {
        public void buildLogManager()
        {
            addConsoleLogger();
            addFileLogger();
            addDataBaseLogger();
        }

        private void addConsoleLogger()
        {
            if (LogConfiguration.Instance.LogConsola)
            {
                ConsoleLogger con = new ConsoleLogger();
                LogManager.Instance.subscribeLogger(con);
            }
        }

        private void addDataBaseLogger()
        {
            if (LogConfiguration.Instance.LogDB)
            {
                DataBaseLogger lbd = new DataBaseLogger(LogConfiguration.Instance.LogDataDirectory);
                LogManager.Instance.subscribeLogger(lbd);
            }
        }

        private void addFileLogger()
        {
            
            if (LogConfiguration.Instance.LogArchivo)
            {
                FileLogger arch = new FileLogger(LogConfiguration.Instance.LogArchivoPath, LogConfiguration.Instance.LogArchivoNombre);
                LogManager.Instance.subscribeLogger(arch);
            }
        }

        
    }
}
