using System;
using System.Collections.Generic;

namespace MedfeesSolution.Models
{
    public partial class Hospitallocation
    {
        public int Hospitallocationid { get; set; }
        public int? Hospitaltenantid { get; set; }
        public string Hospitaluniqueid { get; set; }
        public string Hospitallocation1 { get; set; }
        public string Phonenumber { get; set; }
        public string Address { get; set; }
        public string Address1 { get; set; }
        public int? Cityid { get; set; }
        public int? Createdby { get; set; }
        public DateTime? Createdon { get; set; }
        public int? Modifiedby { get; set; }
        public DateTime? Modifiedon { get; set; }

        public virtual Hospitaltenant Hospitaltenant { get; set; }
    }
}
