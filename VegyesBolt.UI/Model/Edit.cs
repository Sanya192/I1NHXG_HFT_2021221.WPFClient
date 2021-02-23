using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VegyesBolt.Data;

namespace VegyesBolt.UI.Model
{
    class Edit
    {
        object EditableItem { get; set; }
        public List<string> PropNames
        {
            get
            {
                return EditableItem.ToString().Split('\t').ToList();
            }
        }
        public List<object> Values
        {
            get
            {
                return this.EditableItem.GetType() switch
                {

                    _ => throw new NotImplementedException(),
                };
            }
        }

        private List<object> MegyeValues(Megyek input)
        {
            return new List<object>
            {
                input.Nev,
                input.Szekhely,
                input.TelepulesekSzama,
                input.Terulet,
                input.Nepesseg,
            };
        }

        private List<object> TermekValues(Termekek input)
        {
            return new List<object>
            {
                input.TermekNeve,
                input.Ara,
                input.AfasAra,
                input.LeltarMennyiseg,
            };
        }

        private List<object> VasarlokValues(Vasarlok input)
        {
            return new List<object>
            {
                input.Nev,
                input.RegDate,
                input.Email,
            };
        }

        private List<object> VasarlasokValues(Vasarlasok input)
        {
            throw new NotImplementedException();
        }
    }
}
