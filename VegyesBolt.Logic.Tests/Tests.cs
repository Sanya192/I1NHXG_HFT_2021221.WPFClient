// <copyright file="Tests.cs" company="MSanyi">
// Copyright (c) MSanyi.All rights reserved.
// </copyright>

namespace VegyesBolt.Logic.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Moq;
    using NUnit;
    using NUnit.Framework;
    using VegyesBolt.Data;
    using VegyesBolt.Repository;

    /// <summary>
    /// The class which contains the Tests.
    /// </summary>
    [TestFixture]
    internal class Tests
    {
        private static readonly object[] VasarloLista = new object[]
        {
            new List<Vasarlok>
            {
            new Vasarlok { Email = "sddsa@sad.com", Id = 1, Megye = 5, Nev = "Sajt", RegDate = DateTime.Now },
            },
        };

        private static readonly object[] Megye = new object[]
        {
            new Megyek { Id = 1, Nev = "Heves", Nepesseg = 5, Szekhely = "Eger", TelepulesekSzama = 5, Terulet = 6 },
        };

        private static readonly object[] Termek = new object[]
        {
            new Termekek { Id = 1, Ara = 100, AfasAra = 127, LeltarMennyiseg = 5, TermekNeve = "Sajt" },
        };

        private static readonly object[] TermekLista = new object[]
        {
            new List<Termekek>()
            {
            new Termekek { Id = 1, Ara = 100, AfasAra = 127, LeltarMennyiseg = 5, TermekNeve = "Sajt" },
            },
        };

        private static readonly object Vasarlo = new object[]
        {
            new Vasarlok { Email = "sddsa@sad.com", Id = 1, Megye = 5, Nev = "Sajt", RegDate = DateTime.Now },
        };

        /// <summary>
        /// Tests if the getVasarlok is run.
        /// </summary>
        /// <param name="testData">The testData.</param>
        [Test]
        [TestCaseSource("VasarloLista")]
        public void SelectVasarlok(List<Vasarlok> testData)
        {
            var repo = new Mock<IVasarlokRepository>();
            repo.SetupGet(p => p.Elements).Returns(testData);
            var testelt = new Logic
            {
                VasarlokRepository = repo.Object,
            };
            var result = testelt.GetVasarlok();
            repo.Verify(p => p.Elements, Times.Once);
        }

        /// <summary>
        /// Tests if the getVasarlo is run.
        /// </summary>
        /// <param name="testData">The testData.</param>
        [Test]
        [TestCaseSource("VasarloLista")]
        public void SelectVasarlo(List<Vasarlok> testData)
        {
            var repo = new Mock<IVasarlokRepository>();
            repo.SetupGet(p => p.Elements).Returns(testData);
            var testelt = new Logic
            {
                VasarlokRepository = repo.Object,
            };
            var result = testelt.GetVasarlo(0);
            repo.Verify(p => p.Elements, Times.Once);
        }

        /// <summary>
        /// Tests if the update from repo is run and in optimal case it is returning true.
        /// </summary>
        [Test]
        public void UpdateVasarlo()
        {
            var repo = new Mock<IVasarlokRepository>();
            var testelt = new Logic();
            var customer = new Vasarlok();
            repo.Setup(p => p.Update(customer));
            testelt.VasarlokRepository = repo.Object;
            Assert.That(() => testelt.UpdateVasarlo(customer), Is.True);
            repo.Verify(p => p.Update(customer), Times.Once);
        }

        /// <summary>
        /// Tests if the delete from repo is run and in optimal case it is returning true.
        /// </summary>
        [Test]
        public void DeleteVasarlo()
        {
            var repo = new Mock<IVasarlokRepository>();
            var testelt = new Logic();
            var customer = new Vasarlok();
            repo.Setup(p => p.Delete(customer));
            testelt.VasarlokRepository = repo.Object;
            Assert.That(() => testelt.DeleteVasarlo(customer), Is.True);
            repo.Verify(p => p.Delete(customer), Times.Once);
        }

        /// <summary>
        /// Tests if the create from repo is run and in optimal case it is returning true.
        /// </summary>
        [Test]
        public void AddVasarlo()
        {
            var repo = new Mock<IVasarlokRepository>();
            var testelt = new Logic();
            var customer = new Vasarlok();
            repo.Setup(p => p.Create(customer));
            testelt.VasarlokRepository = repo.Object;
            Assert.That(() => testelt.CreateVasarlo(customer), Is.True);
            repo.Verify(p => p.Create(customer), Times.Once);
        }
    }
}
