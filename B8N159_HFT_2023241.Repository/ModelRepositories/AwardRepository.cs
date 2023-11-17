using B8N159_HFT_2023241.Models;
using B8N159_HFT_2023241.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B8N159_HFT_2023241.Repository.ModelRepositories
{
    internal class AwardRepository : Repository<Award>, IRepository<Award>
    {
        public AwardRepository(WineryDbContext ctx) : base(ctx)
        {
        }

        public override Award Read(int id)
        {
            return ctx.Awards.FirstOrDefault(t => t.AwardId == id);
        }

        public override void Update(Award item)
        {
            var old = Read(item.AwardId);
            foreach (var prop in old.GetType().GetProperties())
            {
                prop.SetValue(item, prop.GetValue(item));
            }
            ctx.SaveChanges();
        }
    }
}
