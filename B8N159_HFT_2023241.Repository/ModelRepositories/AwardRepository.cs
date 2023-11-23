using B8N159_HFT_2023241.Models;
using System.Linq;


namespace B8N159_HFT_2023241.Repository
{
    public class AwardRepository : Repository<Award>, IRepository<Award>
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
                if(prop.GetAccessors().FirstOrDefault(t => t.IsVirtual) == null)
                {
                    prop.SetValue(old, prop.GetValue(item));
                }
            }
            ctx.SaveChanges();
        }
    }
}
