// <copyright file="IRepository.cs" company="MSanyi">
// Copyright (c) MSanyi.All rights reserved.
// </copyright>

namespace VegyesBolt.Repository
{
    using System.Collections.Generic;
    using VegyesBolt.Data;

    /// <summary>
    /// The main interface.
    /// </summary>
    /// <typeparam name="T">A parameter which is needed for alinterfaces.</typeparam>
    public interface IRepository<T>
    {
        /// <summary>
        /// Gets a list containing all elements;.
        /// </summary>
        List<T> Elements { get; }

        /// <summary>
        /// A method to delete an object.
        /// </summary>
        /// <param name="toDelete">An object which is deleted.</param>
        void Delete(T toDelete);

        /// <summary>
        /// Updates an element.
        /// </summary>
        /// <param name="toUpdate">The old element.</param>
        void Update(T toUpdate);

        /// <summary>
        /// Creates an element in the database.
        /// </summary>
        /// <param name="create">The new element.</param>
        void Create(T create);
    }
}
