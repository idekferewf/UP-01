using System;
using MySql.Data.MySqlClient;

namespace AptekaEuLib
{
    public class MySQLProductsReader : IProductsRepository
    {
        private string myConnectionString = "server=127.0.0.1;uid=root;pwd=vertrigo;database=aptekaeu;";

        public bool AddProduct(Product product)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(myConnectionString))
                {
                    conn.Open();
                    string query = "INSERT INTO products (name, category_id, purchase_price, sale_price, actual_quantity) " +
                                   "VALUES (@name, @category_id, @purchase_price, @sale_price, @actual_quantity);";

                    MySqlCommand command = new MySqlCommand(query, conn);
                    command.Parameters.AddWithValue("@name", product.Name);
                    command.Parameters.AddWithValue("@category_id", product.CategoryId);
                    command.Parameters.AddWithValue("@purchase_price", product.PurchasePrice);
                    command.Parameters.AddWithValue("@sale_price", product.SalePrice);
                    command.Parameters.AddWithValue("@actual_quantity", product.ActualQuantity);

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
    }
}
