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
        }

    }
}
