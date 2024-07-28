namespace ThreadedProject2
{
    partial class AddEditPackage
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
            groupbox1 = new GroupBox();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            txtDescription = new TextBox();
            label4 = new Label();
            dtpEnd = new DateTimePicker();
            dtpStart = new DateTimePicker();
            label3 = new Label();
            txtAgencyComission = new TextBox();
            label2 = new Label();
            txtPackagePrice = new TextBox();
            label1 = new Label();
            txtName = new TextBox();
            btnAccept = new Button();
            btnReset = new Button();
            btnExit = new Button();
            groupbox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupbox1
            // 
            groupbox1.Controls.Add(label7);
            groupbox1.Controls.Add(label6);
            groupbox1.Controls.Add(label5);
            groupbox1.Controls.Add(txtDescription);
            groupbox1.Controls.Add(label4);
            groupbox1.Controls.Add(dtpEnd);
            groupbox1.Controls.Add(dtpStart);
            groupbox1.Controls.Add(label3);
            groupbox1.Controls.Add(txtAgencyComission);
            groupbox1.Controls.Add(label2);
            groupbox1.Controls.Add(txtPackagePrice);
            groupbox1.Controls.Add(label1);
            groupbox1.Controls.Add(txtName);
            groupbox1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupbox1.Location = new Point(12, 12);
            groupbox1.Name = "groupbox1";
            groupbox1.Size = new Size(363, 281);
            groupbox1.TabIndex = 0;
            groupbox1.TabStop = false;
            groupbox1.Text = "Package Details";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(8, 164);
            label7.Name = "label7";
            label7.Size = new Size(92, 21);
            label7.TabIndex = 8;
            label7.Text = "Description:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F);
            label6.Location = new Point(8, 141);
            label6.Name = "label6";
            label6.Size = new Size(75, 21);
            label6.TabIndex = 7;
            label6.Text = "End Date:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F);
            label5.Location = new Point(8, 112);
            label5.Name = "label5";
            label5.Size = new Size(81, 21);
            label5.TabIndex = 6;
            label5.Text = "Start Date:";
            // 
            // txtDescription
            // 
            txtDescription.Font = new Font("Segoe UI", 12F);
            txtDescription.Location = new Point(118, 167);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(236, 104);
            txtDescription.TabIndex = 2;
            txtDescription.Tag = "Description";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F);
            label4.Location = new Point(8, 80);
            label4.Name = "label4";
            label4.Size = new Size(155, 21);
            label4.TabIndex = 5;
            label4.Text = "Agency Commission:";
            // 
            // dtpEnd
            // 
            dtpEnd.Font = new Font("Segoe UI", 12F);
            dtpEnd.Location = new Point(101, 138);
            dtpEnd.Name = "dtpEnd";
            dtpEnd.Size = new Size(253, 29);
            dtpEnd.TabIndex = 0;
            // 
            // dtpStart
            // 
            dtpStart.Font = new Font("Segoe UI", 12F);
            dtpStart.Location = new Point(101, 109);
            dtpStart.Name = "dtpStart";
            dtpStart.Size = new Size(253, 29);
            dtpStart.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(60, 50);
            label3.Name = "label3";
            label3.Size = new Size(107, 21);
            label3.TabIndex = 4;
            label3.Text = "Package Price:";
            // 
            // txtAgencyComission
            // 
            txtAgencyComission.Font = new Font("Segoe UI", 12F);
            txtAgencyComission.Location = new Point(181, 79);
            txtAgencyComission.Name = "txtAgencyComission";
            txtAgencyComission.Size = new Size(173, 29);
            txtAgencyComission.TabIndex = 4;
            txtAgencyComission.Tag = "Agency Commission";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(118, 22);
            label2.Name = "label2";
            label2.Size = new Size(55, 21);
            label2.TabIndex = 3;
            label2.Text = "Name:";
            // 
            // txtPackagePrice
            // 
            txtPackagePrice.Font = new Font("Segoe UI", 12F);
            txtPackagePrice.Location = new Point(181, 50);
            txtPackagePrice.Name = "txtPackagePrice";
            txtPackagePrice.Size = new Size(173, 29);
            txtPackagePrice.TabIndex = 3;
            txtPackagePrice.Tag = "Package Price";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 30);
            label1.Name = "label1";
            label1.Size = new Size(0, 21);
            label1.TabIndex = 0;
            // 
            // txtName
            // 
            txtName.Font = new Font("Segoe UI", 12F);
            txtName.Location = new Point(181, 20);
            txtName.Name = "txtName";
            txtName.Size = new Size(173, 29);
            txtName.TabIndex = 1;
            txtName.Tag = "Name";
            // 
            // btnAccept
            // 
            btnAccept.Location = new Point(12, 299);
            btnAccept.Name = "btnAccept";
            btnAccept.Size = new Size(106, 36);
            btnAccept.TabIndex = 9;
            btnAccept.Text = "Accept";
            btnAccept.UseVisualStyleBackColor = true;
            btnAccept.Click += btnAccept_Click;
            // 
            // btnReset
            // 
            btnReset.Location = new Point(123, 299);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(106, 36);
            btnReset.TabIndex = 10;
            btnReset.Text = "&Reset";
            btnReset.UseVisualStyleBackColor = true;
            btnReset.Click += btnReset_Click;
            // 
            // btnExit
            // 
            btnExit.Location = new Point(270, 299);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(106, 36);
            btnExit.TabIndex = 11;
            btnExit.Text = "Exit";
            btnExit.UseVisualStyleBackColor = true;
            // 
            // AddEditPackage
            // 
            AcceptButton = btnAccept;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnExit;
            ClientSize = new Size(385, 341);
            Controls.Add(btnExit);
            Controls.Add(btnReset);
            Controls.Add(btnAccept);
            Controls.Add(groupbox1);
            Name = "AddEditPackage";
            Text = "Add Package";
            Load += AddEditPackage_Load;
            groupbox1.ResumeLayout(false);
            groupbox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupbox1;
        private DateTimePicker dtpStart;
        private TextBox txtAgencyComission;
        private TextBox txtPackagePrice;
        private TextBox txtDescription;
        private TextBox txtName;
        private DateTimePicker dtpEnd;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private Label label7;
        private Button btnAccept;
        private Button btnReset;
        private Button btnExit;
    }
}