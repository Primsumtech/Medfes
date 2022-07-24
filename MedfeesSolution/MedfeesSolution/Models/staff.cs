using System;
using System.Collections.Generic;

namespace MedfeesSolution.Models
{
    public partial class staff
    {
        public int Staffid { get; set; }
        public string? Firstname { get; set; }
        public string? Midlename { get; set; }
        public string? Lastname { get; set; }
        public string? Designation { get; set; }
        public string? Hospitallocation { get; set; }
        public int? Locationid { get; set; }
        public int? Roleid { get; set; }
        public int? Hospitaltenantid { get; set; }
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

        public virtual Hospitaltenant? Hospitaltenant { get; set; }
        public virtual Role? Role { get; set; }
    }
}
