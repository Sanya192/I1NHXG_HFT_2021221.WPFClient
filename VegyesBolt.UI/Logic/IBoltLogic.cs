using System.Collections.Generic;

namespace VegyesBolt.UI.Logic
{
    public interface IBoltLogic
    {
        /// <summary>
        /// Gets all of the current items as String.
        /// </summary>
        public List<string> AllCurrentToString { get; }
        public object SelectedObject { get; }

        /// <summary>
        /// Shows all members of the currently selected table.
        /// </summary>
        /// <returns>all members of the currently table.</returns>
        public IEnumerable<object> ShowAll();

        public string HeaderOfTheCurrent();
        public void DeleteCurrent();
    }
}