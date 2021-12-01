using EVDFKG_HFT_2021221.Data;
using EVDFKG_HFT_2021221.Logic;
using EVDFKG_HFT_2021221.Models;
using EVDFKG_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EVDFKG_HFT_2021221.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            RestService rest = new RestService("http://localhost:9861");
            bool a = true;
            while (a)
            {
                Console.WriteLine("1. Read one component");
                Console.WriteLine("2. Read all components");
                Console.WriteLine("3. Create a new component");
                Console.WriteLine("4. Update an existing component");
                Console.WriteLine("5. Delete an existing component");
                Console.WriteLine("6. Last components IDs");

                switch (Console.ReadLine())
                {
                    case "1":
                        bool b = true;
                        Console.Clear();
                        Console.WriteLine("1. Read one CPU");
                        Console.WriteLine("2. Read one Motherboard");
                        Console.WriteLine("3. Read one RAM");
                        Console.WriteLine("4. Read one Combolist");
                        switch (Console.ReadLine())
                        {

                            case "1":
                                Console.Clear();
                                break;
                            case "2":
                                Console.Clear();
                                break;
                            case "3":
                                Console.Clear();
                                break;
                            case "4":
                                Console.Clear();
                                break;
                        }
                        break;
                    case "2":
                        bool c = true;
                        Console.Clear();
                        Console.WriteLine("1. Read all CPU");
                        Console.WriteLine("2. Read all Motherboard");
                        Console.WriteLine("3. Read all RAM");
                        Console.WriteLine("4. Read all Combolist");
                        switch (Console.ReadLine())
                        {

                            case "1":
                                Console.Clear();
                                break;
                            case "2":
                                Console.Clear();
                                break;
                            case "3":
                                Console.Clear();
                                break;
                            case "4":
                                Console.Clear();
                                break;
                        }
                        break;
                    case "3":
                        bool d = true;
                        Console.Clear();
                        Console.WriteLine("1. Create a new CPU");
                        Console.WriteLine("2. Create a new Motherboard");
                        Console.WriteLine("3. Create a new RAM");
                        Console.WriteLine("4. Create a new Combolist");
                        switch (Console.ReadLine())
                        {

                            case "1":
                                Console.Clear();
                                break;
                            case "2":
                                Console.Clear();
                                break;
                            case "3":
                                Console.Clear();
                                break;
                            case "4":
                                Console.Clear();
                                break;
                        }
                        break;
                    case "4":
                        bool e = true;
                        Console.Clear();
                        Console.WriteLine("1. Update an existing CPU");
                        Console.WriteLine("2. Update an existing Motherboard");
                        Console.WriteLine("3. Update an existing RAM");
                        Console.WriteLine("4. Update an existing Combolist");
                        switch (Console.ReadLine())
                        {

                            case "1":
                                Console.Clear();
                                break;
                            case "2":
                                Console.Clear();
                                break;
                            case "3":
                                Console.Clear();
                                break;
                            case "4":
                                Console.Clear();
                                break;
                        }
                        break;
                    case "5":
                        bool f = true;
                        Console.Clear();
                        Console.WriteLine("1. Delete an existing CPU");
                        Console.WriteLine("2. Delete an existing Motherboard");
                        Console.WriteLine("3. Delete an existing RAM");
                        Console.WriteLine("4. Delete an existing combolist");
                        switch (Console.ReadLine())
                        {

                            case "1":
                                Console.Clear();
                                break;
                            case "2":
                                Console.Clear();
                                break;
                            case "3":
                                Console.Clear();
                                break;
                            case "4":
                                Console.Clear();
                                break;
                        }
                        break;
                    case "6":
                        Console.Clear();
                        break;
                    default:
                        break;
                }
                Console.ReadKey();
                Console.Clear();
            }
        }


    }
}
