using System;
using System.Collections.Generic;

namespace MedfeesSolution.Models
{
    public partial class Hospitaltenant
    {
        public Hospitaltenant()
        {
            Doctors = new HashSet<Doctor>();
            Hospitallocations = new HashSet<Hospitallocation>();
            staff = new HashSet<staff>();
        }

        public int Hospitaltenantid { get; set; }
        public string Hospitaluniqueid { get; set; }
        public string Hospitalname { get; set; }
        public int? Stateid { get; set; }
        public int? Countryid { get; set; }
        public string Countrycode { get; set; }
        public int? Createdby { get; set; }
        public DateTime? Createdon { get; set; }
        public int? Modifiedby { get; set; }
        public DateTime? Modifiedon { get; set; }
        public bool? Isactive { get; set; }

        public virtual ICollection<Doctor> Doctors { get; set; }
        public virtual ICollection<Hospitallocation> Hospitallocations { get; set; }
        public virtual ICollection<staff> staff { get; set; }
    }
}
