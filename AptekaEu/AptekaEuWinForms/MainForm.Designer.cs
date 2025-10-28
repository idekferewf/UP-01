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
            this.productsTabControl = new System.Windows.Forms.TabControl();
            this.mainTabs = new System.Windows.Forms.TabPage();
            this.productsToolStrip = new System.Windows.Forms.ToolStrip();
            this.addProductButton = new System.Windows.Forms.ToolStripButton();
            this.removeProductIcon = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.productsGridView)).BeginInit();
            this.productsTabControl.SuspendLayout();
            this.mainTabs.SuspendLayout();
            this.productsToolStrip.SuspendLayout();
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
            this.productsGridView.Location = new System.Drawing.Point(3, 37);
            this.productsGridView.Name = "productsGridView";
            this.productsGridView.ReadOnly = true;
            this.productsGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.productsGridView.Size = new System.Drawing.Size(786, 384);
            this.productsGridView.TabIndex = 0;
            // 
            // productsTabControl
            // 
            this.productsTabControl.Controls.Add(this.mainTabs);
            this.productsTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.productsTabControl.Location = new System.Drawing.Point(0, 0);
            this.productsTabControl.Name = "productsTabControl";
            this.productsTabControl.SelectedIndex = 0;
            this.productsTabControl.Size = new System.Drawing.Size(800, 450);
            this.productsTabControl.TabIndex = 5;
            // 
            // mainTabs
            // 
            this.mainTabs.Controls.Add(this.productsToolStrip);
            this.mainTabs.Controls.Add(this.productsGridView);
            this.mainTabs.Location = new System.Drawing.Point(4, 22);
            this.mainTabs.Name = "mainTabs";
            this.mainTabs.Padding = new System.Windows.Forms.Padding(3);
            this.mainTabs.Size = new System.Drawing.Size(792, 424);
            this.mainTabs.TabIndex = 0;
            this.mainTabs.Text = "Товары";
            this.mainTabs.UseVisualStyleBackColor = true;
            // 
            // productsToolStrip
            // 
            this.productsToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addProductButton,
            this.removeProductIcon});
            this.productsToolStrip.Location = new System.Drawing.Point(3, 3);
            this.productsToolStrip.Name = "productsToolStrip";
            this.productsToolStrip.Size = new System.Drawing.Size(786, 31);
            this.productsToolStrip.TabIndex = 5;
            this.productsToolStrip.Text = "toolStrip2";
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
            // removeProductIcon
            // 
            this.removeProductIcon.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.removeProductIcon.Image = ((System.Drawing.Image)(resources.GetObject("removeProductIcon.Image")));
            this.removeProductIcon.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.removeProductIcon.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.removeProductIcon.Name = "removeProductIcon";
            this.removeProductIcon.Size = new System.Drawing.Size(28, 28);
            this.removeProductIcon.Text = "Удалить товары";
            this.removeProductIcon.Click += new System.EventHandler(this.removeProductIcon_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.productsTabControl);
            this.MinimumSize = new System.Drawing.Size(600, 350);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Главная – AptekaEu";
            ((System.ComponentModel.ISupportInitialize)(this.productsGridView)).EndInit();
            this.productsTabControl.ResumeLayout(false);
            this.mainTabs.ResumeLayout(false);
            this.mainTabs.PerformLayout();
            this.productsToolStrip.ResumeLayout(false);
            this.productsToolStrip.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView productsGridView;
        private System.Windows.Forms.TabControl productsTabControl;
        private System.Windows.Forms.TabPage mainTabs;
        private System.Windows.Forms.ToolStrip productsToolStrip;
        private System.Windows.Forms.ToolStripButton addProductButton;
        private System.Windows.Forms.ToolStripButton removeProductIcon;
    }
}

