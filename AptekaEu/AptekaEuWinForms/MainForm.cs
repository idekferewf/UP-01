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

            productService_ = new ProductService(new ProductsRepository());
            FillProducts();
        }

        public void FillProducts()
        {
            products_ = new BindingList<Product>
            {
                new Product
                {
                    Name = "Парацетамол 500 мг",
                    CategoryId = 1,
                    PurchasePrice = 299.00,
                    SalePrice = 399.00,
                    ActualQuantity = 100
                },
                new Product
                {
                    Name = "Ибупрофен 200 мг",
                    CategoryId = 1,
                    PurchasePrice = 189.00,
                    SalePrice = 279.00,
                    ActualQuantity = 75
                },
                new Product
                {
                    Name = "Аспирин 100 мг",
                    CategoryId = 1,
                    PurchasePrice = 149.00,
                    SalePrice = 229.00,
                    ActualQuantity = 50
                },
                new Product
                {
                    Name = "Ношпа 40 мг",
                    CategoryId = 2,
                    PurchasePrice = 459.00,
                    SalePrice = 599.00,
                    ActualQuantity = 30
                },
                new Product
                {
                    Name = "Активированный уголь",
                    CategoryId = 3,
                    PurchasePrice = 79.00,
                    SalePrice = 129.00,
                    ActualQuantity = 200
                }
            };
            
            productsGridView.DataSource = products_;
            productsGridView.Columns["Name"].MinimumWidth = 160;
            productsGridView.Columns["CategoryId"].MinimumWidth = 90;
            productsGridView.Columns["PurchasePrice"].MinimumWidth = 110;
            productsGridView.Columns["SalePrice"].MinimumWidth = 110;
            productsGridView.Columns["ActualQuantity"].MinimumWidth = 120;
            productsGridView.Columns["ActualQuantity"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void addProductButton_Click(object sender, EventArgs e)
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
