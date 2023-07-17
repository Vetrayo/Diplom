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
    /// Логика взаимодействия для UserAddPage.xaml
    /// </summary>
    public partial class WorkAddPage : Page
    {
        public WorkAddPage()
        {
            InitializeComponent();
        }

        private void BAdd_Click(object sender, RoutedEventArgs e)
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
            DBEntities.GetContext().User.Add(new User()
            {
                Login = TbLogin.Text,
                Password = TbPassword.Text,
                IdRole = 2
                });
            DBEntities.GetContext().SaveChanges();
            if (TbPremium.Text == "")
            {
                DBEntities.GetContext().Employee.Add(new Employee()
                {                            
                    Surname = TbSurname.Text,
                    Name = TbName.Text,
                    Phone = TbPhone.Text,
                    Patronymic = TbOtch.Text,
                    Salary = Convert.ToInt32(TbSalary.Text),
                    Premium = 0,
                    IdUser = DBEntities.GetContext().User.FirstOrDefault(u => u.Login == TbLogin.Text).IdUser
                }); 
                DBEntities.GetContext().SaveChanges();
            }
            else
            {
                DBEntities.GetContext().Employee.Add(new Employee()
                {
                    Surname = TbSurname.Text,
                    Name = TbName.Text,
                    Phone = TbPhone.Text,
                    Patronymic = TbOtch.Text,
                    Salary = Convert.ToInt32(TbSalary.Text),
                    Premium = Convert.ToInt32(TbPremium.Text),
                    IdUser = DBEntities.GetContext().User.FirstOrDefault(u => u.Login == TbLogin.Text).IdUser
                }); 
                DBEntities.GetContext().SaveChanges();
            }
            ClassGlobalVars.textMB = ("Вы добавили сотрудника");
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
                BAdd_Click(sender, e);
            }
        }
    }
}
