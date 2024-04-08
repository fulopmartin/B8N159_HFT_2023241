using B8N159_HFT_2023241.Models;
using B8N159_HFT_2023241.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace B8N159_HFT_2023241.Logic
{
    public class WineLogic : IWineLogic
    {
        IRepository<Wine> repo;
        IRepository<Winery> wineryRepository;

        public WineLogic(IRepository<Wine> repo, IRepository<Winery> wineryRepository)
        {
            this.repo = repo;
            this.wineryRepository = wineryRepository;
        }

        public void Create(Wine item)
        {
            if (item.Name == "" || item.Name == null || item.Year == 0 || item.Price == 0 || item.Price == null || item.WineryId == null || item.Year == null)
            {
                throw new ArgumentException("There is an empty field");
            }
            if (item.WineryId > wineryRepository.ReadAll().Count() || item.WineryId < 1)
            {
                throw new ArgumentException("The winery does not exist!");
            }

            this.repo.Create(item);
        }

        public void Delete(int id)
        {
            var delitem = this.repo.Read(id);
            if(delitem == null)
            {
                throw new ArgumentException("Wine does not exist!");
            }

            if(delitem.Awards.Count > 0)
            {
                throw new ArgumentException("There are awards attached to this wine");
            }

            this.repo.Delete(id);
        }

        public Wine Read(int id)
        {
            var wine = this.repo.Read(id);
            if (wine == null)
            {
                throw new ArgumentException("Wine does not exist");
            }
            return this.repo.Read(id);
        }

        public IEnumerable<Wine> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(Wine item)
        {
            if (item.Name == "" || item.Name == null || item.Year == 0 || item.Price == 0 || item.Price == null || item.WineryId == null || item.Year == null)
            {
                throw new ArgumentException("There is an empty field");
            }
            if (item.WineryId > wineryRepository.ReadAll().Count() || item.WineryId < 1)
            {
                throw new ArgumentException("The winery does not exist!");
            }
            this.repo.Update(item);
        }

        //non-cruds
        public IEnumerable<Wine> WinesWithNationalAward()
        {
            return repo.ReadAll().Select(t => t).Where(x => x.Awards.Any(d => d.IsDomestic == false));
        }

        public Wine WineWithMostDomesticAward()
        {
            return (from x in repo.ReadAll()
                    orderby x.Awards.Count(x => x.IsDomestic) descending
                    select x).First();
        }
    }
    
}
