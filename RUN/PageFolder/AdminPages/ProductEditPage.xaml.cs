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
    /// Логика взаимодействия для ProductEditPage.xaml
    /// </summary>
    public partial class ProductEditPage : Page
    {
        string nameProduct;
        public ProductEditPage(Usluga usluga)
        {
            InitializeComponent();

            DataContext = usluga;
            nameProduct = usluga.Name;
        }

        private void BOut_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new ListProductsPage());
        }

        private void BEdit_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TbName.Text))
            {
                ClassGlobalVars.textMB = ("Необходимо заполнить обязательные поля");
                new WindowMessageError().ShowDialog();
            }
            else
            {
                DBEntities.GetContext().Usluga.FirstOrDefault(z => z.Name == nameProduct).Name = TbName.Text;
                if(TbDescription.Text == "")
                {
                    DBEntities.GetContext().Usluga.FirstOrDefault(z => z.Name == nameProduct).Description = "нету";
                }
                else
                {
                    DBEntities.GetContext().Usluga.FirstOrDefault(z => z.Name == nameProduct).Description = TbDescription.Text;
                }
                DBEntities.GetContext().SaveChanges();
                ClassGlobalVars.textMB = ("Успешно изменено");
                new WindowMessageInfo().ShowDialog();
                this.NavigationService.Navigate(new ListProductsPage());
            }
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
