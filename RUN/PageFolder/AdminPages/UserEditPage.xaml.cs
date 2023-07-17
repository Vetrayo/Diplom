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
    public partial class UserEditPage : Page
    {
        string name;
        public UserEditPage(Client client)
        {
            InitializeComponent();

            name = client.User.Login;
            DataContext = client;

            CbQuestion.ItemsSource = DBEntities.GetContext().ControlQuestion.ToList();
        }

        private void BEdit_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TbLogin.Text) ||
               string.IsNullOrWhiteSpace(TbPassword.Text) ||
               string.IsNullOrWhiteSpace(TbSurname.Text) ||
               string.IsNullOrWhiteSpace(TbName.Text) ||
               string.IsNullOrWhiteSpace(TbPhone.Text) ||
               string.IsNullOrWhiteSpace(TbAnswer.Text) ||
               string.IsNullOrWhiteSpace(CbQuestion.Text))
            {
                ClassGlobalVars.textMB = ("Заполните все поля");
                new WindowMessageError().ShowDialog();
            }
            else
            {
                DBEntities.GetContext().Client.FirstOrDefault(z => z.User.Login == name).Surname = TbSurname.Text;
                DBEntities.GetContext().Client.FirstOrDefault(z => z.User.Login == name).Name = TbName.Text;
                DBEntities.GetContext().Client.FirstOrDefault(z => z.User.Login == name).Patronymic = TbOtch.Text;
                DBEntities.GetContext().Client.FirstOrDefault(z => z.User.Login == name).User.Login = TbLogin.Text;
                DBEntities.GetContext().Client.FirstOrDefault(z => z.User.Login == name).User.Password = TbPassword.Text;
                DBEntities.GetContext().Client.FirstOrDefault(z => z.User.Login == name).Phone = TbPhone.Text;
                DBEntities.GetContext().Client.FirstOrDefault(z => z.User.Login == name).IdControlQuestion = CbQuestion.SelectedIndex + 1;
                DBEntities.GetContext().Client.FirstOrDefault(z => z.User.Login == name).AnswerOnQuestion = TbAnswer.Text;
                DBEntities.GetContext().SaveChanges();
                ClassGlobalVars.textMB = ("Успешно изменено");
                new WindowMessageInfo().ShowDialog();
                this.NavigationService.Navigate(new ListUsersPage());
            }
        }
        private void BOut_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new ListUsersPage());
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
