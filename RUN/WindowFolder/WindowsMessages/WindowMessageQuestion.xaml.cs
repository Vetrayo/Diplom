using RUN.ClassFolder;
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
using System.Windows.Shapes;

namespace RUN.WindowFolder.WindowsMessages
{
    /// <summary>
    /// Логика взаимодействия для WindowMessageQuestion.xaml
    /// </summary>
    public partial class WindowMessageQuestion : Window
    {
        public WindowMessageQuestion()
        {
            InitializeComponent();

            TbInformatiom.Text = ClassGlobalVars.textMB;
        }

        private void BOkay_Click(object sender, RoutedEventArgs e)
        {
            ClassGlobalVars.acceptMB = "Да";
            this.Close();
        }

        private void BCancel_Click(object sender, RoutedEventArgs e)
        {
            ClassGlobalVars.acceptMB = "Нет";
            this.Close();
        }
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                BOkay_Click(sender, e);
            }

            if (e.Key == Key.Escape)
            {
                BCancel_Click(sender, e);
            }
        }
    }
}
