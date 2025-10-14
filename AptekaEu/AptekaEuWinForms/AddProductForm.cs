using System;
using System.Windows.Forms;

namespace AptekaEuWinForms
{
    public partial class AddProductForm : Form
    {
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
    }
}
