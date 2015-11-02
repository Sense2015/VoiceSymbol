//-----------------------------------------------------------------------
// Copyright 2014 Tobii Technology AB. All rights reserved.
//-----------------------------------------------------------------------

namespace GazeAwareElements
{
    using System;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    using EyeXFramework.Wpf;
    using EyeXFramework;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            Console.WriteLine("MainWindow");
            InitializeComponent();
            Message = string.Empty;
        }

        public string Message { get; private set; }

        /// <summary>
        /// Handler for Behavior.HasGazeChanged events for the instruction text block.
        /// </summary>
        private void Instruction_OnHasGazeChanged(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Instruction_OnHasGazeChanged");
            var textBlock = e.Source as TextBlock;
            if (null == textBlock) { return; }

            var model = (MainWindowModel)DataContext;
            var hasGaze = textBlock.GetHasGaze();
            model.NotifyInstructionHasGazeChanged(hasGaze);
        }

        private void Window_KeyDown_1(object sender, KeyEventArgs e)
        {
            Console.WriteLine("Key");
            if (e.Key == Key.Q)
            {
                Console.WriteLine("Q");
                Close();
            }
            else if (e.Key == Key.C)
            {
                Console.WriteLine("C");
                var model = (MainWindowModel)DataContext;
                model.CloseInstruction();
            }
        }

        private void Instruction_OnMouseEnter(object sender, MouseEventArgs e)
        {
            Console.WriteLine("mouse_enter");
            var model = (MainWindowModel)DataContext;
            model.NotifyInstructionHasGazeChanged(true);
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //grid.Children.Clear();
            pictureBox1_Paint(sender,e);
        }
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            int picBoxWidth = pictureBox1.Size.Width;
            int picBoxHeight = pictureBox1.Size.Height;
            int halfWidth = pictureBox1.Size.Width / 2;
            int halfHeight = pictureBox1.Size.Height / 2;
            Graphics objGraphic = e.Graphics; //**請注意這一行**
            Pen pen = new Pen(Color.Black);
            int b = 2; int m = 2; for (int x = 0; x < 426; x++)
            {
                int y = m * x + b; x = (y - b) / m;
                objGraphic.DrawLine(pen, x, y, -x, -y);
                System.Drawing.Drawing2D.GraphicsState graph = objGraphic.Save();
                objGraphic.Restore(graph);
            }
            objGraphic.DrawLine(pen, 0, halfHeight, picBoxWidth, halfHeight);
            objGraphic.DrawLine(pen, halfWidth, 0, halfWidth, picBoxHeight);
            objGraphic.DrawLine(pen, 20, 20, 300, 300);
        }
        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            Eye();
        }
        private void Eye()
        {
            using (var eyeXHost = new EyeXHost())
            {
                eyeXHost.Start();

                using (var stream = eyeXHost.CreateEyePositionDataStream())
                {
                    stream.Next += (s, e) =>
                    {
                        Console.SetCursorPosition(0, 0);

                        // Output information about the left eye.
                        Console.WriteLine("LEFT EYE");
                        Console.WriteLine("========");
                        Console.WriteLine("3D Position: ({0:0.0}, {1:0.0}, {2:0.0})                   ",
                            e.LeftEye.X, e.LeftEye.Y, e.LeftEye.Z);
                        Console.WriteLine("Normalized : ({0:0.0}, {1:0.0}, {2:0.0})                   ",
                            e.LeftEyeNormalized.X, e.LeftEyeNormalized.Y, e.LeftEyeNormalized.Z);

                        // Output information about the right eye.
                        Console.WriteLine();
                        Console.WriteLine("RIGHT EYE");
                        Console.WriteLine("=========");
                        Console.WriteLine("3D Position: {0:0.0}, {1:0.0}, {2:0.0}                   ",
                            e.RightEye.X, e.RightEye.Y, e.RightEye.Z);
                        Console.WriteLine("Normalized : {0:0.0}, {1:0.0}, {2:0.0}                   ",
                            e.RightEyeNormalized.X, e.RightEyeNormalized.Y, e.RightEyeNormalized.Z);
                    };
                    
                    Console.SetCursorPosition(0, 12);
                    Console.WriteLine("");
                    Console.WriteLine("The 3D position consists of X,Y,Z coordinates expressed in millimeters");
                    Console.WriteLine("in relation to the center of the screen where the eye tracker is mounted.");
                    Console.WriteLine("\n");
                    Console.WriteLine("The normalized coordinates are expressed in relation to the track box,");
                    Console.WriteLine("i.e. the volume in which the eye tracker is theoretically able to track eyes.");
                    Console.WriteLine("- (0,0,0) represents the upper, right corner closest to the eye tracker.");
                    Console.WriteLine("- (1,1,1) represents the lower, left corner furthest away from the eye tracker.");
                    Console.WriteLine();
                    Console.WriteLine("---------------------------------------------------------");
                    Console.WriteLine("Listening for eye position data, press any key to exit...");

                    Console.In.Read();
                }
            }
        }
    }
}
