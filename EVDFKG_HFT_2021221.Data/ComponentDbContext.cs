using EVDFKG_HFT_2021221.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVDFKG_HFT_2021221.Data
{
    public class ComponentDbContext : DbContext
    {
        public virtual DbSet<CPU> CPUs { get; set; }
        public virtual DbSet<Motherboard> Motherboards { get; set; }
        public virtual DbSet<RAM> RAMs { get; set; }

        public ComponentDbContext()
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder
            optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseLazyLoadingProxies()
                    .UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\LocalDB.mdf;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Combo>().HasKey(com => new { com.MotherboardId, com.CPUId, com.RAMId });


            Motherboard motherboard1 = new Motherboard()
            {
                MotherboardId = 1,
                Series = "ROG STRIX B450-F Gaming II",
                Brand = "ASUS",
                CompatibleProcessors = "AMD 1st Gerenration Ryzen",
                CPUSocket = "Socket AM4",
                RAMSlot = 4,
                RAMType = "DDR4",
                MAXRAMSpeed = 4400,
                GPUInterface = "PCI-E"
            };
            CPU cpu1 = new CPU
            {
                 CPUId=1,
                 Series= "Ryzen 5",
                 Brand="AMD",
                 CPUSocket= "Socket AM4",
                 CPUCore=6,
                 CPUThread=12,
                 CPUSpeed=4.6f,
                 RAMType="DDR4"
            };
            RAM ram1 = new RAM
            {
                RAMId=1,
                Series= "Corsair Vengeance LPX",
                Brand = "Corsair",
                RAMSize = 16,
                RAMSpeed = 3200,
                RAMType = "DDR4",
                CASLatency ="C16",
                PartNumber = "CMK16GX4M2B3200C16",
            };

            modelBuilder.Entity<Combo>()
                .HasOne<Motherboard>(co => co.Motherboard)
                .WithMany(m => m.Combos)
                .HasForeignKey(co => co.MotherboardId);

            modelBuilder.Entity<Combo>()
            .HasOne<RAM>(co => co.RAM)
            .WithMany(m => m.Combos)
            .HasForeignKey(co => co.RAMId);

            modelBuilder.Entity<Combo>()
            .HasOne<CPU>(co => co.CPU)
            .WithMany(m => m.Combos)
            .HasForeignKey(co => co.CPUId);
        }
    }
}
