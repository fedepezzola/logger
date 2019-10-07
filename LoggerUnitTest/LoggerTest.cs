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
        public void TestLogErrorEnConsola()
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
        public void TestLogWarningEnConsola()
        {
            string fechaYHora = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            using (StringWriter stringWriter = new StringWriter())
            {
                Console.SetOut(stringWriter);
                Logger.Instance.warning("Esto es una prueba de error!");
                string consoleOutput = stringWriter.ToString();
                Regex rgx = new Regex(fechaYHora + @":\d\d - Esto es una prueba de error!");
                Assert.IsTrue(rgx.IsMatch(consoleOutput));
            }
        }
        [TestMethod]
        public void TestLogMessageEnConsola()
        {
            string fechaYHora = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            using (StringWriter stringWriter = new StringWriter())
            {
                Console.SetOut(stringWriter);
                Logger.Instance.message("Esto es una prueba de error!");
                string consoleOutput = stringWriter.ToString();
                Regex rgx = new Regex(fechaYHora + @":\d\d - Esto es una prueba de error!");
                Assert.IsTrue(rgx.IsMatch(consoleOutput));
            }
        }

        [TestMethod]
        public void TestLogErrorEnArchivo()
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
        public void TestLogWarningEnArchivo()
        {
            string fechaYHora = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            string pathArchivo = LoggerConfigManager.LogArchivoPath + LoggerConfigManager.LogArchivoNombre + DateTime.Now.Date.ToString("yyyymmdd") + ".log";
            Logger.Instance.warning("Esto es una prueba de warning!");
            Assert.IsTrue(File.Exists(pathArchivo));
            string texto = "";
            using (var fs = new FileStream(pathArchivo, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (var sr = new StreamReader(fs, Encoding.Default))
            {
                texto = sr.ReadToEnd();
            }
            Regex rgx = new Regex(@"\[WARN\] " + fechaYHora + @":\d\d - Esto es una prueba de warning!");
            Assert.IsTrue(rgx.IsMatch(texto));
        }

        [TestMethod]
        public void TestLogMessageEnArchivo()
        {
            string fechaYHora = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            string pathArchivo = LoggerConfigManager.LogArchivoPath + LoggerConfigManager.LogArchivoNombre + DateTime.Now.Date.ToString("yyyymmdd") + ".log";
            Logger.Instance.message("Esto es una prueba de mensaje!");
            Assert.IsTrue(File.Exists(pathArchivo));
            string texto = "";
            using (var fs = new FileStream(pathArchivo, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (var sr = new StreamReader(fs, Encoding.Default))
            {
                texto = sr.ReadToEnd();
            }
            Regex rgx = new Regex(@"\[MSG\] " + fechaYHora + @":\d\d - Esto es una prueba de mensaje!");
            Assert.IsTrue(rgx.IsMatch(texto));
        }

        [TestMethod]
        public void TestLogMessageEnBD()
        {
            string msj = "Prueba de mensaje " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            Logger.Instance.message(msj);
            LogEntities db = new LogEntities();
            logs log = db.logs.FirstOrDefault(l => l.mensaje.StartsWith(msj));
            Assert.IsNotNull(log);
        }

        [TestMethod]
        public void TestLogErrorEnBD()
        {
            string msj = "Prueba de error " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            Logger.Instance.error(msj);
            LogEntities db = new LogEntities();
            logs log = db.logs.FirstOrDefault(l => l.mensaje.StartsWith(msj));
            Assert.IsNotNull(log);
        }

        [TestMethod]
        public void TestLogWarningEnBD()
        {
            string msj = "Prueba de warning " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            Logger.Instance.warning(msj);
            LogEntities db = new LogEntities();
            logs log = db.logs.FirstOrDefault(l => l.mensaje.StartsWith(msj));
            Assert.IsNotNull(log);
        }


        [TestMethod]
        public void TestNOLogErrorEnConsola()
        {
            string fechaYHora = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            using (StringWriter stringWriter = new StringWriter())
            {
                Console.SetOut(stringWriter);
                ConfigurationManager.AppSettings.Set("logError", "false");
                Logger.Instance.Dispose();
                Logger.Instance.error("Esto es una prueba de no log de error!");
                string consoleOutput = stringWriter.ToString();
                Regex rgx = new Regex(fechaYHora + @":\d\d - Esto es una prueba de no log de error!");
                Assert.IsFalse(rgx.IsMatch(consoleOutput));
            }
        }

        [TestMethod]
        public void TestNOLogWarningEnArchivo()
        {
            string fechaYHora = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            string pathArchivo = LoggerConfigManager.LogArchivoPath + LoggerConfigManager.LogArchivoNombre + DateTime.Now.Date.ToString("yyyymmdd") + ".log";
            ConfigurationManager.AppSettings.Set("logWarning", "false");
            Logger.Instance.Dispose();
            Logger.Instance.warning("Esto es una prueba de no logeo de warning!");
            string texto = "";
            using (var fs = new FileStream(pathArchivo, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (var sr = new StreamReader(fs, Encoding.Default))
            {
                texto = sr.ReadToEnd();
            }
            Regex rgx = new Regex(@"\[WARN\] " + fechaYHora + @":\d\d - Esto es una prueba de no logeo de warning!");
            Assert.IsFalse(rgx.IsMatch(texto));
        }

        [TestMethod]
        public void TestNOLogMessageEnBD()
        {
            string msj = "Prueba de mensaje para no log " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            ConfigurationManager.AppSettings.Set("logMessage", "false");
            Logger.Instance.Dispose();
            Logger.Instance.message(msj);
            LogEntities db = new LogEntities();
            logs log = db.logs.FirstOrDefault(l => l.mensaje.StartsWith(msj));
            Assert.IsNull(log);
        }

        [TestMethod]
        public void TestNOLogEnConsola()
        {
            string fechaYHora = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            using (StringWriter stringWriter = new StringWriter())
            {
                Console.SetOut(stringWriter);
                ConfigurationManager.AppSettings.Set("logConsola", "false");
                Logger.Instance.Dispose();
                Logger.Instance.error("Esto es una prueba de no log de error!");
                string consoleOutput = stringWriter.ToString();
                Regex rgx = new Regex(fechaYHora + @":\d\d - Esto es una prueba de no log de error!");
                Assert.IsFalse(rgx.IsMatch(consoleOutput));
            }
        }

        [TestMethod]
        public void TestNOLogEnArchivo()
        {
            string fechaYHora = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            string pathArchivo = LoggerConfigManager.LogArchivoPath + LoggerConfigManager.LogArchivoNombre + DateTime.Now.Date.ToString("yyyymmdd") + ".log";
            ConfigurationManager.AppSettings.Set("logArchivo", "false");
            Logger.Instance.Dispose();
            Logger.Instance.warning("Esto es una prueba de no logeo en archivo!");
            string texto = "";
            using (var fs = new FileStream(pathArchivo, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (var sr = new StreamReader(fs, Encoding.Default))
            {
                texto = sr.ReadToEnd();
            }
            Regex rgx = new Regex(@"\[WARN\] " + fechaYHora + @":\d\d - Esto es una prueba de no logeo en archivo!");
            Assert.IsFalse(rgx.IsMatch(texto));
        }

        [TestMethod]
        public void TestNOLogEnBD()
        {
            string msj = "Prueba de mensaje para no log " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            ConfigurationManager.AppSettings.Set("logDB", "false");
            Logger.Instance.Dispose();
            Logger.Instance.message(msj);
            LogEntities db = new LogEntities();
            logs log = db.logs.FirstOrDefault(l => l.mensaje.StartsWith(msj));
            Assert.IsNull(log);
        }
    }
}
