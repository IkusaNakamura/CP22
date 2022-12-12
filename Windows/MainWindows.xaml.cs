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

namespace CP22.Windows
{
    /// <summary>
    /// Логика взаимодействия для MainWindows.xaml
    /// </summary>
    public partial class MainWindows : Window
    {
        public MainWindows()
        {
            InitializeComponent();
            ManegerFrames.MainFrame = frame;
            frame.Navigate(new Pages.StartPage());
        }

        private void Click_MainToInViewCards(object sender, RoutedEventArgs e)
        {
            ManegerFrames.MainFrame.Navigate(new Pages.ViewCards());
        }

        private void Click_NaviBackButton(object sender, RoutedEventArgs e)
        {
            if (ManegerFrames.MainFrame.CanGoBack) { ManegerFrames.MainFrame.GoBack(); }
        }

        private void MainFrame_ContentRender(object sender, EventArgs e)
        {
            if (!ManegerFrames.MainFrame.CanGoBack) backNavigwteFrame.Visibility = Visibility.Hidden;
            else backNavigwteFrame.Visibility = Visibility.Visible;
        }

        private void Click_MainToInUsers(object sender, RoutedEventArgs e)
        {
            ManegerFrames.MainFrame.Navigate(new Pages.ViewUsers());
        }

        private void startpage_Click(object sender, RoutedEventArgs e)
        {
            ManegerFrames.MainFrame.Navigate(new Pages.StartPage());
        }

        private void typscardViwe_Click(object sender, RoutedEventArgs e)
        {
            ManegerFrames.MainFrame.Navigate(new Pages.ViewTypsCards());
        }

        private void patients_Click(object sender, RoutedEventArgs e)
        {
            //ManegerFrames.MainFrame.Navigate(new );
        }
    }
}
