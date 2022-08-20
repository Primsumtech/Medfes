using System;
using System.Collections.Generic;

namespace MedfeesSolution.Models
{
    public partial class Patient
    {
        public int Patientid { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Mobilenumber { get; set; }
        public string Emailid { get; set; }
        public string Gender { get; set; }
        public byte[] Passwordhash { get; set; }
        public byte[] Passwordsalt { get; set; }
        public DateOnly Dob { get; set; }
        public string Fathername { get; set; }
        public string Mothername { get; set; }
        public string Bloodgroup { get; set; }
        public int? AdhaarNo { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Pincode { get; set; }
        public byte[] Image { get; set; }
    }
}
