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
    /// Логика взаимодействия для ListWorkerPage.xaml
    /// </summary>
    public partial class ListWorkerPage : Page
    {
        public ListWorkerPage()
        {
            InitializeComponent();

            updateDataGrid();
        }
        private void updateDataGrid()
        {
            DgUsers.ItemsSource = DBEntities.GetContext().Employee.ToList();
        }

        private void DgUsers_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            this.NavigationService.Navigate(new WorkEditPage(DgUsers.SelectedItem as Employee));
            updateDataGrid();
        }

        private void BAdd_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new WorkAddPage());
            updateDataGrid();
        }

        private void BDel_Click(object sender, RoutedEventArgs e)
        {
            if (DgUsers.SelectedItem == null)
            {
                return;
            }
            ClassGlobalVars.textMB = "Вы действительно хотите уволить сотрудника?";
            new WindowMessageQuestion().ShowDialog();
            if (ClassGlobalVars.acceptMB == "Нет")
            {
                return;
            }
            if (ClassGlobalVars.acceptMB == "Да")
            {
                DBEntities.GetContext().Database.ExecuteSqlCommand($"delete from [Employee] where IdEmployee = ('{(DgUsers.SelectedItem as Employee).IdEmployee}')");
                DBEntities.GetContext().Database.ExecuteSqlCommand($"delete from [User] where IdUser = ('{(DgUsers.SelectedItem as Employee).User.IdUser}')");
                updateDataGrid();
                ClassGlobalVars.textMB = "Вы успешно уволили сотрудника";
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

        private void BTotal_Click(object sender, RoutedEventArgs e)
        {
            ClassGlobalVars.textMB = ($"Общие затраты на з/п сотрудников: {DBEntities.GetContext().Employee.Sum(u => u.Salary) +
            "\n\n" + "Общие затраты на премии сотрудников: " 
            + DBEntities.GetContext().Employee.Sum(u => u.Premium)}");
            new WindowMessageInfo().ShowDialog();
        }
    }
}
