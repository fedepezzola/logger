using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggerProyecto
{
    class LoggerConsola : ILogger
    {
        public void Init()
        {
        }

        public void procesarError(string msj)
        {
            msj = string.Format("{0} - {1}", DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"), msj);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(msj);
        }

        public void procesarMessage(string msj)
        {
            msj = string.Format("{0} - {1}", DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"), msj);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(msj);
        }

        public void procesarWarning(string msj)
        {
            msj = string.Format("{0} - {1}", DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"), msj);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(msj);
        }

        public void Terminate()
        {
        }
    }
}
