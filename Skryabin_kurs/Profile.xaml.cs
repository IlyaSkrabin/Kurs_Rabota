using MySql.Data.MySqlClient;
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

namespace Skryabin_kurs
{
    /// <summary>
    /// Логика взаимодействия для Profile.xaml
    /// </summary>
    public partial class Profile : Page
    {
        private int id;
        private string pass;
        private HomeWindow main;
        private UserWindow UserWindow;
        public Profile()
        {
            InitializeComponent();
        }
        public Profile(int iduser, HomeWindow home, string passw)
        {
            InitializeComponent();
            id = iduser;
            main = home;
            pass = passw;
            string connectionString = "SERVER=localhost;DATABASE=database_auto;UID=root;PASSWORD=;";

            try
            {
                MySqlConnection connection = new MySqlConnection(connectionString);

                MySqlCommand cmd = new MySqlCommand("select * from polzovateli", connection);
                connection.Open();
                MySqlDataReader mdr_c = cmd.ExecuteReader();
                if (mdr_c.Read())
                {
                    NameTb.Text = mdr_c["name"].ToString();
                    EmailTb.Text = mdr_c["email"].ToString();
                    PhoneTb.Text = mdr_c["nomer_telefona"].ToString();
                }

            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Ошибка подключения к БД");
                throw;
            }

        }
        public Profile(int iduser, UserWindow user, string passw)
        {
            InitializeComponent();
            id = iduser;
            UserWindow = user;
            pass = passw;
            string connectionString = "SERVER=localhost;DATABASE=database_auto;UID=root;PASSWORD=;";

            try
            {
                MySqlConnection connection = new MySqlConnection(connectionString);

                MySqlCommand cmd = new MySqlCommand("select * from polzovateli where id_polzovatela="+id, connection);
                connection.Open();
                MySqlDataReader mdr_c = cmd.ExecuteReader();
                if (mdr_c.Read())
                {
                    NameTb.Text = mdr_c["name"].ToString();
                    EmailTb.Text = mdr_c["email"].ToString();
                    PhoneTb.Text = mdr_c["nomer_telefona"].ToString();
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Ошибка подключения к БД");
                throw;
            }

        }

        private void btnPass_click(object sender, RoutedEventArgs e)
        {
            Content = null;

        }

        private void btnSave_click(object sender, RoutedEventArgs e)
        {
            using (var connection = new MySqlConnection("SERVER=localhost;DATABASE=database_auto;UID=root;PASSWORD=;Allow User Variables=True"))
            {
                connection.Open();

                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "UPDATE polzovateli SET name='" + NameTb.Text.Trim() + "',email='" + EmailTb.Text.Trim() + "',nomer_telefona='" + PhoneTb.Text.Trim() + "'WHERE id_polzovatela='" + id + "'";
                    command.ExecuteNonQuery();
                    MessageBox.Show("Информация сохранена");

                    command.CommandText = "Select * from polzovateli where id_polzovatela='" + id + "'";
                    command.ExecuteNonQuery();
                    if (PasswordNewTb.Text != "" && PasswordOldTb.Text == pass)
                    {
                            command.CommandText = "UPDATE polzovateli SET password='" + PasswordNewTb.Text.Trim() + "'WHERE id_polzovatela='" + id + "'";
                            command.ExecuteNonQuery();
                            MessageBox.Show("Вы сменили пароль, будет произведён выход из системы");

                    }
                    else
                    {
                        MessageBox.Show("Пароль не был изменён");
                    }

                    //Similarly You can Add Multiple
                }
            }
            
            
            if (id == 1 || id == 2)
            {
                HomeWindow home = new HomeWindow(NameTb.Text.Trim(), id, null);
                home.Show();
            }
            else
            {
                UserWindow user = new UserWindow(NameTb.Text.Trim(), id, null);
                user.Show();
            }
            if (main != null)
            {
                main.Close();
            }
        }

        private void btnEXit_click(object sender, RoutedEventArgs e)
        {
            LogIn log = new LogIn();
            log.Show();
            if (main != null)
            {
                main.Close();
            }
        }
    }
}
