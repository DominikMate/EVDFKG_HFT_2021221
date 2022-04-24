using EVDFKG_HFT_2021221.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace EVDFKG_HFT_2021221.WPFClient
{
    public class MainWindowViewModel:ObservableRecipient
    {
        public RestCollection<Motherboard> Motherboards {get;set; }
        public RestCollection<CPU> Cpus { get; set; }
        public RestCollection<RAM> Rams { get; set; }

        private Motherboard selectedMotherboard;

        public Motherboard SelectedMotherboard
        {
            get { return selectedMotherboard; }
            set { if (value != null)
                {
                    selectedMotherboard = new Motherboard()
                    {
                        MotherboardId = value.MotherboardId,
                        Series = value.Series,
                        CPUSocket = value.CPUSocket,
                        Brand = value.Brand,
                        Combos = value.Combos,
                        CompatibleProcessors = value.CompatibleProcessors,
                        GPUInterface = value.GPUInterface,
                        MAXRAMSpeed = value.MAXRAMSpeed,
                        RAMSlot = value.RAMSlot,
                        RAMType = value.RAMType,
                        
                    };
                    OnPropertyChanged();
                    (CreateMotherboardCommand as RelayCommand).NotifyCanExecuteChanged();
                    (UpdateMotherboardCommand as RelayCommand).NotifyCanExecuteChanged();
                    (DeleteMotherboardCommand as RelayCommand).NotifyCanExecuteChanged();
                }
                
            }
        }

        private CPU selectedCpu;

        public CPU SelectedCpu
        {
            get { return selectedCpu; }
            set
            {
                if (value != null)
                {
                    selectedCpu = new CPU()
                    {
                        CPUId = value.CPUId,
                        CPUCore = value.CPUCore,
                        Combos= value.Combos,
                        Brand = value.Brand,
                        CPUSocket= value.CPUSocket,
                        CPUSpeed=value.CPUSpeed,
                        CPUThread = value.CPUThread,
                        RAMType = value.RAMType,
                        Series = value.Series,

                    };
                    OnPropertyChanged();
                    (CreateCpuCommand as RelayCommand).NotifyCanExecuteChanged();
                    (UpdateCpuCommand as RelayCommand).NotifyCanExecuteChanged();
                    (DeleteCpuCommand as RelayCommand).NotifyCanExecuteChanged();
                }

            }
        }

        private RAM selectedRam;

        public RAM SelectedRam
        {
            get { return selectedRam; }
            set
            {
                if (value != null)
                {
                    selectedRam = new RAM()
                    {
                        RAMId=value.RAMId,
                        Brand=value.Brand,
                        Series=value.Series,
                        CASLatency=value.CASLatency,
                        Combos=value.Combos,
                        PartNumber=value.PartNumber,
                        RAMSize=value.RAMSize,
                        RAMSpeed=value.RAMSpeed,
                        RAMType=value.RAMType,

                    };
                    OnPropertyChanged();
                    (CreateRamCommand as RelayCommand).NotifyCanExecuteChanged();
                    (UpdateRamCommand as RelayCommand).NotifyCanExecuteChanged();
                    (DeleteRamCommand as RelayCommand).NotifyCanExecuteChanged();
                }

            }
        }

        public ICommand CreateMotherboardCommand { get; set; }
        public ICommand DeleteMotherboardCommand { get; set; }
        public ICommand UpdateMotherboardCommand { get; set; }

        public ICommand CreateCpuCommand { get; set; }
        public ICommand DeleteCpuCommand { get; set; }
        public ICommand UpdateCpuCommand { get; set; }

        public ICommand CreateRamCommand { get; set; }
        public ICommand DeleteRamCommand { get; set; }
        public ICommand UpdateRamCommand { get; set; }

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }
        public MainWindowViewModel()
        {
            
            if (!IsInDesignMode)
            {
                //motherboard
                Motherboards = new RestCollection<Motherboard>("http://localhost:9861/", "motherboard", "hub");
                CreateMotherboardCommand = new RelayCommand(() =>
                {
                    Motherboards.Add(new Motherboard()
                    {
                        Series = SelectedMotherboard.Series,
                        Brand= SelectedMotherboard.Brand,
                        CompatibleProcessors= SelectedMotherboard.CompatibleProcessors,
                        CPUSocket = SelectedMotherboard.CPUSocket,
                        RAMSlot = SelectedMotherboard.RAMSlot,
                        RAMType = SelectedMotherboard.RAMType,
                        MAXRAMSpeed = SelectedMotherboard.MAXRAMSpeed,
                        GPUInterface = SelectedMotherboard.GPUInterface,
                    });
                });
                UpdateMotherboardCommand = new RelayCommand(() =>
                {
                    Motherboards.Update(SelectedMotherboard);
                });

                DeleteMotherboardCommand = new RelayCommand(() =>
                {
                    Motherboards.Delete(SelectedMotherboard.MotherboardId);
                },
                () =>
                {
                    return SelectedMotherboard != null;
                });
                selectedMotherboard = new Motherboard() { Brand = "", CPUSocket = "" };

                //cpu
                Cpus = new RestCollection<CPU>("http://localhost:9861/", "cpu", "hub");
                CreateCpuCommand = new RelayCommand(() =>
                {
                    Cpus.Add(new CPU()
                    {
                        CPUCore = selectedCpu.CPUCore,
                        Combos = selectedCpu.Combos,
                        Brand = selectedCpu.Brand,
                        CPUSocket = selectedCpu.CPUSocket,
                        CPUSpeed = selectedCpu.CPUSpeed,
                        CPUThread = selectedCpu.CPUThread,
                        RAMType = selectedCpu.RAMType,
                        Series = selectedCpu.Series

                    });
                });
                UpdateCpuCommand = new RelayCommand(() =>
                {
                    Cpus.Update(SelectedCpu);
                });

                DeleteCpuCommand = new RelayCommand(() =>
                {
                    Cpus.Delete(SelectedCpu.CPUId);
                },
                () =>
                {
                    return SelectedCpu != null;
                });
                selectedCpu = new CPU() {Brand="", CPUSocket="" };

                //ram
                Rams = new RestCollection<RAM>("http://localhost:9861/", "ram", "hub");
                CreateRamCommand = new RelayCommand(() =>
                {
                    Rams.Add(new RAM()
                    {
                        Brand = selectedRam.Brand,
                        Series = selectedRam.Series,
                        CASLatency = selectedRam.CASLatency,
                        Combos = selectedRam.Combos,
                        PartNumber = selectedRam.PartNumber,
                        RAMSize = selectedRam.RAMSize,
                        RAMSpeed = selectedRam.RAMSpeed,
                        RAMType = selectedRam.RAMType

                    });
                });
                UpdateRamCommand = new RelayCommand(() =>
                {
                    Rams.Update(SelectedRam);
                });

                DeleteRamCommand = new RelayCommand(() =>
                {
                    Rams.Delete(SelectedRam.RAMId);
                },
                () =>
                {
                    return SelectedRam != null;
                });
                selectedRam = new RAM() { Brand = "", RAMType = "" };
            }
        }
    }
}
