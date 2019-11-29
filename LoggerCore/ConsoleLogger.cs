using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggerCore
{
    class ConsoleLogger : ILogger
    {
        public void Init()
        {
        }

        public void addError(string msg)
        {
            msg = string.Format("{0} - {1}", DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"), msg);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(msg);
        }

        public void addMessage(string msg)
        {
            msg = string.Format("{0} - {1}", DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"), msg);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(msg);
        }

        public void addWarning(string msg)
        {
            msg = string.Format("{0} - {1}", DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"), msg);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(msg);
        }

        public void Terminate()
        {
        }
    }
}
