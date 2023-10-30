using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B8N159_HFT_2023241.Models
{
    public class Wine
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int WineId { get; set; }

        public string Name { get; set; }
        public int Year { get; set; }
        public int Price { get; set; }

        public int WineryId { get; set; }
        public int AwardId { get; set; }
        
        public virtual Winery Winery { get; private set; }
        public virtual Award Award { get; private set; }
        
    }
}
