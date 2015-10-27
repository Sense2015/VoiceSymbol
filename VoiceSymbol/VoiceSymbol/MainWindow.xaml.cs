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
        //string[] content=new string[9];
        double eyex, eyey;
        Image[] view;
        //int count = 0;
        //storage sto = new storage();
        //string[] content = new string[9];
        public MainWindow()
        {
            InitializeComponent();
        }
        public void viewclose()
        {
            storage.count++;
            if (storage.count == 9) storage.count = 0;
        }
        private void m00_Click(object sender, RoutedEventArgs e)
        {
            Window1 w1 = new Window1();
            w1.Show();

            canvas1.Children.Clear();
            double width = (this.canvas1.ActualWidth - (9 + 1) * 5) / 9; 
            double height = (this.canvas1.ActualHeight - (1 + 1) * 5) / 1;
            Image ig = new Image()
            {
                Width = width,
                Height = height,
            };
            Canvas.SetTop(ig, 0 * height + 5);
            Canvas.SetLeft(ig, storage.count * width + 5);
            canvas1.Children.Add(ig);
            ig.Source = ((Image)TryFindResource("img16")).Source;

            storage.content[storage.count] = "我要吃";
            Console.WriteLine("" + storage.content[storage.count]);
            viewclose();
        }

        private void m01_Click(object sender, RoutedEventArgs e)
        {
            Window2 w2 = new Window2();
            w2.Show();
            storage.content[storage.count] = "我要喝";
            Console.WriteLine("" + storage.content[storage.count]);
            viewclose();
        }

        private void m10_Click(object sender, RoutedEventArgs e)
        {
            Window3 w3 = new Window3();
            w3.Show();
            storage.content[storage.count] = "我想做";
            Console.WriteLine("" + storage.content[storage.count]);
            viewclose();
        }

        private void m11_Click(object sender, RoutedEventArgs e)
        {
            Window4 w4 = new Window4();
            w4.Show();
            storage.content[storage.count] = "我想運動";
            Console.WriteLine("" + storage.content[storage.count]);
            viewclose();
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

        private void c20_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 9; i++)
            {
                Console.Write(storage.content[i]);
            }
            Console.WriteLine("");
        }

        private void _back_Click(object sender, RoutedEventArgs e)
        {
            storage.content[storage.count] = null;
            if(storage.count>0) storage.count-- ;
        }

        private void _delete_Click(object sender, RoutedEventArgs e)
        {
            
            for (int i = 0; i < 9; i++)
            {
                storage.content[i] = null;
            }
            storage.count = 0;
        }

        private void _say_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 9; i++)
            {
                Console.Write(storage.content[i]);
            }
            Console.WriteLine("");
        }

        private void c00_Click(object sender, RoutedEventArgs e)
        {
            storage.content[storage.count] = null;
            if (storage.count > 0) storage.count--;
        }

        private void c10_Click(object sender, RoutedEventArgs e)
        {
            storage.content[storage.count] = null;
            if (storage.count > 0) storage.count--;
        }

        private void c30_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine(storage.content[storage.count-1]);
        }

        private void l00_Click(object sender, RoutedEventArgs e)
        {
            storage.language = 0;
            MediaPlayer player = new MediaPlayer();
            player.Open(new Uri(@"airplane.mp3", UriKind.Relative));
            player.Play();
            Console.WriteLine("test");
        }

        private void l01_Click(object sender, RoutedEventArgs e)
        {
            storage.language = 1;
        }
    }
}
