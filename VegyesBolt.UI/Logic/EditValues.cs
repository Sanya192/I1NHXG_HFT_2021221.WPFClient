namespace VegyesBolt.UI.Logic
{
    using System;
    using System.Collections.Generic;
    using VegyesBolt.Data;

    internal static class EditValues
    {
        /// <summary>
        /// Creates editable values of a megye object.
        /// </summary>
        /// <param name="input">The object we want properties of.</param>
        /// <returns>An object list with the properties of the megye.</returns>
        public static List<object> MegyeValues(Megyek input)
        {
            return new ()
            {
                input.Nev,
                input.Szekhely,
                input.TelepulesekSzama,
                input.Terulet,
                input.Nepesseg,
            };
        }

        /// <summary>
        /// Creates editable values of a termek object.
        /// </summary>
        /// <param name="input">The object we want properties of.</param>
        /// <returns>An object list with the properties of the termek.</returns>
        public static List<object> TermekValues(Termekek input)
        {
            return new ()
            {
                input.TermekNeve,
                input.Ara,
                input.AfasAra,
                input.LeltarMennyiseg,
            };
        }

        /// <summary>
        /// Creates editable values of a vasarlo object.
        /// </summary>
        /// <param name="input">The object we want properties of.</param>
        /// <returns>An object list with the properties of the vasarlo.</returns>
        public static List<object> VasarlokValues(Vasarlok input)
        {
            // throw new NotImplementedException();
            //
            // TODO: Megye implementation.
            return new ()
            {
                input.Nev,
                input.RegDate,
                input.Email,
            };
        }

        /// <summary>
        /// Creates editable values of a vásárlás object.
        /// </summary>
        /// <param name="input">The object we want properties of.</param>
        /// <returns>An object list with the properties of the vásárlás.</returns>
        public static List<object> VasarlasokValues(Vasarlasok input)
        {
            throw new NotImplementedException();
        }
    }
}