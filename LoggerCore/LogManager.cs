using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace LoggerCore
{
    public class LogManager : ILogManager, IDisposable
    {
        private static object _Lock = new object();
        private static LogManager _Logger = null;

        private List<ILogger> _Subscribers;

        private delegate void LogActionDelegate(string msg);
        
        private LogActionDelegate _addMessage;
        private LogActionDelegate _addError;
        private LogActionDelegate _addWarning;

        public static LogManager Instance
        {
            get
            {
                if (_Logger == null)
                {
                    lock (_Lock)
                    {
                        if (_Logger == null)
                        {
                            _Logger = new LogManager();
                        }
                    }
                }
                return _Logger;
            }
        }

        private LogManager()
        {
            _Subscribers = new List<ILogger>();
        }

        public void message(string msg)
        {
            if (LogConfiguration.Instance.LogMessage)
                _addMessage(msg);
        }

        public void warning(string msg)
        {
            if (LogConfiguration.Instance.LogWarning)
                _addWarning(msg);
        }

        public void error(string msg)
        {
            if (LogConfiguration.Instance.LogError)
                _addError(msg);
        }

        public void Dispose()
        {
            foreach (ILogger sub in _Subscribers)
            {
                sub.Terminate();
            }
            _Logger = null;
        }

        public bool subscribeLogger(ILogger sub)
        {
            if (!_Subscribers.Contains(sub))
            {
                sub.Init();
                _Subscribers.Add(sub);
                _addError += sub.addError;
                _addWarning += sub.addWarning;
                _addMessage += sub.addMessage;
                return true;
            }
            return false;
        }

        public bool unsubscribeLogger(ILogger sub)
        {
            if (_Subscribers.Remove(sub))
            {
                _addError -= sub.addError;
                _addWarning -= sub.addWarning;
                _addMessage -= sub.addMessage;
                sub.Terminate();
                return true;
            }
            return false;
            
        }

        ~LogManager()
        {
            Dispose();
        }

    }
}
