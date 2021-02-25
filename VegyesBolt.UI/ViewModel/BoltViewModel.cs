// <copyright file="BoltModel.cs" company="MSanyi">
// Copyright (c) MSanyi.All rights reserved.
// </copyright>

using VegyesBolt.UI.Logic;

namespace VegyesBolt.UI.ViewModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Text;
    using VegyesBolt.Data;
    using VegyesBolt.Logic;

    /// <summary>
    /// The ViewModel For the APP.
    /// </summary>
    public class BoltViewModel : INotifyPropertyChanged
    {
        private Tables selectedTable;

        /// <summary>
        /// Initializes a new instance of the <see cref="BoltViewModel"/> class.
        /// </summary>
        public BoltViewModel()
        {
            this.BoltWorker = new BoltLogic();
            this.SelectedTable = Tables.Megyek;
        }

        /// <inheritdoc/>
        public event PropertyChangedEventHandler PropertyChanged;

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

        /// <summary>
        /// Gets or sets the currently selected table.
        /// </summary>
        public Tables SelectedTable
        {
            get => this.selectedTable; set
            {
                this.selectedTable = value;
                this.OnPropertyChanged();
                this.OnPropertyChanged(nameof(this.AllCurrentToString));
            }
        }

        /// <summary>
        /// Gets or sets the currently selected item.
        /// </summary>
        public int SelectedItem
        {
            get => this.BoltWorker.SelectedItem; set
            {
                this.BoltWorker.SelectedItem = value;
                this.OnPropertyChanged();
            }
        }
        public object SelectedObject => this.BoltWorker.SelectedObject;

        private BoltLogic BoltWorker { get; }

        /// <summary>
        /// Create the OnPropertyChanged method to raise the event
        /// The calling member's name will be used as the parameter.
        /// </summary>
        /// <param name="name">The property name.</param>
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
            //this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.AllCurrentToString)));
        }

        /// <summary>
        /// Shows all members of the currently selected table.
        /// </summary>
        /// <returns>all members of the currently table.</returns>
        private IEnumerable<object> ShowAll()
        {
            return BoltWorker.ShowAll();
        }

        private string HeaderOfTheCurrent()
        {
            return this.BoltWorker.HeaderOfTheCurrent();
        }

        public void DeleteCurrent()
        {
            this.BoltWorker.DeleteCurrent();
            this.OnPropertyChanged(nameof(this.AllCurrentToString));
        }
    }
}
