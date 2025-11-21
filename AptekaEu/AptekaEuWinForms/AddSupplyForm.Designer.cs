namespace AptekaEuWinForms
{
    partial class AddSupplyForm
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
            this.titleLabel = new System.Windows.Forms.Label();
            this.serialNumberTextBox = new System.Windows.Forms.TextBox();
            this.supplierComboBox = new System.Windows.Forms.ComboBox();
            this.serialNumberLabel = new System.Windows.Forms.Label();
            this.supplierLabel = new System.Windows.Forms.Label();
            this.deliveryDatePicker = new System.Windows.Forms.DateTimePicker();
            this.deliveryDateLabel = new System.Windows.Forms.Label();
            this.productsListBox = new System.Windows.Forms.ListBox();
            this.itemsGridView = new System.Windows.Forms.DataGridView();
            this.addSupplyButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.itemsLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.itemsGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // titleLabel
            // 
            this.titleLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.titleLabel.Location = new System.Drawing.Point(0, 0);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(497, 81);
            this.titleLabel.TabIndex = 1;
            this.titleLabel.Text = "Добавить поставку";
            this.titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // serialNumberTextBox
            // 
            this.serialNumberTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.serialNumberTextBox.Location = new System.Drawing.Point(161, 84);
            this.serialNumberTextBox.Name = "serialNumberTextBox";
            this.serialNumberTextBox.Size = new System.Drawing.Size(294, 20);
            this.serialNumberTextBox.TabIndex = 3;
            // 
            // supplierComboBox
            // 
            this.supplierComboBox.FormattingEnabled = true;
            this.supplierComboBox.Location = new System.Drawing.Point(161, 110);
            this.supplierComboBox.Name = "supplierComboBox";
            this.supplierComboBox.Size = new System.Drawing.Size(294, 21);
            this.supplierComboBox.TabIndex = 12;
            // 
            // serialNumberLabel
            // 
            this.serialNumberLabel.AutoSize = true;
            this.serialNumberLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.serialNumberLabel.Location = new System.Drawing.Point(34, 86);
            this.serialNumberLabel.Name = "serialNumberLabel";
            this.serialNumberLabel.Size = new System.Drawing.Size(120, 16);
            this.serialNumberLabel.TabIndex = 13;
            this.serialNumberLabel.Text = "Серийный номер:";
            // 
            // supplierLabel
            // 
            this.supplierLabel.AutoSize = true;
            this.supplierLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.supplierLabel.Location = new System.Drawing.Point(72, 112);
            this.supplierLabel.Name = "supplierLabel";
            this.supplierLabel.Size = new System.Drawing.Size(82, 16);
            this.supplierLabel.TabIndex = 14;
            this.supplierLabel.Text = "Поставщик:";
            // 
            // deliveryDatePicker
            // 
            this.deliveryDatePicker.Location = new System.Drawing.Point(161, 137);
            this.deliveryDatePicker.Name = "deliveryDatePicker";
            this.deliveryDatePicker.Size = new System.Drawing.Size(294, 20);
            this.deliveryDatePicker.TabIndex = 15;
            // 
            // deliveryDateLabel
            // 
            this.deliveryDateLabel.AutoSize = true;
            this.deliveryDateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.deliveryDateLabel.Location = new System.Drawing.Point(48, 138);
            this.deliveryDateLabel.Name = "deliveryDateLabel";
            this.deliveryDateLabel.Size = new System.Drawing.Size(106, 16);
            this.deliveryDateLabel.TabIndex = 16;
            this.deliveryDateLabel.Text = "Дата поставки:";
            // 
            // productsListBox
            // 
            this.productsListBox.FormattingEnabled = true;
            this.productsListBox.Location = new System.Drawing.Point(12, 206);
            this.productsListBox.Name = "productsListBox";
            this.productsListBox.Size = new System.Drawing.Size(149, 186);
            this.productsListBox.TabIndex = 17;
            // 
            // itemsGridView
            // 
            this.itemsGridView.AllowUserToAddRows = false;
            this.itemsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.itemsGridView.Location = new System.Drawing.Point(167, 206);
            this.itemsGridView.Name = "itemsGridView";
            this.itemsGridView.Size = new System.Drawing.Size(318, 186);
            this.itemsGridView.TabIndex = 18;
            // 
            // addSupplyButton
            // 
            this.addSupplyButton.Location = new System.Drawing.Point(281, 404);
            this.addSupplyButton.Name = "addSupplyButton";
            this.addSupplyButton.Size = new System.Drawing.Size(99, 23);
            this.addSupplyButton.TabIndex = 20;
            this.addSupplyButton.Text = "Ок";
            this.addSupplyButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(386, 404);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(99, 23);
            this.cancelButton.TabIndex = 21;
            this.cancelButton.Text = "Отмена";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // itemsLabel
            // 
            this.itemsLabel.AutoSize = true;
            this.itemsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.itemsLabel.Location = new System.Drawing.Point(11, 181);
            this.itemsLabel.Name = "itemsLabel";
            this.itemsLabel.Size = new System.Drawing.Size(132, 16);
            this.itemsLabel.TabIndex = 22;
            this.itemsLabel.Text = "Позиции поставки:";
            // 
            // AddSupplyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(497, 439);
            this.Controls.Add(this.itemsLabel);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.addSupplyButton);
            this.Controls.Add(this.itemsGridView);
            this.Controls.Add(this.productsListBox);
            this.Controls.Add(this.deliveryDateLabel);
            this.Controls.Add(this.deliveryDatePicker);
            this.Controls.Add(this.supplierLabel);
            this.Controls.Add(this.serialNumberLabel);
            this.Controls.Add(this.supplierComboBox);
            this.Controls.Add(this.serialNumberTextBox);
            this.Controls.Add(this.titleLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AddSupplyForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Добавление поставки – AptekaEu";
            ((System.ComponentModel.ISupportInitialize)(this.itemsGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.TextBox serialNumberTextBox;
        private System.Windows.Forms.ComboBox supplierComboBox;
        private System.Windows.Forms.Label serialNumberLabel;
        private System.Windows.Forms.Label supplierLabel;
        private System.Windows.Forms.DateTimePicker deliveryDatePicker;
        private System.Windows.Forms.Label deliveryDateLabel;
        private System.Windows.Forms.ListBox productsListBox;
        private System.Windows.Forms.DataGridView itemsGridView;
        private System.Windows.Forms.Button addSupplyButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label itemsLabel;
    }
}