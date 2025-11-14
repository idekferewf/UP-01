using AptekaEuLib.supplies;
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
            totalCostStatusLabel.Text = $"Общая сумма – {supply.TotalCostDisplay}";
        }

        private void FillSuppliesItems(Supply supply)
        {
            suppliesItemsGridView.DataSource = supply.Items;
            suppliesItemsGridView.Columns["Product"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            suppliesItemsGridView.Columns["Category"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        } 
    }
}
