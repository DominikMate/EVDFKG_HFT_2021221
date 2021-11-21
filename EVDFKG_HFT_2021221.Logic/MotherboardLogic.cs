﻿using EVDFKG_HFT_2021221.Models;
using EVDFKG_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVDFKG_HFT_2021221.Logic
{
    public class MotherboardLogic : IMotherboardLogic
    {
        IMotherboardRepository repo;
        public MotherboardLogic(IMotherboardRepository repo)
        {
            this.repo = repo;
        }
        public void Create(Motherboard motherboard)
        {
            repo.Create(motherboard);
        }

        public void Delete(int id)
        {
            repo.Delete(id);
        }

        public IQueryable<Motherboard> ReadAll()
        {
            return repo.ReadAll();
        }

        public Motherboard ReadOne(int id)
        {
            return repo.ReadOne(id);
        }

        public void Update(Motherboard motherboard)
        {
            repo.Update(motherboard);
        }
        public IEnumerable<KeyValuePair<string, double>> MotherboardCPUCores()
        {
            return repo
                .ReadAll()
                .SelectMany(x => x.Combos)
                .Select(x => new KeyValuePair<string, double>(
                    x.Motherboard.Brand, x.CPU.CPUCore));
        }
    }
}
