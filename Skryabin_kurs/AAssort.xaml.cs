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
    /// Interaction logic for AAssort.xaml
    /// </summary>
    public partial class AAssort : Page
    {
        public AAssort()
        {
            InitializeComponent();
            //DataContext = _product;
            //DGridRecords.ItemsSource = TovarEntities.GetContext().Products.ToList();
        }

        private void btnAdd_click(object sender, RoutedEventArgs e)
        {
            AddEditPageA pageA = new AddEditPageA(null, null, null, null, "0", false);
            pageA.Show();
        }
        private void DGridRecords_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                string connectionString = "SERVER=localhost;DATABASE=database_auto;UID=root;PASSWORD=;";
                MySqlConnection connection = new MySqlConnection(connectionString);

                MySqlCommand cmd = new MySqlCommand("select * from produkt", connection);
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
                AddEditPageA pageA = new AddEditPageA(_DataView.Row[1].ToString(), _DataView.Row[2].ToString(), _DataView.Row[3].ToString(), _DataView.Row[4].ToString(), _DataView.Row[0].ToString(), true);
                pageA.Show();
            }
        }
    }
}
