using LoggerCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoggerTests
{
    class LogManagerBuilderMock : ILogManagerBuilder
    {
        public Mock<ILogger> _m1 { get; set; }
        public Mock<ILogger> _m2 { get; set; }
        public void buildLogManager()
        {
            _m1 = new Mock<ILogger>();
            LogManager.Instance.subscribeLogger(_m1.Object);
            _m2 = new Mock<ILogger>();
            LogManager.Instance.subscribeLogger(_m2.Object);
        }

    }
}
