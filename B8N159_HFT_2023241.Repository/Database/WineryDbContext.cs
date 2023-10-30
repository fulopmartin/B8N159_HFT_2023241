using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using B8N159_HFT_2023241.Models;
using Microsoft.EntityFrameworkCore;

namespace B8N159_HFT_2023241.Repository
{
    internal class WineryDbContext : DbContext
    {
        public virtual DbSet<Winery> Wineries { get; set; }
        public virtual DbSet<Wine> Wines { get; set; }
        public virtual DbSet<Award> Awards { get; set; }
    }
}
