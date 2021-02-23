// <copyright file="Megyek.cs" company="MSanyi">
// Copyright (c) MSanyi.All rights reserved.
// </copyright>

using System.Collections.Generic;

namespace VegyesBolt.Data
{
    /// <summary>
    /// A not auto generated part for megyek.
    /// </summary>
    public partial class Megyek
    {
        /// <inheritdoc/>
        public List<string> Names
        {
            get
            {
                return new List<string>
                {
                $"Név",
                $"Székhely",
                $"TelepülesekSzama",
                $"Terület",
                $"Népesség",
                };
            }
        }

        /// <inheritdoc/>
        public List<object> Value
        {
            get
            {
                return new List<object>
                {
                 this.Nev,
                 this.Szekhely,
                 this.TelepulesekSzama,
                 this.Terulet,
                 this.Nepesseg,
                };
            }
        }
        /// <summary>
        /// A method that returns all of the properties name.
        /// </summary>
        /// <returns>The properties name.</returns>
        public static string Header()
        {
            return $"Név\t" +
                $"Székhely\t" +
                $"TelepülesekSzama\t" +
                $"Terület\t" +
                $"Népesség";
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return $"{this.Nev}\t"
                   + $"{this.Szekhely}\t"
                   + $"{this.TelepulesekSzama} db\t"
                   + $"{this.Terulet} km²\t"
                   + $"{this.Nepesseg} fő";
        }
    }
}
