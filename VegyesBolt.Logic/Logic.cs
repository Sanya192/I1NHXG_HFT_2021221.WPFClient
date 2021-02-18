// <copyright file="Logic.cs" company="MSanyi">
// Copyright (c) MSanyi.All rights reserved.
// </copyright>

namespace VegyesBolt.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Threading.Tasks;
    using VegyesBolt.Data;
    using VegyesBolt.Repository;

    /// <summary>
    /// The Logic repository.
    /// </summary>
    public class Logic : ILogic
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Logic"/> class.
        /// </summary>
        public Logic()
        {
            this.MegyeRepository = new MegyeRepository();
            this.TermekekRepository = new TermekekRepository();
            this.VasarlokRepository = new VasarlokRepository();
            this.VasarlasokRepository = new VasarlasokRepository();
        }

        /// <summary>
        /// Sets the Repository used only for dependency Injection.
        /// </summary>
        public IMegyeRepository MegyeRepository { private get; set; }

        /// <summary>
        /// Sets the Repository used only for dependency Injection.
        /// </summary>
        public ITermekekRepository TermekekRepository { private get; set; }

        /// <summary>
        /// Sets the Repository used only for dependency Injection.
        /// </summary>
        public IVasarlasokRepository VasarlasokRepository { private get; set; }

        /// <summary>
        /// Sets the Repository used only for dependency Injection.
        /// </summary>
        public IVasarlokRepository VasarlokRepository { private get; set; }

        /// <inheritdoc/>
        public List<Megyek> GetMegyek() => this.MegyeRepository.Elements;

        /// <inheritdoc/>
        public List<Termekek> GetTermekek() => this.TermekekRepository.Elements;

        /// <inheritdoc/>
        public List<Vasarlok> GetVasarlok() => this.VasarlokRepository.Elements;

        /// <inheritdoc/>
        public List<Vasarlasok> GetVasarlasok() => this.VasarlasokRepository.Elements;

        /// <inheritdoc/>
        public Megyek GetMegye(int id)
        {
            return this.MegyeRepository.Elements[id];
        }

        /// <inheritdoc/>
        public Termekek GetTermek(int id)
        {
            return this.TermekekRepository.Elements[id];
        }

        /// <inheritdoc/>
        public Vasarlok GetVasarlo(int id)
        {
            return this.VasarlokRepository.Elements[id];
        }

        /// <inheritdoc/>
        public Vasarlasok GetVasarlas(int id)
        {
            return this.VasarlasokRepository.Elements[id];
        }

        /// <inheritdoc/>
        public bool CreateMegye(Megyek create)
        {
            try
            {
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
                this.VasarlasokRepository.Create(create);
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
