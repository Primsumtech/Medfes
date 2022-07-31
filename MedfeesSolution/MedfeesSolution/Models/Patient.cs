using System;
using System.Collections.Generic;

namespace MedfeesSolution.Models
{
    public partial class Patient
    {
        public int Patientid { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Phonenumber { get; set; }
        public string Emailid { get; set; }
        public string Password { get; set; }
        public string Gender { get; set; }
    }
}
