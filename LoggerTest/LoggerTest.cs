using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LoggerTest
{
    [TestClass]
    public class LoggerTest
    {
        [TestMethod]
        public void TestConsola()
        {
            using (StringWriter stringWriter = new StringWriter())
            {
                Console.SetOut(stringWriter);

                //All console outputs goes here
                Console.WriteLine("You are travelling north at a speed of 10m/s");

                string consoleOutput = stringWriter.ToString();
                if ("You are travelling north at a speed of 10m/s\n" == consoleOutput)
                    Assert.IsTrue(true);
                else
                    Assert.IsTrue(false);
                //Assert.AreEqual("You are travelling north at a speed of 10m/s\n", consoleOutput);
            }
        }
    }
}
