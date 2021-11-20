using EVDFKG_HFT_2021221.Data;
using EVDFKG_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVDFKG_HFT_2021221.Repository
{
    class ComboRepository : IComboRepository
    {
        ComponentDbContext context;

        public ComboRepository(ComponentDbContext context)
        {
            this.context = context;
        }
        public void Create(Combo combo)
        {
            context.Combos.Add(combo);
        }

        public void Delete(int id1, int id2, int id3)
        {
            Combo combo = context
                .Combos
                .FirstOrDefault(x => x.CPUId == id1 && x.MotherboardId == id2 && x.RAMId == id3);
            context.Combos.Remove(combo);
            context.SaveChanges();
        }


        public IQueryable<Combo> ReadAll()
        {
            return context.Combos;
        }

        public Combo ReadOne(int id)
        {
            return context
                .Combos
                .FirstOrDefault(x => x.Id == id);
        }

        public void Update(Combo combo)
        {
            Combo old = ReadOne(combo.Id);
            old.CPUId = combo.CPUId;
            old.MotherboardId = combo.MotherboardId;
            old.RAMId = combo.RAMId;
            context.SaveChanges();
        }
    }
}
