using EVDFKG_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVDFKG_HFT_2021221.Logic
{
    public class ComboLogic : IComboLogic
    {
        IComboLogic repo;
        public ComboLogic(IComboLogic repo)
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
            throw new NotImplementedException();
        }

        public Combo ReadOne(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Combo combo)
        {
            throw new NotImplementedException();
        }
    }
}
