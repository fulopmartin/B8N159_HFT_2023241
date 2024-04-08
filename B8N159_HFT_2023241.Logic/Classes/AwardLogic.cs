using B8N159_HFT_2023241.Models;
using B8N159_HFT_2023241.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace B8N159_HFT_2023241.Logic
{
    public class AwardLogic : IAwardLogic
    {
        IRepository<Award> repo;
        IRepository<Wine> wineRepository;

        public AwardLogic(IRepository<Award> repo, IRepository<Wine> wineRepository)
        {
            this.repo = repo;
            this.wineRepository = wineRepository;
        }

        public void Create(Award item)
        {
            if (item.AwardName == null || item.AwardName == "" || item.AwardYear == 0 || item.WineId == 0 || item.WineId == null)
            {
                throw new ArgumentException("There is an empty field");
            }
            if(item.WineId < 1 || item.WineId > wineRepository.ReadAll().Count())
            {
                throw new ArgumentException("The wine does not exist!");
            }
            this.repo.Create(item);
        }

        public void Delete(int id)
        {
            var delitem = this.repo.Read(id);
            if (delitem == null)
            {
                throw new ArgumentException("Award does not exist!");
            }
            this.repo.Delete(id);
        }

        public Award Read(int id)
        {
            var award = this.repo.Read(id);
            if (award == null)
            {
                throw new ArgumentException("Award does not exist");
            }
            return this.repo.Read(id);
        }

        public IEnumerable<Award> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(Award item)
        {
            if (item.AwardName == null || item.AwardName == "" || item.AwardYear == 0 || item.WineId == 0 || item.WineId == null)
            {
                throw new ArgumentException("There is an empty field");
            }
            if (item.WineId < 1 || item.WineId > wineRepository.ReadAll().Count())
            {
                throw new ArgumentException("The wine does not exist!");
            }
            this.repo.Update(item);
        }
    }
}
