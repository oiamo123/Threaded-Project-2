namespace ThreadedProject2
{
    partial class SupplierAddModifyForm
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
            NameLabel = new Label();
            IDLabel = new Label();
            IDTextBox = new TextBox();
            NameTextBox = new TextBox();
            CancelButton = new Button();
            OKButton = new Button();
            SuspendLayout();
            // 
            // NameLabel
            // 
            NameLabel.AutoSize = true;
            NameLabel.Location = new Point(39, 159);
            NameLabel.Name = "NameLabel";
            NameLabel.Size = new Size(85, 15);
            NameLabel.TabIndex = 0;
            NameLabel.Tag = "Supplier Name";
            NameLabel.Text = "Supplier Name";
            // 
            // IDLabel
            // 
            IDLabel.AutoSize = true;
            IDLabel.Location = new Point(60, 105);
            IDLabel.Name = "IDLabel";
            IDLabel.Size = new Size(64, 15);
            IDLabel.TabIndex = 1;
            IDLabel.Text = "Supplier ID";
            // 
            // IDTextBox
            // 
            IDTextBox.Location = new Point(137, 97);
            IDTextBox.Name = "IDTextBox";
            IDTextBox.Size = new Size(160, 23);
            IDTextBox.TabIndex = 2;
            IDTextBox.Tag = "Supplier ID";
            // 
            // NameTextBox
            // 
            NameTextBox.Location = new Point(137, 151);
            NameTextBox.Name = "NameTextBox";
            NameTextBox.Size = new Size(160, 23);
            NameTextBox.TabIndex = 3;
            NameTextBox.Tag = "Supplier Name";
            // 
            // CancelButton
            // 
            CancelButton.Location = new Point(210, 271);
            CancelButton.Name = "CancelButton";
            CancelButton.Size = new Size(121, 48);
            CancelButton.TabIndex = 4;
            CancelButton.Text = "Cancel";
            CancelButton.UseVisualStyleBackColor = true;
            CancelButton.Click += CancelButton_Click;
            // 
            // OKButton
            // 
            OKButton.Location = new Point(47, 271);
            OKButton.Name = "OKButton";
            OKButton.Size = new Size(115, 48);
            OKButton.TabIndex = 5;
            OKButton.Text = "OK";
            OKButton.UseVisualStyleBackColor = true;
            OKButton.Click += OKButton_Click;
            // 
            // SupplierAddModifyForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(423, 348);
            Controls.Add(OKButton);
            Controls.Add(CancelButton);
            Controls.Add(NameTextBox);
            Controls.Add(IDTextBox);
            Controls.Add(IDLabel);
            Controls.Add(NameLabel);
            Name = "SupplierAddModifyForm";
            Text = "Supplier";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label NameLabel;
        private Label IDLabel;
        private TextBox IDTextBox;
        private TextBox NameTextBox;
        private Button CancelButton;
        private Button OKButton;
    }
}