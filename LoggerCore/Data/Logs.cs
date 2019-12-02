using System;
using System.Collections.Generic;

namespace LoggerCore.Data
{
public partial class Logs
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public System.DateTime When { get; set; }
        public string Type { get; set; }
    
        public virtual LogTypes LogType { get; set; }
    }
}
