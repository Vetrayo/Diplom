using RUN.ClassFolder;
using RUN.DataFolder;
using RUN.WindowFolder.WindowsMessages;
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

namespace RUN.PageFolder.AdminPages
{
    /// <summary>
    /// Логика взаимодействия для ListZakazsPage.xaml
    /// </summary>
    public partial class ListZakazsPage : Page
    {
        public ListZakazsPage()
        {
            InitializeComponent();

            updateDataGrid();
        }

        private void updateDataGrid()
        {
            DgZakazi.ItemsSource = DBEntities.GetContext().Zakaz.ToList();
        }

        private void IOut_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.NavigationService.Navigate(new MenuAdminPage());
        }

        private void TbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            DgZakazi.ItemsSource = DBEntities.GetContext().Zakaz.Where
            (c => c.Client.Name.StartsWith(TbSearch.Text)
            || c.Client.Surname.StartsWith(TbSearch.Text) ||
            c.Client.Phone.StartsWith(TbSearch.Text) ||
            c.AcceptedByWhom.StartsWith(TbSearch.Text)).ToList();
            if (DgZakazi.Items.Count < 1)
            {
                return;
            }
        }

        private void BDel_Click(object sender, RoutedEventArgs e)
        {
            if (DgZakazi.SelectedItem == null)
            {
                return;
            }
            ClassGlobalVars.textMB = "Вы действительно хотите удалить заказ?";
            new WindowMessageQuestion().ShowDialog();
            if (ClassGlobalVars.acceptMB == "Нет")
            {
                return;
            }
            if (ClassGlobalVars.acceptMB == "Да")
            {
                DBEntities.GetContext().Database.ExecuteSqlCommand($"delete from [Zakaz] where IdZakaz = ('{(DgZakazi.SelectedItem as Zakaz).IdZakaz}')");
                updateDataGrid();
                ClassGlobalVars.textMB = "Вы успешно уволили сотрудника";
                new WindowMessageInfo().ShowDialog();
            }
        }
    }
}
