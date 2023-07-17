using MaterialDesignThemes.Wpf;
using RUN.ClassFolder;
using RUN.PageFolder;
using RUN.PageFolder.AdminPages;
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
using WpfAnimatedGif;

namespace RUN.WindowFolder.WindowsAdmin
{
    /// <summary>
    /// Логика взаимодействия для MainFrameWindow.xaml
    /// </summary>
    public partial class MainFrameAdminWindow : Window
    {
        public MainFrameAdminWindow()
        {
            InitializeComponent();

            MainFrame.Navigate(new MenuAdminPage());
        }

        private void BMainMenu_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new MenuAdminPage());

            IMainMenu.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 255, 226));
            TMainMenu.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 255, 226));

            IListProduct.Foreground = new SolidColorBrush(Color.FromArgb(255, 224, 224, 224));
            TListProducts.Foreground = new SolidColorBrush(Color.FromArgb(255, 224, 224, 224));
            IListUsers.Foreground = new SolidColorBrush(Color.FromArgb(255, 224, 224, 224));
            TListUsers.Foreground = new SolidColorBrush(Color.FromArgb(255, 224, 224, 224));
            IListWork.Foreground = new SolidColorBrush(Color.FromArgb(255, 224, 224, 224));
            TListWork.Foreground = new SolidColorBrush(Color.FromArgb(255, 224, 224, 224));
            IListZakaz.Foreground = new SolidColorBrush(Color.FromArgb(255, 224, 224, 224));
            TListZakaz.Foreground = new SolidColorBrush(Color.FromArgb(255, 224, 224, 224));
        }

        private void BListProduct_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new ListProductsPage());

            IListProduct.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 255, 226));
            TListProducts.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 255, 226));

            IMainMenu.Foreground = new SolidColorBrush(Color.FromArgb(255, 224, 224, 224));
            TMainMenu.Foreground = new SolidColorBrush(Color.FromArgb(255, 224, 224, 224));
            IListUsers.Foreground = new SolidColorBrush(Color.FromArgb(255, 224, 224, 224));
            TListUsers.Foreground = new SolidColorBrush(Color.FromArgb(255, 224, 224, 224));
            IListWork.Foreground = new SolidColorBrush(Color.FromArgb(255, 224, 224, 224));
            TListWork.Foreground = new SolidColorBrush(Color.FromArgb(255, 224, 224, 224));
            IListZakaz.Foreground = new SolidColorBrush(Color.FromArgb(255, 224, 224, 224));
            TListZakaz.Foreground = new SolidColorBrush(Color.FromArgb(255, 224, 224, 224));
        }

        private void BListWork_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new ListWorkerPage());

            IListWork.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 255, 226));
            TListWork.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 255, 226));

            IMainMenu.Foreground = new SolidColorBrush(Color.FromArgb(255, 224, 224, 224));
            TMainMenu.Foreground = new SolidColorBrush(Color.FromArgb(255, 224, 224, 224));
            IListUsers.Foreground = new SolidColorBrush(Color.FromArgb(255, 224, 224, 224));
            TListUsers.Foreground = new SolidColorBrush(Color.FromArgb(255, 224, 224, 224));
            IListProduct.Foreground = new SolidColorBrush(Color.FromArgb(255, 224, 224, 224));
            TListProducts.Foreground = new SolidColorBrush(Color.FromArgb(255, 224, 224, 224));
            IListZakaz.Foreground = new SolidColorBrush(Color.FromArgb(255, 224, 224, 224));
            TListZakaz.Foreground = new SolidColorBrush(Color.FromArgb(255, 224, 224, 224));
        }

        private void BListUsers_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new ListUsersPage());

            IListUsers.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 255, 226));
            TListUsers.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 255, 226));

            IMainMenu.Foreground = new SolidColorBrush(Color.FromArgb(255, 224, 224, 224));
            TMainMenu.Foreground = new SolidColorBrush(Color.FromArgb(255, 224, 224, 224));
            IListProduct.Foreground = new SolidColorBrush(Color.FromArgb(255, 224, 224, 224));
            TListProducts.Foreground = new SolidColorBrush(Color.FromArgb(255, 224, 224, 224));
            IListZakaz.Foreground = new SolidColorBrush(Color.FromArgb(255, 224, 224, 224));
            TListZakaz.Foreground = new SolidColorBrush(Color.FromArgb(255, 224, 224, 224));
            IListWork.Foreground = new SolidColorBrush(Color.FromArgb(255, 224, 224, 224));
            TListWork.Foreground = new SolidColorBrush(Color.FromArgb(255, 224, 224, 224));
        }

        private void BListZakaz_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new ListZakazsPage());

            IListZakaz.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 255, 226));
            TListZakaz.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 255, 226));

            IMainMenu.Foreground = new SolidColorBrush(Color.FromArgb(255, 224, 224, 224));
            TMainMenu.Foreground = new SolidColorBrush(Color.FromArgb(255, 224, 224, 224));
            IListProduct.Foreground = new SolidColorBrush(Color.FromArgb(255, 224, 224, 224));
            TListProducts.Foreground = new SolidColorBrush(Color.FromArgb(255, 224, 224, 224));
            IListUsers.Foreground = new SolidColorBrush(Color.FromArgb(255, 224, 224, 224));
            TListUsers.Foreground = new SolidColorBrush(Color.FromArgb(255, 224, 224, 224));
            IListWork.Foreground = new SolidColorBrush(Color.FromArgb(255, 224, 224, 224));
            TListWork.Foreground = new SolidColorBrush(Color.FromArgb(255, 224, 224, 224));
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
