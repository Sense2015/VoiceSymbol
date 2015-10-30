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
        public MainWindow win;
        public Window4()
        {
            InitializeComponent();
        }
        public void viewclose()
        {
            win.canvasdraw();
            storage.count++;
            if (storage.count == 9) storage.count = 0;
            this.Close();
        }
        private void x00_Click(object sender, RoutedEventArgs e)
        {
            storage.content[storage.count] = "img34";
            viewclose();
        }

        private void x01_Click(object sender, RoutedEventArgs e)
        {
            storage.content[storage.count] = "img35";
            viewclose();
        }

        private void x02_Click(object sender, RoutedEventArgs e)
        {
            storage.content[storage.count] = "img36";
            viewclose();
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
        //回首頁
        private void _home_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        //倒退
        private void _back_Click(object sender, RoutedEventArgs e)
        {
            if (storage.count > 0)
            {
                storage.content[storage.count - 1] = null;
                storage.count--;
            }
            canvasdraw();
        }
        //清除
        private void _delete_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 9; i++)
            {
                storage.content[i] = null;
            }
            storage.count = 0;
            canvasdraw();
        }
        //念整句
        private void _say_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 9; i++)
            {
                Console.Write(storage.content[i] + ",");
            }
            Console.WriteLine("");
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            canvasdraw();
        }
        public void canvasdraw()
        {
            canvas1.Children.Clear();
            int i = 0;

            while (storage.content[i] != null && i < 9)
            {
                double width = (this.canvas1.ActualWidth - (9 + 1) * 5) / 9;
                double height = (this.canvas1.ActualHeight - (1 + 1) * 5) / 1;
                Image ig = new Image()
                {
                    Width = width,
                    Height = height,
                };
                canvas1.Children.Add(ig);
                Canvas.SetTop(ig, 0 * height + 5);
                Canvas.SetLeft(ig, i * width + 5);

                ig.Source = ((Image)TryFindResource(storage.content[i])).Source;
                i++;
                if (i == 9) break;
            }
        }
    }
}
