using B8N159_HFT_2023241.Models;
using B8N159_HFT_2023241.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

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
            if(item.Name == null || item.Name == "" || item.Zipcode == 0)
            {
                throw new ArgumentException("Name or zipcode cannot be empty");
            }
            this.repo.Create(item);
        }

        public void Delete(int id)
        {
            var delitem = this.repo.Read(id);
            if(delitem == null)
            {
                throw new ArgumentException("Winery does not exist!");
            }

            if(delitem.Wines.Count > 0)
            {
                throw new ArgumentException("There are wines attached to this winery!");
            }

            this.repo.Delete(id);
        }

        public Winery Read(int id)
        {
            var winery = this.repo.Read(id);
            if(winery == null)
            {
                throw new ArgumentException("Winery does not exist");
            }
            return this.repo.Read(id);
        }

        public IEnumerable<Winery> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(Winery item)
        {
            if (item.Name == null || item.Name == "" || item.Zipcode == 0)
            {
                throw new ArgumentException("Name or zipcode cannot be empty");
            }
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
