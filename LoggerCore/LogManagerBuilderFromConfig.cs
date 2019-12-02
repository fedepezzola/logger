using LoggerCore.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoggerCore
{
    class LogManagerBuilderFromConfig : ILogManagerBuilder
    {
        public void BuildLogManager()
        {
            AddConsoleLogger();
            AddFileLogger();
            AddDataBaseLogger();
        }

        private void AddConsoleLogger()
        {
            if (LogConfiguration.Instance.Console.Active)
            {
                ConsoleLogger con = new ConsoleLogger();
                LogManager.Instance.subscribeLogger(con);
            }
        }

        private void AddDataBaseLogger()
        {
            if (LogConfiguration.Instance.DB.Active)
            {
                DataBaseLogger lbd = new DataBaseLogger(new LoggerDbContextFactory().CreateDbContext());
                LogManager.Instance.subscribeLogger(lbd);
            }
        }

        private void AddFileLogger()
        {
            
            if (LogConfiguration.Instance.File.Active)
            {
                FileLogger arch = new FileLogger(LogConfiguration.Instance.File.Path, LogConfiguration.Instance.File.Name);
                LogManager.Instance.subscribeLogger(arch);
            }
        }

        
    }
}
