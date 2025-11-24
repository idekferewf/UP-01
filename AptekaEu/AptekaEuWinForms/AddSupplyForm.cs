using AptekaEuLib;
using AptekaEuLib.supplies;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace AptekaEuWinForms
{
    public partial class AddSupplyForm: Form
    {
        public Supply Supply { get; set; }

        public AddSupplyForm(List<Supplier> suppliers, BindingList<Product> products)
        {
            InitializeComponent();

            FillSuppliers(suppliers);
            FillProducts(products);
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

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
