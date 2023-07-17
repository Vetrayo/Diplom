using RUN.ClassFolder;
using RUN.DataFolder;
using RUN.WindowFolder.WindowsMessages;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Linq.Expressions;
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

namespace RUN.PageFolder.UserPages
{
    /// <summary>
    /// Логика взаимодействия для ZakazPage.xaml
    /// </summary>
    public partial class ZakazPage : Page
    {
        public ZakazPage()
        {
            InitializeComponent();

            CbProduct.ItemsSource = DBEntities.GetContext().Usluga.ToList();
        }

        private void BOut_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new MenuUserPage());
        }

        private void BEdit_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(CbProduct.Text) ||
                string.IsNullOrWhiteSpace(TbDescriprionByClient.Text))
            {
                ClassGlobalVars.textMB = ("Необходимо заполнить все поля");
                new WindowMessageError().ShowDialog();
                return;
            }
            DBEntities.GetContext().Zakaz.Add(new Zakaz()
            {
                IdUsluga = CbProduct.SelectedIndex + 1,
                IdStatus = 1,
                DescriprionByClient = TbDescriprionByClient.Text,
                IdClient = App.CurrentClient.IdClient
            });
            DBEntities.GetContext().SaveChanges();
            ClassGlobalVars.textMB = "Вы успешно заказали услугу";
            new WindowMessageInfo().ShowDialog();
        }

        private void Page_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                BEdit_Click(sender, e);
            }
        }
    }
}
