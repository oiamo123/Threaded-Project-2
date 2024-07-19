namespace ThreadedProject2
{
    partial class MainForm
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
            lstData.Location = new Point(20, 17);
            lstData.Margin = new Padding(4, 4, 4, 4);
            lstData.Name = "lstData";
            lstData.Size = new Size(1381, 510);
            lstData.TabIndex = 0;
            lstData.MouseClick += lstData_MouseClick;
            // 
            // btnPackages
            // 
            btnPackages.Location = new Point(1413, 17);
            btnPackages.Margin = new Padding(4, 4, 4, 4);
            btnPackages.Name = "btnPackages";
            btnPackages.Size = new Size(170, 52);
            btnPackages.TabIndex = 1;
            btnPackages.Text = "Packages";
            btnPackages.UseVisualStyleBackColor = true;
            btnPackages.Click += btnPackages_Click;
            // 
            // btnProducts
            // 
            btnProducts.Location = new Point(1413, 78);
            btnProducts.Margin = new Padding(4, 4, 4, 4);
            btnProducts.Name = "btnProducts";
            btnProducts.Size = new Size(170, 52);
            btnProducts.TabIndex = 2;
            btnProducts.Text = "Products";
            btnProducts.UseVisualStyleBackColor = true;
            btnProducts.Click += btnProducts_Click;
            // 
            // btnSuppliers
            // 
            btnSuppliers.Location = new Point(1413, 140);
            btnSuppliers.Margin = new Padding(4, 4, 4, 4);
            btnSuppliers.Name = "btnSuppliers";
            btnSuppliers.Size = new Size(170, 52);
            btnSuppliers.TabIndex = 3;
            btnSuppliers.Text = "Suppliers";
            btnSuppliers.UseVisualStyleBackColor = true;
            btnSuppliers.Click += btnSuppliers_Click;
            // 
            // btnProductSuppliers
            // 
            btnProductSuppliers.Location = new Point(1413, 200);
            btnProductSuppliers.Margin = new Padding(4, 4, 4, 4);
            btnProductSuppliers.Name = "btnProductSuppliers";
            btnProductSuppliers.Size = new Size(170, 52);
            btnProductSuppliers.TabIndex = 4;
            btnProductSuppliers.Text = "Prod. Suppliers";
            btnProductSuppliers.UseVisualStyleBackColor = true;
            btnProductSuppliers.Click += btnProductSuppliers_Click;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(20, 539);
            btnAdd.Margin = new Padding(4, 4, 4, 4);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(170, 52);
            btnAdd.TabIndex = 5;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnEdit
            // 
            btnEdit.Location = new Point(200, 539);
            btnEdit.Margin = new Padding(4, 4, 4, 4);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(170, 52);
            btnEdit.TabIndex = 6;
            btnEdit.Text = "Edit";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Visible = false;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnRemove
            // 
            btnRemove.Location = new Point(380, 539);
            btnRemove.Margin = new Padding(4, 4, 4, 4);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new Size(170, 52);
            btnRemove.TabIndex = 7;
            btnRemove.Text = "Remove";
            btnRemove.UseVisualStyleBackColor = true;
            btnRemove.Visible = false;
            btnRemove.Click += btnRemove_Click;
            // 
            // btnMore
            // 
            btnMore.Location = new Point(1413, 415);
            btnMore.Margin = new Padding(4, 4, 4, 4);
            btnMore.Name = "btnMore";
            btnMore.Size = new Size(170, 52);
            btnMore.TabIndex = 8;
            btnMore.Text = ">>>";
            btnMore.UseVisualStyleBackColor = true;
            btnMore.Visible = false;
            btnMore.Click += btnMore_Click;
            // 
            // btnLess
            // 
            btnLess.Location = new Point(1413, 475);
            btnLess.Margin = new Padding(4, 4, 4, 4);
            btnLess.Name = "btnLess";
            btnLess.Size = new Size(170, 52);
            btnLess.TabIndex = 9;
            btnLess.Text = "<<<";
            btnLess.UseVisualStyleBackColor = true;
            btnLess.Visible = false;
            btnLess.Click += btnLess_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(144F, 144F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(1602, 604);
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
            Margin = new Padding(4, 4, 4, 4);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
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
