// <copyright file="MegyeController.cs" company="MSanyi">
// Copyright (c) MSanyi.All rights reserved.
// </copyright>

namespace Vegyesbolt.MVC.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Vegyesbolt.MVC.Models;
    using VegyesBolt.Data;
    using VegyesBolt.Logic;

    public class MegyeController : Controller
    {
        // GET: HomeController1
        private static Worker worker = VegyesBoltModelConnector.Worker;

        /// <summary>
        /// The index of the controller.
        /// </summary>
        /// <returns>An actionResult.</returns>
        public ActionResult Index()
        {
            return this.View(worker.GetMegyek());
        }

        // GET: HomeController1/Details/5
        public ActionResult Details(int id)
        {
            return this.View(worker.GetMegye(id));
        }

        // GET: HomeController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HomeController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Megyek megye)
        {
            try
            {
                worker.CreateMegye(megye);
                return this.RedirectToAction(nameof(this.Index));
            }
            catch
            {
                return this.View();
            }
        }

        // GET: HomeController1/Edit/5
        public ActionResult Edit(int id)
        {
            return View(worker.GetMegye(id));
        }

        // POST: HomeController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Megyek megye)
        {
            try
            {
                worker.UpdateMegye(megye);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HomeController1/Delete/5
        public ActionResult Delete(int id)
        {
            return View(worker.GetMegye(id));
        }

        // POST: HomeController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
