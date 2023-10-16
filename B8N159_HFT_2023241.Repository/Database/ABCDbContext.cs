using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace B8N159_HFT_2023241.Repository
{
    internal class ABCDbContext : DbContext
    {
        public DbSet<A> As { get; set; }
    }
}
