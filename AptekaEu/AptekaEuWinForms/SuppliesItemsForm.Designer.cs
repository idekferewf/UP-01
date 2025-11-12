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
            ((System.ComponentModel.ISupportInitialize)(this.suppliesItemsGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // suppliesItemsGridView
            // 
            this.suppliesItemsGridView.AllowUserToAddRows = false;
            this.suppliesItemsGridView.AllowUserToDeleteRows = false;
            this.suppliesItemsGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.suppliesItemsGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.suppliesItemsGridView.Location = new System.Drawing.Point(0, 0);
            this.suppliesItemsGridView.Name = "suppliesItemsGridView";
            this.suppliesItemsGridView.ReadOnly = true;
            this.suppliesItemsGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.suppliesItemsGridView.Size = new System.Drawing.Size(800, 450);
            this.suppliesItemsGridView.TabIndex = 1;
            // 
            // SuppliesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.suppliesItemsGridView);
            this.Name = "SuppliesForm";
            this.Text = "Позиции поставки – AptekaEu";
            ((System.ComponentModel.ISupportInitialize)(this.suppliesItemsGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView suppliesItemsGridView;
    }
}