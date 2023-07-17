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
    public partial class ProductAddPage : Page
    {
        public ProductAddPage()
        {
            InitializeComponent();
        }

        private void BOut_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new ListProductsPage());
        }

        private void BEdit_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TbName.Text))
            {
                ClassGlobalVars.textMB = ("Необходимо написать название услуги");
                new WindowMessageError().ShowDialog();
                return;
            }
            if (TbDescription.Text == "")
            {
                DBEntities.GetContext().Usluga.Add(new Usluga()
                {
                    Name = TbName.Text,
                    Description = "нету",
                });
                DBEntities.GetContext().SaveChanges();
            }
            if (TbDescription.Text != "")
            {
                DBEntities.GetContext().Usluga.Add(new Usluga()
                {
                    Name = TbName.Text,
                    Description = TbDescription.Text,
                });
                DBEntities.GetContext().SaveChanges();
            }
            ClassGlobalVars.textMB = ("Вы добавили услугу");
            new WindowMessageInfo().ShowDialog();
            this.NavigationService.Navigate(new ListProductsPage());
        }

        private void Page_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                BEdit_Click(sender, e);
            }
        }
    }
}
