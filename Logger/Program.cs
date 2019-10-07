using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggerProyecto
{
    class Program
    {
        static void Main(string[] args)
        {
            Logger.Instance.error("Prueba de error!!");
            Console.ReadKey();
            Logger.Instance.warning("Prueba de warning!!");
            Console.ReadKey();
            Logger.Instance.message("Prueba de mensaje!!");
            Console.ReadKey();
        }
    }
}
