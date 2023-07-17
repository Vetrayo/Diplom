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
    public partial class UserAddPage : Page
    {
        public UserAddPage()
        {
            InitializeComponent();

            CbQuestion.ItemsSource = DBEntities.GetContext().ControlQuestion.ToList();
        }

        private void BAdd_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TbLogin.Text) ||
               string.IsNullOrWhiteSpace(TbPassword.Text) ||
               string.IsNullOrWhiteSpace(TbSurname.Text) ||
               string.IsNullOrWhiteSpace(TbName.Text) ||
               string.IsNullOrWhiteSpace(TbPhone.Text) ||
               string.IsNullOrWhiteSpace(CbQuestion.Text) ||
               string.IsNullOrWhiteSpace(TbAnswer.Text))
            {
                ClassGlobalVars.textMB = ("Заполните все поля");
                new WindowMessageError().ShowDialog();
                return;
            }
            DBEntities.GetContext().User.Add(new User()
            {
                Login = TbLogin.Text,
                Password = TbPassword.Text,
                IdRole = 3
            });
            DBEntities.GetContext().SaveChanges();
            if(TbOtch.Text == "")
            {
                DBEntities.GetContext().Client.Add(new Client()
                {
                    Surname = TbSurname.Text,
                    Name = TbName.Text,
                    Phone = TbPhone.Text,
                    Patronymic = "нету",
                    IdControlQuestion = CbQuestion.SelectedIndex + 1,
                    AnswerOnQuestion = TbAnswer.Text,
                    IdUser = DBEntities.GetContext().User.FirstOrDefault(u => u.Login == TbLogin.Text).IdUser
                });
                DBEntities.GetContext().SaveChanges();
            }
            else
            {
                DBEntities.GetContext().Client.Add(new Client()
                {
                    Surname = TbSurname.Text,
                    Name = TbName.Text,
                    Phone = TbPhone.Text,
                    Patronymic = TbOtch.Text,
                    IdControlQuestion = CbQuestion.SelectedIndex + 1,
                    AnswerOnQuestion = TbAnswer.Text,
                    IdUser = DBEntities.GetContext().User.FirstOrDefault(u => u.Login == TbLogin.Text).IdUser
                });
                DBEntities.GetContext().SaveChanges();
            }
            ClassGlobalVars.textMB = ("Вы добавили пользователя");
            new WindowMessageInfo().ShowDialog();
            this.NavigationService.Navigate(new ListUsersPage());
        }
        private void BOut_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new ListUsersPage());
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
