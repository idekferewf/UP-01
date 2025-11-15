namespace AptekaEuWinForms
{
    partial class SuppliesItemsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.suppliesItemsGridView = new System.Windows.Forms.DataGridView();
            this.suppliesItemsStatusStrip = new System.Windows.Forms.StatusStrip();
            this.totalCostStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.suppliesItemsGridView)).BeginInit();
            this.suppliesItemsStatusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // suppliesItemsGridView
            // 
            this.suppliesItemsGridView.AllowUserToAddRows = false;
            this.suppliesItemsGridView.AllowUserToDeleteRows = false;
            this.suppliesItemsGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.suppliesItemsGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.suppliesItemsGridView.ColumnHeadersHeight = 40;
            this.suppliesItemsGridView.Location = new System.Drawing.Point(0, 0);
            this.suppliesItemsGridView.Name = "suppliesItemsGridView";
            this.suppliesItemsGridView.ReadOnly = true;
            this.suppliesItemsGridView.RowHeadersWidth = 72;
            this.suppliesItemsGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.suppliesItemsGridView.Size = new System.Drawing.Size(763, 404);
            this.suppliesItemsGridView.TabIndex = 1;
            // 
            // suppliesItemsStatusStrip
            // 
            this.suppliesItemsStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.totalCostStatusLabel});
            this.suppliesItemsStatusStrip.Location = new System.Drawing.Point(0, 404);
            this.suppliesItemsStatusStrip.Name = "suppliesItemsStatusStrip";
            this.suppliesItemsStatusStrip.Size = new System.Drawing.Size(763, 22);
            this.suppliesItemsStatusStrip.TabIndex = 2;
            this.suppliesItemsStatusStrip.Text = "Общая информация позиций";
            // 
            // totalCostStatusLabel
            // 
            this.totalCostStatusLabel.Name = "totalCostStatusLabel";
            this.totalCostStatusLabel.Size = new System.Drawing.Size(97, 17);
            this.totalCostStatusLabel.Text = "Общая сумма: –";
            // 
            // SuppliesItemsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(763, 426);
            this.Controls.Add(this.suppliesItemsStatusStrip);
            this.Controls.Add(this.suppliesItemsGridView);
            this.MinimumSize = new System.Drawing.Size(600, 400);
            this.Name = "SuppliesItemsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Позиции поставки – AptekaEu";
            ((System.ComponentModel.ISupportInitialize)(this.suppliesItemsGridView)).EndInit();
            this.suppliesItemsStatusStrip.ResumeLayout(false);
            this.suppliesItemsStatusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView suppliesItemsGridView;
        private System.Windows.Forms.StatusStrip suppliesItemsStatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel totalCostStatusLabel;
    }
}