    using System;
    using System.Collections.Generic;

namespace LoggerCore.Data
{
    public partial class LogTypes
    {
        
        public LogTypes()
        {
            this.Logs = new HashSet<Logs>();
        }
    
        public string Id { get; set; }
        public string Description { get; set; }
    
        public virtual ICollection<Logs> Logs { get; set; }
    }
}
