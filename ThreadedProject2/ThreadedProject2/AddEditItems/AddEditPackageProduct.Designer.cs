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
            btnNewProduct = new Button();
            btnNewSupplier = new Button();
            comboBox2 = new ComboBox();
            label2 = new Label();
            label1 = new Label();
            comboBox1 = new ComboBox();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // btnExit
            // 
            btnExit.Font = new Font("Segoe UI", 12F);
            btnExit.Location = new Point(479, 201);
            btnExit.Margin = new Padding(4, 5, 4, 5);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(151, 60);
            btnExit.TabIndex = 14;
            btnExit.Text = "Exit";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Visible = false;
            // 
            // btnAccept
            // 
            btnAccept.Font = new Font("Segoe UI", 12F);
            btnAccept.Location = new Point(13, 201);
            btnAccept.Margin = new Padding(4, 5, 4, 5);
            btnAccept.Name = "btnAccept";
            btnAccept.Size = new Size(151, 60);
            btnAccept.TabIndex = 12;
            btnAccept.Text = "Accept";
            btnAccept.UseVisualStyleBackColor = true;
            btnAccept.Visible = false;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(textBox2);
            groupBox1.Controls.Add(textBox1);
            groupBox1.Controls.Add(btnNewProduct);
            groupBox1.Controls.Add(btnNewSupplier);
            groupBox1.Controls.Add(comboBox1);
            groupBox1.Controls.Add(comboBox2);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Font = new Font("Segoe UI", 12F);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(618, 181);
            groupBox1.TabIndex = 15;
            groupBox1.TabStop = false;
            groupBox1.Text = "Product Details";
            // 
            // btnNewProduct
            // 
            btnNewProduct.Font = new Font("Segoe UI", 12F);
            btnNewProduct.Location = new Point(443, 58);
            btnNewProduct.Margin = new Padding(4, 5, 4, 5);
            btnNewProduct.Name = "btnNewProduct";
            btnNewProduct.Size = new Size(168, 42);
            btnNewProduct.TabIndex = 16;
            btnNewProduct.Text = "Other";
            btnNewProduct.UseVisualStyleBackColor = true;
            btnNewProduct.Visible = false;
            // 
            // btnNewSupplier
            // 
            btnNewSupplier.Font = new Font("Segoe UI", 12F);
            btnNewSupplier.Location = new Point(443, 104);
            btnNewSupplier.Margin = new Padding(4, 5, 4, 5);
            btnNewSupplier.Name = "btnNewSupplier";
            btnNewSupplier.Size = new Size(168, 40);
            btnNewSupplier.TabIndex = 15;
            btnNewSupplier.Text = "Other";
            btnNewSupplier.UseVisualStyleBackColor = true;
            btnNewSupplier.Visible = false;
            // 
            // comboBox2
            // 
            comboBox2.Font = new Font("Segoe UI", 12F);
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(153, 104);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(273, 40);
            comboBox2.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(32, 107);
            label2.Name = "label2";
            label2.Size = new Size(107, 32);
            label2.TabIndex = 2;
            label2.Text = "Supplier:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(38, 61);
            label1.Name = "label1";
            label1.Size = new Size(101, 32);
            label1.TabIndex = 1;
            label1.Text = "Product:";
            // 
            // comboBox1
            // 
            comboBox1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(153, 57);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(273, 40);
            comboBox1.TabIndex = 0;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(153, 58);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(273, 39);
            textBox1.TabIndex = 17;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(153, 104);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(273, 39);
            textBox2.TabIndex = 18;
            // 
            // AddEditPackageProduct
            // 
            AcceptButton = btnAccept;
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnExit;
            ClientSize = new Size(644, 274);
            Controls.Add(groupBox1);
            Controls.Add(btnExit);
            Controls.Add(btnAccept);
            Name = "AddEditPackageProduct";
            Text = "AddEditProduct";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button btnExit;
        private Button btnAccept;
        private GroupBox groupBox1;
        private ComboBox comboBox1;
        private Label label1;
        private ComboBox comboBox2;
        private Label label2;
        private Button btnNewProduct;
        private Button btnNewSupplier;
        private TextBox textBox2;
        private TextBox textBox1;
    }
}