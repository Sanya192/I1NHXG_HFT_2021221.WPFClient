using System;
using System.Collections.Generic;

#nullable disable

namespace VegyesBolt.Data 
    {
    public partial class Megyek {
        public Megyek() {
            Vasarloks = new HashSet<Vasarlok>();
        }

        public double Id { get; set; }
        public string Nev { get; set; }
        public string Szekhely { get; set; }
        public double? TelepulesekSzama { get; set; }
        public double? Nepesseg { get; set; }
        public double? Terulet { get; set; }

        public virtual ICollection<Vasarlok> Vasarloks { get; set; }
    }
}
