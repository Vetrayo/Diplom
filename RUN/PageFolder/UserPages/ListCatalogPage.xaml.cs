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

namespace RUN.PageFolder.UserPages
{
    public partial class ListCatalogPage : Page
    {
        public ListCatalogPage()
        {
            InitializeComponent();

            updateDataGrid();
        }

        private void updateDataGrid()
        {
            DgUsers.ItemsSource = DBEntities.GetContext().Usluga.ToList();
        }

        private void IOut_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.NavigationService.Navigate(new MenuUserPage());
        }

        private void TbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            DgUsers.ItemsSource = DBEntities.GetContext().Usluga.Where
            (c => c.Name.StartsWith(TbSearch.Text) ||
            c.Description.StartsWith(TbSearch.Text)).ToList();
            if (DgUsers.Items.Count < 1)
            {
                return;
            }
        }
    }
}
