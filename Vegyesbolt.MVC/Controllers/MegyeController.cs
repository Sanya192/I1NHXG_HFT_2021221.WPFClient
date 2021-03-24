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
    using VegyesBolt.Data;
    using VegyesBolt.Logic;
    using Vegyesbolt.MVC.Models;

    /// <summary>
    /// The controller for the megye table.
    /// </summary>
    public class MegyeController : Controller
    {
        // GET: HomeController1
        private static Worker worker = VegyesBoltModelConnector.Worker;

        /// <summary>
        /// The index of the controller.
        /// </summary>
        /// <returns>The index view.</returns>
        [HttpGet]
        public ActionResult Index()
        {
            return this.View(worker.GetMegyek());
        }

        /// <summary>
        /// The details of a specific megye.
        /// </summary>
        /// <param name="id">The id of the Megye.</param>
        /// <returns>The view of the details.</returns>
        // GET: HomeController1/Details/5
        [HttpGet]
        public ActionResult Details(int id)
        {
            return this.View(worker.GetMegye(id));
        }

        /// <summary>
        /// The standard view of a create panel.
        /// </summary>
        /// <returns>The view of megye creation.</returns>
        // GET: HomeController1/Create
        [HttpGet]
        public ActionResult Create()
        {
            return this.View();
        }

        /// <summary>
        /// The backend for the create form.
        /// </summary>
        /// <param name="megye">The created megye.</param>
        /// <returns>The index, unless error happened.</returns>
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

        /// <summary>
        /// The Edit view.
        /// </summary>
        /// <param name="id">The ID of edited Megye.</param>
        /// <returns>The view of edition.</returns>
        // GET: HomeController1/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {
            return this.View(worker.GetMegye(id));
        }

        /// <summary>
        /// The backend for the edit.
        /// </summary>
        /// <param name="megye">The updated megye.</param>
        /// <returns>The index, unless error happened.</returns>
        // POST: HomeController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Megyek megye)
        {
            try
            {
                worker.UpdateMegye(megye);
                return this.RedirectToAction(nameof(this.Index));
            }
            catch
            {
                return this.View();
            }
        }

        /// <summary>
        /// The frontend form for the deletion.
        /// </summary>
        /// <param name="id">The id of the megye.</param>
        /// <returns>The view of the delete.</returns>
        // GET: HomeController1/Delete/5
        [HttpGet]

        public ActionResult Delete(int id)
        {
            return this.View(worker.GetMegye(id));
        }

        /// <summary>
        /// The backend for the deletion.
        /// </summary>
        /// <param name="collection">The collection of megye.</param>
        /// <returns>The index.</returns>
        // POST: HomeController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Megyek collection)
        {
            try
            {
                worker.DeleteMegyek(collection);
                return this.RedirectToAction(nameof(this.Index));
            }
            catch
            {
                return this.View();
            }
        }
    }
}
