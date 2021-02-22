// <copyright file="Vasarlasok.cs" company="MSanyi">
// Copyright (c) MSanyi.All rights reserved.
// </copyright>

namespace VegyesBolt.Data
{
    /// <summary>
    /// A not auto generated part for Vasarlasok.
    /// </summary>
    public partial class Vasarlasok
    {
        /// <summary>
        /// A method that returns all of the properties name.
        /// </summary>
        /// <returns>The properties name.</returns>
        public static string Header()
        {
            return $"Név\t" +
                $"VásárlasDátuma\t" +
                $"TermékNeve\t" +
                $"Mennyiség\t";
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return $"{this.Vasarlo.Nev}\t" +
                $"{this.VasarlasDatuma}\t" +
                $"{this.Termek.TermekNeve}\t" +
                $"{this.Mennyiseg}\t";
        }
    }
}
