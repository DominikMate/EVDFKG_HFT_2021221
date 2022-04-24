using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EVDFKG_HFT_2021221.WPFClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void l_mot_MouseDown(object sender, MouseButtonEventArgs e)
        {
            l_mot.Background = Brushes.LightBlue;
            l_cpu.Background = Brushes.White;
            l_ram.Background = Brushes.White;
            l2_mot.Visibility = Visibility.Visible;
            l2_cpu.Visibility = Visibility.Hidden;
            l2_ram.Visibility = Visibility.Hidden;
            sw_mot.Visibility = Visibility.Visible; sw_mot.IsEnabled = true;
            sw_cpu.Visibility = Visibility.Hidden; sw_cpu.IsEnabled = false;
            sw_ram.Visibility = Visibility.Hidden; sw_ram.IsEnabled = false;
            s_mot.Visibility = Visibility.Visible;
            s_cpu.Visibility = Visibility.Hidden;
            s_ram.Visibility = Visibility.Hidden;
            s_mot.IsEnabled = true;
            s_cpu.IsEnabled = false;
            s_ram.IsEnabled = false;
            svmot.Visibility = Visibility.Visible; svmot.IsEnabled = true;
            svcpu.Visibility=Visibility.Hidden; svcpu.IsEnabled = false;
            svram.Visibility = Visibility.Hidden; svram.IsEnabled = false;
        }

        private void l_cpu_MouseDown(object sender, MouseButtonEventArgs e)
        {
            l_mot.Background = Brushes.White;
            l_cpu.Background = Brushes.LightBlue;
            l_ram.Background = Brushes.White;
            l2_mot.Visibility = Visibility.Hidden;
            l2_cpu.Visibility = Visibility.Visible;
            l2_ram.Visibility = Visibility.Hidden;
            sw_mot.Visibility = Visibility.Hidden; sw_mot.IsEnabled = false;
            sw_cpu.Visibility = Visibility.Visible; sw_cpu.IsEnabled = true;
            sw_ram.Visibility = Visibility.Hidden; sw_ram.IsEnabled = false;
            s_cpu.Visibility = Visibility.Visible;
            s_ram.Visibility = Visibility.Hidden;
            s_mot.IsEnabled = false;
            s_cpu.IsEnabled = true;
            s_ram.IsEnabled = false;
            svmot.Visibility = Visibility.Hidden; svmot.IsEnabled = false;
            svcpu.Visibility = Visibility.Visible; svcpu.IsEnabled = true;
            svram.Visibility = Visibility.Hidden; svram.IsEnabled = false;
        }

        private void l_ram_MouseDown(object sender, MouseButtonEventArgs e)
        {
            l_mot.Background = Brushes.White;
            l_cpu.Background = Brushes.White;
            l_ram.Background = Brushes.LightBlue;
            l2_mot.Visibility = Visibility.Hidden;
            l2_cpu.Visibility = Visibility.Hidden;
            l2_ram.Visibility = Visibility.Visible;
            sw_mot.Visibility = Visibility.Hidden; sw_mot.IsEnabled = false;
            sw_cpu.Visibility = Visibility.Hidden; sw_cpu.IsEnabled = false;
            sw_ram.Visibility = Visibility.Visible; sw_ram.IsEnabled = true;
            s_cpu.Visibility = Visibility.Hidden;
            s_ram.Visibility = Visibility.Visible;
            s_mot.IsEnabled = false;
            s_cpu.IsEnabled = false;
            s_ram.IsEnabled = true;
            svmot.Visibility = Visibility.Hidden; svmot.IsEnabled = false;
            svcpu.Visibility = Visibility.Hidden; svcpu.IsEnabled = false;
            svram.Visibility = Visibility.Visible; svram.IsEnabled = true;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            l_mot.Background = Brushes.LightBlue;
            l_cpu.Background = Brushes.White;
            l_ram.Background = Brushes.White;
            l2_mot.Visibility = Visibility.Visible;
            l2_cpu.Visibility = Visibility.Hidden;
            l2_ram.Visibility = Visibility.Hidden;
            sw_mot.Visibility = Visibility.Visible; sw_mot.IsEnabled = true;
            sw_cpu.Visibility = Visibility.Hidden; sw_cpu.IsEnabled = false;
            sw_ram.Visibility = Visibility.Hidden; sw_ram.IsEnabled = false;
            s_mot.Visibility = Visibility.Visible;
            s_cpu.Visibility = Visibility.Hidden;
            s_ram.Visibility = Visibility.Hidden;
            s_mot.IsEnabled = true;
            s_cpu.IsEnabled = false;
            s_ram.IsEnabled = false;
            svmot.Visibility = Visibility.Visible; svmot.IsEnabled = true;
            svcpu.Visibility = Visibility.Hidden; svcpu.IsEnabled = false;
            svram.Visibility = Visibility.Hidden; svram.IsEnabled = false;
        }
    }
}
