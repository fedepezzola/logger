using LoggerCore;
using LoggerCore.Data;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace LoggerTests
{
    public class DataBaseLoggerShould
    {
        [Fact]
        public void InsertAnError() {
            var options = new DbContextOptionsBuilder<LoggerDbContext>()
                .UseInMemoryDatabase(databaseName: "Logger")
                .Options;

            using (var context = new LoggerDbContext(options))
            {
                Mock<DataBaseLogger> logger = new Mock<DataBaseLogger>(context);
                DateTime expTime = DateTime.Now;
                string msg = "Prueba Error";
                logger.Setup(m => m.GetCurrentTime()).Returns(expTime);
                logger.Object.addError(msg);
                
                Assert.NotNull(context.Logs.FirstOrDefault(l=>l.Message==msg && l.When == expTime));
            }
        }
    }
}
