using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    class Logger
    {
        private static object _Lock = new object();
        private static Logger _Logger = null;

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
            msj = string.Format("{0} - {1}", DateTime.Now.ToString(), msj);
            foreach (ILogger observer in _Observers)
            {
                observer.procesarMensaje(msj);
            }
        }

        public void warning(string msj)
        {
            msj = string.Format("{0} - {1}", DateTime.Now.ToString(), msj);
            foreach (ILogger observer in _Observers)
            {
                observer.procesarWarning(msj);
            }
        }

        public void error(string msj)
        {
            msj = string.Format("{0} - {1}", DateTime.Now.ToString(), msj);
            foreach (ILogger observer in _Observers)
            {
                observer.procesarError(msj);
            }
        }
    }
}
