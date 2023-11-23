using B8N159_HFT_2023241.Models;
using System.Linq;


namespace B8N159_HFT_2023241.Repository
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
                if (prop.GetAccessors().FirstOrDefault(t => t.IsVirtual) == null)
                {
                    prop.SetValue(old, prop.GetValue(item));
                }
            }
            ctx.SaveChanges();
        }
    }
}
