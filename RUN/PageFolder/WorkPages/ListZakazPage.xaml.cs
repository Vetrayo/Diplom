using RUN.ClassFolder;
using RUN.DataFolder;
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
    /// Логика взаимодействия для ListZakazsPage.xaml
    /// </summary>
    public partial class ListZakazPage : Page
    {
        public ListZakazPage()
        {
            InitializeComponent();

            updateDataGrid();
        }
        private void updateDataGrid()
        {
            DgZakazi.ItemsSource = DBEntities.GetContext().Zakaz.ToList();
        }
        private void TbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            DgZakazi.ItemsSource = DBEntities.GetContext().Zakaz.Where
            (c => c.Client.Name.StartsWith(TbSearch.Text)
            || c.Client.Surname.StartsWith(TbSearch.Text)
            || c.Client.Phone.StartsWith(TbSearch.Text)
            || c.Usluga.Name.StartsWith(TbSearch.Text)
            || c.DescriprionByClient.StartsWith(TbSearch.Text)).ToList();
            if (DgZakazi.Items.Count < 1)
            {
                return;
            }
        }
        private void DgZakazi_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            this.NavigationService.Navigate(new ZakazEditPage(DgZakazi.SelectedItem as Zakaz));
        }
    }
}
