using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVDFKG_HFT_2021221.Models
{
    public class RAM
    {
        [Key] //Primary Key
        public int RAMId { get; set; }
        public string Series { get; set; }
        public string Brand { get; set; }
        public int RAMSize { get; set; }
        public int RAMSpeed { get; set; }
        public string RAMType { get; set; }
        public string CASLatency { get; set; }
        public string PartNumber { get; set; }
    }
}
