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
    /// Логика взаимодействия для ListProductsPage.xaml
    /// </summary>
    public partial class ListProductsPage : Page
    {
        public ListProductsPage()
        {
            InitializeComponent();

            updateDataGrid();
        }

        private void updateDataGrid()
        {
            DgUsers.ItemsSource = DBEntities.GetContext().Usluga.ToList();
        }

        private void DgUsers_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            this.NavigationService.Navigate(new ProductEditPage(DgUsers.SelectedItem as Usluga));
            updateDataGrid();
        }

        private void TbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            DgUsers.ItemsSource = DBEntities.GetContext().Usluga.Where
            (c => c.Name.StartsWith(TbSearch.Text) ||
            c.Description.StartsWith(TbSearch.Text)).ToList();

            if (DgUsers.Items.Count < 1)
            {
                return;
            }
        }

        private void BAdd_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new ProductAddPage());
            updateDataGrid();
        }

        private void BDel_Click(object sender, RoutedEventArgs e)
        {
            if (DgUsers.SelectedItem == null)
            {
                return;
            }
            ClassGlobalVars.textMB = "Вы действительно хотите удалить услугу?";
            new WindowMessageQuestion().ShowDialog();
            if (ClassGlobalVars.acceptMB == "Нет")
            {
                return;
            }
            if (ClassGlobalVars.acceptMB == "Да")
            {
                DBEntities.GetContext().Database.ExecuteSqlCommand($"delete from [Usluga] where IdUsluga = ('{(DgUsers.SelectedItem as Usluga).IdUsluga}')");
                updateDataGrid();
                ClassGlobalVars.textMB = "Вы успешно удалили услугу";
                new WindowMessageInfo().ShowDialog();
            }
        }
    }
}
