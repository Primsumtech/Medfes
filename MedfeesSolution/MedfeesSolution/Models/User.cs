using System;
using System.Collections.Generic;

namespace MedfeesSolution.Models
{
    public partial class User
    {
        public int Userid { get; set; }
        public string Firstname { get; set; }
        public string Middlename { get; set; }
        public string Lastname { get; set; }
        public string Phonenumber { get; set; }
        public string Address { get; set; }
        public string Address1 { get; set; }
        public string City { get; set; }
        public string States { get; set; }
        public string Country { get; set; }
        public string Countrycode { get; set; }
        public int? Roleid { get; set; }
        public byte[] Passwordhash { get; set; }
        public byte[] Passwordsalt { get; set; }
        public string Email { get; set; }

        public virtual Role Role { get; set; }
    }
}
