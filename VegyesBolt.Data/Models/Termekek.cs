using System;
using System.Collections.Generic;

#nullable disable

namespace VegyesBolt.Data {
    public partial class Termekek {
        public Termekek() {
            Vasarlasoks = new HashSet<Vasarlasok>();
        }

        public double Id { get; set; }
        public string TermekNeve { get; set; }
        public double? Ara { get; set; }
        public double? AfasAra { get; set; }
        public int? LeltarMennyiseg { get; set; }

        public virtual ICollection<Vasarlasok> Vasarlasoks { get; set; }
    }
}
