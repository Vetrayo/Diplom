using MaterialDesignThemes.Wpf;
using RUN.ClassFolder;
using RUN.DataFolder;
using RUN.WindowFolder.WindowsAdmin;
using RUN.WindowFolder.WindowsMessages;
using RUN.WindowFolder.WindowsUser;
using RUN.WindowFolder.WindowsWork;
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

namespace RUN.WindowFolder.WindowsWelcome
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationWindow.xaml
    /// </summary>
    public partial class AuthorizationWindow : Window
    {
        public AuthorizationWindow()
        {
            InitializeComponent();

            LoginTb.Text = ClassGlobalVars.login;
        }
        private void RegistrationBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            new Registration1Window().ShowDialog();
            this.Close();
        }
        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(LoginTb.Text))
            {
                ClassGlobalVars.textMB = "Необходимо заполнить все поля";
                new WindowMessageError().ShowDialog();
                return;
            }
            var user = DBEntities.GetContext().User.FirstOrDefault(u => u.Login == LoginTb.Text);
            var employee = DBEntities.GetContext().Employee.FirstOrDefault(u => u.User.Login == LoginTb.Text);
            var client = DBEntities.GetContext().Client.FirstOrDefault(u => u.User.Login == LoginTb.Text);
            if (TbPassword.Text != PbPassword.Password)
            {
                if(TbPassword.Text != "")
                {
                    PbPassword.Password = TbPassword.Text;
                }
            }
            if (user == null)
            {
                ClassGlobalVars.textMB = $"Пользователя с логином {LoginTb.Text} нету в системе";
                new WindowMessageError().ShowDialog();
                return;
            }
            if (user.Password != PbPassword.Password)
            {
                ClassGlobalVars.textMB = "Пароль введен неверно";
                new WindowMessageError().ShowDialog();
                return;
            }
            switch (user.IdRole)
            {
                case 1:
                    App.CurrentUser = user;
                    this.Hide();
                    new MainFrameAdminWindow().ShowDialog();
                    this.Close();
                    break;

                case 2:
                    App.CurrentUser = user;
                    App.CurrentEmployee = employee;
                    this.Hide();
                    new MainFrameWorkWindow().ShowDialog();
                    this.Close();
                    break;
                case 3:
                    App.CurrentUser = user;
                    App.CurrentClient = client;
                    this.Hide();
                    new MainFrameUserWindow().ShowDialog();
                    this.Close();
                    break;
            }
        }
        private void Page_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                LoginBtn_Click(sender, e);
            }
        }

        private void BClose_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }

        private void ForgetPassword_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            new WindowForgetPassword().ShowDialog();
            this.Close();
        }

        private void ShowPassword_Click(object sender, RoutedEventArgs e)
        {
            TbPassword.Text = PbPassword.Password;
            TbPassword.Visibility = Visibility.Visible;
            PbPassword.Visibility = Visibility.Hidden;
            HidePassword.Visibility = Visibility.Visible;
            ShowPassword.Visibility = Visibility.Hidden;
        }

        private void HidePassword_Click(object sender, RoutedEventArgs e)
        {
            PbPassword.Password = TbPassword.Text;
            TbPassword.Visibility = Visibility.Hidden;
            PbPassword.Visibility = Visibility.Visible;
            HidePassword.Visibility = Visibility.Hidden;
            ShowPassword.Visibility = Visibility.Visible;
        }
    }
}
