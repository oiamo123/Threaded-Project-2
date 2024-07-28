namespace ThreadedProject2
{
    partial class AddEditPackageProduct
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
            btnExit = new Button();
            btnAccept = new Button();
            grbDetails = new GroupBox();
            txtSupplier = new TextBox();
            txtProduct = new TextBox();
            btnNewProduct = new Button();
            btnNewSupplier = new Button();
            cboProduct = new ComboBox();
            cboSupplier = new ComboBox();
            lblSupplier = new Label();
            lblProduct = new Label();
            grbDetails.SuspendLayout();
            SuspendLayout();
            // 
            // btnExit
            // 
            btnExit.Font = new Font("Segoe UI", 12F);
            btnExit.Location = new Point(464, 135);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(113, 35);
            btnExit.TabIndex = 14;
            btnExit.Text = "Exit";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // btnAccept
            // 
            btnAccept.Font = new Font("Segoe UI", 12F);
            btnAccept.Location = new Point(16, 135);
            btnAccept.Name = "btnAccept";
            btnAccept.Size = new Size(113, 35);
            btnAccept.TabIndex = 12;
            btnAccept.Text = "Accept";
            btnAccept.UseVisualStyleBackColor = true;
            btnAccept.Click += btnAccept_Click;
            // 
            // grbDetails
            // 
            grbDetails.Controls.Add(txtSupplier);
            grbDetails.Controls.Add(txtProduct);
            grbDetails.Controls.Add(btnNewProduct);
            grbDetails.Controls.Add(btnNewSupplier);
            grbDetails.Controls.Add(cboProduct);
            grbDetails.Controls.Add(cboSupplier);
            grbDetails.Controls.Add(lblSupplier);
            grbDetails.Controls.Add(lblProduct);
            grbDetails.Font = new Font("Segoe UI", 12F);
            grbDetails.Location = new Point(9, 7);
            grbDetails.Margin = new Padding(2);
            grbDetails.Name = "grbDetails";
            grbDetails.Padding = new Padding(2);
            grbDetails.Size = new Size(575, 123);
            grbDetails.TabIndex = 15;
            grbDetails.TabStop = false;
            grbDetails.Text = "Product Details";
            // 
            // txtSupplier
            // 
            txtSupplier.Location = new Point(115, 81);
            txtSupplier.Margin = new Padding(2);
            txtSupplier.Name = "txtSupplier";
            txtSupplier.Size = new Size(317, 29);
            txtSupplier.TabIndex = 18;
            txtSupplier.Tag = "Supplier Name";
            // 
            // txtProduct
            // 
            txtProduct.Location = new Point(115, 34);
            txtProduct.Margin = new Padding(2);
            txtProduct.Name = "txtProduct";
            txtProduct.Size = new Size(317, 29);
            txtProduct.TabIndex = 17;
            txtProduct.Tag = "Product Name";
            // 
            // btnNewProduct
            // 
            btnNewProduct.Font = new Font("Segoe UI", 12F);
            btnNewProduct.Location = new Point(442, 34);
            btnNewProduct.Name = "btnNewProduct";
            btnNewProduct.Size = new Size(126, 29);
            btnNewProduct.TabIndex = 16;
            btnNewProduct.Text = "New";
            btnNewProduct.UseVisualStyleBackColor = true;
            btnNewProduct.Click += btnNewProduct_Click;
            // 
            // btnNewSupplier
            // 
            btnNewSupplier.Font = new Font("Segoe UI", 12F);
            btnNewSupplier.Location = new Point(442, 81);
            btnNewSupplier.Name = "btnNewSupplier";
            btnNewSupplier.Size = new Size(126, 29);
            btnNewSupplier.TabIndex = 15;
            btnNewSupplier.Text = "New";
            btnNewSupplier.UseVisualStyleBackColor = true;
            btnNewSupplier.Click += btnNewSupplier_Click;
            // 
            // cboProduct
            // 
            cboProduct.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cboProduct.FormattingEnabled = true;
            cboProduct.Location = new Point(115, 33);
            cboProduct.Margin = new Padding(2);
            cboProduct.Name = "cboProduct";
            cboProduct.Size = new Size(317, 29);
            cboProduct.TabIndex = 0;
            cboProduct.Tag = "Product";
            cboProduct.KeyPress += cboProduct_KeyPress;
            // 
            // cboSupplier
            // 
            cboSupplier.Font = new Font("Segoe UI", 12F);
            cboSupplier.FormattingEnabled = true;
            cboSupplier.Location = new Point(115, 81);
            cboSupplier.Margin = new Padding(2);
            cboSupplier.Name = "cboSupplier";
            cboSupplier.Size = new Size(317, 29);
            cboSupplier.TabIndex = 3;
            cboSupplier.Tag = "Supplier";
            cboSupplier.KeyPress += cboSupplier_KeyPress;
            // 
            // lblSupplier
            // 
            lblSupplier.AutoSize = true;
            lblSupplier.Font = new Font("Segoe UI", 12F);
            lblSupplier.Location = new Point(24, 84);
            lblSupplier.Margin = new Padding(2, 0, 2, 0);
            lblSupplier.Name = "lblSupplier";
            lblSupplier.Size = new Size(71, 21);
            lblSupplier.TabIndex = 2;
            lblSupplier.Text = "Supplier:";
            // 
            // lblProduct
            // 
            lblProduct.AutoSize = true;
            lblProduct.Font = new Font("Segoe UI", 12F);
            lblProduct.Location = new Point(28, 36);
            lblProduct.Margin = new Padding(2, 0, 2, 0);
            lblProduct.Name = "lblProduct";
            lblProduct.Size = new Size(67, 21);
            lblProduct.TabIndex = 1;
            lblProduct.Text = "Product:";
            // 
            // AddEditPackageProduct
            // 
            AcceptButton = btnAccept;
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            CancelButton = btnExit;
            ClientSize = new Size(594, 177);
            Controls.Add(grbDetails);
            Controls.Add(btnExit);
            Controls.Add(btnAccept);
            Margin = new Padding(2);
            Name = "AddEditPackageProduct";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AddEditProduct";
            Load += AddEditPackageProduct_Load;
            grbDetails.ResumeLayout(false);
            grbDetails.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button btnExit;
        private Button btnAccept;
        private GroupBox grbDetails;
        private ComboBox cboProduct;
        private Label lblProduct;
        private ComboBox cboSupplier;
        private Label lblSupplier;
        private Button btnNewProduct;
        private Button btnNewSupplier;
        private TextBox txtSupplier;
        private TextBox txtProduct;
    }
}