﻿using System;
using System.Collections.Generic;

namespace MedfeesSolution.Models
{
    public partial class Doctor
    {
        public int Doctorid { get; set; }
        public int? Hospitaltenantid { get; set; }
        public string Doctoruniqueid { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Mobilenumeber { get; set; }
        public string Education { get; set; }
        public string Emailid { get; set; }
        public int? Docdesigid { get; set; }
        public byte[] Passwordhash { get; set; }
        public byte[] Passwordsalt { get; set; }
        public string Gender { get; set; }
        public string Licenseno { get; set; }
        public DateTime? Licenseexpirydate { get; set; }
        public int? Emergencycontactno { get; set; }
        public int? Aadharno { get; set; }
        public string Pancardno { get; set; }
        public int? City { get; set; }
        public int? State { get; set; }
        public int? Pincode { get; set; }
        public int? Country { get; set; }
        public DateTime? Joiningdate { get; set; }
        public int? Roleid { get; set; }
        public bool? Isactive { get; set; }
        public byte[] Uploadimage { get; set; }
        public int? Createdby { get; set; }
        public DateTime? Createdon { get; set; }
        public int? Modifiedby { get; set; }
        public DateTime? Modifiedon { get; set; }

        public virtual Doctorsdesignation Docdesig { get; set; }
        public virtual Hospitaltenant Hospitaltenant { get; set; }
        public virtual Role Role { get; set; }
    }
}
