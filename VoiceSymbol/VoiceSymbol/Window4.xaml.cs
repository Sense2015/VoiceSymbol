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
    /// Window4.xaml 的互動邏輯
    /// </summary>
    public partial class Window4 : Window
    {
        public Window4()
        {
            InitializeComponent();
        }
        public void viewclose()
        {
            storage.count++;
            if (storage.count == 9) storage.count = 0;
            this.Close();
        }
        
        private void _home_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void x00_Click(object sender, RoutedEventArgs e)
        {

        }

        private void x01_Click(object sender, RoutedEventArgs e)
        {

        }

        private void x02_Click(object sender, RoutedEventArgs e)
        {

        }

        private void x10_Click(object sender, RoutedEventArgs e)
        {

        }

        private void x11_Click(object sender, RoutedEventArgs e)
        {

        }

        private void x12_Click(object sender, RoutedEventArgs e)
        {

        }

        private void x20_Click(object sender, RoutedEventArgs e)
        {
            viewclose();
        }

        private void x21_Click(object sender, RoutedEventArgs e)
        {
            viewclose();
        }
        private void x22_Click(object sender, RoutedEventArgs e)
        {
            viewclose();
        }

        private void _say_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 9; i++)
            {
                Console.Write(storage.content[i]);
            }
            Console.WriteLine("");
        }
    }
}
