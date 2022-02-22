// <copyright file="MegyeRepository.cs" company="MSanyi">
// Copyright (c) MSanyi.All rights reserved.
// </copyright>

namespace VegyesBolt.Repository
{
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using VegyesBolt.Data;

    /// <summary>
    /// The reposotory for megye.
    /// </summary>
    public class MegyeRepository : IMegyeRepository
    {
        private static readonly VegyesBoltDatabaseEntities1 VegyesBolt = new VegyesBoltDatabaseEntities1();

        /// <inheritdoc/>
        public IList<Megyek> Elements => VegyesBolt.Megyeks.ToList();

        /// <inheritdoc/>
        public void Create(Megyek create)
        {
            VegyesBolt.Megyeks.Add(create);
            VegyesBolt.SaveChanges();
        }

        /// <inheritdoc/>
        public void Delete(Megyek toDelete)
        {
            var cascade = VegyesBolt.Vasarloks.Where(p => p.Megye == toDelete.Id);
            foreach (var item in cascade)
            {
                item.Megye = null;
            }

            var delete = VegyesBolt.Megyeks.Where(p => p.Id == toDelete.Id).First();
            VegyesBolt.Megyeks.Remove(delete);
            VegyesBolt.SaveChanges();
        }

        /// <inheritdoc/>
        public void Update(Megyek toUpdate)
        {
            var old = VegyesBolt.Megyeks.First(p => p.Id == toUpdate.Id);

            // old.Id = toUpdate.Id == null ? old.Id : toUpdate.Id;
            old.Nepesseg = toUpdate?.Nepesseg == null ? old.Nepesseg : toUpdate.Nepesseg;
            old.Nev = toUpdate.Nev ?? old.Nev;
            old.Szekhely = toUpdate.Szekhely ?? old.Szekhely;
            old.TelepulesekSzama = toUpdate.TelepulesekSzama == null ? old.TelepulesekSzama : toUpdate.TelepulesekSzama;
            old.Terulet = toUpdate.Terulet == null ? old.Terulet : toUpdate.Terulet;
            old.Vasarloks = toUpdate.Vasarloks ?? old.Vasarloks;
            VegyesBolt.SaveChanges();
        }
    }
}
