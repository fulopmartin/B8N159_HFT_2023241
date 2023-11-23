﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace B8N159_HFT_2023241.Models
{
    public enum WineType
    {
        Vörös = 1,
        Fehér = 2,
        Rozé = 3
    };
    public class Wine
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int WineId { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public WineType Type { get; set; }
        public int Price { get; set; }
        public bool IsCheap { get; set; }
        //foreign key
        public int WineryId { get; set; }        
        [NotMapped]
        [JsonIgnore]
        public virtual Winery Winery { get; set; }
        [NotMapped]
        [JsonIgnore]
        public virtual ICollection<Award> Awards { get; set; }

        public Wine()
        {
        }
        public Wine(int wineId, string name, int year,WineType type, int price, int wineryId)
        {
            WineId = wineId;
            Name = name;
            Year = year;
            Type = type;
            Price = price;
            if(price < 2000)
            {
                IsCheap = true;
            }
            else
            {
                IsCheap = false;
            }
            WineryId = wineryId;
            Awards = new HashSet<Award>();
        }        
    }
}
