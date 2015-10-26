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

namespace VoiceSymbol
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void m00_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Window1 w1 = new Window1();
            w1.Show();
        }

        private void m01_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Window2 w2 = new Window2();
            w2.Show();
        }

        private void m10_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Window3 w3 = new Window3();
            w3.Show();
        }

        private void m11_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Window4 w4 = new Window4();
            w4.Show();
        }
    }
}
