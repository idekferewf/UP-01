namespace AptekaEuWinForms
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.productsGridView = new System.Windows.Forms.DataGridView();
            this.mainTabControl = new System.Windows.Forms.TabControl();
            this.productsTab = new System.Windows.Forms.TabPage();
            this.productsToolStrip = new System.Windows.Forms.ToolStrip();
            this.addProductButton = new System.Windows.Forms.ToolStripButton();
            this.removeProductsButton = new System.Windows.Forms.ToolStripButton();
            this.suppliesTab = new System.Windows.Forms.TabPage();
            this.suppliesToolStrip = new System.Windows.Forms.ToolStrip();
            this.supplierFilterLabel = new System.Windows.Forms.ToolStripLabel();
            this.supplierFilterComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.suppliesGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.productsGridView)).BeginInit();
            this.mainTabControl.SuspendLayout();
            this.productsTab.SuspendLayout();
            this.productsToolStrip.SuspendLayout();
            this.suppliesTab.SuspendLayout();
            this.suppliesToolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.suppliesGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // productsGridView
            // 
            this.productsGridView.AllowUserToAddRows = false;
            this.productsGridView.AllowUserToDeleteRows = false;
            this.productsGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.productsGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.productsGridView.ColumnHeadersHeight = 40;
            this.productsGridView.Location = new System.Drawing.Point(3, 37);
            this.productsGridView.Name = "productsGridView";
            this.productsGridView.ReadOnly = true;
            this.productsGridView.RowHeadersWidth = 72;
            this.productsGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.productsGridView.Size = new System.Drawing.Size(786, 384);
            this.productsGridView.TabIndex = 0;
            // 
            // mainTabControl
            // 
            this.mainTabControl.Controls.Add(this.productsTab);
            this.mainTabControl.Controls.Add(this.suppliesTab);
            this.mainTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainTabControl.Location = new System.Drawing.Point(0, 0);
            this.mainTabControl.Name = "mainTabControl";
            this.mainTabControl.SelectedIndex = 0;
            this.mainTabControl.Size = new System.Drawing.Size(800, 450);
            this.mainTabControl.TabIndex = 5;
            this.mainTabControl.SelectedIndexChanged += new System.EventHandler(this.mainTabControl_SelectedIndexChanged);
            // 
            // productsTab
            // 
            this.productsTab.Controls.Add(this.productsToolStrip);
            this.productsTab.Controls.Add(this.productsGridView);
            this.productsTab.Location = new System.Drawing.Point(4, 22);
            this.productsTab.Name = "productsTab";
            this.productsTab.Padding = new System.Windows.Forms.Padding(3);
            this.productsTab.Size = new System.Drawing.Size(792, 424);
            this.productsTab.TabIndex = 0;
            this.productsTab.Text = "Товары";
            this.productsTab.UseVisualStyleBackColor = true;
            // 
            // productsToolStrip
            // 
            this.productsToolStrip.ImageScalingSize = new System.Drawing.Size(28, 28);
            this.productsToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addProductButton,
            this.removeProductsButton});
            this.productsToolStrip.Location = new System.Drawing.Point(3, 3);
            this.productsToolStrip.Name = "productsToolStrip";
            this.productsToolStrip.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.productsToolStrip.Size = new System.Drawing.Size(786, 31);
            this.productsToolStrip.TabIndex = 5;
            this.productsToolStrip.Text = "Управление товарами";
            // 
            // addProductButton
            // 
            this.addProductButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.addProductButton.Image = global::AptekaEuWinForms.Properties.Resources.addIcon;
            this.addProductButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.addProductButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addProductButton.Name = "addProductButton";
            this.addProductButton.Size = new System.Drawing.Size(28, 28);
            this.addProductButton.Text = "Добавить товар";
            this.addProductButton.Click += new System.EventHandler(this.addProductButton_Click);
            // 
            // removeProductsButton
            // 
            this.removeProductsButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.removeProductsButton.Image = ((System.Drawing.Image)(resources.GetObject("removeProductsButton.Image")));
            this.removeProductsButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.removeProductsButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.removeProductsButton.Name = "removeProductsButton";
            this.removeProductsButton.Size = new System.Drawing.Size(28, 28);
            this.removeProductsButton.Text = "Удалить товары";
            this.removeProductsButton.Click += new System.EventHandler(this.removeProductsButton_Click);
            // 
            // suppliesTab
            // 
            this.suppliesTab.Controls.Add(this.suppliesToolStrip);
            this.suppliesTab.Controls.Add(this.suppliesGridView);
            this.suppliesTab.Location = new System.Drawing.Point(4, 22);
            this.suppliesTab.Name = "suppliesTab";
            this.suppliesTab.Size = new System.Drawing.Size(792, 424);
            this.suppliesTab.TabIndex = 1;
            this.suppliesTab.Text = "Поставки";
            this.suppliesTab.UseVisualStyleBackColor = true;
            // 
            // suppliesToolStrip
            // 
            this.suppliesToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.supplierFilterLabel,
            this.supplierFilterComboBox});
            this.suppliesToolStrip.Location = new System.Drawing.Point(0, 0);
            this.suppliesToolStrip.Name = "suppliesToolStrip";
            this.suppliesToolStrip.Size = new System.Drawing.Size(792, 25);
            this.suppliesToolStrip.TabIndex = 2;
            this.suppliesToolStrip.Text = "Инструменты для поставок";
            // 
            // supplierFilterLabel
            // 
            this.supplierFilterLabel.Name = "supplierFilterLabel";
            this.supplierFilterLabel.Size = new System.Drawing.Size(73, 22);
            this.supplierFilterLabel.Text = "Поставщик:";
            // 
            // supplierFilterComboBox
            // 
            this.supplierFilterComboBox.Items.AddRange(new object[] {
            "Все"});
            this.supplierFilterComboBox.Name = "supplierFilterComboBox";
            this.supplierFilterComboBox.Size = new System.Drawing.Size(121, 25);
            this.supplierFilterComboBox.Text = "Все";
            this.supplierFilterComboBox.TextChanged += new System.EventHandler(this.supplierFilterComboBox_TextChanged);
            // 
            // suppliesGridView
            // 
            this.suppliesGridView.AllowUserToAddRows = false;
            this.suppliesGridView.AllowUserToDeleteRows = false;
            this.suppliesGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.suppliesGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.suppliesGridView.ColumnHeadersHeight = 40;
            this.suppliesGridView.Location = new System.Drawing.Point(0, 28);
            this.suppliesGridView.Name = "suppliesGridView";
            this.suppliesGridView.ReadOnly = true;
            this.suppliesGridView.RowHeadersWidth = 72;
            this.suppliesGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.suppliesGridView.Size = new System.Drawing.Size(792, 396);
            this.suppliesGridView.TabIndex = 1;
            this.suppliesGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.suppliesGridView_CellDoubleClick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.mainTabControl);
            this.MinimumSize = new System.Drawing.Size(596, 339);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Главная – AptekaEu";
            ((System.ComponentModel.ISupportInitialize)(this.productsGridView)).EndInit();
            this.mainTabControl.ResumeLayout(false);
            this.productsTab.ResumeLayout(false);
            this.productsTab.PerformLayout();
            this.productsToolStrip.ResumeLayout(false);
            this.productsToolStrip.PerformLayout();
            this.suppliesTab.ResumeLayout(false);
            this.suppliesTab.PerformLayout();
            this.suppliesToolStrip.ResumeLayout(false);
            this.suppliesToolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.suppliesGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView productsGridView;
        private System.Windows.Forms.TabControl mainTabControl;
        private System.Windows.Forms.TabPage productsTab;
        private System.Windows.Forms.ToolStrip productsToolStrip;
        private System.Windows.Forms.ToolStripButton addProductButton;
        private System.Windows.Forms.ToolStripButton removeProductsButton;
        private System.Windows.Forms.TabPage suppliesTab;
        private System.Windows.Forms.DataGridView suppliesGridView;
        private System.Windows.Forms.ToolStrip suppliesToolStrip;
        private System.Windows.Forms.ToolStripLabel supplierFilterLabel;
        private System.Windows.Forms.ToolStripComboBox supplierFilterComboBox;
    }
}

