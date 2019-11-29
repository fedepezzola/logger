using System;
using System.Collections.Generic;

namespace LoggerCore
{
public partial class logs
    {
        public int Id { get; set; }
        public string mensaje { get; set; }
        public System.DateTime fecha_hora { get; set; }
        public string tipo { get; set; }
    
        public virtual logs_tipos logs_tipos { get; set; }
    }
}
