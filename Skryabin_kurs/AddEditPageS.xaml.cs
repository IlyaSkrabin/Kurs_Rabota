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
using System.Windows.Shapes;

namespace Skryabin_kurs
{
    /// <summary>
    /// Логика взаимодействия для AddEditPageS.xaml
    /// </summary>
    public partial class AddEditPageS : Window
    {
        public string intQ;
        public bool isEditt;
        public AddEditPageS(string name, string email, string phone, string adress, string id, bool isEdit)
        {
            InitializeComponent();

            NameTb.Text = name;
            EmailTb.Text = email;
            PhoneTb.Text = phone;
            AdressTb.Text = adress;
            intQ = id;
            isEditt = isEdit;
        }
        private void btnSave_click(object sender, RoutedEventArgs e)
        {
            /*if (_currentEmploy.Id_employ == 0)
            {
                TovarEntities.GetContext().Employs.Add(new Employ {FIO = FIOTb.Text.Trim(), Position = PositionTb.Text.Trim(), Email = EmailTb.Text.Trim(), Adress = AdressTb.Text.Trim(), PhoneNumber = PhoneTb.Text.Trim()});
            }*/
            if (isEditt)
            {
                string connectionString = "SERVER=localhost;DATABASE=database_auto;UID=root;PASSWORD=;";
                MySqlConnection myConnection_c = new MySqlConnection(connectionString);
                MySqlCommand myCommand_c = new MySqlCommand("UPDATE polzovateli SET name='" + NameTb.Text.Trim() + "',email='" + EmailTb.Text.Trim() + "',nomer_telefona='" + PhoneTb.Text.Trim() + "',adress='" + AdressTb.Text.Trim() + "'WHERE id_polzovatela='" + int.Parse(intQ) + "'", myConnection_c);
                myConnection_c.Open(); //Устанавливаем соединение с базой данных
                MySqlDataReader mdr_c = myCommand_c.ExecuteReader();
                MessageBox.Show("Информация сохранена");
                Close();
            }
            else
            {
                if (NameTb.Text.Trim() != "" && EmailTb.Text.Trim() != "" && AdressTb.Text.Trim() != "" && PhoneTb.Text.Trim() != "")
                {
                    try
                    {
                        string connectionString = "SERVER=localhost;DATABASE=database_auto;UID=root;PASSWORD=;";
                        MySqlConnection connection = new MySqlConnection(connectionString);
                        if (connection.State == System.Data.ConnectionState.Closed)
                        {
                            connection.Open();
                        }
                        MySqlCommand cmd = new MySqlCommand("proc_add_employ", connection);
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@nam", NameTb.Text.Trim());
                        cmd.Parameters.AddWithValue("@mail", EmailTb.Text.Trim());
                        cmd.Parameters.AddWithValue("@pass", "password");
                        cmd.Parameters.AddWithValue("@adres", AdressTb.Text.Trim());
                        cmd.Parameters.AddWithValue("@phone", PhoneTb.Text.Trim());
                        cmd.Parameters.AddWithValue("@dolzh", null);
                        cmd.Parameters.AddWithValue("@typee", 4);
                        int i = cmd.ExecuteNonQuery();
                        if (i > 0)
                        {
                            MessageBox.Show("Информация сохранена");
                        }
                        Close();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("Не все поля заполнены для добавления товара!");
                }


            }
        }
        private void btnCancel_click(object sender, RoutedEventArgs e)
        {
            Close();
        }


        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string connectionString = "SERVER=localhost;DATABASE=database_auto;UID=root;PASSWORD=;";
            MySqlConnection myConnection_c = new MySqlConnection(connectionString);
            MySqlCommand myCommand_c = new MySqlCommand("Select * from dolchnost", myConnection_c);
            myConnection_c.Open(); //Устанавливаем соединение с базой данных
            MySqlDataReader mdr_c = myCommand_c.ExecuteReader();

            //cmd_textbox.Text = cmd_textbox.Text + "--- myConnection_c \n";
            myConnection_c.Close();
        }

        private void BtnSave_Copy_Click(object sender, RoutedEventArgs e)
        {
            string connectionString = "SERVER=localhost;DATABASE=database_auto;UID=root;PASSWORD=;";
            MySqlConnection myConnection_c = new MySqlConnection(connectionString);
            MySqlCommand myCommand_c = new MySqlCommand("DELETE FROM polzovateli WHERE id_polzovatela ='" + int.Parse(intQ) + "'", myConnection_c);
            myConnection_c.Open(); //Устанавливаем соединение с базой данных
            MySqlDataReader mdr_c = myCommand_c.ExecuteReader();
            MessageBox.Show("Информация сохранена");
            Close();
        }
    }
}
