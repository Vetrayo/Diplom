using RUN.ClassFolder;
using RUN.DataFolder;
using RUN.WindowFolder.WindowsMessages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
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
    /// Логика взаимодействия для ListZakazsPage.xaml
    /// </summary>
    public partial class ListUserZakazPage : Page
    {
        public ListUserZakazPage()
        {
            InitializeComponent();

            updateDataGrid();
        }

        private void updateDataGrid()
        {
            DgZakazi.ItemsSource = DBEntities.GetContext().Zakaz.ToList().Where(u => u.IdClient == App.CurrentClient.IdClient);
        }

        private void IOut_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.NavigationService.Navigate(new MenuUserPage());
        }

        private void TbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            DgZakazi.ItemsSource = DBEntities.GetContext().Zakaz.Where
            (c => c.DescriprionByClient.StartsWith(TbSearch.Text)
            || c.Status.Name.StartsWith(TbSearch.Text)).ToList().Where(u => u.IdClient == App.CurrentClient.IdClient);
            if (DgZakazi.Items.Count < 1)
            {
                return;
            }
        }

        private void BCheck_Click(object sender, RoutedEventArgs e)
        {
            if (DgZakazi.SelectedItem == null)
            {
                return;
            }
            else
            {
                if ((DgZakazi.SelectedItem as Zakaz).IdStatus == 3)
                {
                    ClassGlobalVars.textMB = ("Вам отказано в выдаче заказа");
                    new WindowMessageError().ShowDialog();
                    return;
                }
                if ((DgZakazi.SelectedItem as Zakaz).IdStatus == 4)
                {
                    (DgZakazi.SelectedItem as Zakaz).IdStatus = 5;
                    DBEntities.GetContext().SaveChanges();
                    updateDataGrid();
                    ClassGlobalVars.textMB = ("Вы успешно подтвердили получение заказа");
                    new WindowMessageInfo().ShowDialog();
                    return;
                }
                if ((DgZakazi.SelectedItem as Zakaz).IdStatus <= 2)
                {
                    ClassGlobalVars.textMB = ("Вы не можете подтвердить заказ,поскольку он еще не проверен");
                    new WindowMessageError().ShowDialog();
                    return;
                }
                if ((DgZakazi.SelectedItem as Zakaz).IdStatus == 5)
                {
                    ClassGlobalVars.textMB = ("Вы не можете подтвердить заказ, поскольку он уже подтвержден");
                    new WindowMessageError().ShowDialog();
                    return;
                }
            }
        }
    }
}
