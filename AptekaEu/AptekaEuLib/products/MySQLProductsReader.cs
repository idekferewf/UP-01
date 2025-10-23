using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using AptekaEuLib.products;

namespace AptekaEuLib
{
    public class MySQLProductsReader : IProductsRepository
    {
        public bool AddProduct(Product product)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(MySQLConfig.DbConnectionString))
                {
                    conn.Open();
                    string query = "INSERT INTO products (name, category_id, purchase_price, sale_price, actual_quantity) " +
                                   "VALUES (@name, @category_id, @purchase_price, @sale_price, @actual_quantity);";

                    MySqlCommand command = new MySqlCommand(query, conn);
                    command.Parameters.AddWithValue("@name", product.Name);
                    command.Parameters.AddWithValue("@category_id", product.Category.Id);
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
                using (MySqlConnection conn = new MySqlConnection(MySQLConfig.DbConnectionString))
                {
                    conn.Open();
                    string query = @"SELECT p.id, p.category_id, p.name, c.name as category_name, p.purchase_price, p.sale_price, p.actual_quantity 
                                     FROM products p INNER JOIN categories c ON p.category_id = c.id";
                    MySqlCommand command = new MySqlCommand(query, conn);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Product product = new Product(reader.GetInt32("id"));
                            product.Name = reader.GetString("name");

                            Category category = new Category(reader.GetInt32("category_id"));
                            category.Name = reader.GetString("category_name");
                            product.Category = category;

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

        public List<Category> ReadCategories()
        {
            List<Category> result = new List<Category>();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(MySQLConfig.DbConnectionString))
                {
                    conn.Open();
                    string query = @"SELECT id, name FROM categories;";
                    MySqlCommand command = new MySqlCommand(query, conn);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Category category = new Category(reader.GetInt32("id"));
                            category.Name = reader.GetString("name");
                            result.Add(category);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка при загрузке категорий: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }
    }
}
