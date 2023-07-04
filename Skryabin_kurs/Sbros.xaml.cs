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
using System.Windows.Forms;
using System.Drawing;

namespace Skryabin_kurs
{
    /// <summary>
    /// Логика взаимодействия для Sbros.xaml
    /// </summary>
    public partial class Sbros : Window
    {
        public Sbros()
        {
            InitializeComponent();
        }

        private void Button_Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void Button_Sver_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void reg_link_Click(object sender, RoutedEventArgs e)
        {
            LogIn min2 = new LogIn();
            min2.Show();
            Close();
        }

        private void sbros_button_Click(object sender, RoutedEventArgs e)
        {

        }

        
    }
}
