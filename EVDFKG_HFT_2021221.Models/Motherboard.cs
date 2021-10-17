using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVDFKG_HFT_2021221.Models
{
    public class Motherboard
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key] //Primary Key
        public int MotherboardId { get; set; }
        public string Series { get; set; }
        public string Brand { get; set; }
        public string CompatibleProcessors { get; set; }
        public string CPUSocket { get; set; }
        public int RAMSlot { get; set; }
        public string RAMType { get; set; }
        public int MAXRAMSpeed { get; set; }
        public string GPUInterface { get; set; }


        //-------------------------------------------------------
        // NAVIGATION PROPERTIES
        //-------------------------------------------------------

        public Motherboard()
        {
            this.rams = new HashSet<RAM>();
            this.cpus= new HashSet<CPU>();
        }
        [NotMapped]
        public virtual ICollection<RAM> rams { get; set; }
        [NotMapped]
        public virtual ICollection<CPU> cpus { get; set; }
    }
}
