// <copyright file="TermekekRepository.cs" company="MSanyi">
// Copyright (c) MSanyi.All rights reserved.
// </copyright>

namespace VegyesBolt.Repository
{
    using System.Collections.Generic;
    using System.Linq;
    using VegyesBolt.Data;

    /// <summary>
    /// The repositroy for Termekek.
    /// </summary>
    public class TermekekRepository : ITermekekRepository
    {
        private static readonly VegyesBoltDatabaseEntities1 VegyesBolt = new VegyesBoltDatabaseEntities1();

        /// <inheritdoc/>
        public List<Termekek> Elements => VegyesBolt.Termekeks.ToList();

        /// <inheritdoc/>
        public void Create(Termekek create)
        {
            VegyesBolt.Termekeks.Add(create);
            VegyesBolt.SaveChanges();
        }

        /// <inheritdoc/>
        public void Delete(Termekek toDelete)
        {
            var cascade = VegyesBolt.Vasarlasoks.Where(p => p.TermekId == toDelete.Id);
            foreach (var item in cascade)
            {
                VegyesBolt.Vasarlasoks.Remove(item);
            }

            var delete = VegyesBolt.Termekeks.Where(p => p.Id == toDelete.Id).First();
            VegyesBolt.Termekeks.Remove(delete);
            VegyesBolt.SaveChanges();
        }

        /// <inheritdoc/>
        public List<Termekek> ListByOwner(Vasarlok owner)
        {
            return VegyesBolt.Termekeks.Where(p => p.Vasarlasoks.Any(x => x.VasarloId == owner.Id)).ToList();
        }

        /// <inheritdoc/>
        public Termekek MostOwnedProduct()
        {
            return VegyesBolt.Termekeks.OrderBy(p => p.Vasarlasoks.Count).First();
        }

        /// <inheritdoc/>
        public void Update(Termekek toUpdate)
        {
            var old = VegyesBolt.Termekeks.Find(toUpdate.Id);
            old.LeltarMennyiseg = toUpdate.LeltarMennyiseg == null ? old.LeltarMennyiseg : toUpdate.LeltarMennyiseg;
            old.TermekNeve = toUpdate.TermekNeve ?? old.TermekNeve;
            old.Vasarlasoks = toUpdate.Vasarlasoks ?? old.Vasarlasoks;
            VegyesBolt.SaveChanges();
        }
    }
}
