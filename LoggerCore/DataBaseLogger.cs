using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace LoggerCore
{
    class DataBaseLogger : ILogger
    {
        private string logDataDirectory;

        public DataBaseLogger(string logDataDirectory)
        {
            this.logDataDirectory = logDataDirectory;
        }

        /* private LogEntities db = null;

public LoggerBaseDatos(string dataPath)
{
    AppDomain.CurrentDomain.SetData("DataDirectory", dataPath);
}

public void Init()
{
    db = new LogEntities();
}

public void Terminate()
{
    db = null;
}

public void procesarMessage(string msj)
{
    agregarLog(msj, "M");
}

private void agregarLog(string msj, string tipo)
{
    logs l = new logs();
    l.mensaje = msj;
    l.fecha_hora = DateTime.Now;
    l.tipo = tipo;
    db.logs.Add(l);
    db.SaveChanges();
}

public void procesarWarning(string msj)
{
    agregarLog(msj, "W");
}

public void procesarError(string msj)
{
    agregarLog(msj, "E");
}*/
        public void addError(string msj)
        {
        }

        public void addMessage(string msj)
        {
        }

        public void addWarning(string msj)
        {
        }

        public void Init()
        {
        }

        public void Terminate()
        {
        }
    }
}
