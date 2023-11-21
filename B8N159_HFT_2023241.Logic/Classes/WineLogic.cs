using B8N159_HFT_2023241.Models;
using B8N159_HFT_2023241.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B8N159_HFT_2023241.Logic
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
