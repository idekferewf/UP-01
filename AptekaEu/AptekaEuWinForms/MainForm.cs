using AptekaEuLib;
using AptekaEuLib.products;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace AptekaEuWinForms
{
    public partial class MainForm: Form
    {
        private ProductService productService_;

        public MainForm()
        {
            InitializeComponent();

            productService_ = new ProductService(new MySQLProductsReader());
            FillProducts();
        }   

        public void FillProducts()
        {
            productsGridView.DataSource = productService_.GetAllProducts();
            productsGridView.Columns["Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            productsGridView.Columns["Category"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void addProductBtn_Click(object sender, EventArgs e)
        {
            List<Category> categories = productService_.GetAllCategories();
            AddProductForm addProductForm = new AddProductForm(categories);
            if (addProductForm.ShowDialog() == DialogResult.OK)
            {
                string error = productService_.AddProduct(addProductForm.product);
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
    }
}
