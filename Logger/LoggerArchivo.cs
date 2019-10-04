using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggerProyecto
{
    class LoggerArchivo : ILogger
    {
        private static Task tarea = null;
        private string _pathArchivo;
        private StreamWriter _archivo;

        public string PathArchivo
        {
            get { return _pathArchivo; }
        }

        public LoggerArchivo(string path, string nombre)
        {
            _pathArchivo = path + nombre + DateTime.Now.Date.ToString("yyyymmdd") + ".log";
        }

        public void Init()
        {
            _archivo = new StreamWriter(_pathArchivo, true);
        }

        public void Terminate()
        {
            try
            {
                if (_archivo.BaseStream != null)
                    _archivo.Close();
            }catch (Exception)
            {

            }
        }

        public void procesarMensaje(string msj)
        {
            msj = string.Format("{0} - {1}", DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"), msj);
            if (tarea != null)
                tarea.Wait();
            _archivo.WriteLine("[MSG] " + msj);
            tarea = _archivo.FlushAsync();
        }

        public void procesarWarning(string msj)
        {
            msj = string.Format("{0} - {1}", DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"), msj);
            if (tarea != null)
                tarea.Wait();
            _archivo.WriteLine("[WARN] " + msj);
            tarea = _archivo.FlushAsync();
        }

        public void procesarError(string msj)
        {
            msj = string.Format("{0} - {1}", DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"), msj);
            if (tarea != null)
                tarea.Wait();
            _archivo.WriteLine("[ERROR] " + msj);
            tarea = _archivo.FlushAsync();
        }
    }
}
