// <copyright file="BoltViewModel.cs" company="MSanyi">
// Copyright (c) MSanyi.All rights reserved.
// </copyright>

namespace VegyesBolt.UI.ViewModel
{
    using Microsoft.AspNetCore.SignalR.Client;
    using Microsoft.Toolkit.Mvvm.ComponentModel;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Text;
    using VegyesBolt.Data;
    using VegyesBolt.Logic;
    using VegyesBolt.RestWpfUi.Logic;
    using VegyesBolt.UI.Logic;


    /// <summary>
    /// The ViewModel For the APP.
    /// </summary>
    public class BoltViewModel : ObservableRecipient
    {
        private Tables selectedTable;
        private int selectedItem;
        private HubConnection connection;

        /// <summary>
        /// Initializes a new instance of the <see cref="BoltViewModel"/> class.
        /// </summary>
        public BoltViewModel()
        {
            this.Worker = new RestWorker();
            this.SelectedTable = Tables.Megyek;
            this.selectedItem = 0;
             connection = new HubConnectionBuilder()
                .WithUrl("https://localhost:7207/hub")
                .WithAutomaticReconnect()
                .Build();
             this.connection.On<string>("Changed", (accounts) =>
             {
                 this.Refresh();
             });
            connection.StartAsync();
            (this.Worker as RestWorker).CollectionChanged += (a, b) => { this.Refresh(); };
        }

        /// <inheritdoc/>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Gets all of the current items as String.
        /// </summary>
        public IReadOnlyCollection<string> AllCurrentToString
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

        /// <summary>
        /// Gets or sets the currently selected table.
        /// </summary>
        public Tables SelectedTable
        {
            get => this.selectedTable; set
            {
                this.selectedTable = value;
                this.OnPropertyChanged();
                this.Refresh();
            }
        }

        /// <summary>
        /// Gets or sets the currently selected item.
        /// </summary>
        public int SelectedItem
        {
            get => this.selectedItem; set
            {
                if (value <= 0)
                {
                    this.selectedItem = 0;
                }
                else
                {
                    this.selectedItem = value-1;
                }

                this.OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets the currently selected object.
        /// </summary>
        public object SelectedObject
        {
            get
            {
                return this.SelectedTable switch
                {
                    Tables.Megyek => this.Worker.GetMegye(this.selectedItem),
                    Tables.Vasarlok => this.Worker.GetVasarlo(this.selectedItem),
                    Tables.Termekek => this.Worker.GetTermek(this.selectedItem),
                    Tables.Vasarlasok => this.Worker.GetVasarlas(this.selectedItem),
                    _ => null,
                };
            }
        }

        private ILogic Worker { get; }

        private List<Megyek> MegyekList { get => this.Worker.GetMegyek(); }

        private List<Vasarlok> VasarlokList { get => this.Worker.GetVasarlok(); }

        private List<Termekek> TermekekList { get => this.Worker.GetTermekek(); }

        private List<Vasarlasok> VasarlasokList { get => this.Worker.GetVasarlasok(); }

        /// <summary>
        /// Delete the currently selected object.
        /// </summary>
        public void DeleteCurrent()
        {
            switch (this.SelectedTable)
            {
                case Tables.Megyek:
                    this.Worker.DeleteMegyek(this.MegyekList[this.SelectedItem]);
                    this.Refresh();
                    break;
                case Tables.Vasarlok:
                    this.Worker.DeleteVasarlo(this.VasarlokList[this.SelectedItem]);
                    this.Refresh();
                    break;
                case Tables.Termekek:
                    this.Worker.DeleteTermek(this.TermekekList[this.SelectedItem]);
                    this.Refresh();
                    break;
                case Tables.Vasarlasok:
                    this.Worker.DeleteVasarlasok(this.VasarlasokList[this.SelectedItem]);
                    this.Refresh();
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Saves the current megye. Not Implemented for other things.
        /// </summary>
        /// <param name="megyek">The edited megye.</param>
        /// <param name="uje"><see langword="true"/>if its new.</param>
        internal void SaveCurrent(Megyek megyek, bool uje)
        {
            if (uje)
            {
                this.Worker.CreateMegye(megyek);
            }
            else
            {
                this.Worker.UpdateMegye(megyek);
            }

            this.Refresh();
        }

        /* /// <summary>
         /// Create the OnPropertyChanged method to raise the event
         /// The calling member's name will be used as the parameter.
         /// </summary>
         /// <param name="name">The property name.</param>
         protected void OnPropertyChanged([CallerMemberName] string name = null)
         {
             this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
         }*/

        private void Refresh()
        {
            this.OnPropertyChanged(nameof(this.AllCurrentToString));
        }

        /// <summary>
        /// Shows all members of the currently selected table.
        /// </summary>
        /// <returns>all members of the currently table.</returns>
        private IEnumerable<object> ShowAll()
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

        private string HeaderOfTheCurrent()
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

        
    }
}
