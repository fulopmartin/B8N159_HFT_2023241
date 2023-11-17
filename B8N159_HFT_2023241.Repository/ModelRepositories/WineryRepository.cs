using B8N159_HFT_2023241.Models;
using B8N159_HFT_2023241.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B8N159_HFT_2023241.Repository.ModelRepositories
{
    public class WineryRepository : Repository<Winery>, IRepository<Winery>
    {
        public WineryRepository(WineryDbContext ctx) : base(ctx)
        {
        }

        public override Winery Read(int id)
        {
            return ctx.Wineries.FirstOrDefault(t => t.WineryId == id);

        }

        public override void Update(Winery item)
        {
            var old = Read(item.WineryId);
            foreach (var prop in old.GetType().GetProperties())
            {
                prop.SetValue(item, prop.GetValue(item));
            }
            ctx.SaveChanges();
        }
    }
}
