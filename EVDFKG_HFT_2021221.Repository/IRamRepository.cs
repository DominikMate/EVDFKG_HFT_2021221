using EVDFKG_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVDFKG_HFT_2021221.Repository
{
    public interface IRamRepository
    {
        void Create(RAM ram);
        RAM ReadOne(int id);
        IQueryable<RAM> ReadAll();
        void Update(RAM ram);
        void Delete(int id);
    }
}
