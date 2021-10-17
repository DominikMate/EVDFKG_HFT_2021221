using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVDFKG_HFT_2021221.Models
{
    public class Combo
    {
        [NotMapped]
        //-------------------------------------------------------
        // NAVIGATION PROPERTIES
        //-------------------------------------------------------
        public RAM RAM { get; set; }
        public Motherboard Motherboard { get; set; }
        public CPU CPU { get; set; }

        //-------------------------------------------------------
        // FOREIGN KEYS
        //-------------------------------------------------------
        [ForeignKey(nameof(Motherboard))]
        public int MotherboardId { get; set; }

        [ForeignKey(nameof(CPU))]
        public int CPUId { get; set; }

        [ForeignKey(nameof(RAM))]
        public int RAMId { get; set; }
    }
}
