using System;
using System.Collections.Generic;

namespace MedfeesSolution.Models
{
    public partial class Country
    {
        public Country()
        {
            States = new HashSet<State>();
        }

        public int Countryid { get; set; }
        public string Countryname { get; set; }

        public virtual ICollection<State> States { get; set; }
    }
}
