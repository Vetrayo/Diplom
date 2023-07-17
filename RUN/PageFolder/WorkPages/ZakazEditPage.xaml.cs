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
    /// Логика взаимодействия для ZakazEditPage.xaml
    /// </summary>
    public partial class ZakazEditPage : Page
    {
        int idZakaz;
        public ZakazEditPage(Zakaz zakaz)
        {
            InitializeComponent();

            CbIdStatus.ItemsSource = DBEntities.GetContext().Status.ToList().Where(u => u.IdStatus <= 4);

            idZakaz = zakaz.IdZakaz;

            CbIdStatus.SelectedItem = zakaz.IdStatus;

            DataContext = zakaz;
        }

        private void BEdit_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(CbIdStatus.Text))
            {
                ClassGlobalVars.textMB = ("Выберете статус");
                new WindowMessageError().ShowDialog();
            }
            else
            {
                DBEntities.GetContext().Zakaz.FirstOrDefault(z => z.IdZakaz == idZakaz).
                Status = DBEntities.GetContext().
                Status.FirstOrDefault(s => s.IdStatus == CbIdStatus.SelectedIndex + 1);
                if(App.CurrentEmployee.Patronymic == "нету")
                {
                    string workerfio = App.CurrentEmployee.Surname + " " + App.CurrentEmployee.Name;
                    DBEntities.GetContext().Zakaz.FirstOrDefault(z => z.IdZakaz == idZakaz).AcceptedByWhom = workerfio;
                    DBEntities.GetContext().SaveChanges();
                    ClassGlobalVars.textMB = ("Статус успешно изменен");
                    new WindowMessageInfo().ShowDialog();
                    this.NavigationService.Navigate(new ListZakazPage());
                }
                if(App.CurrentEmployee.Patronymic != "нету")
                {
                    string workerfio = App.CurrentEmployee.Surname + " " + App.CurrentEmployee.Name + " " + App.CurrentEmployee.Patronymic;
                    DBEntities.GetContext().Zakaz.FirstOrDefault(z => z.IdZakaz == idZakaz).AcceptedByWhom = workerfio;
                    DBEntities.GetContext().SaveChanges();
                    ClassGlobalVars.textMB = ("Статус успешно изменен");
                    new WindowMessageInfo().ShowDialog();
                    this.NavigationService.Navigate(new ListZakazPage());
                }
            }
        }      

        private void BOut_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new ListZakazPage());
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
