using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVDFKG_HFT_2021221.Models
{
    [Table("CPU")]
    public class CPU
    {
        [Key] //Primary Key
        public int CPUId { get; set; }
        public string Series { get; set; }
        public string Brand { get; set; }
        public string CPUSocket { get; set; }
        public int CPUCore { get; set; }
        public int CPUThread { get; set; }
        public float CPUSpeed { get; set; }
        public string RAMType { get; set; }


        //-------------------------------------------------------
        // NAVIGATION PROPERTIES
        //-------------------------------------------------------
        [NotMapped]
        public virtual List<Combo> Combos { get; set; }
    }
}
