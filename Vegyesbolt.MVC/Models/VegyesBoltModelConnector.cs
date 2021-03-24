// <copyright file="VegyesBoltModelConnector.cs" company="MSanyi">
// Copyright (c) MSanyi.All rights reserved.
// </copyright>

namespace Vegyesbolt.MVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using VegyesBolt.Logic;

    /// <summary>
    /// A class to manage the Logic of the application between controllers.
    /// </summary>
    public static class VegyesBoltModelConnector
    {
        /// <summary>
        /// Gets the worker.
        /// </summary>
        public static Worker Worker => new Worker();
    }
}
