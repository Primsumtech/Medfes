using System;
using System.Collections.Generic;

namespace MedfeesSolution.Models
{
    public partial class Patient
    {
        public int Patientid { get; set; }
        public string Firstname { get; set; } = null!;
        public string Lastname { get; set; } = null!;
        public string Phonenumber { get; set; } = null!;
        public string? Emailid { get; set; }
        public string Password { get; set; } = null!;
        public string Gender { get; set; } = null!;
    }
}
