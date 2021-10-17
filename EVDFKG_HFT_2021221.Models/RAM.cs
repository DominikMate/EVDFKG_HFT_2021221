﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVDFKG_HFT_2021221.Models
{
    public class RAM
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key] //Primary Key
        public int RAMId { get; set; }
        public string Series { get; set; }
        public string Brand { get; set; }
        public int RAMSize { get; set; }
        public int RAMSpeed { get; set; }
        public string RAMType { get; set; }
        public string CASLatency { get; set; }
        public string PartNumber { get; set; }


        //-------------------------------------------------------
        // NAVIGATION PROPERTIES
        //-------------------------------------------------------

        public RAM()
        {
            this.Motherboards = new HashSet<Motherboard>();
            this.cpus = new HashSet<CPU>();
        }
        [NotMapped]
        public virtual ICollection<Motherboard> Motherboards { get; set; }
        [NotMapped]
        public virtual ICollection<CPU> cpus { get; set; }
    }
}
