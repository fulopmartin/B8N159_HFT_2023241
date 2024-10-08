﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

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
        [JsonIgnore]

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
    }
}
