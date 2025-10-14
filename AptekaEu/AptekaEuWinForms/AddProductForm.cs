using AptekaEuLib;
using System;
using System.Windows.Forms;

namespace AptekaEuWinForms
{
    public partial class AddProductForm : Form
    {
        public Product product { get; set; }

        public AddProductForm()
        {
            InitializeComponent();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            nameTextBox.Text = "";
            categoryIdNumericUpDown.Value = 0;
            purchasePriceNumericUpDown.Value = 0;
            salePriceNumericUpDown.Value = 0;
            actualQuantiryNumericUpDown.Value = 0;
            Close();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            Product productToAdd = new Product
            {
                Name = nameTextBox.Text,
                CategoryId = (int)categoryIdNumericUpDown.Value,
                PurchasePrice = (double)purchasePriceNumericUpDown.Value,
                SalePrice = (double)salePriceNumericUpDown.Value,
                ActualQuantity = (int)actualQuantiryNumericUpDown.Value,
            };
            product = productToAdd;
        }
    }
}
