using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace B8N159_HFT_2023241.Models
{
    public class Winery
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int WineryId { get; set; }
        public string Name { get; set; }
        public int Zipcode { get; set; }
        [NotMapped]
        [JsonIgnore]
        public virtual ICollection<Wine> Wines { get; set; }
        public Winery()
        {
        }
        public Winery(int wineryId, string name, int zipcode)
        {
            WineryId = wineryId;
            Name = name;
            Zipcode = zipcode;
            Wines = new HashSet<Wine>();
        }
    }
}
