// <copyright file="HonfoglaloViewModel.cs" company="MSanyi">
// Copyright (c) MSanyi.All rights reserved.
// </copyright>

namespace VegyesBolt.UI.ViewModel
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using VegyesBolt.Data;

    /// <summary>
    /// Ezzel kezeljük a megye tablat.
    /// </summary>
    internal class HonfoglaloViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HonfoglaloViewModel"/> class.
        /// The standard method for creating a megye.
        /// </summary>
        public HonfoglaloViewModel()
        {
            this.EditedMegye = new Megyek();
            this.NewMode = true;

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HonfoglaloViewModel"/> class.
        /// The standard method for editing a megye.
        /// </summary>
        /// <param name="editedMegye">The megye needs to be edited.</param>
        public HonfoglaloViewModel(Megyek editedMegye)
        {
            this.EditedMegye = new Megyek();
            this.NewMode = false;
            this.EditedMegye.Id = editedMegye.Id;
            this.Nev = editedMegye.Nev;
            this.Szekhely = editedMegye.Szekhely;
            this.TelepulesekSzama = editedMegye.TelepulesekSzama;
            this.Nepesseg = editedMegye.Nepesseg;
            this.Terulet = editedMegye.Terulet;
        }
        public delegate void MegyeDelegate(Megyek megye, bool uje);
        public event MegyeDelegate OnSave;
        public string Nev { get; set; }
        public string Szekhely { get; set; }
        public double? TelepulesekSzama { get; set; }
        public double? Nepesseg { get; set; }
        public double? Terulet { get; set; }

        /// <summary>
        /// Gets or sets the currently edited megye.
        /// </summary>
        private Megyek EditedMegye { get; set; }

        private bool NewMode { get; set; }

        public void Save()
        {
            this.EditedMegye.Nev = this.Nev;
            this.EditedMegye.Szekhely = this.Szekhely;
            this.EditedMegye.TelepulesekSzama = this.TelepulesekSzama;
            this.EditedMegye.Nepesseg = this.Nepesseg;
            this.EditedMegye.Terulet = this.Terulet;
            this.OnSave?.Invoke(this.EditedMegye, this.NewMode);
        }
    }
}
