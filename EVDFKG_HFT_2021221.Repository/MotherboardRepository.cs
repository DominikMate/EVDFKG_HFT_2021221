using EVDFKG_HFT_2021221.Data;
using EVDFKG_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVDFKG_HFT_2021221.Repository
{
    class MotherboardRepository : IMotherboardRepository
    {
        ComponentDbContext context;

        public MotherboardRepository(ComponentDbContext context)
        {
            this.context = context;
        }
        public void Create(Motherboard motherboard)
        {
            context.Motherboards.Add(motherboard);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            Motherboard motherboard = context
                .Motherboards
                .FirstOrDefault(x => x.MotherboardId == id);

            context.Motherboards.Remove(motherboard);
            context.SaveChanges();
        }

        public IQueryable<Motherboard> ReadAll()
        {
            return context.Motherboards;
        }

        public Motherboard ReadOne(int id)
        {
            return context
                .Motherboards
                .FirstOrDefault(x => x.MotherboardId == id);
        }

        public void Update(Motherboard motherboard)
        {
            Motherboard old = ReadOne(motherboard.MotherboardId);
            old.Series = motherboard.Series;
            old.Brand = motherboard.Brand;
            old.CompatibleProcessors = motherboard.CompatibleProcessors;
            old.CPUSocket = motherboard.CPUSocket;
            old.RAMSlot = motherboard.RAMSlot;
            old.RAMType = motherboard.RAMType;
            old.MAXRAMSpeed = motherboard.MAXRAMSpeed;
            old.GPUInterface = motherboard.GPUInterface;
        }
    }
}
