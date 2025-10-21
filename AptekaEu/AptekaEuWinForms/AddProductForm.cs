using AptekaEuLib;
using AptekaEuLib.products;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AptekaEuWinForms
{
    public partial class AddProductForm : Form
    {
        public Product product { get; set; }

        public AddProductForm(List<Category> categories)
        {
            InitializeComponent();
            FillCategories(categories);
        }

        private void FillCategories(List<Category> categories)
        {
            categoriesComboBox.DataSource = categories;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            Product productToAdd = new Product(null)
            {
                Name = nameTextBox.Text,
                Category = (Category)categoriesComboBox.SelectedItem,
                PurchasePrice = (double)purchasePriceNumericUpDown.Value,
                SalePrice = (double)salePriceNumericUpDown.Value,
                ActualQuantity = (int)actualQuantiryNumericUpDown.Value,
            };
            product = productToAdd;
        }
    }
}
