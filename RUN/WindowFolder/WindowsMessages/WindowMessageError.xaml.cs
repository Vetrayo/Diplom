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
    /// Логика взаимодействия для WindowMessageError.xaml
    /// </summary>
    public partial class WindowMessageError : Window
    {
        public WindowMessageError()
        {
            InitializeComponent();

            TbInformatiom.Text = ClassGlobalVars.textMB;
        }

        private void BOkay_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                this.Close();
            }
        }
    }
}
