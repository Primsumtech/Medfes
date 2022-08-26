using System;
using System.Collections.Generic;

namespace MedfeesSolution.Models
{
    public partial class Role
    {
        public Role()
        {
            Doctors = new HashSet<Doctor>();
            Privileges = new HashSet<Privilege>();
            Users = new HashSet<User>();
            staff = new HashSet<staff>();
        }

        public int Roleid { get; set; }
        public string Rolename { get; set; }

        public virtual ICollection<Doctor> Doctors { get; set; }
        public virtual ICollection<Privilege> Privileges { get; set; }
        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<staff> staff { get; set; }
    }
}
