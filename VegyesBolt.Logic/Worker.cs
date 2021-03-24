// <copyright file="Worker.cs" company="MSanyi">
// Copyright (c) MSanyi.All rights reserved.
// </copyright>

namespace VegyesBolt.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using VegyesBolt.Data;
    using VegyesBolt.Repository;

    /// <summary>
    /// The Logic repository.
    /// </summary>
    public class Worker : ILogic
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Worker"/> class.
        /// </summary>
        public Worker()
        {
            this.MegyeRepository = new MegyeRepository();
            this.TermekekRepository = new TermekekRepository();
            this.VasarlokRepository = new VasarlokRepository();
            this.VasarlasokRepository = new VasarlasokRepository();
        }

        private IMegyeRepository MegyeRepository { get; set; }

        private ITermekekRepository TermekekRepository { get; set; }

        private IVasarlasokRepository VasarlasokRepository { get; set; }

        private IVasarlokRepository VasarlokRepository { get; set; }

        /// <inheritdoc/>
        public List<Megyek> GetMegyek() => this.MegyeRepository.Elements as List<Megyek>;

        /// <inheritdoc/>
        public List<Termekek> GetTermekek() => this.TermekekRepository.Elements as List<Termekek>;

        /// <inheritdoc/>
        public List<Vasarlok> GetVasarlok() => this.VasarlokRepository.Elements as List<Vasarlok>;

        /// <inheritdoc/>
        public List<Vasarlasok> GetVasarlasok() => this.VasarlasokRepository.Elements as List<Vasarlasok>;

        /// <inheritdoc/>
        public Megyek GetMegye(int id)
        {
            return this.MegyeRepository.Elements[id - 1];
        }

        /// <inheritdoc/>
        public Termekek GetTermek(int id)
        {
            return this.TermekekRepository.Elements[id - 1];
        }

        /// <inheritdoc/>
        public Vasarlok GetVasarlo(int id)
        {
            return this.VasarlokRepository.Elements[id - 1];
        }

        /// <inheritdoc/>
        public Vasarlasok GetVasarlas(int id)
        {
            return this.VasarlasokRepository.Elements[id - 1];
        }

        /// <inheritdoc/>
        public bool CreateMegye(Megyek create)
        {
            try
            {
                if (create != null)
                {
                    create.Id = this.GetMegyek().OrderBy(p => p.Id).Last().Id + 1;
                }

                this.MegyeRepository.Create(create);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        /// <inheritdoc/>
        public bool CreateTermek(Termekek create)
        {
            try
            {
                if (create != null)
                {
                    create.Id = this.GetTermekek().OrderBy(p => p.Id).Last().Id + 1;
                }

                this.TermekekRepository.Create(create);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        /// <inheritdoc/>
        public bool CreateVasarlasok(Vasarlasok create)
        {
            try
            {
                if (create != null)
                {
                    this.VasarlasokRepository.Create(create);
                }
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        /// <inheritdoc/>
        public bool CreateVasarlo(Vasarlok create)
        {
            try
            {
                if (create != null)
                {
                    create.Id = this.GetVasarlok().OrderBy(p => p.Id).Last().Id + 1;
                }

                this.VasarlokRepository.Create(create);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        /// <inheritdoc/>
        public bool DeleteMegyek(Megyek delete)
        {
            try
            {
                this.MegyeRepository.Delete(delete);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        /// <inheritdoc/>
        public bool DeleteTermek(Termekek delete)
        {
            try
            {
                this.TermekekRepository.Delete(delete);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        /// <inheritdoc/>
        public bool DeleteVasarlasok(Vasarlasok delete)
        {
            try
            {
                this.VasarlasokRepository.Delete(delete);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        /// <inheritdoc/>
        public bool DeleteVasarlo(Vasarlok delete)
        {
            try
            {
                this.VasarlokRepository.Delete(delete);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        /// <inheritdoc/>
        public List<Vasarlok> EbbeAMegyebeLakik(Megyek megye)
        {
            return this.VasarlokRepository.Elements.Where(p => p.Megye == megye.Id).ToList();
        }

        /// <inheritdoc/>
        public List<Termekek> ListbyOwner(Vasarlok owner)
        {
            return this.TermekekRepository.Elements.Where(p => p.Vasarlasoks.Any(x => x.VasarloId == owner.Id)).ToList();
        }

        /// <inheritdoc/>
        public Termekek MostOwnedProduct()
        {
            return this.TermekekRepository.Elements.OrderBy(p => p.Vasarlasoks.Count).First();
        }

        /// <inheritdoc/>
        public bool UpdateMegye(Megyek create)
        {
            try
            {
                this.MegyeRepository.Update(create);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        /// <inheritdoc/>
        public bool UpdateTermek(Termekek update)
        {
            try
            {
                this.TermekekRepository.Update(update);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        /// <inheritdoc/>
        public bool UpdateVasarlasok(Vasarlasok update)
        {
            try
            {
                this.VasarlasokRepository.Update(update);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        /// <inheritdoc/>
        public bool UpdateVasarlo(Vasarlok update)
        {
            try
            {
                this.VasarlokRepository.Update(update);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }
    }
}
