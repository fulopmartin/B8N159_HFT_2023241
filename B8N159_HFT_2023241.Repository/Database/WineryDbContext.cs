using System.Collections.Generic;
using B8N159_HFT_2023241.Models;
using Microsoft.EntityFrameworkCore;

namespace B8N159_HFT_2023241.Repository
{
    public class WineryDbContext : DbContext
    {
        public DbSet<Winery> Wineries { get; set; }
        public DbSet<Wine> Wines { get; set; }
        public DbSet<Award> Awards { get; set; }

        public WineryDbContext()
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseLazyLoadingProxies()
                    .UseInMemoryDatabase("WineryDb");
            }
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //connections
            modelBuilder.Entity<Wine>()
                .HasOne(w => w.Winery)
                .WithMany(t => t.Wines)
                .HasForeignKey(w => w.WineryId);

            modelBuilder.Entity<Award>()
                .HasOne(w => w.Wine)
                .WithMany(a => a.Awards)
                .HasForeignKey(w => w.WineId);


            //DbSeed
            var winery = new List<Winery>()
            {
                new Winery(1,"Bodri pincészet",7100),
                new Winery(2,"Bock pince",7773),
                new Winery(3,"Frittmann borászat",6230),
                new Winery(4,"Mészáros Pál borház és pince",7100),
                new Winery(5,"Takler borbirtok",7100)
            };

            modelBuilder.Entity<Winery>().HasData(winery);

            var wines = new List<Wine>()
            {
                //bodri winery
                new Wine(1,"Rozi",2023,WineType.Rozé,1900,1),
                new Wine(2,"Orsi",2022,WineType.Rozé,1900,1),
                new Wine(3,"Emma",2023,WineType.White,1900,1),
                new Wine(4,"Gurovica",2021,WineType.White,3300,1),
                new Wine(5,"Etalon",2020,WineType.Red,3600,1),
                new Wine(6,"Grand",2017,WineType.Red,25000,1),
                new Wine(7,"Gurovica",2016,WineType.Red,9000,1),
                new Wine(8,"No.1",2017,WineType.Red,40000,1),

                //bock winery
                new Wine(9,"Merlot Special Reserve",2015,WineType.Red,10450,2),
                new Wine(10,"Kékfrankos",2021,WineType.Red,2480,2),
                new Wine(11,"Cuvée",2016,WineType.Red,9050,2),
                new Wine(12,"Rajnai Rizling",2022,WineType.White,3190,2),
                new Wine(13,"Olaszrizling",2022,WineType.White,2100,2),
                new Wine(14,"Rosé Cuvée",2022,WineType.Rozé,2190,2),
                new Wine(15,"Primőr Rosé Cuvée",2023,WineType.Rozé,2190,2),                           
                new Wine(16,"Libra",2017,WineType.Red,22250,2),                           
               
                //frittmann winery
                new Wine(17,"Rosé Cuvée",2017,WineType.Rozé,1500,3),                        
                new Wine(18,"Néró Rosé",2017,WineType.Rozé,1400,3),                        
                new Wine(19,"Kadarka Fpv",2015,WineType.Red,1500,3),                        
                new Wine(20,"Portugieser",2017,WineType.Red,1190,3),                        
                new Wine(21,"Duett",2020,WineType.Red,2390,3),                      
                new Wine(22,"Olívia",2023,WineType.White,1690,3),                      
                new Wine(23,"Irsai Olivér",2023,WineType.White,1790,3),                        
                new Wine(24,"Cserszegi Fűszeres",2017,WineType.White,1700,3),                        
                
                //mészáros pál winery
                new Wine(25,"Kékfrankos Classic",2020,WineType.Red,1790,4),                        
                new Wine(26,"Grand Antiqua Merlot",2016,WineType.Red,18900,4),                        
                new Wine(27,"Chardonnay Classic",2022,WineType.White,1670,4),                        
                new Wine(28,"Fehér Kadarka",2022,WineType.White,1820,4),                        
                new Wine(29,"Grandiózus Cuvée",2020,WineType.Red,4520,4),                        
                new Wine(30,"Irsai Olivér",2022,WineType.White,1950,4),                        
                new Wine(31,"Rosé",2022,WineType.Rozé,1690,4),                        
                new Wine(32,"Kadarka",2019,WineType.Red,2390,4),  
                
                //takler winery
                new Wine(33,"Örökség Bikavér",2018,WineType.Red,4290,5),                        
                new Wine(34,"Trió Vörös",2019,WineType.Red,2450,5),                        
                new Wine(35,"Syrah",2020,WineType.Red,2950,5),                        
                new Wine(36,"Királyleányka",2022,WineType.White,2200,5),                        
                new Wine(37,"Trió Fehér",2022,WineType.White,1800,5),                        
                new Wine(38,"Pinot Noir Rosé",2022,WineType.Rozé,2000,5),                        
                new Wine(39,"Rozetta",2022,WineType.Rozé,1900,5),                        
                new Wine(40,"Regnum",2019,WineType.Red,8900,5),                        
                                
            };
            modelBuilder.Entity<Wine>().HasData(wines);

            var awards = new List<Award>()
            {
                //bodri winery
                new Award(1,2022,"Szekszárdi Borvidék Borverseny Fehér",4,true),

                new Award(2,2019,"Challange International Du Vin",7,false),
                new Award(3,2019,"Concours International De Vins",7,false),
                new Award(4,2019,"Országos Borverseny",7,true),
                new Award(5,2019,"Szekszárdi Borvidék Borverseny",7,true),
                new Award(6,2020,"Concours International De Vins Hungary",7,true),
                
                new Award(7,2021,"28th Grand International Wine Award",8,false),
                new Award(8,2021,"Concours International De Vins Hungary",8,true),
                new Award(9,2021,"23. Berliner Wein Trophy",8,false),                 
                new Award(10,2022,"Vinagora Hungary",8,true),  
                new Award(11,2020,"Vinagora Hungary",8,true),
                new Award(12,2020,"Szekszárdi Borvidék Borverseny Vörös",8,true),

                //bock winery
                new Award(13,2020,"Berliner Wein Trophy",9,false),
                new Award(14,2019,"Országos Syngenta Borverseny",9,true),
                new Award(15,2019,"Vinagora",9,true),

                new Award(16,2022,"Decanter World Wine Awards",11,false),

                new Award(17,2023,"Best of Riesling",12,false),

                new Award(18,2023,"Országos Borverseny",16,true),
                new Award(19,2021,"Concours Mondial Bruxelles",16,false),

                //frittmann winery
                new Award(20,2018,"Le Mondial du Rosé",17,false),
                new Award(21,2017,"XII. Magyarországi Újbor verseny",17,true),

                new Award(22,2018,"Külügyminisztérium Borválogatása",24,true),
                
                new Award(23,2017,"XIV. Országos rosé borverseny",18,true),
                new Award(24,2017,"XIV. Magyarországi Újbor verseny",18,true),

                new Award(25,2016,"XXI. Kadarka Nemzetközi Nagydíj",19,true),

                //mészáros winery
                new Award(26,2022,"Az Országház Bora Kadarka",32,true),

                //takler winery
                new Award(27,2022,"Az Országház Bora Bikavér",33,true),
                new Award(28,2023,"Országos Borverseny",33,true),
                new Award(29,2023,"Berliner Wein Trophy",33,true),

            };
            modelBuilder.Entity<Award>().HasData(awards);

            base.OnModelCreating(modelBuilder);
        }
    }
}
