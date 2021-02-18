// <copyright file="Menu.cs" company="MSanyi">
// Copyright (c) MSanyi.All rights reserved.
// </copyright>

namespace VegyesBolt.Program
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using VegyesBolt.Data;
    using VegyesBolt.Logic;

    /// <summary>
    /// The class which handles the menu system.
    /// </summary>
    internal partial class Menu
    {
        private readonly string menuOptions;
        private readonly Logic logic;
        private int currentlySelectedMenu;

        /// <summary>
        /// Initializes a new instance of the <see cref="Menu"/> class.
        /// </summary>
        public Menu()
        {
            this.OptionsWithString = this.CreateOptionsWithString();
            this.currentlySelectedMenu = -1;
            this.menuOptions = string.Empty;
            this.logic = new Logic();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Menu"/> class.
        /// </summary>
        /// <param name="menuOptions">The settings which uses different text than the enum.</param>
        public Menu(string menuOptions)
        {
            this.menuOptions = menuOptions;
            this.currentlySelectedMenu = -1;
            this.OptionsWithString = this.CreateOptionsWithString();
            this.logic = new Logic();
        }

        /// <summary>
        /// Gets the options matched with string values.
        /// </summary>
        public Dictionary<int, string> OptionsWithString { get; }

        /// <summary>
        /// Gets the Options formatted.
        /// </summary>
        public string OptionsDescription
        {
            get
            {
                string output = default;
                int i = 0;
                foreach (var item in this.OptionsWithString)
                {
                    output += $"{item.Key}: {item.Value}{(i++ % 2 == 1 ? "\n" : "\t\t\t")}";
                }

                return output;
            }
        }

        /// <summary>
        /// Starts the menu.
        /// </summary>
        public void Start()
        {
            while (this.currentlySelectedMenu != 0)
            {
                Console.Clear();

                Console.WriteLine("Kérlek válassz menüpontot");
                Console.WriteLine(this.OptionsDescription);
                if (int.TryParse(Console.ReadLine(), out this.currentlySelectedMenu))
                {
                    Options currOpt = (Options)Enum.Parse(typeof(Options), value: this.currentlySelectedMenu.ToString());
                    switch (currOpt)
                    {
                        case Options.Exit:
                            Console.WriteLine("Szia");
                            break;
                        case Options.ListAll:
                            Console.WriteLine(this.logic.GetMegyek());
                            Console.WriteLine();
                            Console.WriteLine(this.logic.GetTermekek());
                            Console.WriteLine();
                            Console.WriteLine(this.logic.GetVasarlok());
                            Console.WriteLine();
                            Console.WriteLine(this.logic.GetVasarlasok());
                            break;
                        case Options.ListMegyek:
                            Console.WriteLine(this.logic.GetMegyek());
                            break;
                        case Options.ListTermekek:
                            Console.WriteLine(this.logic.GetTermekek());
                            break;
                        case Options.ListVasarlok:
                            Console.WriteLine(this.logic.GetVasarlok());
                            break;
                        case Options.ListVasarlasok:
                            Console.WriteLine(this.logic.GetVasarlasok());
                            break;
                        case Options.AddMegye:
                            if (this.logic.CreateMegye(this.AddData<Megyek>()))
                            {
                                Console.WriteLine("A művelet sikeres volt.");
                            }
                            else
                            {
                                Console.WriteLine("A művelet sikertelen volt, kérlek próbáld újra");
                            }

                            break;
                        case Options.AddTermek:
                            if (this.logic.CreateTermek(this.AddData<Termekek>()))
                            {
                                Console.WriteLine("A művelet sikeres volt.");
                            }
                            else
                            {
                                Console.WriteLine("A művelet sikertelen volt, kérlek próbáld újra");
                            }

                            break;
                        case Options.AddVasarlo:
                            if (this.logic.CreateVasarlo(this.AddData<Vasarlok>()))
                            {
                                Console.WriteLine("A művelet sikeres volt.");
                            }
                            else
                            {
                                Console.WriteLine("A művelet sikertelen volt, kérlek próbáld újra");
                            }

                            break;
                        case Options.AddVasarlas:
                            if (this.logic.CreateVasarlasok(this.AddData<Vasarlasok>()))
                            {
                                Console.WriteLine("A művelet sikeres volt.");
                            }
                            else
                            {
                                Console.WriteLine("A művelet sikertelen volt, kérlek próbáld újra");
                            }

                            break;
                        case Options.DeleteMegye:
                            {
                                if (this.logic.DeleteMegyek(this.JustID<Megyek>()))
                                {
                                    Console.WriteLine("A művelet sikeres volt.");
                                }
                                else
                                {
                                    Console.WriteLine("A művelet sikertelen volt, kérlek próbáld újra");
                                }
                            }

                            break;
                        case Options.DeleteTermek:
                            {
                                if (this.logic.DeleteTermek(this.JustID<Termekek>()))
                                {
                                    Console.WriteLine("A művelet sikeres volt.");
                                }
                                else
                                {
                                    Console.WriteLine("A művelet sikertelen volt, kérlek próbáld újra");
                                }
                            }

                            break;
                        case Options.DeleteVasarlo:
                            {
                                if (this.logic.DeleteVasarlo(this.JustID<Vasarlok>()))
                                {
                                    Console.WriteLine("A művelet sikeres volt.");
                                }
                                else
                                {
                                    Console.WriteLine("A művelet sikertelen volt, kérlek próbáld újra");
                                }
                            }

                            break;
                        case Options.DeleteVasarlasok:
                            {
                                Console.WriteLine("Mi a  VásárlóId-t szeretnéd törölni?");
                                int i;
                                while (!int.TryParse(Console.ReadLine(), out i))
                                {
                                    Console.WriteLine("Mi a  VásárlóId-t szeretnéd törölni?");
                                }

                                int j;
                                while (!int.TryParse(Console.ReadLine(), out j))
                                {
                                    Console.WriteLine("Mi a  Termek-t szeretnéd törölni?");
                                }

                                this.logic.DeleteVasarlasok(new Vasarlasok() { VasarloId = i, TermekId = j });
                            }

                            break;
                        case Options.UpdateMegye:
                            if (this.logic.UpdateMegye(this.UpdateData<Megyek>()))
                            {
                                Console.WriteLine("A művelet sikeres volt.");
                            }
                            else
                            {
                                Console.WriteLine("A művelet sikertelen volt, kérlek próbáld újra");
                            }

                            break;
                        case Options.UpdateTermek:
                            if (this.logic.UpdateTermek(this.UpdateData<Termekek>()))
                            {
                                Console.WriteLine("A művelet sikeres volt.");
                            }
                            else
                            {
                                Console.WriteLine("A művelet sikertelen volt, kérlek próbáld újra");
                            }

                            break;
                        case Options.UpdateVasarlo:
                            if (this.logic.UpdateVasarlo(this.UpdateData<Vasarlok>()))
                            {
                                Console.WriteLine("A művelet sikeres volt.");
                            }
                            else
                            {
                                Console.WriteLine("A művelet sikertelen volt, kérlek próbáld újra");
                            }

                            break;
                        case Options.UpdateVasarlas:
                            if (this.logic.UpdateVasarlo(this.UpdateData<Vasarlok>()))
                            {
                                Console.WriteLine("A művelet sikeres volt.");
                            }
                            else
                            {
                                Console.WriteLine("A művelet sikertelen volt, kérlek próbáld újra");
                            }

                            break;
                        case Options.ListByOwner:
                            Console.WriteLine(this.logic.ListbyOwner(this.JustID<Vasarlok>()));
                            break;
                        case Options.MostOwnedProduct:
                            Console.WriteLine(this.logic.MostOwnedProduct());
                            break;
                        case Options.EbbeAMegyebeLakik:
                            Console.WriteLine(this.logic.EbbeAMegyebeLakik(this.JustID<Megyek>()));
                            break;
                        case Options.JavaVegpont:
                            Console.WriteLine(this.JavaVegpont());
                            break;
                        default:
                            Console.WriteLine("Nincs is ilyen");
                            break;
                    }
                }
                else
                {
                   // Console.Clear();
                    this.currentlySelectedMenu = -1;
                    Console.WriteLine("Rossz adat");
                }

                Console.WriteLine("Nyomj egy gonbot a folytatáshoz.");
                Console.ReadLine();
            }
        }

        /// <summary>
        /// Creates a dictionary where option values matched with strings.
        /// </summary>
        /// <returns>The options matched with values.</returns>
        private Dictionary<int, string> CreateOptionsWithString()
        {
            var values = Enum.GetValues(typeof(Options)) as int[];
            var names = values.Select(p => Enum.GetName(typeof(Options), p)).ToArray();
            var tempStrings = this.menuOptions.Split('\n').Select(p => p.Split(';')).ToArray();
            var strings = new Dictionary<string, string>();
            foreach (var item in tempStrings)
            {
                strings.Add(item[0], item[1]);
            }

            var output = new Dictionary<int, string>();
            for (int i = 0; i < names.Length; i++)
            {
                output.Add(
                    values[i],
                    !strings.ContainsKey(names[i]) ? names[i] : strings[names[i]]);
            }

            return output;
        }

        private T AddData<T>()
        {
                var properties = typeof(T).GetProperties();
                T output = (T)Activator.CreateInstance(typeof(T));
                foreach (var item in properties.Where(p => !p.GetMethod.IsVirtual))
                {
                    if (item.PropertyType == typeof(double?) || item.PropertyType == typeof(double))
                    {
                        double result;
                        Console.WriteLine($"Kérlek írd be a {item.Name}-t:");
                        while (!double.TryParse(Console.ReadLine(), out result))
                        {
                            Console.WriteLine($"Kérlek írd be a {item.Name}-t:");
                        }

                        item.SetValue(output, result);
                    }
                    else if (item.PropertyType == typeof(int?) || item.PropertyType == typeof(int))
                    {
                        double result;
                        Console.WriteLine($"Kérlek írd be a {item.Name}-t:");

                        while (!double.TryParse(Console.ReadLine(), out result))
                        {
                            Console.WriteLine($"Kérlek írd be a {item.Name}-t:");
                        }

                        item.SetValue(output, result);
                    }
                    else if (item.PropertyType == typeof(DateTime))
                    {
                        Console.WriteLine($"Kérlek írd be a {item.Name}-t:");
                        Console.WriteLine($"Kérlek írd be a {item.Name}-t:");
                        while (!DateTime.TryParse(Console.ReadLine(), out DateTime result))
                            {
                                Console.WriteLine($"Kérlek írd be a {item.Name}-t:");
                            }
                    }
                    else
                    {
                        Console.WriteLine($"Kérlek írd be a {item.Name}-t:");
                        item.SetValue(output, Console.ReadLine());
                    }
                }

                return output;
                    }

        private T UpdateData<T>()
        {
            try
            {
                var properties = typeof(T).GetProperties();
                T output = (T)Activator.CreateInstance(typeof(T));
                foreach (var item in properties.Where(p => !p.GetMethod.IsVirtual))
                {
                    if (typeof(T) == typeof(double))
                    {
                        double result;
                        Console.WriteLine($"Kérlek írd be a {item.Name}-t:");
                        Console.WriteLine("Ha nem akarod hogy legyen értéke írj be 0-t.");
                        while (!double.TryParse(Console.ReadLine(), out result))
                        {
                            Console.WriteLine($"Kérlek írd be a {item.Name}-t:");
                        }

                        item.SetValue(output, result == 0 ? (double?)null : result);
                    }
                    else if (typeof(T) == typeof(int))
                    {
                        double result;
                        Console.WriteLine($"Kérlek írd be a {item.Name}-t:");
                        Console.WriteLine("Ha nem akarod hogy változzon értéke írj be 0-t.");

                        while (!double.TryParse(Console.ReadLine(), out result))
                        {
                            Console.WriteLine($"Kérlek írd be a {item.Name}-t:");
                        }

                        item.SetValue(output, result == 0 ? (double?)null : result);
                    }
                    else if (item.PropertyType == typeof(DateTime))
                    {
                        Console.WriteLine($"Kérlek írd be a {item.Name}-t:");
                        Console.WriteLine("Ha nem szeretnéd megváltoztatni nyomj entert:");
                        string temp = Console.ReadLine();
                        if (temp == string.Empty)
                        {
                            item.SetValue(output, null);
                        }
                        else
                        {
                            Console.WriteLine($"Kérlek írd be a {item.Name}-t:");
                            while (!DateTime.TryParse(Console.ReadLine(), out DateTime result))
                            {
                                Console.WriteLine($"Kérlek írd be a {item.Name}-t:");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Kérlek írd be a {item.Name}-t:");
                        Console.WriteLine("Ha nem akarod hogy változzon értéke nyomj entert");
                        item.SetValue(output, Console.ReadLine());
                    }
                }

                return output;
            }
            catch (Exception)
            {
                return default;
            }
        }

        private T JustID<T>()
        {
            Console.WriteLine("Kérlek írj be egy id-t!");
            double id;
            T output = (T)Activator.CreateInstance(typeof(T));
            while (!double.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Kérlek írj be egy id-t!");
            }

            typeof(T).GetProperty("Id").SetValue(output, id);
            return output;
        }

        private string JavaVegpont()
        {
            Console.WriteLine("Írd be a neved: ");
            string nev = Console.ReadLine();
            Console.WriteLine("Írd be a db számot:");
            int db;
            while (!int.TryParse(Console.ReadLine(), out db))
            {
                Console.WriteLine("Írd be a db számot:");
            }

            string response;
            using (StreamReader sr = new StreamReader(WebRequest.Create($"http://localhost:8080/JavaVegpont/?nev={nev}&db={db}").GetResponse().GetResponseStream()))
            {
                 response = sr.ReadToEnd();
            }

            if (response == string.Empty || response == "Hibás Paraméter.")
            {
                return "Hiba történt";
            }

            var temp = response.Split(';');
            var output = $"{temp[0]}\n";
            for (int i = 1; i < temp.Length; i++)
            {
                output += $"\t{temp[i]}\n";
            }

            return output.Substring(0, output.Length - 2);
        }
    }
}
