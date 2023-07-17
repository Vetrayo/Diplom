using MaterialDesignThemes.Wpf;
using RUN.ClassFolder;
using RUN.PageFolder;
using RUN.PageFolder.AdminPages;
using RUN.PageFolder.UserPages;
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

namespace RUN.WindowFolder.WindowsUser
{
    /// <summary>
    /// Логика взаимодействия для MainFrameUserWindow.xaml
    /// </summary>
    public partial class MainFrameUserWindow : Window
    {
        public MainFrameUserWindow()
        {
            InitializeComponent();

            MainFrame.Navigate(new MenuUserPage());
        }

        private void BMainMenu_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new MenuUserPage());

            IMainMenu.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 255, 226));
            TMainMenu.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 255, 226));

            ICatalog.Foreground = new SolidColorBrush(Color.FromArgb(255, 224, 224, 224));
            TCatalog.Foreground = new SolidColorBrush(Color.FromArgb(255, 224, 224, 224));
            IOrderUsluga.Foreground = new SolidColorBrush(Color.FromArgb(255, 224, 224, 224));
            TOrderUsluga.Foreground = new SolidColorBrush(Color.FromArgb(255, 224, 224, 224));
            IListMyOrders.Foreground = new SolidColorBrush(Color.FromArgb(255, 224, 224, 224));
            TListMyOrders.Foreground = new SolidColorBrush(Color.FromArgb(255, 224, 224, 224));
        }

        private void BCatalog_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new ListCatalogPage());

            ICatalog.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 255, 226));
            TCatalog.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 255, 226));

            IMainMenu.Foreground = new SolidColorBrush(Color.FromArgb(255, 224, 224, 224));
            TMainMenu.Foreground = new SolidColorBrush(Color.FromArgb(255, 224, 224, 224));
            IOrderUsluga.Foreground = new SolidColorBrush(Color.FromArgb(255, 224, 224, 224));
            TOrderUsluga.Foreground = new SolidColorBrush(Color.FromArgb(255, 224, 224, 224));
            IListMyOrders.Foreground = new SolidColorBrush(Color.FromArgb(255, 224, 224, 224));
            TListMyOrders.Foreground = new SolidColorBrush(Color.FromArgb(255, 224, 224, 224));
        }

        private void BOrderUsluga_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new ZakazPage());

            IOrderUsluga.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 255, 226));
            TOrderUsluga.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 255, 226));

            IMainMenu.Foreground = new SolidColorBrush(Color.FromArgb(255, 224, 224, 224));
            TMainMenu.Foreground = new SolidColorBrush(Color.FromArgb(255, 224, 224, 224));
            ICatalog.Foreground = new SolidColorBrush(Color.FromArgb(255, 224, 224, 224));
            TCatalog.Foreground = new SolidColorBrush(Color.FromArgb(255, 224, 224, 224));
            IListMyOrders.Foreground = new SolidColorBrush(Color.FromArgb(255, 224, 224, 224));
            TListMyOrders.Foreground = new SolidColorBrush(Color.FromArgb(255, 224, 224, 224));
        }

        private void BListMyOrders_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new ListUserZakazPage());

            IListMyOrders.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 255, 226));
            TListMyOrders.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 255, 226));

            IMainMenu.Foreground = new SolidColorBrush(Color.FromArgb(255, 224, 224, 224));
            TMainMenu.Foreground = new SolidColorBrush(Color.FromArgb(255, 224, 224, 224));
            ICatalog.Foreground = new SolidColorBrush(Color.FromArgb(255, 224, 224, 224));
            TCatalog.Foreground = new SolidColorBrush(Color.FromArgb(255, 224, 224, 224));
            IOrderUsluga.Foreground = new SolidColorBrush(Color.FromArgb(255, 224, 224, 224));
            TOrderUsluga.Foreground = new SolidColorBrush(Color.FromArgb(255, 224, 224, 224));
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
