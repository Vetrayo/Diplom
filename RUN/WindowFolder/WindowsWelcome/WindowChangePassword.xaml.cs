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

namespace RUN.WindowFolder.WindowsWelcome
{
    /// <summary>
    /// Логика взаимодействия для RegistrationPage.xaml
    /// </summary>
    public partial class WindowChangePassword : Window
    {
        public WindowChangePassword()
        {
            InitializeComponent();
        }

        private void BAdd_Click(object sender, RoutedEventArgs e)
        {
            DBEntities.GetContext().User.FirstOrDefault(u => u.Login == ClassGlobalVars.login).Password = PbPassword.Password;
            DBEntities.GetContext().SaveChanges();
            ClassGlobalVars.textMB = ("Вы успешно сменили пароль");
            new WindowMessageInfo().ShowDialog();
            this.Hide();
            new AuthorizationWindow().ShowDialog();
            this.Close();
        }

        private void BBack_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            new AuthorizationWindow().ShowDialog();
            this.Close();
        }

        private void BClose_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }
    }
}
