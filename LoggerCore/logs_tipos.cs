    using System;
    using System.Collections.Generic;

namespace LoggerCore
{
    public partial class logs_tipos
    {
        
        public logs_tipos()
        {
            this.logs = new HashSet<logs>();
        }
    
        public string id { get; set; }
        public string descripcion { get; set; }
    
        public virtual ICollection<logs> logs { get; set; }
    }
}
