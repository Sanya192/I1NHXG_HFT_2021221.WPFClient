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

        /// <summary>
        /// A delegate for megye Input Events.
        /// </summary>
        /// <param name="megye">The edited megye.</param>
        /// <param name="uje">True if new.</param>
        public delegate void MegyeDelegate(Megyek megye, bool uje);

        /// <summary>
        /// An event which fires if saved.
        /// </summary>
        public event MegyeDelegate OnSave;

        /// <summary>
        /// Gets or sets the edited name.
        /// </summary>
        public string Nev { get; set; }

        /// <summary>
        /// Gets or sets the edited szekhely.
        /// </summary>
        public string Szekhely { get; set; }

        /// <summary>
        /// Gets or sets the edited town numbers.
        /// </summary>
        public double? TelepulesekSzama { get; set; }

        /// <summary>
        /// Gets or sets the edited pops numbers.
        /// </summary>
        public double? Nepesseg { get; set; }

        /// <summary>
        /// Gets or sets the edited size.
        /// </summary>
        public double? Terulet { get; set; }

        /// <summary>
        /// Gets or sets the currently edited megye.
        /// </summary>
        private Megyek EditedMegye { get; set; }

        private bool NewMode { get; set; }

        /// <summary>
        /// It saves the thingy.
        /// </summary>
        public void Save()
        {
            this.EditedMegye.Nev = this.Nev;
            this.EditedMegye.Szekhely = this.Szekhely;
            this.EditedMegye.TelepulesekSzama = this.TelepulesekSzama;
            this.EditedMegye.Nepesseg = this.Nepesseg;
            this.EditedMegye.Terulet = this.Terulet;

            // *bang*
            this.OnSave?.Invoke(this.EditedMegye, this.NewMode);
        }
    }
}
