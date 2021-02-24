using System.Collections.Generic;

namespace VegyesBolt.UI.Logic
{
    public interface IBoltLogic
    {
        /// <summary>
        /// Gets all of the current items as String.
        /// </summary>
        public List<string> AllCurrentToString { get; }
    }
}