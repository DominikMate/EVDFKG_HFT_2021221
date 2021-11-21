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
        public IEnumerable<KeyValuePair<string, double>> AverageRamtypeSpeed()
        {
            return repo
                .ReadAll()
                .GroupBy(x => x.CPU.Brand)
                .Select(x => new KeyValuePair<string, double>(
                    x.Key.ToString(), x.Average(r => r.RAM.RAMSpeed)));
        }
    }
}
