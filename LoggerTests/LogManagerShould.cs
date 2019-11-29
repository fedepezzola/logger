using System;
using Xunit;
using LoggerCore;
using Moq;

namespace LoggerTests
{
    public class LogManagerShould
    {
        private LogManagerBuilderMock _lmb;
        public LogManagerShould()
        {
            LogManager.Instance.Dispose();
            _lmb = new LogManagerBuilderMock();
            _lmb.buildLogManager();
        }

        [Fact]
        public void CallAddErrorOnceForEachLogger()
        {
            LogConfiguration.Instance.LogError = true;
            string msg = "Prueba err";
            LogManager.Instance.error(msg);
            _lmb._m1.Verify(m => m.addError(msg), Times.Once());
            _lmb._m2.Verify(m => m.addError(msg), Times.Once());
        }

        [Fact]
        public void NotCallAddErrorForEachLogger()
        {
            LogConfiguration.Instance.LogError = false;
            string msg = "Prueba err";
            LogManager.Instance.error(msg);
            _lmb._m1.Verify(m => m.addError(msg), Times.Never());
            _lmb._m2.Verify(m => m.addError(msg), Times.Never());
        }

        [Fact]
        public void CallAddWarningOnceForEachLogger()
        {
            LogConfiguration.Instance.LogWarning = true;
            string msg = "Prueba warn";
            LogManager.Instance.warning(msg);
            _lmb._m1.Verify(m => m.addWarning(msg), Times.Once());
            _lmb._m2.Verify(m => m.addWarning(msg), Times.Once());
        }

        [Fact]
        public void NotCallAddWarningForEachLogger()
        {
            LogConfiguration.Instance.LogWarning = false;
            string msg = "Prueba warn";
            LogManager.Instance.warning(msg);
            _lmb._m1.Verify(m => m.addWarning(msg), Times.Never());
            _lmb._m2.Verify(m => m.addWarning(msg), Times.Never());
        }

        [Fact]
        public void CallAddMessageOnceForEachLogger()
        {
            LogConfiguration.Instance.LogMessage = true;
            string msg = "Prueba msg";
            LogManager.Instance.message(msg);
            _lmb._m1.Verify(m => m.addMessage(msg), Times.Once());
            _lmb._m2.Verify(m => m.addMessage(msg), Times.Once());
        }

        [Fact]
        public void NotCallAddMessageForEachLogger()
        {
            LogConfiguration.Instance.LogMessage = false;
            string msg = "Prueba msg";
            LogManager.Instance.message(msg);
            _lmb._m1.Verify(m => m.addWarning(msg), Times.Never());
            _lmb._m2.Verify(m => m.addWarning(msg), Times.Never());
        }

        [Fact]
        public void AddASubscriberAndCallInitThenAddError()
        {
            LogConfiguration.Instance.LogError = true;
            Mock<ILogger> log = new Mock<ILogger>();
            bool r = LogManager.Instance.subscribeLogger(log.Object);
            Assert.True(r);
            log.Verify(m => m.Init());
            string msg = "Prueba err";
            LogManager.Instance.error(msg);
            _lmb._m1.Verify(m => m.addError(msg), Times.Once());
            _lmb._m2.Verify(m => m.addError(msg), Times.Once());
            log.Verify(m => m.addError(msg), Times.Once());
            LogManager.Instance.unsubscribeLogger(log.Object);
        }

        [Fact]
        public void AddASubscriberAndUnsubscribeAndCallTerminate()
        {
            LogConfiguration.Instance.LogError = true;
            Mock<ILogger> log = new Mock<ILogger>();
            bool r = LogManager.Instance.subscribeLogger(log.Object);
            Assert.True(r);
            log.Verify(m => m.Init());
            r = LogManager.Instance.unsubscribeLogger(log.Object);
            Assert.True(r);
            log.Verify(m => m.Terminate());
        }
    }
}
