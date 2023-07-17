using RUN.ClassFolder;
using RUN.DataFolder;
using RUN.WindowFolder.WindowsMessages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
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
    /// Логика взаимодействия для ListUsersPage.xaml
    /// </summary>
    public partial class ListUsersPage : Page
    {
        public ListUsersPage()
        {
            InitializeComponent();

            updateDataGrid();
        }
        private void updateDataGrid()
        {
            DgUsers.ItemsSource = DBEntities.GetContext().Client.ToList();
        }

        private void DgUsers_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            this.NavigationService.Navigate(new UserEditPage(DgUsers.SelectedItem as Client));
            updateDataGrid();
        }

        private void BAdd_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new UserAddPage());
            updateDataGrid();
        }

        private void BDel_Click(object sender, RoutedEventArgs e)
        {
            if (DgUsers.SelectedItem == null)
            {
                return;
            }
            ClassGlobalVars.textMB = "Вы действительно хотите удалить пользователя?";
            new WindowMessageQuestion().ShowDialog();
            if (ClassGlobalVars.acceptMB == "Нет")
            {
                return;
            }
            if (ClassGlobalVars.acceptMB == "Да")
            {
                DBEntities.GetContext().Database.ExecuteSqlCommand($"delete from [Zakaz] where IdClient = ('{(DgUsers.SelectedItem as Client).IdClient}')");
                DBEntities.GetContext().Database.ExecuteSqlCommand($"delete from [Client] where IdClient = ('{(DgUsers.SelectedItem as Client).IdClient}')");
                DBEntities.GetContext().Database.ExecuteSqlCommand($"delete from [User] where IdUser = ('{(DgUsers.SelectedItem as Client).User.IdUser}')");

                updateDataGrid();
                ClassGlobalVars.textMB = "Вы успешно удалили пользователя";
                new WindowMessageInfo().ShowDialog();
            }
        }

        private void TbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            DgUsers.ItemsSource = DBEntities.GetContext().Client.Where
            (c => c.Surname.StartsWith(TbSearch.Text)
            || c.Name.StartsWith(TbSearch.Text) ||
            c.Phone.StartsWith(TbSearch.Text)).ToList();
            if (DgUsers.Items.Count < 1)
            {
                return;
            }
        }
    }
}
