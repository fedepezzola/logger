using LoggerCore.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace LoggerCore
{
    public class DataBaseLogger : ILogger
    {
        private LoggerDbContext _db;

        public DataBaseLogger(LoggerDbContext Db)
        {
            _db = Db;
        }

        public void Init()
        {
        }

        public void Terminate()
        {
            _db = null;
        }

        private void addLog(string msj, string tipo)
        {
            Logs l = new Logs();
            l.Message = msj;
            l.When = GetCurrentTime();
            l.Type = tipo;
            _db.Logs.Add(l);
            _db.SaveChanges();
        }

        public virtual DateTime GetCurrentTime()
        {
            return DateTime.Now;
        }

        public void addError(string msg)
        {
            addLog(msg, "E");
        }

        public void addMessage(string msg)
        {
            addLog(msg, "M");
        }

        public void addWarning(string msg)
        {
            addLog(msg, "W");
        }
    }
}
