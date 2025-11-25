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
            supplierFilterComboBox.Items.AddRange(supplies.Select(s => s.SupplierName).ToArray());
        }

        private void FillFilteredSupplies()
        {
            suppliesGridView.DataSource = null;
            suppliesGridView.DataSource = supplyService_.FilteredAndSortedSupplies;
        }

        private void addProductButton_Click(object sender, EventArgs e)
        {
            List<Category> categories = productService_.GetAllCategories();
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
                    MessageBox.Show("Поставка успешно добавлена!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
