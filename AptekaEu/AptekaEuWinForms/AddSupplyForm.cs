using AptekaEuLib;
using AptekaEuLib.products;
using AptekaEuLib.supplies;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace AptekaEuWinForms
{
    public partial class AddSupplyForm: Form
    {
        private BindingList<SupplyItem> supplyItems_ = new BindingList<SupplyItem>();

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
            productsListBox.DataSource = products;
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
                MessageBox.Show("Необходимо заполнить серийный номер поставки.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (supplierComboBox.SelectedItem == null)
            {
                MessageBox.Show("Необходимо выбрать поставщика.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (itemsGridView.Rows.Count == 0)
            {
                MessageBox.Show("Необходимо добавить хотя бы одну позицию.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void productsListBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Product product = (Product)productsListBox.SelectedItem;
            SupplyItem supplyItem = new SupplyItem() 
            {
                Product = product,
            };
            supplyItems_.Add(supplyItem);
        }
    }
}
