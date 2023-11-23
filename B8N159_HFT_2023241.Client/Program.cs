using B8N159_HFT_2023241.Models;
using ConsoleTables;
using ConsoleTools;
using System;
using System.Collections.Generic;
using System.Linq;

namespace B8N159_HFT_2023241.Client
{
    internal class Program
    {
        static RestService rest;
        private static void Update(string entity)
        {
            if (entity == "Award")
            {
                Console.Write("Enter award's id to update: ");
                int awardId = int.Parse(Console.ReadLine());
                Award newAward = rest.Get<Award>(awardId, "award");           
                
                Console.Write("Do you want to change award name? (Y/N)");
                string decision = Console.ReadLine();

                if(decision == "Y")
                {
                    Console.Write($"New name [old: {newAward.AwardName}]: ");
                    string newName = Console.ReadLine();
                    newAward.AwardName = newName;
                }
                Console.Write("Do you want to change award year? (Y/N) ");
                decision = Console.ReadLine();
                if(decision == "Y")
                {
                    Console.Write($"New year [old: {newAward.AwardYear}]: ");
                    int newYear = int.Parse(Console.ReadLine());
                    newAward.AwardYear = newYear;
                }
                Console.Write("Do you want to change award isDomestic? (Y/N) ");
                decision = Console.ReadLine();
                if (decision == "Y")
                {
                    Console.Write($"New isDomestic [old: {newAward.IsDomestic}] (T/F): ");
                    string newIsDomestic = Console.ReadLine();
                    bool newIsDomesticb = false;
                    if(newIsDomestic == "T")
                    {
                        newIsDomesticb = true;
                    }                    
                    newAward.IsDomestic = newIsDomesticb;
                }
                Console.Write("Do you want to change award wineId? (Y/N) ");
                decision = Console.ReadLine();
                if (decision == "Y")
                {
                    Console.Write($"New wineId [old: {newAward.WineId}]: ");
                    int newWineId = int.Parse(Console.ReadLine());
                    newAward.WineId = newWineId;
                }

                rest.Put(newAward, "award");                
            }
            if(entity == "Wine")
            {
                Console.Write("Enter wine's id to update: ");
                int wineId = int.Parse(Console.ReadLine());
                Wine newWine = rest.Get<Wine>(wineId, "wine");

                Console.Write("Do you want to change wine name? (Y/N) ");
                string decision = Console.ReadLine();
                if (decision == "Y")
                {
                    Console.Write($"New name [old: {newWine.Name}]: ");
                    string newName = Console.ReadLine();
                    newWine.Name = newName;
                }
                Console.Write("Do you want to change wine year? (Y/N) ");
                decision = Console.ReadLine();
                if (decision == "Y")
                {
                    Console.Write($"New year [old: {newWine.Year}]: ");
                    int newYear = int.Parse(Console.ReadLine());
                    newWine.Year = newYear;
                }
                Console.Write("Do you want to change wine type? (Y/N) ");
                decision = Console.ReadLine();
                if (decision == "Y")
                {
                    Console.Write($"New type [old: {newWine.Type}] (White/Rozé/Red): ");
                    string newType = Console.ReadLine();
                    WineType newWineType = WineType.Vörös;
                    if(newType == "White")
                    {
                        newWineType = WineType.Fehér;
                    }
                    else if(newType == "Rozé")
                    {
                        newWineType = WineType.Rozé;
                    }
                    newWine.Type = newWineType;
                }
                Console.Write("Do you want to change wine price? (Y/N) ");
                decision = Console.ReadLine();
                if (decision == "Y")
                {
                    Console.Write($"New price [old: {newWine.Price}]: ");
                    int newPrice = int.Parse(Console.ReadLine());
                    newWine.Price = newPrice;
                    if(newPrice < 2000)
                    {
                        newWine.IsCheap = true;
                    }
                    else
                    {
                        newWine.IsCheap = false;
                    }
                }
                Console.Write("Do you want to change wine wineryId? (Y/N) ");
                decision = Console.ReadLine();
                if (decision == "Y")
                {
                    Console.Write($"New wineId [old: {newWine.WineryId}]: ");
                    int newWineId = int.Parse(Console.ReadLine());
                    newWine.WineId = newWineId;
                }
                rest.Put(newWine, "wine");

            }
            if(entity == "Winery")
            {
                Console.Write("Enter winery's id to update: ");
                int wineryId = int.Parse(Console.ReadLine());
                Winery newWinery = rest.Get<Winery>(wineryId, "winery");

                Console.Write("Do you want to change winery name? (Y/N) ");
                string decision = Console.ReadLine();
                if (decision == "Y")
                {
                    Console.Write($"New name [old: {newWinery.Name}]: ");
                    string newName = Console.ReadLine();
                    newWinery.Name = newName;
                }
                Console.Write("Do you want to change winery zipcode? (Y/N) ");
                decision = Console.ReadLine();
                if (decision == "Y")
                {
                    Console.Write($"New year [old: {newWinery.Zipcode}]: ");
                    int newZipCode = int.Parse(Console.ReadLine());
                    newWinery.Zipcode = newZipCode;
                }
                rest.Put(newWinery, "winery");
            }
        }
        private static void Delete(string entity)
        {
            if (entity == "Award")
            {
                Console.WriteLine("Enter award's id to delete: ");
                int awardId = int.Parse(Console.ReadLine());
                rest.Delete(awardId,"award");
            }
            if (entity == "Wine")
            {
                Console.WriteLine("Enter wine's id to delete: ");
                int wineId = int.Parse(Console.ReadLine());
                rest.Delete(wineId, "wine");
            }
            if (entity == "Winery")
            {
                Console.WriteLine("Enter winery's id to delete: ");
                int wineryId = int.Parse(Console.ReadLine());
                rest.Delete(wineryId, "winery");
            }
        }
        private static void Create(string entity)
        {
            if (entity == "Award")
            {
                Console.Write("Enter award name: ");
                string awardName = Console.ReadLine();
                Console.Write("Enter award year: ");
                int year = int.Parse(Console.ReadLine());
                Console.Write("Enter award IsDomestic? (T/F): ");
                char isdomestic = char.Parse(Console.ReadLine());
                bool isDomestic = false;
                if(isdomestic == 'T')
                {
                    isDomestic = true;
                }                
                Console.Write("Enter award's wine: ");
                int awardswine = int.Parse(Console.ReadLine());
                rest.Post(new Award() 
                { 
                    AwardName = awardName,
                    AwardYear = year, 
                    IsDomestic = isDomestic,
                    WineId = awardswine
                },"award");
            }       
            if(entity == "Wine")
            {
                Console.Write("Enter wine name: ");
                string wineName = Console.ReadLine();
                Console.Write("Enter wine year: "); 
                int year = int.Parse(Console.ReadLine());
                Console.Write("Enter wine type (Whihe/Rozé/Red): ");
                string wineType = Console.ReadLine();
                Console.Write("Enter wine price: ");
                int price = int.Parse(Console.ReadLine());
                Console.Write("Enter wine wineryId: ");
                int wineryId = int.Parse(Console.ReadLine());
                bool isCheap;
                if(price < 2000)
                {
                    isCheap = true;
                }
                else
                {
                    isCheap = false;
                }
                WineType type = WineType.Vörös;
                if (wineType == "White")
                {
                    type = WineType.Fehér;
                }
                else if (wineType == "Rozé")
                {
                    type = WineType.Rozé;
                }                
                rest.Post(new Wine()
                {
                    Name = wineName,
                    Year = year,
                    Price = price,
                    WineryId = wineryId,
                    IsCheap = isCheap,
                    Type = type

                },"wine");
            }
            if(entity == "Winery")
            {
                Console.Write("Enter winery name: ");
                string wineryName = Console.ReadLine();
                Console.Write("Enter winery zipcode: ");
                int zipcode = int.Parse(Console.ReadLine());
                rest.Post(new Winery()
                {
                    Name = wineryName,
                    Zipcode = zipcode
                },"winery");
            }
        }
        private static void List(string entity)
        {
            if (entity == "Award")
            {
                List<Award> awards = rest.Get<Award>("award");
                var table = new ConsoleTable("AwardId", "AwardName", "AwardYear", "IsDomestic?");
                foreach (var item in awards)
                {                    
                    table.AddRow(item.AwardId, item.AwardName, item.AwardYear, item.IsDomestic);
                }                    
                table.Write(Format.Minimal);
            }
            if(entity == "Wine")
            {
                List<Wine> wines = rest.Get<Wine>("wine");
                var table = new ConsoleTable("WineId", "WineName", "Year", "Price");
                foreach (var item in wines)
                {
                    table.AddRow(item.WineId, item.Name, item.Year, item.Price + " Ft");
                }
                table.Write(Format.Minimal);
            }
            if (entity == "Winery")
            {
                List<Winery> wineries = rest.Get<Winery>("winery");
                var table = new ConsoleTable("WineryId", "WineryName", "Zipcode");
                foreach (var item in wineries)
                {
                    table.AddRow(item.WineryId, item.Name, item.Zipcode);
                }
                table.Write(Format.Minimal);
            }
            Console.ReadLine();
        }
        private static void WinesWithNationalAward()
        {
            List<Wine> wines = rest.Get<Wine>("WineStat/WinesWithNationalAward");
            var table = new ConsoleTable("WineId", "WineName", "Year", "Price");
            foreach (var item in wines)
            {
                table.AddRow(item.WineId, item.Name, item.Year, item.Price + " Ft");
            }
            table.Write(Format.Minimal);
            Console.ReadLine();            
        }
        private static void AverageWinePrice()
        {
            double result = rest.GetSingle<double>("WineryStat/AverageWinePrice");
            Console.WriteLine("Average price: " + result);
            Console.ReadLine();
        }
        private static void WineWithMostDomesticAward()
        {
            Wine result = rest.GetSingle<Wine>("WineStat/WineWithMostDomesticAward");
            Console.WriteLine("Wine with most domestic award: " + result.Name);
            Console.ReadLine();
        }
        private static void WineryWithMostExpensiveWine()
        {
            Winery result = rest.GetSingle<Winery>("WineryStat/WineryWithMostExpensiveWine");
            Console.WriteLine("Winery with most expensive wine: " + result.Name);
            Console.ReadLine();
        }
        private static void AveragePriceByWinery()
        {
            var result = rest.Get<AvgByWinery>("WineryStat/AveragePriceByWinery");
            var table = new ConsoleTable("Winery",  "Average Price");
            foreach (var item in result)
            {
                table.AddRow(item.Name, item.Avg + " Ft");
            }
            table.Write(Format.Minimal);
            Console.ReadLine();
        }
        private static void WinesWtihoutAwardsByWinery()
        {
            var result = rest.Get<WinesWtihoutAward>("WineryStat/WinesWtihoutAwardsByWinery");
            
            var table = new ConsoleTable("Winery", "Wines without awards");
            foreach (var item in result)
            {
                table.AddRow(item.Name, item.Wines.First().Name);                
                for(int i= 1; i < item.Wines.Count(); i++)
                {
                    table.AddRow(" ", item.Wines.ToList()[i].Name);
                }
                table.AddRow(" ", " ");
            }
            table.Write(Format.MarkDown);

            Console.ReadLine();
        }
        private class AvgByWinery
        {
            public AvgByWinery()
            {
            }
            public string Name { get; set; }
            public double Avg { get; set; }
        }
        public class WinesWtihoutAward
        {
            public WinesWtihoutAward()
            {
            }
            public string Name { get; set; }
            public IEnumerable<Wine> Wines { get; set; }

            public IEnumerable<Wine> GetWines()
            {
                return Wines;
            }
        }

        static void Main(string[] args)
        {
            rest = new RestService("http://localhost:5874/", "winery");
            
            var awardSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Award"))
                .Add("Create", () => Create("Award"))
                .Add("Delete", () => Delete("Award"))
                .Add("Update", () => Update("Award"))
                .Add("Exit", ConsoleMenu.Close);

            var wineSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Wine"))
                .Add("Create", () => Create("Wine"))
                .Add("Delete", () => Delete("Wine"))
                .Add("Update", () => Update("Wine"))
                .Add("WineWithMostDomesticAward", () => WineWithMostDomesticAward())
                .Add("WinesWithNationalAward", () => WinesWithNationalAward())
                .Add("Exit", ConsoleMenu.Close);

            var winerySubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Winery"))
                .Add("Create", () => Create("Winery"))
                .Add("Delete", () => Delete("Winery"))
                .Add("Update", () => Update("Winery"))
                .Add("AverageWinePrice", () => AverageWinePrice())
                .Add("AveragePriceByWinery", () => AveragePriceByWinery())
                .Add("WinesWtihoutAwardsByWinery", () => WinesWtihoutAwardsByWinery())
                .Add("WineryWithMostExpensiveWine", () => WineryWithMostExpensiveWine())
                .Add("Exit", ConsoleMenu.Close);

            var menu = new ConsoleMenu(args, level: 0)
                .Add("Awards", () => awardSubMenu.Show())
                .Add("Wines", () => wineSubMenu.Show())
                .Add("Wineries", () => winerySubMenu.Show())              
                .Add("Exit", ConsoleMenu.Close);

            menu.Show();
        }        
    }
}
