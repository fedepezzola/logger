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
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(msj);
        }

        public void procesarMensaje(string msj)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(msj);
        }

        public void procesarWarning(string msj)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(msj);
        }

        public void Terminate()
        {
        }
    }
}
