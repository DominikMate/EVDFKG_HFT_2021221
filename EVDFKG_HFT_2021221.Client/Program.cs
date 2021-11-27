using EVDFKG_HFT_2021221.Data;
using EVDFKG_HFT_2021221.Logic;
using EVDFKG_HFT_2021221.Models;
using EVDFKG_HFT_2021221.Repository;
using System;

namespace EVDFKG_HFT_2021221.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            ComponentDbContext db = new ComponentDbContext();
            CpuLogic cpuLogic = new CpuLogic(
                new CpuRepository(db));

        }
    }
}
