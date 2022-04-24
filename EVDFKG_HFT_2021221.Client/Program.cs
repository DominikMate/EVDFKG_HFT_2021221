using EVDFKG_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EVDFKG_HFT_2021221.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Threading.Thread.Sleep(6000);
            RestService rest = new RestService("http://localhost:9861");
            bool a = true;
            while (a)
            {
                Console.WriteLine("1. Read one component");
                Console.WriteLine("2. Read all components");
                Console.WriteLine("3. Create a new component");
                Console.WriteLine("4. Update an existing component");
                Console.WriteLine("5. Delete an existing component");
                Console.WriteLine("6. Cpu Ram Speed Average");
                Console.WriteLine("7. Motherboard Cpu Core Average");
                Console.WriteLine("8. Ram Cpu Speed Average");
                Console.WriteLine("9. Cpu RAM Slot Average");
                Console.WriteLine("10. Ram CPU Thread Average");
                try
                {
                    switch (Console.ReadLine())
                    {
                        case "1":
                            Console.Clear();
                            Console.WriteLine("1. Read one CPU");
                            Console.WriteLine("2. Read one Motherboard");
                            Console.WriteLine("3. Read one RAM");
                            Console.WriteLine("4. Read one Combolist");
                            switch (Console.ReadLine())
                            {
                                case "1":
                                    int id = 0;
                                    Console.Clear();
                                    Console.WriteLine("Cpu id: ");
                                    int.TryParse(Console.ReadLine(), out id);
                                    Console.Clear();
                                    Console.WriteLine(ReadOneCpu(rest, id));
                                    break;
                                case "2":
                                    Console.Clear();
                                    Console.WriteLine("Motherboard id: ");
                                    int.TryParse(Console.ReadLine(), out id);
                                    Console.Clear();
                                    Console.WriteLine(ReadOneMotherboard(rest, id));
                                    break;
                                case "3":
                                    Console.Clear();
                                    Console.WriteLine("RAM id: ");
                                    int.TryParse(Console.ReadLine(), out id);
                                    Console.Clear();
                                    Console.WriteLine(ReadOneRam(rest, id));
                                    break;
                                case "4":
                                    Console.Clear();
                                    Console.WriteLine("Combolist id: ");
                                    int.TryParse(Console.ReadLine(), out id);
                                    Console.Clear();
                                    Console.WriteLine(ReadOneCombo(rest, id));
                                    break;
                            }
                            break;
                        case "2":
                            Console.Clear();
                            Console.WriteLine("1. Read all CPU");
                            Console.WriteLine("2. Read all Motherboard");
                            Console.WriteLine("3. Read all RAM");
                            Console.WriteLine("4. Read all Combolist");
                            switch (Console.ReadLine())
                            {

                                case "1":
                                    Console.Clear();
                                    foreach (var x in ReadAllCpu(rest))
                                    {
                                        Console.WriteLine($"CPUId: {x.CPUId}, Series: {x.Series}, Brand: {x.Brand}, CPUSocket: {x.CPUSocket}, CPUCore: {x.CPUCore}, CPUThread: {x.CPUThread}, CPUSpeed: {x.CPUSpeed}, RAMType: {x.RAMType}");
                                    }
                                    break;
                                case "2":
                                    Console.Clear();
                                    foreach (var x in ReadAllMotherboard(rest))
                                    {
                                        Console.WriteLine($"MotherboardId: {x.MotherboardId}, Series: {x.Series}, Brand: {x.Brand}, CompatibleProcessors: {x.CompatibleProcessors}, CPUSocket: {x.CPUSocket}, RAMSlot: {x.RAMSlot}, RAMType: {x.RAMType}, MAXRAMSpeed: {x.MAXRAMSpeed}, GPUInterface: {x.GPUInterface}");
                                    }
                                    break;
                                case "3":
                                    Console.Clear();
                                    foreach (var x in ReadAllRam(rest))
                                    {
                                        Console.WriteLine($"RAMId: {x.RAMId}, Series: {x.Series}, Brand: {x.Brand}, RAMSize: {x.RAMSize}, RAMSpeed: {x.RAMSpeed}, RAMType: {x.RAMType}, CASLatency: {x.CASLatency}, PartNumber: {x.PartNumber}");
                                    }
                                    break;
                                case "4":
                                    Console.Clear();
                                    foreach (var x in ReadAllCombo(rest))
                                    {
                                        Console.WriteLine($"CPUId: {x.CPUId}, MotherboardId: {x.MotherboardId}, RAMId: {x.RAMId}");
                                    }
                                    break;
                            }
                            break;
                        case "3":
                            Console.Clear();
                            Console.WriteLine("1. Create a new CPU");
                            Console.WriteLine("2. Create a new Motherboard");
                            Console.WriteLine("3. Create a new RAM");
                            Console.WriteLine("4. Create a new Combolist");
                            switch (Console.ReadLine())
                            {

                                case "1":
                                    Console.Clear();
                                    string Brand;
                                    int CPUCore;
                                    string CPUSocket;
                                    int CPUSpeed;
                                    int CPUThread;
                                    string RAMType;
                                    string Series;
                                    Console.WriteLine("Brand: ");
                                    Brand = Console.ReadLine();
                                    Console.WriteLine("CPUCore [number]: ");
                                    int.TryParse(Console.ReadLine(), out CPUCore);
                                    Console.WriteLine("CPUSocket: ");
                                    CPUSocket = Console.ReadLine();
                                    Console.WriteLine("CPUSpeed [number]: ");
                                    int.TryParse(Console.ReadLine(), out CPUSpeed);
                                    Console.WriteLine("CPUThread [number]: ");
                                    int.TryParse(Console.ReadLine(), out CPUThread);
                                    Console.WriteLine("RAMType: ");
                                    RAMType = Console.ReadLine();
                                    Console.WriteLine("Series: ");
                                    Series = Console.ReadLine();

                                    AddOneCpu(rest, new CPU
                                    {

                                        Brand = Brand,
                                        CPUCore = CPUCore,
                                        CPUSocket = CPUSocket,
                                        CPUSpeed = CPUSpeed,
                                        CPUThread = CPUThread,
                                        RAMType = RAMType,
                                        Series = Series,
                                    });
                                    break;
                                case "2":
                                    Console.Clear();
                                    string Brand1;
                                    string CompatibleProcessors1;
                                    string CPUSocket1;
                                    string GPUInterface1;
                                    int MAXRAMSpeed1;
                                    int RAMSlot1;
                                    string RAMType1;
                                    string Series1;
                                    Console.WriteLine("Brand: ");
                                    Brand1 = Console.ReadLine();
                                    Console.WriteLine("CompatibleProcessors: ");
                                    CompatibleProcessors1 = Console.ReadLine();
                                    Console.WriteLine("CPUSocket: ");
                                    CPUSocket1 = Console.ReadLine();
                                    Console.WriteLine("GPUInterface: ");
                                    GPUInterface1 = Console.ReadLine();
                                    Console.WriteLine("MAXRAMSpeed [number]: ");
                                    int.TryParse(Console.ReadLine(), out MAXRAMSpeed1);
                                    Console.WriteLine("RAMSlot [number]: ");
                                    int.TryParse(Console.ReadLine(), out RAMSlot1);
                                    Console.WriteLine("RAMType: ");
                                    RAMType1 = Console.ReadLine();
                                    Console.WriteLine("Series: ");
                                    Series1 = Console.ReadLine();
                                    AddOneMotherboard(rest, new Motherboard
                                    {
                                        Brand =Brand1,
                                        CompatibleProcessors =CompatibleProcessors1,
                                        CPUSocket =CPUSocket1,
                                        GPUInterface =GPUInterface1,
                                        MAXRAMSpeed =MAXRAMSpeed1,
                                        RAMSlot =RAMSlot1,
                                        RAMType =RAMType1,
                                        Series =Series1
                                    });
                                    break;
                                case "3":
                                    Console.Clear();
                                    string Brand2;
                                    string CASLatency2;
                                    string PartNumber2;
                                    int RAMSize2;
                                    int RAMSpeed2;
                                    string RAMType2;
                                    string Series2;
                                    Console.WriteLine("Brand: ");
                                    Brand2 = Console.ReadLine();
                                    Console.WriteLine("CASLatency: ");
                                    CASLatency2 = Console.ReadLine();
                                    Console.WriteLine("PartNumber: ");
                                    PartNumber2 = Console.ReadLine();
                                    Console.WriteLine("RAMSize [number]: ");
                                    int.TryParse(Console.ReadLine(), out RAMSize2);
                                    Console.WriteLine("RAMSpeed [number]: ");
                                    int.TryParse(Console.ReadLine(), out RAMSpeed2);
                                    Console.WriteLine("RAMType: ");
                                    RAMType2 = Console.ReadLine();
                                    Console.WriteLine("Series: ");
                                    Series2 = Console.ReadLine();

                                    AddOneRam(rest, new RAM
                                    {
                                        Brand=Brand2,
                                        CASLatency=CASLatency2,
                                        PartNumber=PartNumber2,
                                        RAMSize=RAMSize2,
                                        RAMSpeed=RAMSpeed2,
                                        RAMType=RAMType2,
                                        Series=Series2,
                                    });
                                    break;
                                case "4":
                                    Console.Clear();
                                    int CPUId;
                                    int MotherboardId;
                                    int RAMId;
                                    Console.WriteLine("CPUId [number]: ");
                                    int.TryParse(Console.ReadLine(), out CPUId);
                                    Console.WriteLine("MotherboardId [number]: ");
                                    int.TryParse(Console.ReadLine(), out MotherboardId);
                                    Console.WriteLine("RAMId [number]: ");
                                    int.TryParse(Console.ReadLine(), out RAMId);
                                    AddOneCombo(rest, new Combo
                                    {
                                        CPUId=CPUId,
                                        MotherboardId=MotherboardId,
                                        RAMId=RAMId,
                                    });
                                    break;
                            }
                            break;
                        case "4":
                            Console.Clear();
                            Console.WriteLine("1. Update an existing CPU");
                            Console.WriteLine("2. Update an existing Motherboard");
                            Console.WriteLine("3. Update an existing RAM");
                            switch (Console.ReadLine())
                            {
                                case "1":
                                    Console.Clear();
                                    int CPUId;
                                    string Brand;
                                    int CPUCore;
                                    string CPUSocket;
                                    int CPUSpeed;
                                    int CPUThread;
                                    string RAMType;
                                    string Series;
                                    Console.WriteLine("CPUId [number]: ");
                                    int.TryParse(Console.ReadLine(), out CPUId);
                                    Console.WriteLine("Brand: ");
                                    Brand = Console.ReadLine();
                                    Console.WriteLine("CPUCore [number]: ");
                                    int.TryParse(Console.ReadLine(), out CPUCore);
                                    Console.WriteLine("CPUSocket: ");
                                    CPUSocket = Console.ReadLine();
                                    Console.WriteLine("CPUSpeed [number]: ");
                                    int.TryParse(Console.ReadLine(), out CPUSpeed);
                                    Console.WriteLine("CPUThread [number]: ");
                                    int.TryParse(Console.ReadLine(), out CPUThread);
                                    Console.WriteLine("RAMType: ");
                                    RAMType = Console.ReadLine();
                                    Console.WriteLine("Series: ");
                                    Series = Console.ReadLine();

                                    UpdateCPU(rest, new CPU
                                    {
                                        CPUId = CPUId,
                                        Brand = Brand,
                                        CPUCore = CPUCore,
                                        CPUSocket = CPUSocket,
                                        CPUSpeed = CPUSpeed,
                                        CPUThread = CPUThread,
                                        RAMType = RAMType,
                                        Series = Series,
                                        Combos = null
                                    }); ;
                                    break;
                                case "2":
                                    Console.Clear();
                                    int MotherboardId;
                                    string Brand1;
                                    string CompatibleProcessors1;
                                    string CPUSocket1;
                                    string GPUInterface1;
                                    int MAXRAMSpeed1;
                                    int RAMSlot1;
                                    string RAMType1;
                                    string Series1;
                                    Console.WriteLine("MotherboardId [number]: ");
                                    int.TryParse(Console.ReadLine(), out MotherboardId);
                                    Console.WriteLine("Brand: ");
                                    Brand1 = Console.ReadLine();
                                    Console.WriteLine("CompatibleProcessors: ");
                                    CompatibleProcessors1 = Console.ReadLine();
                                    Console.WriteLine("CPUSocket: ");
                                    CPUSocket1 = Console.ReadLine();
                                    Console.WriteLine("GPUInterface: ");
                                    GPUInterface1 = Console.ReadLine();
                                    Console.WriteLine("MAXRAMSpeed [number]: ");
                                    int.TryParse(Console.ReadLine(), out MAXRAMSpeed1);
                                    Console.WriteLine("RAMSlot [number]: ");
                                    int.TryParse(Console.ReadLine(), out RAMSlot1);
                                    Console.WriteLine("RAMType: ");
                                    RAMType1 = Console.ReadLine();
                                    Console.WriteLine("Series: ");
                                    Series1 = Console.ReadLine();
                                    UpdateMotherboard(rest, new Motherboard
                                    {
                                        MotherboardId=MotherboardId,
                                        Brand = Brand1,
                                        CompatibleProcessors = CompatibleProcessors1,
                                        CPUSocket = CPUSocket1,
                                        GPUInterface = GPUInterface1,
                                        MAXRAMSpeed = MAXRAMSpeed1,
                                        RAMSlot = RAMSlot1,
                                        RAMType = RAMType1,
                                        Series = Series1
                                    });
                                    break;
                                case "3":
                                    Console.Clear();
                                    int RamId;
                                    string Brand2;
                                    string CASLatency2;
                                    string PartNumber2;
                                    int RAMSize2;
                                    int RAMSpeed2;
                                    string RAMType2;
                                    string Series2;
                                    Console.WriteLine("RamId [number]: ");
                                    int.TryParse(Console.ReadLine(), out RamId);
                                    Console.WriteLine("Brand: ");
                                    Brand2 = Console.ReadLine();
                                    Console.WriteLine("CASLatency: ");
                                    CASLatency2 = Console.ReadLine();
                                    Console.WriteLine("PartNumber: ");
                                    PartNumber2 = Console.ReadLine();
                                    Console.WriteLine("RAMSize [number]: ");
                                    int.TryParse(Console.ReadLine(), out RAMSize2);
                                    Console.WriteLine("RAMSpeed [number]: ");
                                    int.TryParse(Console.ReadLine(), out RAMSpeed2);
                                    Console.WriteLine("RAMType: ");
                                    RAMType2 = Console.ReadLine();
                                    Console.WriteLine("Series: ");
                                    Series2 = Console.ReadLine();

                                    UpdateRam(rest, new RAM
                                    {
                                        RAMId= RamId,
                                        Brand = Brand2,
                                        CASLatency = CASLatency2,
                                        PartNumber = PartNumber2,
                                        RAMSize = RAMSize2,
                                        RAMSpeed = RAMSpeed2,
                                        RAMType = RAMType2,
                                        Series = Series2,
                                    });
                                    break;
                            }
                            break;
                        case "5":
                            Console.Clear();
                            Console.WriteLine("1. Delete an existing CPU");
                            Console.WriteLine("2. Delete an existing Motherboard");
                            Console.WriteLine("3. Delete an existing RAM");
                            Console.WriteLine("4. Delete an existing combolist");
                            switch (Console.ReadLine())
                            {

                                case "1":
                                    int id = 0;
                                    Console.Clear();
                                    Console.WriteLine("Cpu id: ");
                                    int.TryParse(Console.ReadLine(), out id);
                                    DeleteCpu(rest, id);
                                    Console.Clear();
                                    break;
                                case "2":
                                    Console.Clear();
                                    Console.WriteLine("Motherboard id: ");
                                    int.TryParse(Console.ReadLine(), out id);
                                    DeleteMotherboard(rest, id);
                                    Console.Clear();
                                    break;
                                case "3":
                                    Console.Clear();
                                    Console.WriteLine("RAM id: ");
                                    int.TryParse(Console.ReadLine(), out id);
                                    DeleteRam(rest, id);
                                    Console.Clear();
                                    break;
                                case "4":
                                    Console.Clear();
                                    Console.WriteLine("combolist id: ");
                                    int.TryParse(Console.ReadLine(), out id);
                                    DeleteCombo(rest, id);
                                    Console.Clear();
                                    break;
                            }
                            break;
                        case "6":
                                Console.Clear();
                                Console.WriteLine(CpuRamSpeedAverage(rest));
                            break;
                        case "7":
                            Console.Clear();
                            Console.WriteLine(MotherboardCpuCoreAverage(rest));
                            break;
                        case "8":
                            Console.Clear();
                            Console.WriteLine(RamCpuSpeedAverage(rest));
                            break;
                        case "9":
                            Console.Clear();
                            Console.WriteLine(CpuRAMSlotAverage(rest));
                            break;
                        case "10":
                            Console.Clear();
                            Console.WriteLine(RamCPUThreadAverage(rest));
                            break;
                        default:
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine();
                    Console.WriteLine("Whoops looks like something went wrong D:");
                    Console.WriteLine(e.Message);
                }
                Console.WriteLine();
                Console.WriteLine("Press enter to continue");
                Console.ReadKey();
                Console.Clear();
            }
        }
        static string ReadOneCpu(RestService rest, int id)
        {
            var x = rest.GetSingle<CPU>("/cpu/" + id);
            if (x!=null)
            {
                return string.Join('\n', $"CPUId: {x.CPUId}, Series: {x.Series}, Brand: {x.Brand}, CPUSocket: {x.CPUSocket}, CPUCore: {x.CPUCore}, CPUThread: {x.CPUThread}, CPUSpeed: {x.CPUSpeed}, RAMType: {x.RAMType}");
            }
            return "CPU not found";
        }
        static string ReadOneRam(RestService rest, int id)
        {
            var x = rest.GetSingle<RAM>("/ram/" + id);
            if (x != null)
            {
                return string.Join('\n', $"RAMId: {x.RAMId}, Series: {x.Series}, Brand: {x.Brand}, RAMSize: {x.RAMSize}, RAMSpeed: {x.RAMSpeed}, RAMType: {x.RAMType}, CASLatency: {x.CASLatency}, PartNumber: {x.PartNumber}");
            }
            return "RAM not found";
        }
        static string ReadOneMotherboard(RestService rest, int id)
        {
            var x = rest.GetSingle<Motherboard>("/motherboard/" + id);
            if (x != null)
            {
                return string.Join('\n', $"MotherboardId: {x.MotherboardId}, Series: {x.Series}, Brand: {x.Brand}, CompatibleProcessors: {x.CompatibleProcessors}, CPUSocket: {x.CPUSocket}, RAMSlot: {x.RAMSlot}, RAMType: {x.RAMType}, MAXRAMSpeed: {x.MAXRAMSpeed}, GPUInterface: {x.GPUInterface}");
            }
            return "Motherboard not found";
        }
        static string ReadOneCombo(RestService rest, int id)
        {
            var x = rest.GetSingle<Combo>("/combo/" + id);
            if (x != null)
            {
                return string.Join('\n', $"CPUId: {x.CPUId}, MotherboardId: {x.MotherboardId}, RAMId: {x.RAMId}");
            }
            return "Combo not found";
        }
        static List<CPU> ReadAllCpu(RestService rest)
        {
            return rest.Get<CPU>("/cpu");
        }
        static List<RAM> ReadAllRam(RestService rest)
        {
            return rest.Get<RAM>("/ram");
        }
        static List<Motherboard> ReadAllMotherboard(RestService rest)
        {
            return rest.Get<Motherboard>("/motherboard");
        }
        static List<Combo> ReadAllCombo(RestService rest)
        {
            return rest.Get<Combo>("/combo");
        }
        static void AddOneCpu(RestService rest, CPU cpu)
        {
            rest.Post<CPU>(cpu, "/cpu");
        }
        static void AddOneMotherboard(RestService rest, Motherboard motherboard)
        {
            rest.Post<Motherboard>(motherboard, "/motherboard");
        }
        static void AddOneRam(RestService rest, RAM ram)
        {
            rest.Post<RAM>(ram, "/ram");
        }
        static void AddOneCombo(RestService rest, Combo combo)
        {
            rest.Post<Combo>(combo, "/combo");
        }
        static void UpdateCPU(RestService rest, CPU cpu)
        {
            rest.Put<CPU>(cpu, "/cpu");
        }
        static void UpdateMotherboard(RestService rest, Motherboard motherboard)
        {
            rest.Put<Motherboard>(motherboard, "/motherboard");
        }
        static void UpdateRam(RestService rest, RAM ram)
        {
            rest.Put<RAM>(ram, "/ram");
        }
        static void DeleteCpu(RestService rest,int id)
        {
            if (id!=0 && int.TryParse(id.ToString(), out _))
            {
                rest.Delete(id, "/cpu");
            }
        }
        static void DeleteMotherboard(RestService rest, int id)
        {
            if (id != 0 && int.TryParse(id.ToString(), out _))
            {
                rest.Delete(id, "/motherboard");
            }
        }
        static void DeleteRam(RestService rest, int id)
        {
            if (id != 0 && int.TryParse(id.ToString(), out _))
            {
                rest.Delete(id, "/ram");
            }
        }
        static void DeleteCombo(RestService rest, int id)
        {
            if (id != 0 && int.TryParse(id.ToString(), out _))
            {
                rest.Delete(id, "/combo");
            }
        }
        static string CpuRamSpeedAverage(RestService rest)
        {
            return string.Join('\n', rest.Get<KeyValuePair<string, double>>("/combo/crsa").Select(x => $"brand: {x.Key}, average: {x.Value}"));
        }
        static string MotherboardCpuCoreAverage(RestService rest)
        {
            return string.Join('\n', rest.Get<KeyValuePair<string, double>>("/combo/mcca").Select(x => $"brand: {x.Key}, average: {x.Value}"));
        }
        static string RamCpuSpeedAverage(RestService rest)
        {
            return string.Join('\n', rest.Get<KeyValuePair<string, double>>("/combo/rcsa").Select(x => $"brand: {x.Key}, average: {x.Value}"));
        }
        static string CpuRAMSlotAverage(RestService rest)
        {
            return string.Join('\n', rest.Get<KeyValuePair<string, double>>("/combo/crrsa").Select(x => $"brand: {x.Key}, average: {x.Value}"));
        }
        static string RamCPUThreadAverage(RestService rest)
        {
            return string.Join('\n', rest.Get<KeyValuePair<string, double>>("/combo/crta").Select(x => $"brand: {x.Key}, average: {x.Value}"));
        }
    }
}
