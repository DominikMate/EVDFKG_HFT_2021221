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
        CpuLogic cpul;
        RamLogic raml;
        MotherboardLogic mbl;

        [SetUp]
        public void Init()
        {
            var mockCpuRepository = new Mock<ICpuRepository>();
            var cpu1 = new CPU()
            {
                CPUId = 1,
                Series = "Ryzen 5",
                Brand = "AMD",
                CPUSocket = "Socket AM4",
                CPUCore = 6,
                CPUThread = 12,
                CPUSpeed = 4.6f,
                RAMType = "DDR4",
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
            var cpus = new List<CPU>
            {cpu1,cpu2,}.AsQueryable();
            var mockRamRepository = new Mock<IRamRepository>();
            var ram1 = new RAM()
            {
                RAMId = 1,
                Series = "Corsair Vengeance LPX",
                Brand = "Corsair",
                RAMSize = 16,
                RAMSpeed = 3200,
                RAMType = "DDR4",
                CASLatency = "C16",
                PartNumber = "CMK16GX4M2B3200C16",
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
            var rams = new List<RAM>()
            { ram1,ram2 }.AsQueryable();
            var mockMotherboardRepository = new Mock<IMotherboardRepository>();
            var motherboard1 = new Motherboard()
            {
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
            var motherboards = new List<Motherboard>()
            { motherboard1,motherboard2 }.AsQueryable();
            var mockComboRepository = new Mock<IComboRepository>();
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

            mockRamRepository.Setup((t) => t.ReadAll())
                .Returns(rams);
            raml = new RamLogic(
                mockRamRepository.Object);

            mockCpuRepository.Setup((t) => t.ReadAll())
                .Returns(cpus);
            cpul = new CpuLogic(
                mockCpuRepository.Object);

            mockMotherboardRepository.Setup((t) => t.ReadAll())
                .Returns(motherboards);
            mbl = new MotherboardLogic(
                mockMotherboardRepository.Object);
        }



        [Test]
        public void CpuRamSpeedAverage()
        {
            var result = cl.CpuRamSpeedAverage();
            var expected = new List
                <KeyValuePair<string, double>>()
            {
                new KeyValuePair<string, double>
                ("AMD", 3200)
            };
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void MotherboardCpuCoreAverage()
        {
            var result = cl.MotherboardCpuCoreAverage();
            var expected = new List
                <KeyValuePair<string, double>>()
            {
                new KeyValuePair<string, double>
                ("ASUS", 6)
            };
            Assert.That(result, Is.EqualTo(expected));
        }
        [Test]
        public void RamCpuSpeedAverage()
        {
            var result = cl.RamCpuSpeedAverage();
            var expected = new List
                <KeyValuePair<string, double>>()
            {
                new KeyValuePair<string, double>
                ("Corsair", 4.6f)
            };
            Assert.That(result, Is.EqualTo(expected));
        }
        [Test]
        public void CpuRAMSlotAverage()
        {
            var result = cl.CpuRAMSlotAverage();
            var expected = new List
                <KeyValuePair<string, double>>()
            {
                new KeyValuePair<string, double>
                ("AMD", 4)
            };
            Assert.That(result, Is.EqualTo(expected));
        }
        [Test]
        public void RamCPUThreadAverage()
        {
            var result = cl.RamCPUThreadAverage();
            var expected = new List
                <KeyValuePair<string, double>>()
            {
                new KeyValuePair<string, double>
                ("Corsair", 12)
            };
            Assert.That(result, Is.EqualTo(expected));
        }
        [Test]
        public void CreateCpu()
        {
            Assert.That(() => cpul.Create(new CPU()), Throws.Exception);
        }
        [Test]
        public void CreateRam()
        {
            Assert.That(() => raml.Create(new RAM()), Throws.Exception);
        }
        [Test]
        public void CreateMotherboard()
        {
            Assert.That(() => mbl.Create(new Motherboard()), Throws.Exception);
        }
        [Test]
        public void ComboReadAllType()
        {
            Assert.AreEqual(cl.ReadAll().GetType(), typeof(EnumerableQuery<Combo>));
        }
        [Test]
        public void CPUReadAllType()
        {
            Assert.AreEqual(cpul.ReadAll().GetType(), typeof(EnumerableQuery<CPU>));
        }
    }
}
