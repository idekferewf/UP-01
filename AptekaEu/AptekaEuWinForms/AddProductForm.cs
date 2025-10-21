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
            if (string.IsNullOrEmpty(nameTextBox.Text))
            {
                MessageBox.Show("Необходимо заполнить название товара.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (categoriesComboBox.SelectedItem == null)
            {
                MessageBox.Show("Необходимо выбрать категорию.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (purchasePriceNumericUpDown.Value <= 0) {
                MessageBox.Show("Цена покупки должна быть больше 0.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (salePriceNumericUpDown.Value <= 0)
            {
                MessageBox.Show("Цена продажи должна быть больше 0.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (actualQuantiryNumericUpDown.Value < 1)
            {
                MessageBox.Show("Минимальное количество товара - 1 шт.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                product = productToAdd;

                DialogResult = DialogResult.OK;
            }
        }
    }
}
