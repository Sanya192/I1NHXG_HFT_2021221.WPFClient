// <copyright file="HomeController.cs" company="MSanyi">
// Copyright (c) MSanyi.All rights reserved.
// </copyright>

namespace Vegyesbolt.MVC.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using Vegyesbolt.MVC.Models;

    /// <summary>
    /// The Home page controller for the application.
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// The index page.
        /// </summary>
        /// <returns>The view of the index.</returns>
        [HttpGet]
        public IActionResult Index()
        {
            return this.View();
        }

        /// <summary>
        /// If there is an error this page handles it.
        /// </summary>
        /// <returns>The view of the error.</returns>
        [HttpGet]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
