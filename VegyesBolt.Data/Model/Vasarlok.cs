// <copyright file="Vasarlok.cs" company="MSanyi">
// Copyright (c) MSanyi.All rights reserved.
// </copyright>

namespace VegyesBolt.Data
{
    /// <summary>
    /// A not auto generated part for megyek.
    /// </summary>
    public partial class Vasarlok
    {
        /// <summary>
        /// A method that returns all of the properties name.
        /// </summary>
        /// <returns>The properties name.</returns>
        public static string Header()
        {
            return $"Név\t" +
                $"Megye\t" +
                $"Regisztráció dátuma\t" +
                $"Email";
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return $"{this.Nev}\t"
                   + $"{(this.Megye == null ? "Hajléktalan" : this.MegyeNavigation?.Nev)}\t"
                   + $"{this.RegDate}\t"
                   + $"{this.Email}";
        }
    }
}
