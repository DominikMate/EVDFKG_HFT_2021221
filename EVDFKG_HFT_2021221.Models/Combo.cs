using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVDFKG_HFT_2021221.Models
{
    [Table("Combo")]
    public class Combo
    {

        //-------------------------------------------------------
        // NAVIGATION PROPERTIES
        //-------------------------------------------------------

        public int MotherboardId { get; set; }
        [NotMapped]
        public virtual Motherboard Motherboard { get; set; }
        public int RAMId { get; set; }
        [NotMapped]
        public virtual RAM RAM { get; set; }
        public int CPUId { get; set; }
        [NotMapped]
        public virtual CPU CPU { get; set; }
    }
}
