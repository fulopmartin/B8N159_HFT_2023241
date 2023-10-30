﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B8N159_HFT_2023241.Models
{
    public class Winery
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int WineryId { get; set; }
        public string Name { get; set; }
        public int Zipcode { get; set; }
        public virtual ICollection<Wine> Wines { get; set; }

        public Winery()
        {
            this.Wines = new HashSet<Wine>();
        }

    }
}
