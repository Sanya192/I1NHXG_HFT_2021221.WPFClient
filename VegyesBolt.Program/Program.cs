// <copyright file="Program.cs" company="MSanyi">
// Copyright (c) MSanyi.All rights reserved.
// </copyright>

namespace VegyesBolt.Program
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using VegyesBolt.Data;
    using VegyesBolt.Logic;

    /// <summary>
    /// The main class, where the magic runs.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Where the program starts working.
        /// </summary>
        private static void Main()
        {
            var sajt = new Menu(File.ReadAllText("MenuOptions.conf"));
            sajt.Start();
            Console.ReadLine();
        }
    }
}
