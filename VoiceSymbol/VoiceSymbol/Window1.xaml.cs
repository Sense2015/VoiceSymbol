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
using System.Windows.Shapes;

namespace VoiceSymbol
{
    /// <summary>
    /// Window1.xaml 的互動邏輯
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }
        public void viewclose()
        {
            storage.count++;
            if (storage.count == 9) storage.count = 0;
            this.Close();
        }
        private void x00_Click(object sender, RoutedEventArgs e)
        {
            //Console.WriteLine("" + storage.count);
            storage.content[storage.count] = "Astro";
            viewclose();
        }
        private void x01_Click(object sender, RoutedEventArgs e)
        {
            storage.content[storage.count] = "Bender";
            viewclose();
        }
        private void x02_Click(object sender, RoutedEventArgs e)
        {
            storage.content[storage.count] = "Cupcake";
            viewclose();
        }
        private void x03_Click(object sender, RoutedEventArgs e)
        {
            storage.content[storage.count] = "Donut";
            viewclose();
        }
        private void x23_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void _home_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void _say_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 9; i++)
            {
                Console.Write(storage.content[i]);
            }
        }
    }
}
