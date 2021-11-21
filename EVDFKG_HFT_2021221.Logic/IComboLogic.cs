using EVDFKG_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVDFKG_HFT_2021221.Logic
{
    public interface IComboLogic
    {
        void Create(Combo combo);
        Combo ReadOne(int id);
        IQueryable<Combo> ReadAll();
        void Update(Combo combo);
        void Delete(int id);
    }
}
