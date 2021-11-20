using EVDFKG_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVDFKG_HFT_2021221.Repository
{
    interface IComboRepository
    {
        void Create(Combo combo);
        IQueryable<Combo> ReadAll();
        void Update(Combo combo);
        void Delete(int id1, int id2, int id3);
    }
}
