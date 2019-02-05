using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
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

namespace Photoer
{
    public partial class PhotoWindow : Window
    {
        [DllImport("User32.dll")]
        private static extern bool SetCursorPos(int x, int y);

        private string PhotoDirectory;
        public string SelectedDirectory
        {
            get { return PhotoDirectory; }
            set { PhotoDirectory = value; }
        }

        double currentScale = 1.0;
        ScaleTransform scaleTransform;
        TranslateTransform translateTransform;
        double offsetX = 0;
        double offsetY = 0;

        Point lastPosition;

        private int PhotoIndex;
        private string[] PhotoList;

        public PhotoWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.Cursor = Cursors.None;
            WindowStyle = WindowStyle.None;
            Width = SystemParameters.PrimaryScreenWidth;
            Height = SystemParameters.PrimaryScreenHeight;
            Left = 0;
            Top = 0;
            SetCursorPos((int)SystemParameters.PrimaryScreenWidth / 2, (int)SystemParameters.PrimaryScreenHeight / 2);
            lastPosition = new Point((SystemParameters.PrimaryScreenWidth / 2) - 7, (SystemParameters.PrimaryScreenHeight / 2) - 7);
            PhotoList = Directory.GetFiles(PhotoDirectory);
            PhotoIndex = 0;
            LoadPhoto();
        }

        private void LoadPhoto()
        {
            if (PhotoIndex > PhotoList.Length - 1) PhotoIndex = 0;
            if (PhotoIndex < 0) PhotoIndex = PhotoList.Length - 1;
            ImageSource imageSource = new BitmapImage(new Uri(PhotoList[PhotoIndex]));
            PhotoBox.Source = imageSource;
        }

        private void Window_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            if (e.Delta > 0)
            {
                currentScale += 0.1;
                //if (currentScale > 2.66) currentScale = 2.66;
            }
            else if (e.Delta < 0)
            {
                currentScale -= 0.1;
                if (currentScale < 0.66) currentScale = 0.66;
            }
            if (currentScale > 0.66)
            {
                TransformGroup transformGroup = new TransformGroup();
                scaleTransform = new ScaleTransform(currentScale, currentScale, PhotoBox.ActualWidth / 2, PhotoBox.ActualHeight / 2);
                if(translateTransform != null) transformGroup.Children.Add(translateTransform);
                transformGroup.Children.Add(scaleTransform);
                PhotoBox.RenderTransform = transformGroup;
                SetCursorPos((int)SystemParameters.PrimaryScreenWidth / 2, (int)SystemParameters.PrimaryScreenHeight / 2);
                lastPosition = new Point((SystemParameters.PrimaryScreenWidth / 2) - 7, (SystemParameters.PrimaryScreenHeight / 2) - 7);
            }
        }

        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
            if (currentScale != 1.0)
            {
                Point actualPosition = e.GetPosition(this);
                offsetX += actualPosition.X - lastPosition.X;
                offsetY += actualPosition.Y - lastPosition.Y;
                TransformGroup transformGroup = new TransformGroup();
                translateTransform = new TranslateTransform(offsetX, offsetY);
                if (scaleTransform != null) transformGroup.Children.Add(scaleTransform);
                transformGroup.Children.Add(translateTransform);
                PhotoBox.RenderTransform = transformGroup;
                SetCursorPos((int)SystemParameters.PrimaryScreenWidth / 2, (int)SystemParameters.PrimaryScreenHeight / 2);
                lastPosition = new Point((SystemParameters.PrimaryScreenWidth / 2) - 7, (SystemParameters.PrimaryScreenHeight / 2) - 7);
            }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.None:
                    break;
                case Key.Cancel:
                    break;
                case Key.Back:
                    break;
                case Key.Tab:
                    break;
                case Key.LineFeed:
                    break;
                case Key.Clear:
                    break;
                case Key.Enter:
                    break;
                case Key.Pause:
                    break;
                case Key.CapsLock:
                    break;
                case Key.Escape:
                    Close();
                    break;
                case Key.ImeConvert:
                    break;
                case Key.ImeNonConvert:
                    break;
                case Key.ImeAccept:
                    break;
                case Key.ImeModeChange:
                    break;
                case Key.Space:
                    currentScale = 1.0;
                    offsetX = 0;
                    offsetY = 0;
                    scaleTransform = null;
                    translateTransform = null;
                    PhotoBox.RenderTransform = null;
                    LoadPhoto();
                    break;
                case Key.PageUp:
                    break;
                case Key.PageDown:
                    break;
                case Key.End:
                    break;
                case Key.Home:
                    break;
                case Key.Left:
                    PhotoIndex--;
                    LoadPhoto();
                    break;
                case Key.Up:
                    break;
                case Key.Right:
                    PhotoIndex++;
                    LoadPhoto();
                    break;
                case Key.Down:
                    break;
                case Key.Select:
                    break;
                case Key.Print:
                    break;
                case Key.Execute:
                    break;
                case Key.PrintScreen:
                    break;
                case Key.Insert:
                    break;
                case Key.Delete:
                    break;
                case Key.Help:
                    break;
                case Key.D0:
                    break;
                case Key.D1:
                    break;
                case Key.D2:
                    break;
                case Key.D3:
                    break;
                case Key.D4:
                    break;
                case Key.D5:
                    break;
                case Key.D6:
                    break;
                case Key.D7:
                    break;
                case Key.D8:
                    break;
                case Key.D9:
                    break;
                case Key.A:
                    break;
                case Key.B:
                    break;
                case Key.C:
                    break;
                case Key.D:
                    break;
                case Key.E:
                    break;
                case Key.F:
                    break;
                case Key.G:
                    break;
                case Key.H:
                    break;
                case Key.I:
                    break;
                case Key.J:
                    break;
                case Key.K:
                    break;
                case Key.L:
                    break;
                case Key.M:
                    break;
                case Key.N:
                    break;
                case Key.O:
                    break;
                case Key.P:
                    break;
                case Key.Q:
                    break;
                case Key.R:
                    break;
                case Key.S:
                    break;
                case Key.T:
                    break;
                case Key.U:
                    break;
                case Key.V:
                    break;
                case Key.W:
                    break;
                case Key.X:
                    break;
                case Key.Y:
                    break;
                case Key.Z:
                    break;
                case Key.LWin:
                    break;
                case Key.RWin:
                    break;
                case Key.Apps:
                    break;
                case Key.Sleep:
                    break;
                case Key.NumPad0:
                    break;
                case Key.NumPad1:
                    break;
                case Key.NumPad2:
                    break;
                case Key.NumPad3:
                    break;
                case Key.NumPad4:
                    break;
                case Key.NumPad5:
                    break;
                case Key.NumPad6:
                    break;
                case Key.NumPad7:
                    break;
                case Key.NumPad8:
                    break;
                case Key.NumPad9:
                    break;
                case Key.Multiply:
                    break;
                case Key.Add:
                    break;
                case Key.Separator:
                    break;
                case Key.Subtract:
                    break;
                case Key.Decimal:
                    break;
                case Key.Divide:
                    break;
                case Key.F1:
                    break;
                case Key.F2:
                    break;
                case Key.F3:
                    break;
                case Key.F4:
                    break;
                case Key.F5:
                    break;
                case Key.F6:
                    break;
                case Key.F7:
                    break;
                case Key.F8:
                    break;
                case Key.F9:
                    break;
                case Key.F10:
                    break;
                case Key.F11:
                    break;
                case Key.F12:
                    break;
                case Key.F13:
                    break;
                case Key.F14:
                    break;
                case Key.F15:
                    break;
                case Key.F16:
                    break;
                case Key.F17:
                    break;
                case Key.F18:
                    break;
                case Key.F19:
                    break;
                case Key.F20:
                    break;
                case Key.F21:
                    break;
                case Key.F22:
                    break;
                case Key.F23:
                    break;
                case Key.F24:
                    break;
                case Key.NumLock:
                    break;
                case Key.Scroll:
                    break;
                case Key.LeftShift:
                    break;
                case Key.RightShift:
                    break;
                case Key.LeftCtrl:
                    break;
                case Key.RightCtrl:
                    break;
                case Key.LeftAlt:
                    break;
                case Key.RightAlt:
                    break;
                case Key.BrowserBack:
                    break;
                case Key.BrowserForward:
                    break;
                case Key.BrowserRefresh:
                    break;
                case Key.BrowserStop:
                    break;
                case Key.BrowserSearch:
                    break;
                case Key.BrowserFavorites:
                    break;
                case Key.BrowserHome:
                    break;
                case Key.VolumeMute:
                    break;
                case Key.VolumeDown:
                    break;
                case Key.VolumeUp:
                    break;
                case Key.MediaNextTrack:
                    break;
                case Key.MediaPreviousTrack:
                    break;
                case Key.MediaStop:
                    break;
                case Key.MediaPlayPause:
                    break;
                case Key.LaunchMail:
                    break;
                case Key.SelectMedia:
                    break;
                case Key.LaunchApplication1:
                    break;
                case Key.LaunchApplication2:
                    break;
                default:
                    break;
            }
        }

    }
}
