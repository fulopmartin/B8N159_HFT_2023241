﻿using B8N159_HFT_2023241.Models;
using B8N159_HFT_2023241.Repository;
using Castle.Core.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B8N159_HFT_2023241.Logic
{
    public class WineryLogic : IWineryLogic
    {
        IRepository<Winery> repo;

        public WineryLogic(IRepository<Winery> repo)
        {
            this.repo = repo;
        }

        public void Create(Winery item)
        {
            this.repo.Create(item);
        }

        public void Delete(int id)
        {
            this.repo.Delete(id);
        }

        public Winery Read(int id)
        {
            return this.repo.Read(id);
        }

        public IEnumerable<Winery> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(Winery item)
        {
            this.repo.Update(item);
        }
        //non-cruds
        public IEnumerable<WinesWtihoutAward> WinesWhitoutAwardByWinery()
        {
            return (from x in repo.ReadAll()
                    select new WinesWtihoutAward()
                    {
                        Name = x.Name,                       
                        Wines = x.Wines.Where(a => a.Awards.Count() == 0)

                    });
                    
        }
        public IEnumerable<AvgByWinery> AveragePriceByWinery()
        {
            return (from x in repo.ReadAll()
                    select new AvgByWinery()
                    {
                        Name = x.Name,
                        Avg = x.Wines.Average(p => p.Price)
                    });
        }

        public double AverageWinePrice()
        {
            return repo.ReadAll().Select(a => a.Wines.Average(p => p.Price)).Average();
        }

        public Winery WineryWithMostExpensiveWine()
        {
            return (from x in repo.ReadAll()
                    orderby x.Wines.Max(p => p.Price) descending
                    select x).First();
        }
    }

    public class WinesWtihoutAward
    {
        public WinesWtihoutAward()
        {
        }
        public string Name { get; set; }
        public IEnumerable<Wine> Wines { get; set; }
    }

    public class AvgByWinery
    {
        public AvgByWinery()
        {
        }

        public string Name { get; set; }
        public double Avg { get; set; }
    }
}
