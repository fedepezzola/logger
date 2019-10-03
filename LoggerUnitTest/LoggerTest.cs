using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using LoggerProyecto;
using System.Collections;
using System.Linq;
using System.Text.RegularExpressions;

namespace LoggerUnitTest
{
    [TestClass]
    public class LoggerTest
    {
        [TestMethod]
        public void TestLogEnConsola()
        {
            using (StringWriter stringWriter = new StringWriter())
            {
                Console.SetOut(stringWriter);

                Logger.Instance.error("Esto es una prueba de error!");

                string consoleOutput = stringWriter.ToString();

                Assert.AreEqual("Esto es una prueba de error!\r\n", consoleOutput);
            }
        }

        [TestMethod]
        public void TestLogEnArchivoError()
        {
            string pathArchivo = LoggerConfigManager.LogArchivoPath + LoggerConfigManager.LogArchivoNombre + DateTime.Now.Date.ToString("yyyymmdd") + ".log";
            Logger.Instance.error("Esto es una prueba de error!");
            Console.WriteLine(pathArchivo);
            Assert.IsTrue(File.Exists(pathArchivo));
            Logger.Instance.Dispose();
            string texto = File.ReadAllLines(pathArchivo).Last();
            Regex rgx = new Regex(@"\[ERROR\] \d\d\/\d\d\/\d\d\d\d \d\d:\d\d:\d\d - Esto es una prueba de error!");
            Assert.IsTrue(rgx.IsMatch(texto));
        }
        
    }
}
