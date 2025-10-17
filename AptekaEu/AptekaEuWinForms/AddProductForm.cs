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
            Close();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            Product productToAdd = new Product(null, (int)categoryIdNumericUpDown.Value)
            {
                Name = nameTextBox.Text,
                PurchasePrice = (double)purchasePriceNumericUpDown.Value,
                SalePrice = (double)salePriceNumericUpDown.Value,
                ActualQuantity = (int)actualQuantiryNumericUpDown.Value,
            };
            product = productToAdd;
        }
    }
}
