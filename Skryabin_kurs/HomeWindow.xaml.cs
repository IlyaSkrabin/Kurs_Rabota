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

namespace Skryabin_kurs
{
    /// <summary>
    /// Логика взаимодействия для HomeWindow.xaml
    /// </summary>
    public partial class HomeWindow : Window
    {
        private int id;
        private string passw;
        public HomeWindow()
        {
            InitializeComponent();
        }
        public HomeWindow(string name, int id_user, string password)
        {
            InitializeComponent();
            NickName.Text = name;
            id = id_user;
            passw = password;
        }

        private void Button_Close_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }


        private void Button_Sver_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            UserFrame.Navigate(new Profile(id , this, passw));
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new AAssort());
        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Employ());
        }

        private void RadioButton_Checked_2(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Records(0));
        }

        private void RadioButton_Checked_3(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new TheSupplier());
        }
    }
}
