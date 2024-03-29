﻿using System;
using System.Collections.Generic;

namespace MedfeesSolution.Models
{
    public partial class Doctorsdesignation
    {
        public Doctorsdesignation()
        {
            Doctors = new HashSet<Doctor>();
        }

        public int Docdesigid { get; set; }
        public string Designationname { get; set; }
        public bool? Isactive { get; set; }

        public virtual ICollection<Doctor> Doctors { get; set; }
    }
}
