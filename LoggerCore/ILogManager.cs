using System;
using System.Collections.Generic;
using System.Text;

namespace LoggerCore
{
    interface ILogManager
    {
        public bool subscribeLogger(ILogger sub);
        public bool unsubscribeLogger(ILogger sub);

        
        public void message(string msg);
        public void warning(string msg);
        public void error(string msg);
    }
}
