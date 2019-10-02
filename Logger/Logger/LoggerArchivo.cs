using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    class LoggerArchivo : ILogger
    {
        private string _pathArchivo;
        private StreamWriter _archivo;

        public string PathArchivo
        {
            get { return _pathArchivo; }
        }

        public LoggerArchivo(string fileName)
        {
            _pathArchivo = fileName;
        }

        public void Init()
        {
            _archivo = new StreamWriter(_pathArchivo);
        }

        public void Terminate()
        {
            _archivo.Close();
        }

        public void procesarMensaje(string msj)
        {
            _archivo.WriteLine("[MSG] " + msj);
        }

        public void procesarWarning(string msj)
        {
            _archivo.WriteLine("[WARN] " + msj);
        }

        public void procesarError(string msj)
        {
            _archivo.WriteLine("[ERROR] " + msj);
        }
    }
}
