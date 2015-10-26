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

using EyeXFramework;
using Tobii.EyeX.Framework;

namespace VoiceSymbol
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window
    {
        string[] content=new string[9];
        double eyex, eyey;
        int count = 0;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void m00_Click(object sender, RoutedEventArgs e)
        {
            Window1 w1 = new Window1();
            w1.Show();
            content[count] = "我要吃";
            Console.WriteLine("" + content[count]);
            count++;
            Console.WriteLine("" + count);
            if (count == 9) count = 0;
        }

        private void m01_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Window2 w2 = new Window2();
            w2.Show();
            content[count] = "我要喝";
            Console.WriteLine("" + content[count]);
            count++;
            if (count == 9) count = 0;
        }

        private void m10_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Window3 w3 = new Window3();
            w3.Show();
            content[count] = "我想做";
            Console.WriteLine("" + content[count]);
            count++;
            if (count == 9) count = 0;
        }

        private void m11_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Window4 w4 = new Window4();
            w4.Show();
            content[count] = "我想運動";
            Console.WriteLine("" + content[count]);
            count++;
            if (count == 9) count = 0;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Eyetracking();
        }
        private void Eyetracking()
        {
            Console.WriteLine("eyetracking");
            using (var eyeXHost = new EyeXHost())
            {
                eyeXHost.Start();
                using (var lightlyFilteredGazeDataStream = eyeXHost.CreateGazePointDataStream(GazePointDataMode.LightlyFiltered))
                {
                    lightlyFilteredGazeDataStream.Next += (s, e) =>
                    {
                        Console.WriteLine("Gaze point at ({0:0.0}, {1:0.0}) @{2:0}", e.X, e.Y, e.Timestamp);
                        eyex = e.X;
                        eyey = e.Y;
                    };
                    Console.In.Read();
                }
            }
        }

        private void tohome_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            this.Close();
            mainWindow.Show();
        }

        private void c20_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine(content[i]);
            }
        }
    }
}
