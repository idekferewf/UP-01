using AptekaEuLib;
using AptekaEuLib.supplies;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace AptekaEuWinForms
{
    public partial class AddSupplyForm: Form
    {
        private BindingList<SupplyItem> supplyItems_ = new BindingList<SupplyItem>();
        private List<Product> products_;

        public Supply Supply { get; set; }

        public AddSupplyForm(List<Supplier> suppliers, BindingList<Product> products)
        {
            InitializeComponent();

            FillSuppliers(suppliers);
            FillProducts(products);
            FillSupplyItems();
        }

        public void FillSuppliers(List<Supplier> suppliers)
        {
            supplierComboBox.DataSource = suppliers;
            supplierComboBox.DisplayMember = "Name";
        }

        public void FillProducts(BindingList<Product> products)
        {
            products_ = new List<Product>(products);
            productsListBox.DataSource = products_;
        }

        public void FillSupplyItems()
        {
            itemsGridView.DataSource = supplyItems_;
            itemsGridView.Columns["Category"].Visible = false;
            itemsGridView.Columns["UnitPriceDisplay"].Visible = false;
            itemsGridView.Columns["ProductionDate"].DefaultCellStyle.Format = "dd.MM.yyyy";
            itemsGridView.Columns["ExpiryDate"].DefaultCellStyle.Format = "dd.MM.yyyy";
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void addSupplyButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(serialNumberTextBox.Text))
            {
                MessageBox.Show("Необходимо заполнить серийный номер поставки.", "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (supplierComboBox.SelectedItem == null)
            {
                MessageBox.Show("Необходимо выбрать поставщика.", "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (itemsGridView.Rows.Count == 0)
            {
                MessageBox.Show("Необходимо добавить хотя бы одну позицию.", "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Supply supplyToAdd = new Supply(serialNumberTextBox.Text)
                {
                    Supplier = (Supplier)supplierComboBox.SelectedItem,
                    DeliveryDate = deliveryDatePicker.Value,
                    Items = new List<SupplyItem>(supplyItems_)
                };
                Supply = supplyToAdd;
                DialogResult = DialogResult.OK;
            }
        }

        private void AddProducts(List<Product> products)
        {
            foreach (Product product in products)
            {
                if (supplyItems_.Any(i => i.Product.Name == product.Name))
                {
                    MessageBox.Show($"Товар «{product.Name}» уже добавлен.", "Ошибка добавления", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    continue;
                }

                SupplyItem supplyItem = new SupplyItem() { Product = product };
                supplyItems_.Add(supplyItem);
            }
        }

        private void productsListBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Product product = (Product)productsListBox.SelectedItem;
            if (supplyItems_.Any(i => i.Product.Name == product.Name))
            {
                MessageBox.Show("Данный товар уже добавлен.", "Ошибка добавления", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            SupplyItem supplyItem = new SupplyItem() { Product = product };
            supplyItems_.Add(supplyItem);
        }

        private void addSelectedProductsButton_Click(object sender, EventArgs e)
        {
            if (productsListBox.SelectedItems.Count == 0)
            {
                MessageBox.Show("Не выбрано ни одного товара.", "Ошибка добавления", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            List<Product> selectedProducts = productsListBox.SelectedItems.Cast<Product>().ToList();
            AddProducts(selectedProducts);
        }

        private void addAllProductsButton_Click(object sender, EventArgs e)
        {
            List<Product> allProducts = productsListBox.Items.Cast<Product>().ToList();
            AddProducts(allProducts);
        }

        private void itemsGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;

            string errorMessage;
            if (e.Exception is FormatException)
            {
                errorMessage = "Неверный формат данных. Проверьте введенные значения.";
            }
            else
            {
                errorMessage = e.Exception.Message;
            }

            MessageBox.Show(errorMessage, "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);

            e.Cancel = true;
        }

        private void itemsGridView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            itemsGridView.Rows[e.RowIndex].Cells["ProductionDate"].Value = DateTime.Today;
            itemsGridView.Rows[e.RowIndex].Cells["ExpiryDate"].Value = DateTime.Today.AddYears(1);
        }

        private void searchProductsTextBox_TextChanged(object sender, EventArgs e)
        {
            List<Product> result;
            if (string.IsNullOrEmpty(searchProductsTextBox.Text))
            {
                result = products_;
            }
            else
            {
                result = products_.Where(p => p.Name.Contains(searchProductsTextBox.Text)).ToList();
            }

            productsListBox.DataSource = null;
            productsListBox.DataSource = result;
        }
    }   
}
