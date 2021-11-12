using EVDFKG_HFT_2021221.Data;
using EVDFKG_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVDFKG_HFT_2021221.Repository
{
    public class CpuRepository : ICpuRepository
    {
        ComponentDbContext context;

        public CpuRepository(ComponentDbContext context)
        {
            this.context = context;
        }

        public void Create(CPU cpu)
        {
            context.CPUs.Add(cpu);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            CPU cpu = context
                .CPUs
                .FirstOrDefault(x => x.CPUId == id);
            context.CPUs.Remove(cpu);
            context.SaveChanges();
        }

        public IQueryable<CPU> ReadAll()
        {
            return context.CPUs;
        }

        public CPU ReadOne(int id)
        {
            return context
                .CPUs
                .FirstOrDefault(x => x.CPUId == id);
        }

        public void Update(CPU cpu)
        {
            CPU old = ReadOne(cpu.CPUId);
            old.Series = cpu.Series;
            old.Brand = cpu.Brand;
            old.CPUSocket = cpu.CPUSocket;
            old.CPUCore = cpu.CPUCore;
            old.CPUThread = cpu.CPUThread;
            old.CPUSpeed = cpu.CPUSpeed;
            old.RAMType = cpu.RAMType;
        }
    }
}
