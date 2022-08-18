using System;
using System.Collections.Generic;

namespace MedfeesSolution.Models
{
    public partial class Privilege
    {
        public int Priid { get; set; }
        public bool? Pview { get; set; }
        public bool? Pcreate { get; set; }
        public bool? Pedit { get; set; }
        public bool? Pdelete { get; set; }
        public int? Roleid { get; set; }
        public int? Pageid { get; set; }

        public virtual Page Page { get; set; }
        public virtual Role Role { get; set; }
    }
}
