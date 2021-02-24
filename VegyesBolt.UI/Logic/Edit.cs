using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VegyesBolt.Data;

namespace VegyesBolt.UI.Logic
{
    class Edit
    {
        public Edit(object editableItem)
        {
            EditableItem = editableItem;
            Mode = EditMode.Update;
        }

        private object EditableItem { get; set; }
        private object EditedItem { get; set; }
        private EditMode Mode { get; set; }
        public List<string> PropNames
        {
            get
            {
                // return EditableItem.ToString().Split('\t').ToList();
                return this.EditableItem switch
                {
                    Megyek m => Megyek.Header().Split('\t').ToList(),
                    Termekek t => Termekek.Header().Split('\t').ToList(),
                    Vasarlok v => Vasarlok.Header().Split('\t').ToList(),
                    Vasarlasok v => Vasarlasok.Header().Split('\t').ToList(),
                    _ => throw new NotImplementedException(),
                };
            }
        }
        public List<object> Values
        {
            get
            {
                return this.EditableItem switch
                {
                    Megyek m => this.MegyeValues(m),
                    Termekek t => this.TermekValues(t),
                    Vasarlok v => this.VasarlokValues(v),
                    Vasarlasok v => this.VasarlasokValues(v),
                    _ => throw new NotImplementedException(),
                };
            }
            set
            {
                this.EditedItem = value;
            }
        }
        public string Title
        {
            get
            {
                return this.EditableItem switch
                {
                    Megyek m => "Megye",
                    Termekek t => "Termek",
                    Vasarlok v => "Vasarlo",
                    Vasarlasok v => "Vasarlasok",
                    _ => throw new NotImplementedException(),
                };
            }
        }

        public bool Save()
        {
            switch (EditedItem)
            {
                case Megyek m:

                    break;
                default:
                    break;
            }

            return false;
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
            //throw new NotImplementedException();
            //
            // Megye is not well implemented
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
