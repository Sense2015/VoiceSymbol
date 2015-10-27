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
    /// Window2.xaml 的互動邏輯
    /// </summary>
    public partial class Window2 : Window
    {
        public Window2()
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
            storage.content[storage.count] = "Eclair";
            viewclose();
        }
        private void x01_Click(object sender, RoutedEventArgs e)
        {
            storage.content[storage.count] = "Froyo";
            viewclose();
        }
        private void x02_Click(object sender, RoutedEventArgs e)
        {
            storage.content[storage.count] = "Gingerbread";
            viewclose();
        }
        private void x03_Click(object sender, RoutedEventArgs e)
        {
            storage.content[storage.count] = "Honey";
            viewclose();
        }
        private void x23_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void _home_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
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
