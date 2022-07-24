using System;
using System.Collections.Generic;

namespace MedfeesSolution.Models
{
    public partial class Errorlog
    {
        public int Errorid { get; set; }
        public string? Errormethodname { get; set; }
        public string? Errorcontroller { get; set; }
        public string? Errormessage { get; set; }
        public DateTime? Creadteddate { get; set; }
    }
}
