using AptekaEuLib.supplies;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AptekaEuWinForms
{
    public partial class SuppliesItemsForm : Form
    {
        public SuppliesItemsForm(Supply supply)
        {
            InitializeComponent();

            FillSuppliesItems(supply);
            Text = $"Позиции поставки – {supply.SerialNumber}";
        }

        private void FillSuppliesItems(Supply supply)
        {
            suppliesItemsGridView.DataSource = supply.Items;
            suppliesItemsGridView.Columns["Product"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            suppliesItemsGridView.Columns["Category"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        } 
    }
}
