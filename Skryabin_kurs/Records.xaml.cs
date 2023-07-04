using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for Records.xaml
    /// </summary>
    public partial class Records : Page
    {
        private int id;
        public Records(int Id_user)
        {
            InitializeComponent();
            id = Id_user;

        }
        private void DGridRecords_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                if(id != 0)
                {
                    string connectionString = "SERVER=localhost;DATABASE=database_auto;UID=root;PASSWORD=;";
                    MySqlConnection connection = new MySqlConnection(connectionString);

                    MySqlCommand cmd = new MySqlCommand("select * from `order` where polzovateli_id_polzovatela='" + id + "'", connection);
                    connection.Open();
                    DataTable dt = new DataTable();
                    dt.Load(cmd.ExecuteReader());
                    connection.Close();
                    DGridRecords.DataContext = dt;
                }
                else
                {
                    string connectionString = "SERVER=localhost;DATABASE=database_auto;UID=root;PASSWORD=;";
                    MySqlConnection connection = new MySqlConnection(connectionString);

                    MySqlCommand cmd = new MySqlCommand("select * from `order`", connection);
                    connection.Open();
                    DataTable dt = new DataTable();
                    dt.Load(cmd.ExecuteReader());
                    connection.Close();
                    DGridRecords.DataContext = dt;
                }
            }
        }

        private void DataGridRow_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            DataRowView _DataView = DGridRecords.CurrentCell.Item as DataRowView;

            if (_DataView != null)
            {
                MessageBoxResult result = MessageBox.Show("Вы действительно хотите удалить заказ?", "ВНИМАНИЕ!", MessageBoxButton.YesNo,MessageBoxImage.Question);
                if (result == MessageBoxResult.No)
                {
                    if (id != 0)
                    {
                        string connectionString = "SERVER=localhost;DATABASE=database_auto;UID=root;PASSWORD=;";
                        MySqlConnection connection = new MySqlConnection(connectionString);

                        MySqlCommand cmd = new MySqlCommand("select * from `order` where polzovateli_id_polzovatela='" + id + "'", connection);
                        connection.Open();
                        DataTable dt = new DataTable();
                        dt.Load(cmd.ExecuteReader());
                        connection.Close();
                        DGridRecords.DataContext = dt;
                    }
                    else
                    {
                        string connectionString = "SERVER=localhost;DATABASE=database_auto;UID=root;PASSWORD=;";
                        MySqlConnection connection = new MySqlConnection(connectionString);

                        MySqlCommand cmd = new MySqlCommand("select * from `order`", connection);
                        connection.Open();
                        DataTable dt = new DataTable();
                        dt.Load(cmd.ExecuteReader());
                        connection.Close();
                        DGridRecords.DataContext = dt;
                    }
                }
                else if (result == MessageBoxResult.Yes)
                {

                    string connectionString = "SERVER=localhost;DATABASE=database_auto;UID=root;PASSWORD=;";
                    MySqlConnection myConnection_c = new MySqlConnection(connectionString);
                    MySqlCommand myCommand_c = new MySqlCommand("DELETE FROM `order` WHERE id_order ='" + _DataView.Row[0].ToString() + "'", myConnection_c);
                    myConnection_c.Open(); //Устанавливаем соединение с базой данных
                    MySqlDataReader mdr_c = myCommand_c.ExecuteReader();
                    MessageBox.Show("Заказ удалён");
                }
            }
        }
    }
}
