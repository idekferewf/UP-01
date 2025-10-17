using AptekaEuLib;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace AptekaEuWinForms
{
    public partial class MainForm: Form
    {
        private BindingList<Product> products_;
        private ProductService productService_;

        public MainForm()
        {
            InitializeComponent();

            productService_ = new ProductService(new MySQLProductsReader());

            FillProducts();
        }   

        public void FillProducts()
        {
            products_ = new BindingList<Product>(productService_.GetAllProducts());

            productsGridView.DataSource = products_;
            productsGridView.Columns["Name"].MinimumWidth = 160;
            productsGridView.Columns["CategoryName"].MinimumWidth = 180;
            productsGridView.Columns["PurchasePrice"].MinimumWidth = 110;
            productsGridView.Columns["SalePrice"].MinimumWidth = 110;
            productsGridView.Columns["ActualQuantity"].MinimumWidth = 120;
            productsGridView.Columns["ActualQuantity"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void addProductBtn_Click(object sender, EventArgs e)
        {
            AddProductForm addProductForm = new AddProductForm();
            if (addProductForm.ShowDialog() == DialogResult.OK)
            {
                string error = productService_.AddProduct(addProductForm.product);
                if (error != string.Empty)
                {
                    MessageBox.Show(error, "Ошибка при добавлении", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    products_.Add(addProductForm.product);
                    MessageBox.Show("Товар успешно добавлен!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
