using System;
using System.Collections.Generic;

namespace MedfeesSolution.Models
{
    public partial class Hospitaltenant
    {
        public Hospitaltenant()
        {
            Doctors = new HashSet<Doctor>();
            staff = new HashSet<staff>();
        }

        public int Hospitaltenantid { get; set; }
        public string? Hospitaluniqueid { get; set; }
        public string? Hospitalname { get; set; }
        public string? Hospitallocation { get; set; }
        public int? Locationid { get; set; }
        public string? Phonenumber { get; set; }
        public string? Address { get; set; }
        public string? Address1 { get; set; }
        public string? City { get; set; }
        public string? States { get; set; }
        public string? Country { get; set; }
        public string? Countrycode { get; set; }
        public int? Createdby { get; set; }
        public DateTime? Createdon { get; set; }
        public int? Modifiedby { get; set; }
        public DateTime? Modifiedon { get; set; }

        public virtual ICollection<Doctor> Doctors { get; set; }
        public virtual ICollection<staff> staff { get; set; }
    }
}
