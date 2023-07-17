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
    public partial class Registration2Window : Window
    {
        public Registration2Window()
        {
            InitializeComponent();

            CbQuestion.ItemsSource = DBEntities.GetContext().ControlQuestion.ToList();
        }

        private void BAdd_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TbSurname.Text) ||
                string.IsNullOrWhiteSpace(TbName.Text) ||
                string.IsNullOrWhiteSpace(TbAnswer.Text) ||
                string.IsNullOrWhiteSpace(CbQuestion.Text))
            {
                ClassGlobalVars.textMB = ("Необходимо заполнить все поля");
                new WindowMessageError().ShowDialog();
                return;
            }
            DBEntities.GetContext().User.Add(new User()
            {
                Login = ClassGlobalVars.login,
                Password = ClassGlobalVars.password,
                IdRole = 3
            });
            DBEntities.GetContext().SaveChanges();
            if (TbPatronymic.Text == "")
            {
                DBEntities.GetContext().Client.Add(new Client()
                {
                    Surname = TbSurname.Text,
                    Name = TbSurname.Text,
                    Patronymic = "нету",
                    Phone = TbPhone.Text,
                    IdControlQuestion = CbQuestion.SelectedIndex + 1,
                    AnswerOnQuestion = TbAnswer.Text,
                    IdUser = DBEntities.GetContext().User.FirstOrDefault(u => u.Login == ClassGlobalVars.login).IdUser
                });
                DBEntities.GetContext().SaveChanges();
            }
            else
            {
                DBEntities.GetContext().Client.Add(new Client()
                {
                    Surname = TbSurname.Text,
                    Name = TbSurname.Text,
                    Patronymic = TbPatronymic.Text,
                    Phone = TbPhone.Text,
                    IdControlQuestion = CbQuestion.SelectedIndex + 1,
                    AnswerOnQuestion = TbAnswer.Text,
                    IdUser = DBEntities.GetContext().User.FirstOrDefault(u => u.Login == ClassGlobalVars.login).IdUser
                });
                DBEntities.GetContext().SaveChanges();
            }
            ClassGlobalVars.textMB = ("Вы успешно зарегистрировались в системе");
            new WindowMessageInfo().ShowDialog();
            this.Hide();
            new AuthorizationWindow().ShowDialog();
            this.Close();
        }

        private void BClose_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }

        private void BBack_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            new Registration1Window().ShowDialog();
            this.Close();
        }
    }
}
