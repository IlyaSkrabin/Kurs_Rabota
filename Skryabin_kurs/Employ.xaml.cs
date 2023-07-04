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
    /// Interaction logic for Employ.xaml
    /// </summary>
    public partial class Employ : Page
    {
        public string query;
        public string name_string;
        private DataTable dataTable = new DataTable();

        public Employ()
        {
            InitializeComponent();
            Window_Loaded();
        }
        private void Window_Loaded()
        {
            LoadDataFromMySQL();
            DGridRecord.ItemsSource = dataTable.DefaultView;
        }
        private void LoadDataFromMySQL()
        {
            string connectionString = "SERVER=localhost;DATABASE=database_auto;UID=root;PASSWORD=;";
            string query = "SELECT * FROM polzovateli;";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection))
                {
                    adapter.Fill(dataTable);
                }
            }
        }
        private void btnAdd_click(object sender, RoutedEventArgs e)
        {
              AddEditPageE pageE = new AddEditPageE(null, null, null, null, null, null, false);
              pageE.Show();
        }



        private void DataGridRow_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

            DataRowView _DataView = DGridRecord.CurrentCell.Item as DataRowView;

            if (_DataView != null)
            {
                AddEditPageE pageA = new AddEditPageE(_DataView.Row[2].ToString(), _DataView.Row[3].ToString(), _DataView.Row[8].ToString(), _DataView.Row[6].ToString(), _DataView.Row[5].ToString(), _DataView.Row[0].ToString(), true);
                pageA.Show();
            }
            
        }
    }
}
