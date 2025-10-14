using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Configuration;

namespace AptekaEuLib
{
    public class MySQLProductsReader : IProductsRepository
    {
        private string myConnectionString = ConfigurationManager.AppSettings["DbConnectionString"];

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

        public List<Product> ReadProducts()
        {
            List<Product> result = new List<Product>();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(myConnectionString))
                {
                    conn.Open();
                    string query = "SELECT * FROM products;";
                    MySqlCommand command = new MySqlCommand(query, conn);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Product product = new Product(reader.GetInt32("id"));
                            product.Name = reader.GetString("name");
                            product.CategoryId = reader.GetInt32("category_id");
                            product.PurchasePrice = reader.GetDouble("purchase_price");
                            product.SalePrice = reader.GetDouble("sale_price");
                            product.ActualQuantity = reader.GetInt32("actual_quantity");
                            result.Add(product);
                        }
                    }
                }
            }
            catch (Exception ex) {
                MessageBox.Show($"Произошла ошибка при загрузке товаров: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }
    }
}
