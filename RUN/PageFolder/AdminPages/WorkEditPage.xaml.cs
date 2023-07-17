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
using System.Xml.Linq;

namespace RUN.PageFolder.AdminPages
{
    /// <summary>
    /// Логика взаимодействия для UserEditPage.xaml
    /// </summary>
    public partial class WorkEditPage : Page
    {
        string name;
        public WorkEditPage(Employee employee)
        {
            InitializeComponent();

            name = employee.User.Login;
            DataContext = employee;
        }

        private void BEdit_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TbLogin.Text) ||
               string.IsNullOrWhiteSpace(TbPassword.Text) ||
               string.IsNullOrWhiteSpace(TbSurname.Text) ||
               string.IsNullOrWhiteSpace(TbName.Text) ||
               string.IsNullOrWhiteSpace(TbPhone.Text) ||
               string.IsNullOrWhiteSpace(TbSalary.Text))
            {
                ClassGlobalVars.textMB = ("Заполните все поля");
                new WindowMessageError().ShowDialog();
                return;
            }
            DBEntities.GetContext().Employee.FirstOrDefault(z => z.User.Login == name).Surname = TbSurname.Text;
            DBEntities.GetContext().Employee.FirstOrDefault(z => z.User.Login == name).Name = TbName.Text;
            DBEntities.GetContext().Employee.FirstOrDefault(z => z.User.Login == name).Patronymic = TbOtch.Text;
            DBEntities.GetContext().Employee.FirstOrDefault(z => z.User.Login == name).User.Login = TbLogin.Text;
            DBEntities.GetContext().Employee.FirstOrDefault(z => z.User.Login == name).User.Password = TbPassword.Text;
            DBEntities.GetContext().Employee.FirstOrDefault(z => z.User.Login == name).Phone = TbPhone.Text;
            DBEntities.GetContext().Employee.FirstOrDefault(z => z.User.Login == name).Salary = Convert.ToInt32(TbSalary.Text);
            if(TbPremium.Text == "")
            {
                DBEntities.GetContext().Employee.FirstOrDefault(z => z.User.Login == name).Premium = 0;
            }
            else
            {
                DBEntities.GetContext().Employee.FirstOrDefault(z => z.User.Login == name).Premium = Convert.ToInt32(TbPremium.Text);
            }
            DBEntities.GetContext().SaveChanges();
            ClassGlobalVars.textMB = ("Успешно изменено");
            new WindowMessageInfo().ShowDialog();
            this.NavigationService.Navigate(new ListWorkerPage());
        }
        private void BOut_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new ListWorkerPage());
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
