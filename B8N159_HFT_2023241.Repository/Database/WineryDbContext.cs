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

        public DbSet<Winery> Wineries { get; set; }
        public DbSet<Wine> Wines { get; set; }
        public DbSet<Award> Awards { get; set; }
        public WineryDbContext()
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                builder
                    .UseLazyLoadingProxies()
                    .UseInMemoryDatabase("winery");
            }
        }
    }
}
