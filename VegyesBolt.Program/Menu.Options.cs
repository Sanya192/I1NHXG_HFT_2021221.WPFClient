// <copyright file="Menu.Options.cs" company="MSanyi">
// Copyright (c) MSanyi.All rights reserved.
// </copyright>

namespace VegyesBolt.Program
{
    /// <summary>
    /// The class which handles the menu.
    /// This part contains the options enum.
    /// </summary>
    internal partial class Menu
    {
        /// <summary>
        /// The avalaible options for the menu.
        /// </summary>
        public enum Options
        {
            /// <summary>
            /// The option to leave the menu.
            /// </summary>
            Exit,

            /// <summary>
            /// List everything in the database.
            /// </summary>
            ListAll,

            /// <summary>
            /// List every County.
            /// </summary>
            ListMegyek,

            /// <summary>
            /// List all Products.
            /// </summary>
            ListTermekek,

            /// <summary>
            /// List all buyers.
            /// </summary>
            ListVasarlok,

            /// <summary>
            /// List all purchases.
            /// </summary>
            ListVasarlasok,

            /// <summary>
            /// Add a county.
            /// </summary>
            AddMegye,

            /// <summary>
            /// Add a product.
            /// </summary>
            AddTermek,

            /// <summary>
            /// Add a buyer.
            /// </summary>
            AddVasarlo,

            /// <summary>
            /// Add a purchase.
            /// </summary>
            AddVasarlas,

            /// <summary>
            /// Delete county.
            /// </summary>
            DeleteMegye,

            /// <summary>
            /// Delete a product.
            /// </summary>
            DeleteTermek,

            /// <summary>
            /// Delete a buyer.
            /// </summary>
            DeleteVasarlo,

            /// <summary>
            /// Delete a purchase.
            /// </summary>
            DeleteVasarlasok,

            /// <summary>
            /// Updates a megye.
            /// </summary>
            UpdateMegye,

            /// <summary>
            /// Updates a Termek.
            /// </summary>
            UpdateTermek,

            /// <summary>
            /// Updates a Vasarlo.
            /// </summary>
            UpdateVasarlo,

            /// <summary>
            /// Updates a Vasarlas.
            /// </summary>
            UpdateVasarlas,

            /// <summary>
            /// Ki listázza azokat a termekeket amit már egy tulajdonos megvásárolt.
            /// </summary>
            ListByOwner,

            /// <summary>
            /// Ki listázza a legtöbbet vásárolt terméket.
            /// </summary>
            MostOwnedProduct,

            /// <summary>
            /// Ki Listázza ebbe a megyébe ki lakik.
            /// </summary>
            EbbeAMegyebeLakik,

            /// <summary>
            /// Ki kér egy bevásárló listát a java végpontol.
            /// </summary>
            JavaVegpont,
        }
    }
}
