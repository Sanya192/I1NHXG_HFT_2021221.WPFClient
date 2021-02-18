// <copyright file="ILogic.cs" company="MSanyi">
// Copyright (c) MSanyi.All rights reserved.
// </copyright>

namespace VegyesBolt.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using VegyesBolt.Data;

    /// <summary>
    /// The Logic interface.
    /// </summary>
    internal interface ILogic
    {
        /// <summary>
        /// Gets all Megye.
        /// </summary>
        /// <returns>Returns every record in string format.</returns>
        string GetMegyek();

        /// <summary>
        /// Gets all Termek.
        /// </summary>
        /// <returns>Returns every record in string format.</returns>
        string GetTermekek();

        /// <summary>
        /// Gets all Vasarlok.
        /// </summary>
        /// <returns>Returns every record in string format.</returns>
        string GetVasarlok();

        /// <summary>
        /// Gets all Vasarlasok.
        /// </summary>
        /// <returns>Returns every record in string format.</returns>
        string GetVasarlasok();

        /// <summary>
        /// Gets one Megye.
        /// </summary>
        /// <param name="id">The id of the record.</param>
        /// <returns>A record in string format.</returns>
        string GetMegye(int id);

        /// <summary>
        /// Gets one Termek.
        /// </summary>
        /// <param name="id">The id of the record.</param>
        /// <returns>Returns every record in string format.</returns>
        string GetTermek(int id);

        /// <summary>
        /// Gets one Vasarlo.
        /// </summary>
        /// <param name="id">The id of the record.</param>
        /// <returns>Returns every record in string format.</returns>
        string GetVasarlo(int id);

        /// <summary>
        /// Gets one Vasarlas.
        /// </summary>
        /// <param name="id">The id of the record.</param>
        /// <returns>Returns every record in string format.</returns>
        string GetVasarlas(int id);

        // MegyeCUD

        /// <summary>
        /// Create a Megye object in the database.
        /// </summary>
        /// <param name="create">The object to be in the database. </param>
        /// <returns>If it was succesful returns true.</returns>
        bool CreateMegye(Megyek create);

        /// <summary>
        /// Delete a megyek object.
        /// </summary>
        /// <param name="delete">The object to be deleted.</param>
        /// <returns>If it was succesful returns true.</returns>
        bool DeleteMegyek(Megyek delete);

        /// <summary>
        /// Update a Megye record.
        /// </summary>
        /// <param name="create">Updates a megye record.</param>
        /// <returns>If it was succesful returns true.</returns>
        bool UpdateMegye(Megyek create);

        // TermekCUD

        /// <summary>
        /// Creates a Termek.
        /// </summary>
        /// <param name="create">The new object.</param>
        /// <returns>If it was succesful returns true.</returns>
        bool CreateTermek(Termekek create);

        /// <summary>
        /// Updates a termek object.
        /// </summary>
        /// <param name="update">The record which needs to be updated.</param>
        /// <returns>If it was succesful returns true.</returns>
        bool UpdateTermek(Termekek update);

        /// <summary>
        /// Deletes a termek object.
        /// </summary>
        /// <param name="delete">The object which needs to be deleted.</param>
        /// <returns>If it was succesful returns true.</returns>
        bool DeleteTermek(Termekek delete);

        // Termek methods.

        /// <summary>
        /// Lists the Products owned by one user.
        /// </summary>
        /// <param name="owner">The owner.</param>
        /// <returns>The products.</returns>
        string ListbyOwner(Vasarlok owner);

        /// <summary>
        /// Returns the most owned Product.
        /// </summary>
        /// <returns>The most owned Product.</returns>
        string MostOwnedProduct();

        // Vasarlok CUD

        /// <summary>
        /// Creates a new Vasarlok.
        /// </summary>
        /// <param name="create">The new object.</param>
        /// <returns>If it was succesful returns true.</returns>
        bool CreateVasarlo(Vasarlok create);

        /// <summary>
        /// Updates a Vasarlo record.
        /// </summary>
        /// <param name="update">The record which needs to be updated.</param>
        /// <returns>If it was succesful returns true.</returns>
        bool UpdateVasarlo(Vasarlok update);

        /// <summary>
        /// Deletes a Vasarlo record.
        /// </summary>
        /// <param name="delete">The record which needs to be deleted.</param>
        /// <returns>If it was succesful returns true.</returns>
        bool DeleteVasarlo(Vasarlok delete);

        /// <summary>
        /// Lists all Users who lives in this county.
        /// </summary>
        /// <param name="megye">The county.</param>
        /// <returns>The users.</returns>
        string EbbeAMegyebeLakik(Megyek megye);

        // Vasarlasok CUD.

        /// <summary>
        /// Creates a new Vasarlas.
        /// </summary>
        /// <param name="create">The new Vasarlas.</param>
        /// <returns>If it was succesful returns true.</returns>
        bool CreateVasarlasok(Vasarlasok create);

        /// <summary>
        /// Updates the record.
        /// </summary>
        /// <param name="update">The record which needs to be updated.</param>
        /// <returns>If it was succesful returns true.</returns>
        bool UpdateVasarlasok(Vasarlasok update);

        /// <summary>
        /// Deletes a Vasarlas.
        /// </summary>
        /// <param name="delete">The record which needs to be deleted.</param>
        /// <returns>If it was succesful returns true.</returns>
        bool DeleteVasarlasok(Vasarlasok delete);

        // Additional Methods.

        /// <summary>
        /// Gets a list with custom classes and returns all of the properties values from that item.
        /// </summary>
        /// <param name="list">The list where the data is stored.</param>
        /// <returns>The values of the items.</returns>
        string ListToString(List<object> list);

        /// <summary>
        /// Get the property names from a list.
        /// </summary>
        /// <param name="list">The list.</param>
        /// <returns>The property names.</returns>
        string ListHeaders(List<object> list);

        /// <summary>
        /// Lists everything about a list.
        /// </summary>
        /// <param name="list">The list.</param>
        /// <returns>Header plus records.</returns>
        string ListAll(List<object> list);

        /// <summary>
        /// Gets an item and list everything about it.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>Headers plus the one record.</returns>
        string ListOne(object item);
    }
}
