using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggerCore
{
    public class FileLogger : ILogger
    {
        private static Task tarea = null;
        private string _pathArchivo;
        private StreamWriter _archivo;

        public string PathArchivo
        {
            get { return _pathArchivo; }
        }

        public FileLogger(string path, string nombre)
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

        public void addMessage(string msg)
        {
            msg = string.Format("{0} - {1}", DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"), msg);
            if (tarea != null)
                tarea.Wait();
            _archivo.WriteLine("[MSG] " + msg);
            tarea = _archivo.FlushAsync();
        }

        public void addWarning(string msg)
        {
            msg = string.Format("{0} - {1}", DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"), msg);
            if (tarea != null)
                tarea.Wait();
            _archivo.WriteLine("[WARN] " + msg);
            tarea = _archivo.FlushAsync();
        }

        public void addError(string msg)
        {
            msg = string.Format("{0} - {1}", DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"), msg);
            if (tarea != null)
                tarea.Wait();
            _archivo.WriteLine("[ERROR] " + msg);
            tarea = _archivo.FlushAsync();
        }
    }
}
