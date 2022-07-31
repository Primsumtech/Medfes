﻿using System;
using System.Collections.Generic;

namespace MedfeesSolution.Models
{
    public partial class Role
    {
        public Role()
        {
            Users = new HashSet<User>();
        }

        public int Roleid { get; set; }
        public string Rolename { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
