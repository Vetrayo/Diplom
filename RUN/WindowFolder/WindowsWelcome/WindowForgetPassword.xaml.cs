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
    /// Логика взаимодействия для WindowForgetPassword.xaml
    /// </summary>
    public partial class WindowForgetPassword : Window
    {
        public WindowForgetPassword()
        {
            InitializeComponent();

            CbQuestion.ItemsSource = DBEntities.GetContext().ControlQuestion.ToList();
        }

        private void BAdd_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TbLogin.Text) ||
               string.IsNullOrWhiteSpace(CbQuestion.Text) ||
               string.IsNullOrWhiteSpace(TbAnswer.Text))
            {
                ClassGlobalVars.textMB = ("Необходимо заполнить все поля");
                new WindowMessageError().ShowDialog();
                return;
            }
            if (DBEntities.GetContext().User.FirstOrDefault(u => u.Login == TbLogin.Text) == null)
            {
                ClassGlobalVars.textMB = ($"Пользователя с логином: {TbLogin.Text} нету в системе");
                new WindowMessageError().ShowDialog();
                return;
            }
            if (DBEntities.GetContext().Client.FirstOrDefault(u => u.User.Login == TbLogin.Text).IdControlQuestion != CbQuestion.SelectedIndex + 1)
            {
                ClassGlobalVars.textMB = ("У вас был указан другой контрольный вопрос при регистрации");
                new WindowMessageError().ShowDialog();
                return;
            }
            if (DBEntities.GetContext().Client.FirstOrDefault(u => u.User.Login == TbLogin.Text).AnswerOnQuestion != TbAnswer.Text)
            {
                ClassGlobalVars.textMB = ("Вы неправильно ввели ответ на вопрос");
                new WindowMessageError().ShowDialog();
                return;
            }
            ClassGlobalVars.login = TbLogin.Text;
            ClassGlobalVars.textMB = ($"Вы успешно подтвердили, что вы владелец учетной записи, переходим к смене пароля");
            new WindowMessageInfo().ShowDialog();
            this.Hide();
            new WindowChangePassword().ShowDialog();
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
