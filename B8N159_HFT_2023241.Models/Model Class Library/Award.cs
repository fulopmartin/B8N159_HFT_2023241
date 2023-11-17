using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B8N159_HFT_2023241.Models
{
    public class Award
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AwardId { get; set; }
        public int AwardYear { get; set; }
        public string AwardName { get; set; }
        //foreign key
        public int WineId { get; set; }
        [NotMapped]
        public virtual Wine Wine { get; set; }

        public Award(int awardId, int awardYear, string awardName, int wineId)
        {
            AwardId = awardId;
            AwardYear = awardYear;
            AwardName = awardName;
            WineId = wineId;
        }
    }
}
