﻿using B8N159_HFT_2023241.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B8N159_HFT_2023241.Logic
{
    public interface IAwardLogic
    {
        void Create(Award item);
        void Delete(int id);
        Award Read(int id);
        IEnumerable<Award> ReadAll();
        void Update(Award item);
    }
}
