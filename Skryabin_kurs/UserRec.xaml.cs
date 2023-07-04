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

namespace Skryabin_kurs
{
    /// <summary>
    /// Логика взаимодействия для UserRec.xaml
    /// </summary>
    public partial class UserRec : Window
    {
        private int id;
        public string priceInt;
        public string idProd;
        public UserRec(int iduser, string name, string article, string price, string quantity, string id_product)
        {
            InitializeComponent();
            id = iduser;
            productName.Text = name;
            articleTb.Text = "Артикул: " + article;
            priceTb.Text = "Цена: " + price + ".руб";
            priceInt = price;
            idProd = id_product;
            quantityTb.Text = quantity;
        }

        private void btnReg_click(object sender, RoutedEventArgs e)
        {
            string connectionString = "SERVER=localhost;DATABASE=database_auto;UID=root;PASSWORD=;";
            MySqlConnection connection = new MySqlConnection(connectionString);
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
            MySqlCommand cmd = new MySqlCommand("proc_order", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@userId", id);
            cmd.Parameters.AddWithValue("@quantityy", quantityTb.Text.Trim());
            cmd.Parameters.AddWithValue("@prodId", idProd);
            int i = cmd.ExecuteNonQuery();
            if (i > 0)
            {
                MessageBox.Show("Заказ успешно оформлен");
                Close();
                Application.Current.Windows.OfType<UserWindow>().SingleOrDefault(x => x.IsActive).Effect = null;
            }
            
        }
        private void btnCancel_click(object sender, RoutedEventArgs e)
        {
            Close();
            Application.Current.Windows.OfType<UserWindow>().SingleOrDefault(x => x.IsActive).Effect = null;
        }

        private void QuantityTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (String.IsNullOrEmpty(quantityTb.Text) || quantityTb.Text == "0")
            {
                priceItog.Text = "Количество не указано";
            }
            else
            {
                priceItog.Text = "Итого: " + int.Parse(priceInt) * int.Parse(quantityTb.Text.Trim()) + ".руб"; //здесь есть математическая функция (цена умножается на количество запчастей)
            }
            
        }
    }
}
