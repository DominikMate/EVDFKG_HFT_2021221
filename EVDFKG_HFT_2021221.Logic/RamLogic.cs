using EVDFKG_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVDFKG_HFT_2021221.Logic
{
    public class RamLogic : IRamLogic
    {
        IRamLogic repo;

        public RamLogic(IRamLogic repo)
        {
            this.repo = repo;
        }
        public void Create(RAM ram)
        {
            repo.Create(ram);
        }

        public void Delete(int id)
        {
            repo.Delete(id);
        }

        public IQueryable<RAM> ReadAll()
        {
            return repo.ReadAll();
        }

        public RAM ReadOne(int id)
        {
            return repo.ReadOne(id);
        }

        public void Update(RAM ram)
        {
            repo.Update(ram);
        }
    }
}
