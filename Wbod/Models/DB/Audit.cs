using System;
using System.Collections.Generic;

namespace Wbod.Models.DB
{
    public partial class Audit
    {
        public Guid AuditId { get; set; }
        public string UserName { get; set; }
        public string Ipaddress { get; set; }
        public string AreaAccessed { get; set; }
        public DateTime? Timestamp { get; set; }

        public Audit() { }

    }
}
