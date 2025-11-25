using AptekaEuLib;
using AptekaEuLib.products;
using AptekaEuLib.supplies;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace AptekaEuWinForms
{
    public partial class MainForm : Form
    {
        private ProductService productService_;
        private SupplyService supplyService_;

        public MainForm()
        {
            InitializeComponent();

            productService_ = new ProductService(new MySQLProductsReader());
            supplyService_ = new SupplyService(new MySQLSuppliesReader());

            FillProducts();
        }

        private void FillProducts()
        {
            productsGridView.DataSource = productService_.GetAllProducts();
            productsGridView.Columns["Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            productsGridView.Columns["Category"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void FillSupplies()
        {
            BindingList<Supply> supplies = supplyService_.GetAllSupplies();
            suppliesGridView.DataSource = supplies;
            suppliesGridView.Columns["DeliveryDate"].DefaultCellStyle.Format = "yyyy-MM-dd";
            supplierFilterComboBox.Items.AddRange(supplies.Select(s => s.SupplierName).Distinct().ToArray());
        }

        private void FillFilteredSupplies()
        {
            suppliesGridView.DataSource = null;
            suppliesGridView.DataSource = supplyService_.FilteredAndSortedSupplies;
            suppliesGridView.Columns["DeliveryDate"].DefaultCellStyle.Format = "yyyy-MM-dd";
        }

        private void addProductButton_Click(object sender, EventArgs e)
        {
            List<Category> categories = productService_.GetAllCategories();
            if (categories.Count == 0)
            {
                MessageBox.Show("Для добавления товара необходимо добавить хотя бы одну категорию.", "Нет категорий", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            AddProductForm addProductForm = new AddProductForm(categories);
            if (addProductForm.ShowDialog() == DialogResult.OK)
            {
                string error = productService_.AddProduct(addProductForm.Product);
                if (error != string.Empty)
                {
                    MessageBox.Show(error, "Ошибка при добавлении", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Товар успешно добавлен!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void removeProductsButton_Click(object sender, EventArgs e)
        {
            if (productsGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Не выбрано ни одного товара.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult result = MessageBox.Show(
                "Вы действительно хотите удалить выбранные товары?",
                "Подтверждение удаления",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result != DialogResult.Yes)
            {
                return;
            }

            List<int> productIdsToDelete = new List<int>();
            foreach (DataGridViewRow row in productsGridView.SelectedRows)
            {
                Product product = (Product)row.DataBoundItem;
                productIdsToDelete.Add((int)product.Id);
            }

            string error = productService_.DeleteProducts(productIdsToDelete);
            if (error != string.Empty)
            {
                MessageBox.Show(error, "Ошибка при удалении", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Товары успешно удалены!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void mainTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (mainTabControl.SelectedIndex == 1)
            {
                Text = "Поставки – AptekaEu";
                FillSupplies();
            } else
            {
                Text = "Главная – AptekaEu";
            }
        }

        private void suppliesGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 && e.ColumnIndex == -1)
            {
                return;
            }

            if (e.RowIndex == -1 && e.ColumnIndex >= 0)
            {
                string propertyName = suppliesGridView.Columns[e.ColumnIndex].DataPropertyName;
                supplyService_.SortBy(propertyName);
                FillFilteredSupplies();
                return;
            }

            DataGridViewRow row = suppliesGridView.Rows[e.RowIndex];
            Supply supply = (Supply)row.DataBoundItem;

            if (supply != null)
            {
                SuppliesItemsForm suppliesItemsForm = new SuppliesItemsForm(supply);
                suppliesItemsForm.ShowDialog();
            }
        }

        private void supplierFilterComboBox_TextChanged(object sender, EventArgs e)
        {
            supplyService_.FilterBySupplierTin(supplierFilterComboBox.Text);
            FillFilteredSupplies();
        }

        private void addSupplyButton_Click(object sender, EventArgs e)
        {
            List<Supplier> suppliers = supplyService_.GetAllSuppliers();

            if (suppliers.Count == 0)
            {
                MessageBox.Show("Для добавления поставки необходимо добавить хотя бы одного поставщика.", "Нет поставщиков", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (productService_.Products.Count == 0)
            {
                MessageBox.Show("Для добавления поставки необходимо добавить хотя бы один товар.", "Нет товаров", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            AddSupplyForm addSupplyForm = new AddSupplyForm(suppliers, productService_.Products);
            if (addSupplyForm.ShowDialog() == DialogResult.OK)
            {
                string error = supplyService_.AddSupply(addSupplyForm.Supply);
                if (error != string.Empty)
                {
                    MessageBox.Show(error, "Ошибка при добавлении", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    FillFilteredSupplies();
                    MessageBox.Show("Поставка успешно добавлена!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void generateReportsButton_Click(object sender, EventArgs e)
        {
            if (suppliesGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Не выбрано ни одной поставки.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            foreach (DataGridViewRow row in suppliesGridView.SelectedRows)
            {
                Supply supply = (Supply)row.DataBoundItem;
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "HTML files (*.html)|*.html";
                    saveFileDialog.FileName = $"Приходная накладная {supply.SerialNumber}.html";
                    saveFileDialog.DefaultExt = "html";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            SupplyReportGenerator reportGenerator = new SupplyReportGenerator();
                            reportGenerator.SaveReportToFile(supply, saveFileDialog.FileName);
                            MessageBox.Show($"Отчет успешно сохранен по пути: {saveFileDialog.FileName}", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Ошибка при сохранении отчета:\n{ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }
    }
}
