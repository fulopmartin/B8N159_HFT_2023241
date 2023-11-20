﻿using B8N159_HFT_2023241.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B8N159_HFT_2023241.Logic.Interfaces
{
    public interface IWineLogic
    {
        void Create(Wine item);
        void Delete(int id);
        Wine Read(int id);
        IQueryable<Wine> ReadAll();
        void Update(Wine item);
    }
}