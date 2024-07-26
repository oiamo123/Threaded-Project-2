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
            txtSupplierID = new TextBox();
            lblSupplierID = new Label();
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
            btnExit.Location = new Point(928, 270);
            btnExit.Margin = new Padding(6);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(226, 70);
            btnExit.TabIndex = 14;
            btnExit.Text = "Exit";
            btnExit.UseVisualStyleBackColor = true;
            // 
            // btnAccept
            // 
            btnAccept.Font = new Font("Segoe UI", 12F);
            btnAccept.Location = new Point(32, 270);
            btnAccept.Margin = new Padding(6);
            btnAccept.Name = "btnAccept";
            btnAccept.Size = new Size(226, 70);
            btnAccept.TabIndex = 12;
            btnAccept.Text = "Accept";
            btnAccept.UseVisualStyleBackColor = true;
            btnAccept.Click += btnAccept_Click;
            // 
            // grbDetails
            // 
            grbDetails.Controls.Add(txtSupplierID);
            grbDetails.Controls.Add(lblSupplierID);
            grbDetails.Controls.Add(txtSupplier);
            grbDetails.Controls.Add(txtProduct);
            grbDetails.Controls.Add(btnNewProduct);
            grbDetails.Controls.Add(btnNewSupplier);
            grbDetails.Controls.Add(cboProduct);
            grbDetails.Controls.Add(cboSupplier);
            grbDetails.Controls.Add(lblSupplier);
            grbDetails.Controls.Add(lblProduct);
            grbDetails.Font = new Font("Segoe UI", 12F);
            grbDetails.Location = new Point(18, 14);
            grbDetails.Margin = new Padding(4);
            grbDetails.Name = "grbDetails";
            grbDetails.Padding = new Padding(4);
            grbDetails.Size = new Size(1150, 246);
            grbDetails.TabIndex = 15;
            grbDetails.TabStop = false;
            grbDetails.Text = "Product Details";
            // 
            // txtSupplierID
            // 
            txtSupplierID.Location = new Point(302, 178);
            txtSupplierID.Margin = new Padding(4);
            txtSupplierID.Name = "txtSupplierID";
            txtSupplierID.Size = new Size(630, 50);
            txtSupplierID.TabIndex = 21;
            txtSupplierID.Tag = "Supplier ID";
            // 
            // lblSupplierID
            // 
            lblSupplierID.AutoSize = true;
            lblSupplierID.Font = new Font("Segoe UI", 12F);
            lblSupplierID.Location = new Point(50, 190);
            lblSupplierID.Margin = new Padding(4, 0, 4, 0);
            lblSupplierID.Name = "lblSupplierID";
            lblSupplierID.Size = new Size(257, 40);
            lblSupplierID.TabIndex = 19;
            lblSupplierID.Text = "Supplier ID:";
            // 
            // txtSupplier
            // 
            txtSupplier.Location = new Point(230, 120);
            txtSupplier.Margin = new Padding(4);
            txtSupplier.Name = "txtSupplier";
            txtSupplier.Size = new Size(630, 50);
            txtSupplier.TabIndex = 18;
            txtSupplier.Tag = "Supplier Name";
            // 
            // txtProduct
            // 
            txtProduct.Location = new Point(230, 68);
            txtProduct.Margin = new Padding(4);
            txtProduct.Name = "txtProduct";
            txtProduct.Size = new Size(630, 50);
            txtProduct.TabIndex = 17;
            txtProduct.Tag = "Product Name";
            // 
            // btnNewProduct
            // 
            btnNewProduct.Font = new Font("Segoe UI", 12F);
            btnNewProduct.Location = new Point(884, 68);
            btnNewProduct.Margin = new Padding(6);
            btnNewProduct.Name = "btnNewProduct";
            btnNewProduct.Size = new Size(252, 48);
            btnNewProduct.TabIndex = 16;
            btnNewProduct.Text = "New";
            btnNewProduct.UseVisualStyleBackColor = true;
            btnNewProduct.Click += btnNewProduct_Click;
            // 
            // btnNewSupplier
            // 
            btnNewSupplier.Font = new Font("Segoe UI", 12F);
            btnNewSupplier.Location = new Point(884, 120);
            btnNewSupplier.Margin = new Padding(6);
            btnNewSupplier.Name = "btnNewSupplier";
            btnNewSupplier.Size = new Size(252, 46);
            btnNewSupplier.TabIndex = 15;
            btnNewSupplier.Text = "New";
            btnNewSupplier.UseVisualStyleBackColor = true;
            btnNewSupplier.Click += btnNewSupplier_Click;
            // 
            // cboProduct
            // 
            cboProduct.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cboProduct.FormattingEnabled = true;
            cboProduct.Location = new Point(230, 66);
            cboProduct.Margin = new Padding(4);
            cboProduct.Name = "cboProduct";
            cboProduct.Size = new Size(630, 48);
            cboProduct.TabIndex = 0;
            // 
            // cboSupplier
            // 
            cboSupplier.Font = new Font("Segoe UI", 12F);
            cboSupplier.FormattingEnabled = true;
            cboSupplier.Location = new Point(230, 120);
            cboSupplier.Margin = new Padding(4);
            cboSupplier.Name = "cboSupplier";
            cboSupplier.Size = new Size(630, 48);
            cboSupplier.TabIndex = 3;
            // 
            // lblSupplier
            // 
            lblSupplier.AutoSize = true;
            lblSupplier.Font = new Font("Segoe UI", 12F);
            lblSupplier.Location = new Point(48, 124);
            lblSupplier.Margin = new Padding(4, 0, 4, 0);
            lblSupplier.Name = "lblSupplier";
            lblSupplier.Size = new Size(197, 40);
            lblSupplier.TabIndex = 2;
            lblSupplier.Text = "Supplier:";
            // 
            // lblProduct
            // 
            lblProduct.AutoSize = true;
            lblProduct.Font = new Font("Segoe UI", 12F);
            lblProduct.Location = new Point(56, 72);
            lblProduct.Margin = new Padding(4, 0, 4, 0);
            lblProduct.Name = "lblProduct";
            lblProduct.Size = new Size(177, 40);
            lblProduct.TabIndex = 1;
            lblProduct.Text = "Product:";
            // 
            // AddEditPackageProduct
            // 
            AcceptButton = btnAccept;
            AutoScaleDimensions = new SizeF(192F, 192F);
            AutoScaleMode = AutoScaleMode.Dpi;
            CancelButton = btnExit;
            ClientSize = new Size(1188, 354);
            Controls.Add(grbDetails);
            Controls.Add(btnExit);
            Controls.Add(btnAccept);
            Margin = new Padding(4);
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
        private TextBox txtSupplierID;
        private Label lblSupplierID;
    }
}