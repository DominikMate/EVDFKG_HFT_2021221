using EVDFKG_HFT_2021221.Models;
using EVDFKG_HFT_2021221.Repository;
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
            if (combo==null)
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
                .GroupBy(x => x.CPU.Brand)
                .Select(x => new KeyValuePair<string, double>(
                    x.Key.ToString(), x.Average(r => r.RAM.RAMSpeed)));
        }
        public IEnumerable<KeyValuePair<string, double>> MotherboardCpuCoreAverage()
        {
            return repo
                .ReadAll()
                .GroupBy(x => x.Motherboard.Brand)
                .Select(x => new KeyValuePair<string, double>(
                    x.Key.ToString(), x.Average(r => r.CPU.CPUCore)));
        }

        public IEnumerable<KeyValuePair<string, double>> RamCpuSpeedAverage()
        {
            return repo
            .ReadAll()
            .GroupBy(x => x.RAM.Brand)
            .Select(x => new KeyValuePair<string, double>(
             x.Key.ToString(), x.Average(r => r.CPU.CPUSpeed)));
        }

        public IEnumerable<KeyValuePair<string, double>> CpuRAMSlotAverage()
        {
            return repo
            .ReadAll()
            .GroupBy(x => x.CPU.Brand)
            .Select(x => new KeyValuePair<string, double>(
             x.Key.ToString(), x.Average(r => r.Motherboard.RAMSlot)));
        }

        public IEnumerable<KeyValuePair<string, double>> RamCPUThreadAverage()
        {
            return repo
            .ReadAll()
            .GroupBy(x => x.RAM.Brand)
            .Select(x => new KeyValuePair<string, double>(
            x.Key.ToString(), x.Average(r => r.CPU.CPUThread)));
        }
    }
}
