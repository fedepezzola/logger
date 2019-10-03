using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using LoggerProyecto;
using System.Collections;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;
using System.Configuration;

namespace LoggerUnitTest
{
    [TestClass]
    public class LoggerTest
    {
        [TestMethod]
        public void TestLogEnConsola()
        {
            string fechaYHora = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            using (StringWriter stringWriter = new StringWriter())
            {
                Console.SetOut(stringWriter);
                Logger.Instance.error("Esto es una prueba de error!");
                string consoleOutput = stringWriter.ToString();
                Regex rgx = new Regex(fechaYHora + @":\d\d - Esto es una prueba de error!");
                Assert.IsTrue(rgx.IsMatch(consoleOutput));
            }
        }

        [TestMethod]
        public void TestLogEnArchivoError()
        {
            string fechaYHora = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            string pathArchivo = LoggerConfigManager.LogArchivoPath + LoggerConfigManager.LogArchivoNombre + DateTime.Now.Date.ToString("yyyymmdd") + ".log";
            Logger.Instance.error("Esto es una prueba de error!");
            Assert.IsTrue(File.Exists(pathArchivo));
            string texto = "";
            using (var fs = new FileStream(pathArchivo, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (var sr = new StreamReader(fs, Encoding.Default))
            {
                texto = sr.ReadToEnd();
            }
            Regex rgx = new Regex(@"\[ERROR\] " + fechaYHora + @":\d\d - Esto es una prueba de error!");
            Assert.IsTrue(rgx.IsMatch(texto));
        }

        [TestMethod]
        public void TestNOLogEnArchivo()
        {
            string fechaYHora = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            string pathArchivo = LoggerConfigManager.LogArchivoPath + LoggerConfigManager.LogArchivoNombre + DateTime.Now.Date.ToString("yyyymmdd") + ".log";
            ConfigurationManager.AppSettings.Set("logWarning", "false");
            Logger.Instance.Dispose();
            Logger.Instance.warning("Esto es una prueba de warning!");
            string texto = "";
            using (var fs = new FileStream(pathArchivo, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (var sr = new StreamReader(fs, Encoding.Default))
            {
                texto = sr.ReadToEnd();
            }
            Regex rgx = new Regex(@"\[WARN\] " + fechaYHora + @":\d\d - Esto es una prueba de error!");
            Assert.IsFalse(rgx.IsMatch(texto));
        }

    }
}
