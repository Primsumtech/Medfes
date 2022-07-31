using System;
using System.Collections.Generic;

namespace MedfeesSolution.Models
{
    public partial class Audit
    {
        public int Auditid { get; set; }
        public int? Createdby { get; set; }
        public DateTime? Createddate { get; set; }
        public int? Modifiedby { get; set; }
        public DateTime? Modifieddate { get; set; }
    }
}
