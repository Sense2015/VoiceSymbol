//-----------------------------------------------------------------------
// Copyright 2014 Tobii Technology AB. All rights reserved.
//-----------------------------------------------------------------------
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
        //我要吃
        private void m00_Click(object sender, RoutedEventArgs e)
        {
            Window1 w1 = new Window1();
            storage.content[storage.count] = "img11";
            Console.WriteLine("" + storage.content[storage.count]);
            w1.Show();
            w1.win = this;
            canvasdraw();
            viewclose();
        }
        //我要喝
        private void m01_Click(object sender, RoutedEventArgs e)
        {
            Window2 w2 = new Window2();
            storage.content[storage.count] = "img12";
            Console.WriteLine("" + storage.content[storage.count]);
            w2.Show();
            w2.win = this;
            canvasdraw();
            viewclose();
        }
        //我要做
        private void m10_Click(object sender, RoutedEventArgs e)
        {
            Window3 w3 = new Window3();
            storage.content[storage.count] = "img13";
            Console.WriteLine("" + storage.content[storage.count]);
            w3.Show();
            w3.win = this;
            canvasdraw();
            viewclose();
        }
        //我要運動
        private void m11_Click(object sender, RoutedEventArgs e)
        {
            Window4 w4 = new Window4();
            storage.content[storage.count] = "img14";
            Console.WriteLine("" + storage.content[storage.count]);
            w4.Show();
            w4.win = this;
            canvasdraw();
            viewclose();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Eyetracking();
        }
        
        //念整句
        private void c20_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 9; i++)
            {
                Console.Write(storage.content[i] + ",");
            }
            Console.WriteLine("");
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
        string path;
        int index = 1;
        private void _say_Click(object sender, RoutedEventArgs e)
        {
            //int i = 0;
            //while (storage.content[i] != null && i < 9)
            //{
            MediaPlayer player = new MediaPlayer();
            path = @"C:\Sense2015\VoiceSymbol\VoiceSymbol\Sounds\" + storage.content[0] + ".mp3";
            play(path);
            //player.Open(new Uri(@"C:\Sense2015\VoiceSymbol\VoiceSymbol\Sounds\" + storage.content[i] + ".mp3", UriKind.Relative));
            //player.Play();

            //player.MediaEnded += new EventHandler(player_MediaEnded);
            //i++;
            //if (i == 9) break;
            //}

        }
        void play(string p)
        {
            //MediaPlayer player = new MediaPlayer();
            MediaPlayer player = new MediaPlayer();
            player.Open(new Uri(p, UriKind.Relative));
            player.Play();

            player.MediaEnded += new EventHandler(player_MediaEnded);
        }

        void player_MediaEnded(object sender, EventArgs e)
        {
            //if (index >= storage.count - 1)
            if (index >= 9 && storage.content[index - 1] != null)
            {
                index = 1;
                return;
            }

            path = @"C:\Sense2015\VoiceSymbol\VoiceSymbol\Sounds\" + storage.content[index] + ".mp3";
            index++;
            //player.MediaEnded -= new EventHandler(player_MediaEnded);
            play(path);
        }
        //倒退
        private void c00_Click(object sender, RoutedEventArgs e)
        {
            if (storage.count > 0)
            {
                storage.content[storage.count - 1] = null;
                storage.count--;
            }
            canvasdraw();
        }
        //清除
        private void c10_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 9; i++)
            {
                storage.content[i] = null;
            }
            storage.count = 0;
            canvasdraw();
        }
        //發單音
        private void c30_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine(storage.content[storage.count - 1]);
            MediaPlayer player = new MediaPlayer();
            player.Open(new Uri(@"C:\Sense2015\VoiceSymbol\VoiceSymbol\Sounds\" + storage.content[storage.count - 1] + ".mp3", UriKind.Relative));
            player.Play();
        }

        private void l00_Click(object sender, RoutedEventArgs e)
        {
            storage.language = 0;
            MediaPlayer player = new MediaPlayer();
            player.Open(new Uri(@"C:\Sense2015\VoiceSymbol\VoiceSymbol\Sounds\airplane.mp3", UriKind.Relative));
            player.Play();
            Console.WriteLine("test");
        }

        private void l01_Click(object sender, RoutedEventArgs e)
        {
            storage.language = 1;
            MediaPlayer player = new MediaPlayer();
            player.Open(new Uri(@"C:\Sense2015\VoiceSymbol\VoiceSymbol\Sounds\img01.mp3", UriKind.Relative));
            player.Play();
            Console.WriteLine("test");
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
        public void Eyetracking()
        {
            using (var eyeXHost = new EyeXHost())
            {
                // Create a data stream: lightly filtered gaze point data.
                // Other choices of data streams include EyePositionDataStream and FixationDataStream.
                using (var lightlyFilteredGazeDataStream = eyeXHost.CreateGazePointDataStream(GazePointDataMode.LightlyFiltered))
                {
                    // Start the EyeX host.
                    eyeXHost.Start();

                    // Write the data to the console.
                    lightlyFilteredGazeDataStream.Next += (s, e) => Console.WriteLine("Gaze point at ({0:0.0}, {1:0.0}) @{2:0}", e.X, e.Y, e.Timestamp);

                    // Let it run until a key is pressed.
                    Console.WriteLine("Listening for gaze data, press any key to exit...");
                    Console.In.Read();
                }
            }
        }
    }
}

