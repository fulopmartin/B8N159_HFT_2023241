using B8N159_HFT_2023241.Models;
using B8N159_HFT_2023241.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B8N159_HFT_2023241.Repository.ModelRepositories
{
    public class WineRepository : Repository<Wine>, IRepository<Wine>
    {
        public WineRepository(WineryDbContext ctx) : base(ctx)
        {
        }

        public override Wine Read(int id)
        {
            return ctx.Wines.FirstOrDefault(t => t.WineId == id);
        }

        public override void Update(Wine item)
        {
            var old = Read(item.WineId);
            foreach (var prop in old.GetType().GetProperties())
            {
                prop.SetValue(item, prop.GetValue(item));
            }
            ctx.SaveChanges();
        }
    }
}
