using AptekaEuLib.products;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AptekaEuLib.supplies
{
    public class MySQLSuppliesReader : ISuppliesRepository
    {
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
                            s.serial_number, s.supplier_tin, s.delivery_date,
                            si.product_id, si.quantity, si.unit_price, si.production_date, si.expiry_date,
                            p.name as product_name, p.category_id, c.name as category_name, p.purchase_price, p.sale_price, p.actual_quantity
                        FROM supplies s
                            LEFT JOIN supply_items si ON s.serial_number = si.supply_serial_number
                            LEFT JOIN products p ON si.product_id = p.id
                            LEFT JOIN categories c ON p.category_id = c.id
                        ORDER BY s.delivery_date, s.serial_number";

                    MySqlCommand command = new MySqlCommand(query, conn);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        Supply currentSupply = null;
                        string currentSerialNumber = null;

                        while (reader.Read())
                        {
                            string serialNumber = reader.GetString("serial_number");

                            /// Создаём объект Supply, если это новая поставка
                            if (currentSerialNumber != serialNumber)
                            {
                                currentSupply = new Supply(serialNumber)
                                {
                                    SupplierTin = reader.GetString("supplier_tin"),
                                    DeliveryDate = reader.GetDateTime("delivery_date"),
                                    Items = new List<SupplyItem>()
                                };
                                result.Add(currentSupply);
                                currentSerialNumber = serialNumber;
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
