using EVDFKG_HFT_2021221.Data;
using EVDFKG_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVDFKG_HFT_2021221.Repository
{
    class RamRepository : IRamRepository
    {
        ComponentDbContext context;
        public RamRepository(ComponentDbContext context)
        {
            this.context = context;
        }
        public void Create(RAM ram)
        {
            context.RAMs.Add(ram);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            RAM ram = context
                .RAMs
                .FirstOrDefault(x => x.RAMId == id);
            context.RAMs.Remove(ram);
            context.SaveChanges();
        }

        public IQueryable<RAM> ReadAll()
        {
            return context.RAMs;
        }

        public RAM ReadOne(int id)
        {
            return context
                .RAMs
                .FirstOrDefault(x => x.RAMId == id);
        }

        public void Update(RAM ram)
        {
            RAM old = ReadOne(ram.RAMId);
            old.Series = ram.Series;
            old.Brand = ram.Brand;
            old.RAMSize = ram.RAMSize;
            old.RAMSpeed = ram.RAMSpeed;
            old.RAMType = ram.RAMType;
            old.CASLatency = ram.CASLatency;
            old.PartNumber = ram.PartNumber;
        }
    }
}
