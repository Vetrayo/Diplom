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
    public partial class Registration1Window : Window
    {
        public Registration1Window()
        {
            InitializeComponent();
        }

        private void BAdd_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TbLogin.Text) ||
               string.IsNullOrWhiteSpace(PbPassword.Password))
            {
                ClassGlobalVars.textMB = ("Необходимо заполнить все поля");
                new WindowMessageError().ShowDialog();
                return;
            }
            if (DBEntities.GetContext().User.FirstOrDefault(u => u.Login == TbLogin.Text) != null)
            {
                ClassGlobalVars.textMB = ($"Пользователь с логином: {TbLogin.Text} уже есть в системе");
                new WindowMessageError().ShowDialog();
                return;
            }
            ClassGlobalVars.login = TbLogin.Text;
            ClassGlobalVars.password = PbPassword.Password;
            ClassGlobalVars.textMB = ("Хорошо, сейчас перейдем ко второму этапу регистрации");
            new WindowMessageInfo().ShowDialog();
            this.Hide();
            new Registration2Window().ShowDialog();
            this.Close();
        }

        private void BClose_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }

        private void BBack_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            new AuthorizationWindow().ShowDialog();
            this.Close();
        }
    }
}
