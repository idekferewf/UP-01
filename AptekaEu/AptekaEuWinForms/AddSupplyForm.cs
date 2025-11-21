using AptekaEuLib.supplies;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AptekaEuWinForms
{
    public partial class AddSupplyForm: Form
    {
        public Supply Supply { get; set; }

        public AddSupplyForm(List<Supplier> suppliers)
        {
            InitializeComponent();
        }

        public void FillSuppliers(List<Supplier> suppliers)
        {
            supplierComboBox.DataSource = suppliers;
        }
    }
}
