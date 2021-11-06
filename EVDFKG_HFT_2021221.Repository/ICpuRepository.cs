using EVDFKG_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVDFKG_HFT_2021221.Repository
{
    interface ICpuRepository
    {
        void Create(CPU cpu);
        CPU ReadOne(int id);
        IQueryable<CPU> ReadAll();
        void Update(CPU cpu);
        void Delete(int id);
    }
}
