// <copyright file="Termekek.cs" company="MSanyi">
// Copyright (c) MSanyi.All rights reserved.
// </copyright>

namespace VegyesBolt.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// A not auto generated part for termekek.
    /// </summary>
    public partial class Termekek
    {
        /// <summary>
        /// A method that returns all of the properties name.
        /// </summary>
        /// <returns>The properties name.</returns>
        public static string Header()
        {
            return $"Név\t" +
                $"Ára\t" +
                $"ÁfásÁra\t" +
                $"Mennyiség";
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return $"{this.TermekNeve}\t" +
                $"{this.Ara}\t" +
                $"{this.AfasAra}\t" +
                $"{this.LeltarMennyiseg}";
        }
    }
}
