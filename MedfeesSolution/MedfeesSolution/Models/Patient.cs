﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedfeesSolution.Models
{
    public partial class Patient
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string  Patientid { get; set; } 
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Mobilenumber { get; set; }
        public string Emailid { get; set; }
        public string Gender { get; set; }
        public byte[] Passwordhash { get; set; }
        public byte[] Passwordsalt { get; set; }
        public DateTime DOB { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public string BloodGroup { get; set; }
        public int AdhaarNo { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int PinCode { get; set; }
        public byte[] Image { get; set; }
    }
}
