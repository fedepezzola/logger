using System;
using System.Collections.Generic;
using System.Text;

namespace LoggerCore
{
    public interface ILogger
    {
        void addMessage(string msj);
        void addWarning(string msj);
        void addError(string msj);
        void Init();
        void Terminate();
    }
}
