using System;
using System.Collections.Generic;

namespace MedfeesSolution.Models
{
    public partial class State
    {
        public State()
        {
            Cities = new HashSet<City>();
        }

        public int Stateid { get; set; }
        public string? Statename { get; set; }
        public int? Countryid { get; set; }

        public virtual Country? Country { get; set; }
        public virtual ICollection<City> Cities { get; set; }
    }
}
