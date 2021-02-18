// <copyright file="VasarlasokRepository.cs" company="MSanyi">
// Copyright (c) MSanyi.All rights reserved.
// </copyright>

namespace VegyesBolt.Repository
{
    using System.Collections.Generic;
    using System.Linq;
    using VegyesBolt.Data;

    /// <summary>
    /// The repository for Vasarlasok.
    /// </summary>
    public class VasarlasokRepository : IVasarlasokRepository
    {
        private static readonly VegyesBoltDatabaseEntities1 VegyesBolt = new VegyesBoltDatabaseEntities1();

        /// <inheritdoc/>
        public List<Vasarlasok> Elements => VegyesBolt.Vasarlasoks.ToList();

        /// <inheritdoc/>
        public void Create(Vasarlasok create)
        {
            VegyesBolt.Vasarlasoks.Add(create);
            VegyesBolt.SaveChanges();
        }

        /// <inheritdoc/>
        public void Delete(Vasarlasok toDelete)
        {
            var delete = VegyesBolt.Vasarlasoks.Find(new { toDelete.VasarloId, toDelete.TermekId });
            VegyesBolt.Vasarlasoks.Remove(delete);
            VegyesBolt.SaveChanges();
        }

        /// <inheritdoc/>
        public void Update(Vasarlasok toUpdate)
        {
            var old = VegyesBolt.Vasarlasoks.Find(new { toUpdate.VasarloId, toUpdate.TermekId });
            old.Mennyiseg = toUpdate.Mennyiseg == null ? old.Mennyiseg : toUpdate.Mennyiseg;
            old.Termek = toUpdate.Termek ?? old.Termek;
            old.VasarlasDatuma = toUpdate.VasarlasDatuma == null ? old.VasarlasDatuma : toUpdate.VasarlasDatuma;
            old.Vasarlo = toUpdate.Vasarlo ?? old.Vasarlo;
            VegyesBolt.SaveChanges();
        }
    }
}
