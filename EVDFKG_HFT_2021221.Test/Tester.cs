using EVDFKG_HFT_2021221.Logic;
using EVDFKG_HFT_2021221.Models;
using EVDFKG_HFT_2021221.Repository;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVDFKG_HFT_2021221.Test
{
    [TestFixture]
    public class Tester
    {
        ComboLogic cl;

        [SetUp]
        public void Init()
        {
            var mockComboRepository = new Mock<IComboRepository>();
            var cpu1 =new CPU(){
                CPUId=1,
                Series= "Ryzen 5",
                Brand="AMD",
                CPUSocket= "Socket AM4",
                CPUCore=6,
                CPUThread=12,
                CPUSpeed=4.6f,
                RAMType="DDR4",
            };
            var ram1 = new RAM(){
                RAMId=1,
                Series= "Corsair Vengeance LPX",
                Brand = "Corsair",
                RAMSize = 16,
                RAMSpeed = 3200,
                RAMType = "DDR4",
                CASLatency ="C16",
                PartNumber = "CMK16GX4M2B3200C16",
            };
            var motherboard1 = new Motherboard(){
                MotherboardId = 1,
                Series = "ROG STRIX B450-F Gaming II",
                Brand = "ASUS",
                CompatibleProcessors = "AMD_1G_RYZEN",
                CPUSocket = "Socket AM4",
                RAMSlot = 4,
                RAMType = "DDR4",
                MAXRAMSpeed = 4400,
                GPUInterface = "PCI-E",
            };
            var cpu2 = new CPU()
            {
                CPUId = 2,
                Series = "Ryzen 5",
                Brand = "AMD",
                CPUSocket = "Socket AM4",
                CPUCore = 6,
                CPUThread = 12,
                CPUSpeed = 4.6f,
                RAMType = "DDR4",
            };
            var ram2 = new RAM()
            {
                RAMId = 2,
                Series = "Corsair Vengeance LPX",
                Brand = "Corsair",
                RAMSize = 16,
                RAMSpeed = 3200,
                RAMType = "DDR4",
                CASLatency = "C16",
                PartNumber = "CMK16GX4M2B3200C16",
            };
            var motherboard2 = new Motherboard()
            {
                MotherboardId = 2,
                Series = "ROG STRIX B450-F Gaming II",
                Brand = "ASUS",
                CompatibleProcessors = "AMD_1G_RYZEN",
                CPUSocket = "Socket AM4",
                RAMSlot = 4,
                RAMType = "DDR4",
                MAXRAMSpeed = 4400,
                GPUInterface = "PCI-E",
            };
            var combos = new List<Combo>
            {
                new Combo()
                {
                    CPUId=1,
                    CPU=cpu1,
                    RAMId=1,
                    RAM=ram1,
                    MotherboardId=1,
                    Motherboard=motherboard1,
                },
                new Combo()
                {
                    CPUId=2,
                    CPU=cpu2,
                    RAMId=2,
                    RAM=ram2,
                    MotherboardId=2,
                    Motherboard=motherboard2,
                }
            }.AsQueryable();
            mockComboRepository.Setup((t) => t.ReadAll())
                .Returns(combos);
            cl = new ComboLogic(
                mockComboRepository.Object);
        }

        [Test]
        public void AverageRamtypeSpeedTest()
        {
            var result = cl.AverageRamtypeSpeed();
            var expected = new List
                <KeyValuePair<string, double>>()
            {
                new KeyValuePair<string, double>
                ("AMD", 3200)
            };
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
