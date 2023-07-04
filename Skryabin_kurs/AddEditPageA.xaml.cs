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
    /// Interaction logic for AddEditPageA.xaml
    /// </summary>
    public partial class AddEditPageA : Window
    {
        public int id_prod;
        public bool isEditt;
        public AddEditPageA(string name, string article, string price, string quantity, string id, bool isEdit)
        {
            InitializeComponent();
            id_prod = int.Parse(id);
            NameTb.Text= name;
            ArticleTb.Text = article;
            PriceTb.Text = price;
            MuchTb.Text = quantity;
            isEditt = isEdit;
        }

        private void btnSave_click(object sender, RoutedEventArgs e)
        {
            if (isEditt)
            {
                string connectionString = "SERVER=localhost;DATABASE=database_auto;UID=root;PASSWORD=;";
                MySqlConnection myConnection_c = new MySqlConnection(connectionString);
                MySqlCommand myCommand_c = new MySqlCommand("UPDATE produkt SET Name='" + NameTb.Text.Trim() + "',article='" + ArticleTb.Text.Trim() + "',price='" + PriceTb.Text.Trim() + "',quantity='" + MuchTb.Text.Trim() + "'WHERE Id_produkt='" + id_prod + "'", myConnection_c);
                myConnection_c.Open(); //Устанавливаем соединение с базой данных
                MySqlDataReader mdr_c = myCommand_c.ExecuteReader();
                MessageBox.Show("Информация сохранена");
                Close();
            }
            else
            {
                if (NameTb.Text.Trim() != "" && ArticleTb.Text.Trim() != "" && PriceTb.Text.Trim() != "" && MuchTb.Text.Trim() != "")
                {
                    try
                    {
                        string connectionString = "SERVER=localhost;DATABASE=database_auto;UID=root;PASSWORD=;";
                        MySqlConnection connection = new MySqlConnection(connectionString);
                        if (connection.State == System.Data.ConnectionState.Closed)
                        {
                            connection.Open();
                        }
                        MySqlCommand cmd = new MySqlCommand("proc_add_assort", connection);
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@nam", NameTb.Text.Trim());
                        cmd.Parameters.AddWithValue("@articl", ArticleTb.Text.Trim());
                        cmd.Parameters.AddWithValue("@pric", PriceTb.Text.Trim());
                        cmd.Parameters.AddWithValue("@quantit", MuchTb.Text.Trim());
                        int i = cmd.ExecuteNonQuery();
                        if (i > 0)
                        {
                            MessageBox.Show("Информация сохранена");
                        }
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
            
           
            Close();
        }

        private void btnCancel_click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void BtnSave_Copy_Click(object sender, RoutedEventArgs e)
        {
            string connectionString = "SERVER=localhost;DATABASE=database_auto;UID=root;PASSWORD=;";
            MySqlConnection myConnection_c = new MySqlConnection(connectionString);
            MySqlCommand myCommand_c = new MySqlCommand("DELETE FROM produkt WHERE Id_produkt ='" + id_prod + "'", myConnection_c);
            myConnection_c.Open(); //Устанавливаем соединение с базой данных
            MySqlDataReader mdr_c = myCommand_c.ExecuteReader();
            MessageBox.Show("Информация сохранена");
            Close();
        }
    }
}
