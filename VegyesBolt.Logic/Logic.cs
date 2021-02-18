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
        public string GetMegyek() => this.ListAll(this.MegyeRepository.Elements.ConvertAll<object>(p => p));

        /// <inheritdoc/>
        public string GetTermekek() => this.ListAll(this.TermekekRepository.Elements.ConvertAll<object>(p => p));

        /// <inheritdoc/>
        public string GetVasarlok() => this.ListAll(this.VasarlokRepository.Elements.ConvertAll<object>(p => p));

        /// <inheritdoc/>
        public string GetVasarlasok() => this.ListAll(this.VasarlasokRepository.Elements.ConvertAll<object>(p => p));

        /// <inheritdoc/>
        public string GetMegye(int id)
        {
            return this.ListOne(this.MegyeRepository.Elements[id]);
        }

        /// <inheritdoc/>
        public string GetTermek(int id)
        {
            return this.ListOne(this.TermekekRepository.Elements[id]);
        }

        /// <inheritdoc/>
        public string GetVasarlo(int id)
        {
            return this.ListOne(this.VasarlokRepository.Elements[id]);
        }

        /// <inheritdoc/>
        public string GetVasarlas(int id)
        {
            return this.ListOne(this.VasarlasokRepository.Elements[id]);
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
        public string EbbeAMegyebeLakik(Megyek megye)
        {
            try
            {
                return this.ListAll(this.VasarlokRepository.EbbeAMegyebeKiLakik(megye).ConvertAll<object>(p => p));
            }
            catch (Exception)
            {
                return "A művelet sikertelen volt, vagy ebbe a megyébe nem lakik senki.";
            }
        }

        /// <inheritdoc/>
        public string ListbyOwner(Vasarlok owner)
        {
            try
            {
                return this.ListAll(this.TermekekRepository.ListByOwner(owner).ConvertAll<object>(p => p));
            }
            catch (Exception)
            {
                return "A művelet sikertelen volt!";
            }
        }

        /// <inheritdoc/>
        public string MostOwnedProduct()
        {
            try
            {
                return this.ListOne(this.TermekekRepository.MostOwnedProduct());
            }
            catch (Exception)
            {
                return "A művelet sikertelen volt!";
            }
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

        /// <inheritdoc/>
        public string ListToString(List<object> list)
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

        /// <inheritdoc/>
        public string ListHeaders(List<object> list)
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

        /// <inheritdoc/>
        public string ListAll(List<object> list)
        {
            return this.ListHeaders(list) + "\n" + this.ListToString(list);
        }

        /// <inheritdoc/>
        public string ListOne(object item)
        {
            var list = new List<object> { item };
            return this.ListHeaders(list) + "\n" + this.ListToString(list);
        }
    }
}
