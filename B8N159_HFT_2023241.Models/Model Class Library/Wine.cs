using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
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
        public virtual Winery Winery { get; set; }
        [NotMapped]
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
        public override bool Equals(object obj)
        {
            Wine b = obj as Wine;
            if (b == null)
            {
                return false;
            }
            else
            {
                return this.Name == b.Name
                    && this.Year == b.Year
                    && this.Type == b.Type
                    && this.Price == b.Price
                    && this.WineId == b.WineId
                    && this.WineryId == b.WineryId
                    && this.IsCheap == b.IsCheap
                    && this.Awards == b.Awards;
            }
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(
                this.Name,
                this.Year, 
                this.Type,
                this.Price,
                this.WineId,
                this.WineryId,
                this.IsCheap,
                this.Awards);
        }
    }
}
