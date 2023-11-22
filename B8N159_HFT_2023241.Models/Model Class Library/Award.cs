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
        public bool IsDomestic { get; set; }
        //foreign key
        public int WineId { get; set; }
        [NotMapped]
        public virtual Wine Wine { get; set; }
        public Award()
        {
        }
        public Award(int awardId, int awardYear, string awardName, int wineId, bool isDomestic)
        {
            AwardId = awardId;
            AwardYear = awardYear;
            AwardName = awardName;
            WineId = wineId;
            IsDomestic = isDomestic;
        }

        public override bool Equals(object obj)
        {
            Award b = obj as Award;
            if (b == null)
            {
                return false;
            }
            else
            {
                return this.AwardId == b.AwardId
                    && this.AwardYear == b.AwardYear
                    && this.AwardName == b.AwardName
                    && this.WineId == b.WineId
                    && this.IsDomestic == b.IsDomestic;
                    
            }
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(
                this.AwardId,
                this.AwardYear,
                this.AwardName,
                this.WineId,
                this.IsDomestic);
        }
    }
}
