using System;
using System.Collections.Generic;

namespace MedfeesSolution.Models
{
    public partial class Diagnosticmaster
    {
        public string Diagnosticid { get; set; } = null!;
        public string? Diagnosticname { get; set; }
        public bool? Isactive { get; set; }
    }
}
