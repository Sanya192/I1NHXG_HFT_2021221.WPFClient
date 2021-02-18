// <copyright file="VasarlokRepository.cs" company="MSanyi">
// Copyright (c) MSanyi.All rights reserved.
// </copyright>

namespace VegyesBolt.Repository
{
    using System.Collections.Generic;
    using System.Linq;
    using VegyesBolt.Data;

    /// <summary>
    /// The reposotory for Vasarlok.
    /// </summary>
    public class VasarlokRepository : IVasarlokRepository
    {
        private static readonly VegyesBoltDatabaseEntities1 VegyesBolt = new VegyesBoltDatabaseEntities1();

        /// <inheritdoc/>
        public List<Vasarlok> Elements => VegyesBolt.Vasarloks.ToList();

        /// <inheritdoc/>
        public void Create(Vasarlok create)
        {
            VegyesBolt.Vasarloks.Add(create);
            VegyesBolt.SaveChanges();
        }

        /// <inheritdoc/>
        public void Delete(Vasarlok toDelete)
        {
            var cascade = VegyesBolt.Vasarlasoks.Where(p => p.VasarloId == toDelete.Id);
            foreach (var item in cascade)
            {
                VegyesBolt.Vasarlasoks.Remove(item);
            }

            var delete = VegyesBolt.Vasarloks.Where(p => p.Id == toDelete.Id).First();
            VegyesBolt.Vasarloks.Remove(delete);
            VegyesBolt.SaveChanges();
        }

        /// <inheritdoc/>
        public List<Vasarlok> EbbeAMegyebeKiLakik(Megyek megye)
        {
            var vasarlok = VegyesBolt.Vasarloks.Where(p => p.Megye == megye.Id).ToList();
            return vasarlok;
        }

        /// <inheritdoc/>
        public void Update(Vasarlok toUpdate)
        {
            var old = VegyesBolt.Vasarloks.Find(toUpdate.Id);
            old.Email = toUpdate.Email ?? old.Email;
            old.Megye = toUpdate.Megye ?? old.Megye;
            old.MegyeNavigation = toUpdate.MegyeNavigation ?? old.MegyeNavigation;
            old.Nev = toUpdate.Nev ?? old.Nev;
            old.RegDate =  toUpdate.RegDate;
            old.Vasarlasoks = toUpdate.Vasarlasoks ?? old.Vasarlasoks;
            VegyesBolt.SaveChanges();
        }
    }
}
