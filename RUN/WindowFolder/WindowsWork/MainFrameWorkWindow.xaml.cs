using MaterialDesignThemes.Wpf;
using RUN.ClassFolder;
using RUN.PageFolder;
using RUN.PageFolder.WorkPages;
using RUN.WindowFolder.WindowsWelcome;
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

namespace RUN.WindowFolder.WindowsWork
{
    /// <summary>
    /// Логика взаимодействия для MainFrameWindow.xaml
    /// </summary>
    public partial class MainFrameWorkWindow : Window
    {
        public MainFrameWorkWindow()
        {
            InitializeComponent();

            MainFrame.Navigate(new MenuWorkPage());
        }

        private void BMainMenu_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new MenuWorkPage());

            IMainMenu.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 255, 226));
            TMainMenu.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 255, 226));

            IListZakaz.Foreground = new SolidColorBrush(Color.FromArgb(255, 224, 224, 224));
            TListZakaz.Foreground = new SolidColorBrush(Color.FromArgb(255, 224, 224, 224));
        }

        private void BListZakaz_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new ListZakazPage());

            IListZakaz.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 255, 226));
            TListZakaz.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 255, 226));

            IMainMenu.Foreground = new SolidColorBrush(Color.FromArgb(255, 224, 224, 224));
            TMainMenu.Foreground = new SolidColorBrush(Color.FromArgb(255, 224, 224, 224));
        }

        private void BRollUp_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void BClose_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }

        private void BLogOut_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            new AuthorizationWindow().ShowDialog();
            this.Close();
        }
    }
}
