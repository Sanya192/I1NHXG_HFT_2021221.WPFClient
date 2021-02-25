namespace VegyesBolt.UI.Logic
{
    using System;
    using System.Collections.Generic;
    using VegyesBolt.Data;
    using VegyesBolt.Logic;
    using VegyesBolt.UI.ViewModel;

    public class BoltLogic :IBoltLogic
    {
        private Tables selectedTable;
        private int selectedItem;
        private Worker Worker { get; }

        private List<Megyek> MegyekList { get => this.Worker.GetMegyek(); }

        private List<Vasarlok> VasarlokList { get => this.Worker.GetVasarlok(); }

        private List<Termekek> TermekekList { get => this.Worker.GetTermekek(); }

        private List<Vasarlasok> VasarlasokList { get => this.Worker.GetVasarlasok(); }

        /// <summary>
        /// Gets all of the current items as String.
        /// </summary>
        public List<string> AllCurrentToString
        {
            get
            {
                var ki = new List<string>();
                ki.Add(this.HeaderOfTheCurrent());
                foreach (object item in this.ShowAll())
                {
                    ki.Add(item.ToString());
                }

                return ki;
            }
        }

        public object SelectedObject
        {
            get
            {
                return this.SelectedTable switch
                {
                    Tables.Megyek => Worker.GetMegye(selectedItem),
                    Tables.Vasarlok => Worker.GetVasarlo(selectedItem),
                    Tables.Termekek => Worker.GetTermek(selectedItem),
                    Tables.Vasarlasok => Worker.GetVasarlas(selectedItem),
                    _ => throw new NotImplementedException(),
                };
            }
        }

        /// <inheritdoc/>
        public IEnumerable<object> ShowAll()
        {
            return this.SelectedTable switch
            {
                Tables.Megyek => this.MegyekList,
                Tables.Vasarlok => this.VasarlokList,
                Tables.Termekek => this.TermekekList,
                Tables.Vasarlasok => this.VasarlasokList,
                _ => throw new NotSupportedException(),
            };
        }

        /// <inheritdoc/>
        public string HeaderOfTheCurrent()
        {
            return this.SelectedTable switch
            {
                Tables.Megyek => Megyek.Header(),
                Tables.Vasarlok => Vasarlok.Header(),
                Tables.Termekek => Termekek.Header(),
                Tables.Vasarlasok => Vasarlasok.Header(),
                _ => throw new NotSupportedException(),
            };
        }
        
        /// <summary>
        /// Gets or sets the currently selected table.
        /// </summary>
        public Tables SelectedTable
        {
            get => this.selectedTable; set
            {
                this.selectedTable = value;
            }
        }

        /// <summary>
        /// Gets or sets the currently selected item.
        /// </summary>
        public int SelectedItem
        {
            get => this.selectedItem + 1; set
            {
                if (value <= 0)
                {
                    this.selectedItem = 0;
                }
                else
                {
                    this.selectedItem = value - 1;
                }
            }
        }
        public void DeleteCurrent()
        {
            switch (this.SelectedTable)
            {
                case Tables.Megyek:
                    this.Worker.DeleteMegyek(this.Worker.GetMegye(this.selectedItem));
                    break;
                case Tables.Vasarlok:
                    this.Worker.DeleteVasarlo(this.Worker.GetVasarlo(this.selectedItem));
                    break;
                case Tables.Termekek:
                    this.Worker.DeleteTermek(this.Worker.GetTermek(this.selectedItem));
                    break;
                case Tables.Vasarlasok:
                    this.Worker.DeleteVasarlasok(this.Worker.GetVasarlas(this.selectedItem));
                    break;
                default:
                    break;
            }
        }
    }
}