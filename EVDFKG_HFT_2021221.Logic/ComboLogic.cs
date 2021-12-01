using EVDFKG_HFT_2021221.Models;
using EVDFKG_HFT_2021221.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVDFKG_HFT_2021221.Logic
{
    public class ComboLogic : IComboLogic
    {
        IComboRepository repo;
        public ComboLogic(IComboRepository repo)
        {
            this.repo = repo;
        }
        public void Create(Combo combo)
        {
            if (combo.CPU == null || combo.Motherboard == null || combo.RAM==null)
            {
                throw new NullReferenceException();
            }
            repo.Create(combo);
        }

        public void Delete(int id)
        {
            repo.Delete(id);
        }

        public IQueryable<Combo> ReadAll()
        {
            return repo.ReadAll();
        }

        public Combo ReadOne(int id)
        {
            return repo.ReadOne(id);
        }

        public void Update(Combo combo)
        {
            repo.Update(combo);
        }
        public IEnumerable<KeyValuePair<string, double>> CpuRamSpeedAverage()
        {
            return repo
                .ReadAll()
                .Include("CPU")
                .Include("RAM")
                .AsEnumerable()
                .GroupBy(x => x.CPU.Brand)
                .Select(x => new KeyValuePair<string, double>(
                    x.Key.ToString(), x.Average(r => r.RAM.RAMSpeed))).ToList();
        }
        public IEnumerable<KeyValuePair<string, double>> MotherboardCpuCoreAverage()
        {
            return repo
                .ReadAll()
                .Include("Motherboard")
                .Include("CPU")
                .AsEnumerable()
                .GroupBy(x => x.Motherboard.Brand)
                .Select(x => new KeyValuePair<string, double>(
                    x.Key.ToString(), x.Average(r => r.CPU.CPUCore))).ToList();
        }

        public IEnumerable<KeyValuePair<string, double>> RamCpuSpeedAverage()
        {
            return repo
            .ReadAll()
            .Include("RAM")
            .Include("CPU")
            .AsEnumerable()
            .GroupBy(x => x.RAM.Brand)
            .Select(x => new KeyValuePair<string, double>(
             x.Key.ToString(), x.Average(r => r.CPU.CPUSpeed))).ToList();
        }

        public IEnumerable<KeyValuePair<string, double>> CpuRAMSlotAverage()
        {
            return repo
            .ReadAll()
            .Include("CPU")
            .Include("Motherboard")
            .AsEnumerable()
            .GroupBy(x => x.CPU.Brand)
            .Select(x => new KeyValuePair<string, double>(
             x.Key.ToString(), x.Average(r => r.Motherboard.RAMSlot))).ToList();
        }

        public IEnumerable<KeyValuePair<string, double>> RamCPUThreadAverage()
        {
            return repo
            .ReadAll()
            .Include("RAM")
            .Include("CPU")
            .AsEnumerable()
            .GroupBy(x => x.RAM.Brand)
            .Select(x => new KeyValuePair<string, double>(
            x.Key.ToString(), x.Average(r => r.CPU.CPUThread))).ToList();
        }
        public IEnumerable<KeyValuePair<string, double>> LastIds()
        {
            return repo.ReadAll()
                .Include("CPU")
                .AsEnumerable()
                .OrderByDescending(x=>x.Id)
                .Select(x => new KeyValuePair<string, double>(
            "CPUId: "+x.CPU.CPUId.ToString()+", MotherboardId: " 
            + x.Motherboard.MotherboardId.ToString()
            +", RAMId: " + x.RAM.RAMId.ToString(), 0));
        }
    }
}
