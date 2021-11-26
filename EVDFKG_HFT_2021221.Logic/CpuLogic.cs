using EVDFKG_HFT_2021221.Models;
using EVDFKG_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVDFKG_HFT_2021221.Logic
{
    public class CpuLogic : ICpuLogic
    {
        ICpuRepository repo;

        public CpuLogic(ICpuRepository repo)
        {
            this.repo = repo;
        }
        public void Create(CPU cpu)
        {
            if (cpu.Brand==null || cpu.CPUCore==0)
            {
                throw new NullReferenceException();
            }
            repo.Create(cpu);
        }

        public void Delete(int id)
        {
            repo.Delete(id);
        }

        public IQueryable<CPU> ReadAll()
        {
            return repo.ReadAll();
        }

        public CPU ReadOne(int id)
        {
            return repo.ReadOne(id);
        }

        public void Update(CPU cpu)
        {
            repo.Update(cpu);
        }

    }
}
