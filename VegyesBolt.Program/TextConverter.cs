// <copyright file="TextConverter.cs" company="MSanyi">
// Copyright (c) MSanyi.All rights reserved.
// </copyright>

namespace VegyesBolt.Program
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// A <see langword="static"/>class which converts to text.
    /// </summary>
    internal static class TextConverter
    {
        /// <summary>
        /// Gets a list with custom classes and returns all of the properties values from that item.
        /// </summary>
        /// <param name="list">The list where the data is stored.</param>
        /// <returns>The values of the items.</returns>
        public static string ListToString(List<object> list)
        {
            string output = default(string);
            var type = list.GetType().GetGenericArguments().Single();
            foreach (var item in list)
            {
                foreach (var prop in item.GetType().GetProperties().Where(p => !p.GetMethod.IsVirtual))
                {
                    output += prop.GetValue(item) == null ? "null" : prop.GetValue(item).ToString();
                    output += "\t";
                }

                output += Environment.NewLine;
            }

            return output;
        }

        /// <summary>
        /// Get the property names from a list.
        /// </summary>
        /// <param name="list">The list.</param>
        /// <returns>The property names.</returns>
        public static string ListHeaders(List<object> list)
        {
            string output = default(string);
            var type = list.GetType().GetGenericArguments().Single();
            var item = list.First();
            foreach (var prop in item.GetType().GetProperties().Where(p => !p.GetMethod.IsVirtual))
            {
                output += prop.Name;
                output += "\t";
            }

            output += Environment.NewLine;
            return output;
        }

        /// <summary>
        /// Lists everything about a list.
        /// </summary>
        /// <param name="list">The list.</param>
        /// <returns>Header plus records.</returns>
        public static string ListAll(List<object> list)
        {
            return ListHeaders(list) + "\n" + ListToString(list);
        }

        /// <summary>
        /// Gets an item and list everything about it.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>Headers plus the one record.</returns>
        public static string ListOne(object item)
        {
            var list = new List<object> { item };
            return ListHeaders(list) + "\n" + ListToString(list);
        }
    }
}
