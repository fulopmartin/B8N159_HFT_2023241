using B8N159_HFT_2023241.Models;
using ConsoleTools;
using System;
using System.Collections.Generic;

namespace B8N159_HFT_2023241.Client
{
    internal class Program
    {
        static RestService rest;
        private static void Update(string entity)
        {
            if (entity == "Award")
            {
                Console.WriteLine("Enter Award's Id to update: ");
                int awardId = int.Parse(Console.ReadLine());
                Award one = rest.Get<Award>(awardId, "award");
                Console.Write($"New name [old: {one.AwardName}]: ");
                string newName = Console.ReadLine();
                one.AwardName = newName;
                rest.Put(one, "award");
            }
        }

        private static void Delete(string entity)
        {
            if (entity == "Award")
            {
                Console.WriteLine("Enter Award's Id to delete: ");
                int awardId = int.Parse(Console.ReadLine());
                rest.Delete(awardId,"award");
            }            
        }

        private static void Create(string entity)
        {
            if (entity == "Award")
            {
                Console.WriteLine("Enter Award Name: ");
                string awardName = Console.ReadLine();
                rest.Post(new Award() { AwardName = awardName },"award");
            }         
        }

        private static void List(string entity)
        {
            if (entity == "Award")
            {
                List<Award> awards = rest.Get<Award>("award");
                foreach (var item in awards)
                {
                    Console.WriteLine(item.AwardId + ": " + item.AwardName);
                }
            }
            Console.ReadLine();
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
                .Add("Exit", ConsoleMenu.Close);

            var winerySubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Winery"))
                .Add("Create", () => Create("Winery"))
                .Add("Delete", () => Delete("Winery"))
                .Add("Update", () => Update("Winery"))
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
