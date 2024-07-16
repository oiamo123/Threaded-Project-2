using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ThreadedProject2.Helpers;
using ThreadedProject2.Models;
//Author: Erin Bough
//Date: 2024-07-16
namespace ThreadedProject2
{
    public partial class SupplierAddModifyForm : Form
    {
        //determines the mode the form operates in. can be either "add" or "edit".
        private string mode = "";
        public SupplierAddModifyForm()
        {
            InitializeComponent();
        }
        /// <summary>
        /// sets header text, form mode, and stores a reference to the parent form
        /// </summary>
        /// <param name="f">the parent form reference</param>
        public void SetAddMode()
        {
            IDTextBox.Text = "";
            NameTextBox.Text = "";
            IDTextBox.Enabled = true;
            mode = "add";
            this.Text = "Add Supplier";
        }
        /// <summary>
        /// sets header text, form mode, and stores a reference to the parent form
        /// </summary>
        /// <param name="f">the parent form reference</param>
        /// /// <param name="supplier">the data to edit</param>
        public void SetEditMode(Models.Supplier supplier)
        {
            IDTextBox.Text = supplier.SupplierId.ToString();
            IDTextBox.Enabled = false;
            NameTextBox.Text = supplier.SupName;
            mode = "edit";
            this.Text = "Edit Supplier";
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            if (Validation.IsNonNegativeInteger(IDTextBox) & Validation.IsPresent(NameTextBox))
            {
                int id = Convert.ToInt32(IDTextBox.Text);
                string name = NameTextBox.Text;

                if (mode == "add")
                {
                    bool unique = true;
                    foreach (Models.Supplier supplier in SupplierDB.GetSuppliers())
                    {
                        if (supplier.SupplierId == id)
                        {
                            Validation.ShowInvalidInput(IDTextBox, "must be unique.");
                            unique = false;
                            break;
                        }
                    }
                    if (unique)
                    {
                        Models.Supplier newSupplier = new Models.Supplier();
                        newSupplier.SupplierId = id;
                        newSupplier.SupName = name;
                        SupplierDB.AddSupplier(newSupplier);
                        this.Close();
                    }
                }
                if (mode == "edit")
                {
                    Models.Supplier newSupplier = new Models.Supplier();
                    newSupplier.SupplierId = id;
                    newSupplier.SupName = name;
                    SupplierDB.ModifySupplier(id, newSupplier);
                    this.Close();
                }
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
