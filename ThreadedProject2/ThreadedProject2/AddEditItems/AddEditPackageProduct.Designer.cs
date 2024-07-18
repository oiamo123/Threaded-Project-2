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
      groupBox1 = new GroupBox();
      txtSupplier = new TextBox();
      txtProduct = new TextBox();
      btnNewProduct = new Button();
      btnNewSupplier = new Button();
      cboProduct = new ComboBox();
      cboSupplier = new ComboBox();
      lblSupplier = new Label();
      lblProduct = new Label();
      groupBox1.SuspendLayout();
      SuspendLayout();
      // 
      // btnExit
      // 
      btnExit.Font = new Font("Segoe UI", 12F);
      btnExit.Location = new Point(916, 232);
      btnExit.Margin = new Padding(6, 6, 6, 6);
      btnExit.Name = "btnExit";
      btnExit.Size = new Size(226, 70);
      btnExit.TabIndex = 14;
      btnExit.Text = "Exit";
      btnExit.UseVisualStyleBackColor = true;
      // 
      // btnAccept
      // 
      btnAccept.Font = new Font("Segoe UI", 12F);
      btnAccept.Location = new Point(20, 232);
      btnAccept.Margin = new Padding(6, 6, 6, 6);
      btnAccept.Name = "btnAccept";
      btnAccept.Size = new Size(226, 70);
      btnAccept.TabIndex = 12;
      btnAccept.Text = "Accept";
      btnAccept.UseVisualStyleBackColor = true;
      btnAccept.Click += btnAccept_Click;
      // 
      // groupBox1
      // 
      groupBox1.Controls.Add(txtSupplier);
      groupBox1.Controls.Add(txtProduct);
      groupBox1.Controls.Add(btnNewProduct);
      groupBox1.Controls.Add(btnNewSupplier);
      groupBox1.Controls.Add(cboProduct);
      groupBox1.Controls.Add(cboSupplier);
      groupBox1.Controls.Add(lblSupplier);
      groupBox1.Controls.Add(lblProduct);
      groupBox1.Font = new Font("Segoe UI", 12F);
      groupBox1.Location = new Point(18, 14);
      groupBox1.Margin = new Padding(4, 4, 4, 4);
      groupBox1.Name = "groupBox1";
      groupBox1.Padding = new Padding(4, 4, 4, 4);
      groupBox1.Size = new Size(1150, 210);
      groupBox1.TabIndex = 15;
      groupBox1.TabStop = false;
      groupBox1.Text = "Product Details";
      // 
      // txtSupplier
      // 
      txtSupplier.Location = new Point(230, 120);
      txtSupplier.Margin = new Padding(4, 4, 4, 4);
      txtSupplier.Name = "txtSupplier";
      txtSupplier.Size = new Size(630, 50);
      txtSupplier.TabIndex = 18;
      // 
      // txtProduct
      // 
      txtProduct.Location = new Point(230, 68);
      txtProduct.Margin = new Padding(4, 4, 4, 4);
      txtProduct.Name = "txtProduct";
      txtProduct.Size = new Size(630, 50);
      txtProduct.TabIndex = 17;
      // 
      // btnNewProduct
      // 
      btnNewProduct.Font = new Font("Segoe UI", 12F);
      btnNewProduct.Location = new Point(884, 68);
      btnNewProduct.Margin = new Padding(6, 6, 6, 6);
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
      btnNewSupplier.Margin = new Padding(6, 6, 6, 6);
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
      cboProduct.Margin = new Padding(4, 4, 4, 4);
      cboProduct.Name = "cboProduct";
      cboProduct.Size = new Size(630, 48);
      cboProduct.TabIndex = 0;
      // 
      // cboSupplier
      // 
      cboSupplier.Font = new Font("Segoe UI", 12F);
      cboSupplier.FormattingEnabled = true;
      cboSupplier.Location = new Point(230, 120);
      cboSupplier.Margin = new Padding(4, 4, 4, 4);
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
      ClientSize = new Size(1188, 318);
      Controls.Add(groupBox1);
      Controls.Add(btnExit);
      Controls.Add(btnAccept);
      Margin = new Padding(4, 4, 4, 4);
      Name = "AddEditPackageProduct";
      StartPosition = FormStartPosition.CenterScreen;
      Text = "AddEditProduct";
      Load += AddEditPackageProduct_Load;
      groupBox1.ResumeLayout(false);
      groupBox1.PerformLayout();
      ResumeLayout(false);
    }

    #endregion

    private Button btnExit;
        private Button btnAccept;
        private GroupBox groupBox1;
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