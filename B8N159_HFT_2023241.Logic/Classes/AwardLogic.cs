using B8N159_HFT_2023241.Models;
using B8N159_HFT_2023241.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace B8N159_HFT_2023241.Logic
{
    public class AwardLogic : IAwardLogic
    {
        IRepository<Award> repo;

        public AwardLogic(IRepository<Award> repo)
        {
            this.repo = repo;
        }

        public void Create(Award item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("Item is empty");
            }
            this.repo.Create(item);
        }

        public void Delete(int id)
        {
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
            this.repo.Update(item);
        }
    }
}
