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
    /// Логика взаимодействия для MenuAdminPage.xaml
    /// </summary>
    public partial class MenuAdminPage : Page
    {
        public MenuAdminPage()
        {
            InitializeComponent();

            TbLogin.Text = App.CurrentUser.Login;

            TbPassword.Text = App.CurrentUser.Password;
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
                ClassGlobalVars.textMB = "Необходимо написать логин";
                new WindowMessageError().ShowDialog();
                return;
            }
            if(DBEntities.GetContext().User.FirstOrDefault(u => u.Login == TbLogin.Text) != null)
            {
                ClassGlobalVars.textMB = $"Пользователь с логином: {TbLogin.Text} уже есть в системе";
                new WindowMessageError().ShowDialog();
                return;
            }
            DBEntities.GetContext().User.FirstOrDefault(u => u.Login == App.CurrentUser.Login).Login = TbLogin.Text;
            DBEntities.GetContext().SaveChanges();
            ClassGlobalVars.textMB = "Вы успешно сменили логин";
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
                ClassGlobalVars.textMB = "Необходимо написать пароль";
                new WindowMessageError().ShowDialog();
                return;
            }
            DBEntities.GetContext().User.FirstOrDefault(u => u.Login == App.CurrentUser.Login).Password = TbPassword.Text;
            DBEntities.GetContext().SaveChanges();
            ClassGlobalVars.textMB = "Вы успешно сменили пароль";
            new WindowMessageInfo().ShowDialog();
            BEdit2.Visibility = Visibility.Visible;
            BConfirm2.Visibility = Visibility.Hidden;
            TbPassword.IsReadOnly = true;
        }
    }
}
