using System;
using System.Collections.Generic;

namespace MedfeesSolution.Models
{
    public partial class Page
    {
        public Page()
        {
            Privileges = new HashSet<Privilege>();
        }

        public int Pageid { get; set; }
        public string Pagename { get; set; }

        public virtual ICollection<Privilege> Privileges { get; set; }
    }
}
