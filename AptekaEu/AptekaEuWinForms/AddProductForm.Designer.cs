namespace AptekaEuWinForms
{
    partial class AddProductForm
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
            this.nameLabel = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.addProductTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.actualQuantiryNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.salePriceNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.purchasePriceNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.categoryIdLabel = new System.Windows.Forms.Label();
            this.purchasePriceLabel = new System.Windows.Forms.Label();
            this.salePriceLabel = new System.Windows.Forms.Label();
            this.actualQuantityLabel = new System.Windows.Forms.Label();
            this.cancelButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.categoriesComboBox = new System.Windows.Forms.ComboBox();
            this.addProductTableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.actualQuantiryNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.salePriceNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.purchasePriceNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // titleLabel
            // 
            this.titleLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.titleLabel.Location = new System.Drawing.Point(0, 0);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(334, 66);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "Добавить товар";
            this.titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nameLabel
            // 
            this.nameLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.nameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nameLabel.Location = new System.Drawing.Point(34, 4);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(130, 22);
            this.nameLabel.TabIndex = 1;
            this.nameLabel.Text = "Название товара:";
            this.nameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nameTextBox
            // 
            this.nameTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.nameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nameTextBox.Location = new System.Drawing.Point(170, 4);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(130, 22);
            this.nameTextBox.TabIndex = 2;
            // 
            // addProductTableLayoutPanel
            // 
            this.addProductTableLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.addProductTableLayoutPanel.AutoSize = true;
            this.addProductTableLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.addProductTableLayoutPanel.ColumnCount = 2;
            this.addProductTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.addProductTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.addProductTableLayoutPanel.Controls.Add(this.actualQuantiryNumericUpDown, 1, 4);
            this.addProductTableLayoutPanel.Controls.Add(this.salePriceNumericUpDown, 1, 3);
            this.addProductTableLayoutPanel.Controls.Add(this.purchasePriceNumericUpDown, 1, 2);
            this.addProductTableLayoutPanel.Controls.Add(this.categoryIdLabel, 0, 1);
            this.addProductTableLayoutPanel.Controls.Add(this.nameLabel, 0, 0);
            this.addProductTableLayoutPanel.Controls.Add(this.nameTextBox, 1, 0);
            this.addProductTableLayoutPanel.Controls.Add(this.purchasePriceLabel, 0, 2);
            this.addProductTableLayoutPanel.Controls.Add(this.salePriceLabel, 0, 3);
            this.addProductTableLayoutPanel.Controls.Add(this.actualQuantityLabel, 0, 4);
            this.addProductTableLayoutPanel.Controls.Add(this.cancelButton, 1, 5);
            this.addProductTableLayoutPanel.Controls.Add(this.addButton, 0, 5);
            this.addProductTableLayoutPanel.Controls.Add(this.categoriesComboBox, 1, 1);
            this.addProductTableLayoutPanel.Location = new System.Drawing.Point(0, 69);
            this.addProductTableLayoutPanel.Name = "addProductTableLayoutPanel";
            this.addProductTableLayoutPanel.RowCount = 6;
            this.addProductTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.addProductTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.addProductTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.addProductTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.addProductTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.addProductTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.addProductTableLayoutPanel.Size = new System.Drawing.Size(334, 220);
            this.addProductTableLayoutPanel.TabIndex = 3;
            // 
            // actualQuantiryNumericUpDown
            // 
            this.actualQuantiryNumericUpDown.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.actualQuantiryNumericUpDown.Location = new System.Drawing.Point(170, 125);
            this.actualQuantiryNumericUpDown.Maximum = new decimal(new int[] {
            -727379969,
            232,
            0,
            0});
            this.actualQuantiryNumericUpDown.Name = "actualQuantiryNumericUpDown";
            this.actualQuantiryNumericUpDown.Size = new System.Drawing.Size(130, 20);
            this.actualQuantiryNumericUpDown.TabIndex = 10;
            // 
            // salePriceNumericUpDown
            // 
            this.salePriceNumericUpDown.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.salePriceNumericUpDown.DecimalPlaces = 2;
            this.salePriceNumericUpDown.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.salePriceNumericUpDown.Location = new System.Drawing.Point(170, 95);
            this.salePriceNumericUpDown.Maximum = new decimal(new int[] {
            -727379969,
            232,
            0,
            0});
            this.salePriceNumericUpDown.Name = "salePriceNumericUpDown";
            this.salePriceNumericUpDown.Size = new System.Drawing.Size(130, 20);
            this.salePriceNumericUpDown.TabIndex = 9;
            // 
            // purchasePriceNumericUpDown
            // 
            this.purchasePriceNumericUpDown.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.purchasePriceNumericUpDown.DecimalPlaces = 2;
            this.purchasePriceNumericUpDown.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.purchasePriceNumericUpDown.Location = new System.Drawing.Point(170, 65);
            this.purchasePriceNumericUpDown.Maximum = new decimal(new int[] {
            -727379969,
            232,
            0,
            0});
            this.purchasePriceNumericUpDown.Name = "purchasePriceNumericUpDown";
            this.purchasePriceNumericUpDown.Size = new System.Drawing.Size(130, 20);
            this.purchasePriceNumericUpDown.TabIndex = 8;
            // 
            // categoryIdLabel
            // 
            this.categoryIdLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.categoryIdLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.categoryIdLabel.Location = new System.Drawing.Point(34, 34);
            this.categoryIdLabel.Name = "categoryIdLabel";
            this.categoryIdLabel.Size = new System.Drawing.Size(130, 22);
            this.categoryIdLabel.TabIndex = 3;
            this.categoryIdLabel.Text = "ID категории:";
            this.categoryIdLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // purchasePriceLabel
            // 
            this.purchasePriceLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.purchasePriceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.purchasePriceLabel.Location = new System.Drawing.Point(34, 64);
            this.purchasePriceLabel.Name = "purchasePriceLabel";
            this.purchasePriceLabel.Size = new System.Drawing.Size(130, 22);
            this.purchasePriceLabel.TabIndex = 4;
            this.purchasePriceLabel.Text = "Цена закупки:";
            this.purchasePriceLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // salePriceLabel
            // 
            this.salePriceLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.salePriceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.salePriceLabel.Location = new System.Drawing.Point(34, 94);
            this.salePriceLabel.Name = "salePriceLabel";
            this.salePriceLabel.Size = new System.Drawing.Size(130, 22);
            this.salePriceLabel.TabIndex = 5;
            this.salePriceLabel.Text = "Цена продажи:";
            this.salePriceLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // actualQuantityLabel
            // 
            this.actualQuantityLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.actualQuantityLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.actualQuantityLabel.Location = new System.Drawing.Point(34, 124);
            this.actualQuantityLabel.Name = "actualQuantityLabel";
            this.actualQuantityLabel.Size = new System.Drawing.Size(130, 22);
            this.actualQuantityLabel.TabIndex = 6;
            this.actualQuantityLabel.Text = "Количество:";
            this.actualQuantityLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cancelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cancelButton.Location = new System.Drawing.Point(170, 170);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(100, 30);
            this.cancelButton.TabIndex = 5;
            this.cancelButton.Text = "Отменить";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // addButton
            // 
            this.addButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.addButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addButton.Location = new System.Drawing.Point(64, 170);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(100, 30);
            this.addButton.TabIndex = 4;
            this.addButton.Text = "Добавить";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // categoriesComboBox
            // 
            this.categoriesComboBox.FormattingEnabled = true;
            this.categoriesComboBox.Location = new System.Drawing.Point(170, 33);
            this.categoriesComboBox.Name = "categoriesComboBox";
            this.categoriesComboBox.Size = new System.Drawing.Size(130, 21);
            this.categoriesComboBox.TabIndex = 11;
            // 
            // AddProductForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 306);
            this.Controls.Add(this.addProductTableLayoutPanel);
            this.Controls.Add(this.titleLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximumSize = new System.Drawing.Size(350, 345);
            this.MinimumSize = new System.Drawing.Size(350, 345);
            this.Name = "AddProductForm";
            this.Text = "Добавление товара – AptekaEu";
            this.addProductTableLayoutPanel.ResumeLayout(false);
            this.addProductTableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.actualQuantiryNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.salePriceNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.purchasePriceNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.TableLayoutPanel addProductTableLayoutPanel;
        private System.Windows.Forms.Label categoryIdLabel;
        private System.Windows.Forms.Label purchasePriceLabel;
        private System.Windows.Forms.Label salePriceLabel;
        private System.Windows.Forms.Label actualQuantityLabel;
        private System.Windows.Forms.NumericUpDown actualQuantiryNumericUpDown;
        private System.Windows.Forms.NumericUpDown salePriceNumericUpDown;
        private System.Windows.Forms.NumericUpDown purchasePriceNumericUpDown;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.ComboBox categoriesComboBox;
    }
}