// <copyright file="IVasarlokRepository.cs" company="MSanyi">
// Copyright (c) MSanyi.All rights reserved.
// </copyright>

namespace VegyesBolt.Repository
{
    using System.Collections.Generic;
    using VegyesBolt.Data;

    /// <summary>
    /// The repository for Vasarlok Table.
    /// </summary>
    public interface IVasarlokRepository : IRepository<Vasarlok>
    {
        /// <summary>
        /// List all Customers who lives in that county.
        /// </summary>
        /// <param name="megye">The county where they live.</param>
        /// <returns>Get all Customers who lives in that county.</returns>
        List<Vasarlok> EbbeAMegyebeKiLakik(Megyek megye);
    }
}
