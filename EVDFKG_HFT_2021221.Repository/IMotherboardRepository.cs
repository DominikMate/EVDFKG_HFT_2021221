using EVDFKG_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVDFKG_HFT_2021221.Repository
{
    interface IMotherboardRepository
    {
        void Create(Motherboard motherboard);
        Motherboard ReadOne(int id);
        IQueryable<Motherboard> ReadAll();
        void Update(Motherboard motherboard);
        void Delete(int id);
    }
}
