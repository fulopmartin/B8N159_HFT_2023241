using B8N159_HFT_2023241.Logic.Interfaces;
using B8N159_HFT_2023241.Models;
using B8N159_HFT_2023241.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B8N159_HFT_2023241.Logic.Classes
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

        public IQueryable<Winery> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(Winery item)
        {
            this.repo.Update(item);
        }
    }
}
