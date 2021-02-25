namespace VegyesBolt.UI.Logic
{
    using System.Collections.Generic;

    /// <summary>
    ///     An interface which defines the Edit logic.
    /// </summary>
    public interface IEdit
    {
        /// <summary>
        ///     Gets a list that returns the property names according to the object.
        /// </summary>
        public List<string> PropNames { get; }

        /// <summary>
        ///     Gets or sets a list that returns the property values according to the object.
        /// </summary>
        public List<object> Values { get; set; }

        /// <summary>
        ///     Gets the Edit mode.
        /// </summary>
        public EditMode Mode { get; }

        /// <summary>
        ///     Gets the Title of the String.
        /// </summary>
        public string Title { get; }

        

        /// <summary>
        /// Saves the Object.
        /// </summary>
        /// <returns>True if the operation completed successfully.</returns>
        public bool Save();
    }
}