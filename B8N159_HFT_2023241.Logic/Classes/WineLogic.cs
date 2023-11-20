﻿using B8N159_HFT_2023241.Logic.Interfaces;
using B8N159_HFT_2023241.Models;
using B8N159_HFT_2023241.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B8N159_HFT_2023241.Logic.Classes
{
    public class WineLogic : IWineLogic
    {
        IRepository<Wine> repo;

        public WineLogic(IRepository<Wine> repo)
        {
            this.repo = repo;
        }

        public void Create(Wine item)
        {
            this.repo.Create(item);
        }

        public void Delete(int id)
        {
            this.repo.Delete(id);
        }

        public Wine Read(int id)
        {
            return this.repo.Read(id);
        }

        public IQueryable<Wine> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(Wine item)
        {
            this.repo.Update(item);
        }
    }
}
