using B8N159_HFT_2023241.Logic;
using B8N159_HFT_2023241.Models;
using B8N159_HFT_2023241.Repository;
using B8N159_HFT_2023241.Repository.ModelRepositories;
using System;

namespace B8N159_HFT_2023241.Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            WineryDbContext db = new WineryDbContext();

            WineryRepository wr = new WineryRepository(db);
            WineryLogic wl = new WineryLogic(wr);
            WineRepository winer = new WineRepository(db);
            WineLogic winel = new WineLogic(winer);
            var avgByWinery =  wl.AveragePriceByWinery();

            var avg = wl.AverageWinePrice();

            var winesWhitoutAward = wl.WinesWhitoutAwardByWinery();

            var winesWithNationalAward = winel.WinesWithNationalAward();

            
        
        }
    }
}
