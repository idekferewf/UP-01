using AptekaEuLib.products;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AptekaEuLib.supplies
{
    public class MySQLSuppliesReader : ISuppliesRepository
    {
        public bool AddSupply(Supply supply)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(MySQLConfig.DbConnectionString))
                {
                    conn.Open();
                    using (MySqlTransaction transaction = conn.BeginTransaction())
                    {
                        try
                        {
                            // Добавление поставки
                            string supplyQuery = @"
                                INSERT INTO supplies (serial_number, supplier_tin, delivery_date) 
                                VALUES (@serial_number, @supplier_tin, @delivery_date);";

                            MySqlCommand supplyCommand = new MySqlCommand(supplyQuery, conn, transaction);
                            supplyCommand.Parameters.AddWithValue("@serial_number", supply.SerialNumber);
                            supplyCommand.Parameters.AddWithValue("@supplier_tin", supply.Supplier.Tin);
                            supplyCommand.Parameters.AddWithValue("@delivery_date", supply.DeliveryDate);
                            supplyCommand.ExecuteNonQuery();

                            // Добавление позиций поставки
                            foreach (SupplyItem item in supply.Items)
                            {
                                string supplyItemQuery = @"
                                    INSERT INTO supply_items (supply_serial_number, product_id, quantity, unit_price, production_date, expiry_date) 
                                    VALUES (@supply_serial_number, @product_id, @quantity, @unit_price, @production_date, @expiry_date);";

                                MySqlCommand itemCommand = new MySqlCommand(supplyItemQuery, conn, transaction);
                                itemCommand.Parameters.AddWithValue("@supply_serial_number", supply.SerialNumber);
                                itemCommand.Parameters.AddWithValue("@product_id", item.Product.Id);
                                itemCommand.Parameters.AddWithValue("@quantity", item.Quantity);
                                itemCommand.Parameters.AddWithValue("@unit_price", item.UnitPrice);
                                itemCommand.Parameters.AddWithValue("@production_date", item.ProductionDate);
                                itemCommand.Parameters.AddWithValue("@expiry_date", item.ExpiryDate);
                                itemCommand.ExecuteNonQuery();
                            }

                            transaction.Commit();
                        }
                        catch (Exception)
                        {
                            transaction.Rollback();
                            return false;
                        }
                    }
                }
            } 
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public List<Supply> ReadSupplies()
        {
            List<Supply> result = new List<Supply>();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(MySQLConfig.DbConnectionString))
                {
                    conn.Open();

                    string query =
                        @"SELECT 
                            supplies.serial_number, supplies.supplier_tin, supplies.delivery_date, suppliers.name as supplier_name,
                            supply_items.product_id, supply_items.quantity, supply_items.unit_price, supply_items.production_date, supply_items.expiry_date,
                            products.name as product_name, products.category_id, categories.name as category_name, products.purchase_price, products.sale_price, products.actual_quantity
                        FROM supplies supplies
                            INNER JOIN suppliers suppliers ON supplies.supplier_tin = suppliers.tin
                            INNER JOIN supply_items supply_items ON supplies.serial_number = supply_items.supply_serial_number
                            INNER JOIN products products ON supply_items.product_id = products.id
                            INNER JOIN categories categories ON products.category_id = categories.id
                        ORDER BY supplies.serial_number;";

                    MySqlCommand command = new MySqlCommand(query, conn);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        Supply currentSupply = null;

                        while (reader.Read())
                        {
                            string serialNumber = reader.GetString("serial_number");

                            /// Создаём объект Supply, если это новая поставка
                            if (currentSupply?.SerialNumber != serialNumber)
                            {
                                Supplier supplier = new Supplier(reader.GetString("supplier_tin"))
                                {
                                    Name = reader.GetString("supplier_name"),
                                };

                                currentSupply = new Supply(serialNumber)
                                {
                                    Supplier = supplier,
                                    DeliveryDate = reader.GetDateTime("delivery_date"),
                                    Items = new List<SupplyItem>()
                                };
                                result.Add(currentSupply);
                            }

                            /// Получение товара и категории
                            Product product = new Product(reader.GetInt32("product_id"));
                            product.Name = reader.GetString("product_name");

                            Category category = new Category(reader.GetInt32("category_id"));
                            category.Name = reader.GetString("category_name");
                            product.Category = category;

                            product.PurchasePrice = reader.GetDouble("purchase_price");
                            product.SalePrice = reader.GetDouble("sale_price");
                            product.ActualQuantity = reader.GetInt32("actual_quantity");

                            /// Получение позиции поставки
                            SupplyItem supplyItem = new SupplyItem
                            {
                                Product = product,
                                Quantity = reader.GetInt32("quantity"),
                                UnitPrice = reader.GetDouble("unit_price"),
                                ProductionDate = reader.GetDateTime("production_date"),
                                ExpiryDate = reader.GetDateTime("expiry_date")
                            };

                            currentSupply.Items.Add(supplyItem);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка при загрузке поставок: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }
    }
}
