using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVDFKG_HFT_2021221.Models
{
    public class Motherboard
    {
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
    }
}
