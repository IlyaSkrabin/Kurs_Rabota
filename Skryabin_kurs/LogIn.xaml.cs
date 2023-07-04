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
using MySql.Data.MySqlClient;
using System.Data;

namespace Skryabin_kurs
{
    /// <summary>
    /// Логика взаимодействия для LogIn.xaml
    /// </summary>
    public partial class LogIn : Window
    {
        public LogIn()
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

        private void login_button_Click(object sender, RoutedEventArgs e)
        {
            string connectionString = "SERVER=localhost;DATABASE=database_auto;UID=root;PASSWORD=;";

            try
            {
                MySqlConnection connection = new MySqlConnection(connectionString);
                connection.Open();

                MySqlCommand cmd = new MySqlCommand("Select * from polzovateli where email='" + LoginTb.Text.Trim() + "' and password='" + PasswordTb.Text.Trim() + "'", connection);
                cmd.Parameters.AddWithValue("@email", LoginTb.Text.ToString());
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    System.Windows.Forms.MessageBox.Show("Добро пожаловать, " + reader["name"].ToString());
                    //int intQ = int.Parse(reader[8].ToString());
                }
                int intQ = int.Parse(reader[8].ToString());
                int intQ1 = int.Parse(reader[0].ToString());
                if (intQ == 1 || intQ ==3)
                {
                    HomeWindow admin = new HomeWindow(reader["name"].ToString(), intQ1, reader["password"].ToString());
                    admin.Show();
                    Close();
                }
                else
                {

                    //bool successLogin = Logining(LoginTb.Text.Trim(), PasswordTb.Text.Trim());
                    //MessageBox.Show(successLogin ? "Вы вошли в систему" : "Зарегистрируйтесь");
                    //if (successLogin == true)
                    //{
                        UserWindow main = new UserWindow(reader["name"].ToString(),  intQ1, reader["password"].ToString());
                        main.Show();
                        Close();
                    //}

                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Ошибка подключения к БД");
                throw;
            }
            
          
        }
        /*public bool Logining(string email, string pass)
        {
            //return TovarEntities.GetContext().Users.Any(p => p.Email == email && p.Password == pass);
        }
        public User Log(string email, string pass)
        {
            //return TovarEntities.GetContext().Users.FirstOrDefault(p => p.Email == email && p.Password == pass);
        }*/
        private void reg_link_Click(object sender, RoutedEventArgs e)
        {

            MainWindow min1 = new MainWindow();
            min1.Show();
            Close();
        }

        private void sbros_link_Click(object sender, RoutedEventArgs e)
        {
            Sbros min3 = new Sbros();
            min3.Show();
            Close();
        }
    }
}
