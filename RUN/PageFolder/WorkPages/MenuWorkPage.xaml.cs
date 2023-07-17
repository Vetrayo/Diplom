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

namespace RUN.PageFolder.WorkPages
{
    /// <summary>
    /// Логика взаимодействия для MenuAdminPage.xaml
    /// </summary>
    public partial class MenuWorkPage : Page
    {
        public MenuWorkPage()
        {
            InitializeComponent();

            TbLogin.Text = App.CurrentUser.Login;
            TbPassword.Text = App.CurrentUser.Password;
            TbName.Text = App.CurrentEmployee.Name;
            TbSurname.Text = App.CurrentEmployee.Surname;
            TbPatronymic.Text = App.CurrentEmployee.Patronymic;
            TbPhone.Text = App.CurrentEmployee.Phone;
        }

        private void BEdit1_Click(object sender, RoutedEventArgs e)
        {
            TbLogin.IsReadOnly = false;
            BEdit1.Visibility = Visibility.Hidden;
            BConfirm1.Visibility = Visibility.Visible;
        }

        private void BConfirm1_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TbLogin.Text))
            {
                ClassGlobalVars.textMB = ("Необходимо заполнить поле");
                new WindowMessageError().ShowDialog();
                return;
            }
            if (DBEntities.GetContext().User.FirstOrDefault(u => u.Login == TbLogin.Text) != null)
            {
                ClassGlobalVars.textMB = $"Пользователь с логином: {TbLogin.Text} уже есть в системе";
                new WindowMessageError().ShowDialog();
                return;
            }
            DBEntities.GetContext().User.FirstOrDefault(u => u.Login == App.CurrentUser.Login).Login = TbLogin.Text;
            DBEntities.GetContext().SaveChanges();
            ClassGlobalVars.textMB = ("Вы успешно сменили логин");
            new WindowMessageInfo().ShowDialog();
            BEdit1.Visibility = Visibility.Visible;
            BConfirm1.Visibility = Visibility.Hidden;
            TbLogin.IsReadOnly = true;
        }

        private void BEdit2_Click(object sender, RoutedEventArgs e)
        {
            TbPassword.IsReadOnly = false;
            BEdit2.Visibility = Visibility.Hidden;
            BConfirm2.Visibility = Visibility.Visible;
        }

        private void BConfirm2_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TbPassword.Text))
            {
                ClassGlobalVars.textMB = ("Необходимо заполнить поле");
                new WindowMessageError().ShowDialog();
                return;
            }
            DBEntities.GetContext().User.FirstOrDefault(u => u.Login == App.CurrentUser.Login).Password = TbPassword.Text;
            DBEntities.GetContext().SaveChanges();
            ClassGlobalVars.textMB = ("Вы успешно сменили пароль");
            new WindowMessageInfo().ShowDialog();
            BEdit2.Visibility = Visibility.Visible;
            BConfirm2.Visibility = Visibility.Hidden;
            TbPassword.IsReadOnly = true;
        }

        private void BEdit3_Click(object sender, RoutedEventArgs e)
        {
            TbSurname.IsReadOnly = false;
            BEdit3.Visibility = Visibility.Hidden;
            BConfirm3.Visibility = Visibility.Visible;
        }

        private void BConfirm3_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TbSurname.Text))
            {
                ClassGlobalVars.textMB = ("Необходимо заполнить поле");
                new WindowMessageError().ShowDialog();
                return;
            }
            DBEntities.GetContext().Employee.FirstOrDefault(u => u.User.Login == App.CurrentUser.Login).Surname = TbSurname.Text;
            DBEntities.GetContext().SaveChanges();
            ClassGlobalVars.textMB = ("Вы успешно сменили фамилию");
            new WindowMessageInfo().ShowDialog();
            BEdit3.Visibility = Visibility.Visible;
            BConfirm3.Visibility = Visibility.Hidden;
            TbSurname.IsReadOnly = true;
        }
        private void BEdit4_Click(object sender, RoutedEventArgs e)
        {
            TbName.IsReadOnly = false;
            BEdit4.Visibility = Visibility.Hidden;
            BConfirm4.Visibility = Visibility.Visible;
        }
        private void BConfirm4_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TbName.Text))
            {
                ClassGlobalVars.textMB = ("Необходимо заполнить поле");
                new WindowMessageError().ShowDialog();
                return;
            }
            DBEntities.GetContext().Employee.FirstOrDefault(u => u.User.Login == App.CurrentUser.Login).Name = TbName.Text;
            DBEntities.GetContext().SaveChanges();
            ClassGlobalVars.textMB = ("Вы успешно сменили имя");
            new WindowMessageInfo().ShowDialog();
            BEdit4.Visibility = Visibility.Visible;
            BConfirm4.Visibility = Visibility.Hidden;
            TbName.IsReadOnly = true;
        }

        private void BEdit5_Click(object sender, RoutedEventArgs e)
        {
            TbPatronymic.IsReadOnly = false;
            BEdit5.Visibility = Visibility.Hidden;
            BConfirm5.Visibility = Visibility.Visible;
        }
        private void BConfirm5_Click(object sender, RoutedEventArgs e)
        {
            if(TbPatronymic.Text == "")
            {
                DBEntities.GetContext().Employee.FirstOrDefault(u => u.User.Login == App.CurrentUser.Login).Patronymic = "нету";
                DBEntities.GetContext().SaveChanges();
            }
            else
            {
                DBEntities.GetContext().Employee.FirstOrDefault(u => u.User.Login == App.CurrentUser.Login).Patronymic = TbPatronymic.Text;
                DBEntities.GetContext().SaveChanges();
            }
            ClassGlobalVars.textMB = ("Вы успешно сменили отчество");
            new WindowMessageInfo().ShowDialog();
            BEdit5.Visibility = Visibility.Visible;
            BConfirm5.Visibility = Visibility.Hidden;
            TbPatronymic.IsReadOnly = true;
        }

        private void BEdit6_Click(object sender, RoutedEventArgs e)
        {
            TbPhone.IsReadOnly = false;
            BEdit6.Visibility = Visibility.Hidden;
            BConfirm6.Visibility = Visibility.Visible;
        }
        private void BConfirm6_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TbPhone.Text))
            {
                ClassGlobalVars.textMB = ("Необходимо заполнить поле");
                new WindowMessageError().ShowDialog();
                return;
            }
            else
            {
                DBEntities.GetContext().Employee.FirstOrDefault(u => u.User.Login == App.CurrentUser.Login).Phone = TbPhone.Text;
                DBEntities.GetContext().SaveChanges();
                ClassGlobalVars.textMB = ("Вы успешно сменили номер телефона");
                new WindowMessageInfo().ShowDialog();
                BEdit6.Visibility = Visibility.Visible;
                BConfirm6.Visibility = Visibility.Hidden;
                TbPhone.IsReadOnly = true;
            }
        }
    }
}
