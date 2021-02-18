using System;
using System.Collections.Generic;

#nullable disable

namespace VegyesBolt.Data {
    public partial class Vasarlok {
        public Vasarlok() {
            Vasarlasoks = new HashSet<Vasarlasok>();
        }

        public double Id { get; set; }
        public string Nev { get; set; }
        public string Email { get; set; }
        public DateTime RegDate { get; set; }
        public double? Megye { get; set; }

        public virtual Megyek MegyeNavigation { get; set; }
        public virtual ICollection<Vasarlasok> Vasarlasoks { get; set; }
    }
}
