using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace LoggerProyecto
{
    public class Logger : IDisposable
    {
        private static object _Lock = new object();
        private static Logger _Logger = null;

        private bool _logError;
        private bool _logWarning;
        private bool _logMensaje;

        private List<ILogger> _Observers;

        public static Logger Instance
        {
            get
            {
                if (_Logger == null)
                {
                    lock (_Lock)
                    {
                        if (_Logger == null)
                        {
                            _Logger = new Logger();
                        }
                    }
                }
                return _Logger;
            }
        }

        private Logger()
        {
            _Observers = new List<ILogger>();

            if (LoggerConfigManager.LogArchivo)
            {
                LoggerArchivo arch = new LoggerArchivo(LoggerConfigManager.LogArchivoPath, LoggerConfigManager.LogArchivoNombre);
                arch.Init();
                registrarObserver(arch);
            }
            if (LoggerConfigManager.LogConsola)
            {
                LoggerConsola con = new LoggerConsola();
                con.Init();
                registrarObserver(con);
            }
            if (LoggerConfigManager.LogDB)
            {
                LoggerBaseDatos lbd = new LoggerBaseDatos();
                lbd.Init();
                registrarObserver(lbd);
            }

            _logError = LoggerConfigManager.LogError;
            _logWarning = LoggerConfigManager.LogWarning;
            _logMensaje = LoggerConfigManager.LogMensaje;
        }

        private void registrarObserver(ILogger observer)
        {
            if (!_Observers.Contains(observer))
            {
                _Observers.Add(observer);
            }
        }

        public void mensaje(string msj)
        {
            if (_logMensaje)
            {
                msj = string.Format("{0} - {1}", DateTime.Now.ToString(), msj);
                foreach (ILogger observer in _Observers)
                {
                    observer.procesarMensaje(msj);
                }
            }
        }

        public void warning(string msj)
        {
            if (_logWarning)
            {
                msj = string.Format("{0} - {1}", DateTime.Now.ToString(), msj);
                foreach (ILogger observer in _Observers)
                {
                    observer.procesarWarning(msj);
                }
            }
        }

        public void error(string msj)
        {
            if (_logError)
            {
                msj = string.Format("{0} - {1}", DateTime.Now.ToString(), msj);
                foreach (ILogger observer in _Observers)
                {
                    observer.procesarError(msj);
                }
            }
        }

        public void Dispose()
        {
            foreach (ILogger observer in _Observers)
            {
                observer.Terminate();
            }
            _Logger = null;
        }

        ~Logger()
        {
            Dispose();
        }

    }
}
