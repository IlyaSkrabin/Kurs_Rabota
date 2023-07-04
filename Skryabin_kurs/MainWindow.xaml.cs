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
using System.Windows.Forms;
using System.Drawing;
using MySql.Data.MySqlClient;
using System.Data;

namespace Skryabin_kurs
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public CornerRadius CornerRadius { get; set; }
        public MainWindow()
        {
            InitializeComponent();

            
        }

        private void reg_button_Click(object sender, RoutedEventArgs e)
        {
            if (EmailTb.Text.Trim() != "" && NameTb.Text.Trim() != "" && PasswordTb.Text.Trim() != "")
            {
                try
                {
                    string connectionString = "SERVER=localhost;DATABASE=database_auto;UID=root;PASSWORD=;";
                    MySqlConnection connection = new MySqlConnection(connectionString);
                    if (connection.State == System.Data.ConnectionState.Closed)
                    {
                        connection.Open();
                    }
                    MySqlCommand cmd = new MySqlCommand("proc_register", connection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@nam", NameTb.Text.Trim());
                    cmd.Parameters.AddWithValue("@mail", EmailTb.Text.Trim());
                    cmd.Parameters.AddWithValue("@pass", PasswordTb.Text.Trim());
                    cmd.Parameters.AddWithValue("@phone", PhoneTb.Text.Trim());
                    int i = cmd.ExecuteNonQuery();
                    if (i > 0)
                    {
                        System.Windows.Forms.MessageBox.Show("Успешная регистрация.");
                        LogIn log = new LogIn();
                        log.Show();
                        this.Hide();
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Вы не заполнили поля для регистрации.");
            }
        }
            private void reg_link_Click(object sender, RoutedEventArgs e)
        {
            LogIn min2 = new LogIn();
            min2.Show();
            Close();
            string connectionString = "SERVER=localhost;DATABASE=database_auto;UID=root;PASSWORD=;";

            try
            {
                MySqlConnection connection = new MySqlConnection(connectionString);

                MySqlCommand cmd = new MySqlCommand("select * from polzovateli", connection);
                connection.Open();
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Ошибка подключения к БД");
                throw;
            }
        }

        private void Button_Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }


        private void Button_Sver_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
    }
}
