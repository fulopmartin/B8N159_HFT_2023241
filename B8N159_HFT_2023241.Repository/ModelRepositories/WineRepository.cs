using B8N159_HFT_2023241.Models;
using System.Linq;


namespace B8N159_HFT_2023241.Repository
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
                if (prop.GetAccessors().FirstOrDefault(t => t.IsVirtual) == null)
                {
                    prop.SetValue(old, prop.GetValue(item));
                }
            }
            ctx.SaveChanges();
        }
    }
}
