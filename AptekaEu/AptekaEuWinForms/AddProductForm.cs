using AptekaEuLib;
using AptekaEuLib.products;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AptekaEuWinForms
{
    public partial class AddProductForm : Form
    {
        public Product Product { get; set; }

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
            if (string.IsNullOrEmpty(nameTextBox.Text))
            {
                MessageBox.Show("Необходимо заполнить название товара.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (categoriesComboBox.SelectedItem == null)
            {
                MessageBox.Show("Необходимо выбрать категорию.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Product productToAdd = new Product(null)
                {
                    Name = nameTextBox.Text,
                    Category = (Category)categoriesComboBox.SelectedItem,
                    PurchasePrice = (double)purchasePriceNumericUpDown.Value,
                    SalePrice = (double)salePriceNumericUpDown.Value,
                    ActualQuantity = (int)actualQuantiryNumericUpDown.Value,
                };
                Product = productToAdd;

                DialogResult = DialogResult.OK;
            }
        }
    }
}
