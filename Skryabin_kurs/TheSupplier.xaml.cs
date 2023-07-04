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
using MySql.Data.MySqlClient;
using System.Data;

namespace Skryabin_kurs
{
    /// <summary>
    /// Interaction logic for TheSupplier.xaml
    /// </summary>
    public partial class TheSupplier : Page
    {
        public TheSupplier()
        {
            InitializeComponent();
            
        }
        private void btnAdd_click(object sender, RoutedEventArgs e)
        {
            AddEditPageS pageS = new AddEditPageS(null,null,null,null,null,false);
            pageS.Show();
        }
        private void DGridRecords_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                string connectionString = "SERVER=localhost;DATABASE=database_auto;UID=root;PASSWORD=;";
                MySqlConnection connection = new MySqlConnection(connectionString);

                MySqlCommand cmd = new MySqlCommand("SELECT * FROM polzovateli WHERE user_type_id_user_type = 4", connection);
                connection.Open();
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                connection.Close();
                DGridRecords.DataContext = dt;
            }
        }

        private void DataGridRow_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

            DataRowView _DataView = DGridRecords.CurrentCell.Item as DataRowView;

            if (_DataView != null)
            {
                AddEditPageS pageA = new AddEditPageS(_DataView.Row[2].ToString(), _DataView.Row[3].ToString(), _DataView.Row[6].ToString(), _DataView.Row[5].ToString(), _DataView.Row[0].ToString(), true);
                pageA.Show();
            }

        }
    }
}
