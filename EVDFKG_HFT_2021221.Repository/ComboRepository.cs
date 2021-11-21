using EVDFKG_HFT_2021221.Data;
using EVDFKG_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVDFKG_HFT_2021221.Repository
{
    public class ComboRepository : IComboRepository
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

        public void Delete(int id)
        {
            Combo combo = context
                .Combos
                .FirstOrDefault(x => x.Id==id);
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
