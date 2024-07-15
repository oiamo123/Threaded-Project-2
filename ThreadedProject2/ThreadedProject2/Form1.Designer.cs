namespace ThreadedProject2
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lstData = new ListBox();
            btnPackages = new Button();
            btnProducts = new Button();
            btnSuppliers = new Button();
            btnProductSuppliers = new Button();
            btnAdd = new Button();
            btnEdit = new Button();
            btnRemove = new Button();
            btnMore = new Button();
            btnLess = new Button();
            SuspendLayout();
            // 
            // lstData
            // 
            lstData.Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lstData.FormattingEnabled = true;
            lstData.ItemHeight = 22;
            lstData.Location = new Point(17, 20);
            lstData.Margin = new Padding(4, 5, 4, 5);
            lstData.Name = "lstData";
            lstData.Size = new Size(1228, 576);
            lstData.TabIndex = 0;
            lstData.MouseClick += lstData_MouseClick;
            // 
            // btnPackages
            // 
            btnPackages.Location = new Point(1256, 20);
            btnPackages.Margin = new Padding(4, 5, 4, 5);
            btnPackages.Name = "btnPackages";
            btnPackages.Size = new Size(151, 60);
            btnPackages.TabIndex = 1;
            btnPackages.Text = "Packages";
            btnPackages.UseVisualStyleBackColor = true;
            btnPackages.Click += btnPackages_Click;
            // 
            // btnProducts
            // 
            btnProducts.Location = new Point(1256, 90);
            btnProducts.Margin = new Padding(4, 5, 4, 5);
            btnProducts.Name = "btnProducts";
            btnProducts.Size = new Size(151, 60);
            btnProducts.TabIndex = 2;
            btnProducts.Text = "Products";
            btnProducts.UseVisualStyleBackColor = true;
            btnProducts.Click += btnProducts_Click;
            // 
            // btnSuppliers
            // 
            btnSuppliers.Location = new Point(1256, 160);
            btnSuppliers.Margin = new Padding(4, 5, 4, 5);
            btnSuppliers.Name = "btnSuppliers";
            btnSuppliers.Size = new Size(151, 60);
            btnSuppliers.TabIndex = 3;
            btnSuppliers.Text = "Suppliers";
            btnSuppliers.UseVisualStyleBackColor = true;
            btnSuppliers.Click += btnSuppliers_Click;
            // 
            // btnProductSuppliers
            // 
            btnProductSuppliers.Location = new Point(1256, 230);
            btnProductSuppliers.Margin = new Padding(4, 5, 4, 5);
            btnProductSuppliers.Name = "btnProductSuppliers";
            btnProductSuppliers.Size = new Size(151, 60);
            btnProductSuppliers.TabIndex = 4;
            btnProductSuppliers.Text = "Prod. Suppliers";
            btnProductSuppliers.UseVisualStyleBackColor = true;
            btnProductSuppliers.Click += btnProductSuppliers_Click;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(17, 620);
            btnAdd.Margin = new Padding(4, 5, 4, 5);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(151, 60);
            btnAdd.TabIndex = 5;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnEdit
            // 
            btnEdit.Location = new Point(177, 620);
            btnEdit.Margin = new Padding(4, 5, 4, 5);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(151, 60);
            btnEdit.TabIndex = 6;
            btnEdit.Text = "Edit";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Visible = false;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnRemove
            // 
            btnRemove.Location = new Point(337, 620);
            btnRemove.Margin = new Padding(4, 5, 4, 5);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new Size(151, 60);
            btnRemove.TabIndex = 7;
            btnRemove.Text = "Remove";
            btnRemove.UseVisualStyleBackColor = true;
            btnRemove.Visible = false;
            btnRemove.Click += btnRemove_Click;
            // 
            // btnMore
            // 
            btnMore.Location = new Point(1253, 466);
            btnMore.Margin = new Padding(4, 5, 4, 5);
            btnMore.Name = "btnMore";
            btnMore.Size = new Size(151, 60);
            btnMore.TabIndex = 8;
            btnMore.Text = ">>>";
            btnMore.UseVisualStyleBackColor = true;
            btnMore.Visible = false;
            btnMore.Click += btnMore_Click;
            // 
            // btnLess
            // 
            btnLess.Location = new Point(1253, 536);
            btnLess.Margin = new Padding(4, 5, 4, 5);
            btnLess.Name = "btnLess";
            btnLess.Size = new Size(151, 60);
            btnLess.TabIndex = 9;
            btnLess.Text = "<<<";
            btnLess.UseVisualStyleBackColor = true;
            btnLess.Visible = false;
            btnLess.Click += btnLess_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1424, 695);
            Controls.Add(btnLess);
            Controls.Add(btnMore);
            Controls.Add(btnRemove);
            Controls.Add(btnEdit);
            Controls.Add(btnAdd);
            Controls.Add(btnProductSuppliers);
            Controls.Add(btnSuppliers);
            Controls.Add(btnProducts);
            Controls.Add(btnPackages);
            Controls.Add(lstData);
            Margin = new Padding(4, 5, 4, 5);
            Name = "Form1";
            Text = "Agent Panel";
            Load += Form1_Load;
            ResumeLayout(false);
        }

        #endregion

        private ListBox lstData;
        private Button btnPackages;
        private Button btnProducts;
        private Button btnSuppliers;
        private Button btnProductSuppliers;
        private Button btnAdd;
        private Button btnEdit;
        private Button btnRemove;
        private Button btnMore;
        private Button btnLess;
    }
}
