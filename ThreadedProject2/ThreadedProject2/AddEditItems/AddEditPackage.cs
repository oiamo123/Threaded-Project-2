using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ThreadedProject2.Helpers;
using ThreadedProject2.Models;

// Author: Gavin

namespace ThreadedProject2
{
    public partial class AddEditPackage : Form
    {
        // Variables
        Models.TravelExpertsContext context = new Models.TravelExpertsContext();
        private int id { get; set; } // package id for if editing package
        private bool isAdd { get; set; } // determines if adding a new package or editing a package

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="i"></param>
        public AddEditPackage(int i = -1)
        {
            InitializeComponent();
            id = i;
            this.Text = id == -1 ? "Add Package" : "Edit Package";
            isAdd = id == -1 ? true : false;
        }

        /// <summary>
        /// On Load Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddEditPackage_Load(object sender, EventArgs e)
        {
            // if id is not -1, load package data to edit info
            if (id != -1)
            {
                Package? package = DB.Get.Packages(id).FirstOrDefault();
                txtAgencyComission.Text = package.PkgAgencyCommission.ToString();
                txtPackagePrice.Text = package.PkgBasePrice.ToString();
                txtDescription.Text = package.PkgDesc;
                txtName.Text = package.PkgName;
                dtpStart.Value = package.PkgStartDate;
                dtpEnd.Value = package.PkgEndDate;
            }
        }

        /// <summary>
        /// Button Reset
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReset_Click(object sender, EventArgs e)
        {
            clearTextboxes();
        }

        /// <summary>
        /// Clears text boxes
        /// </summary>
        private void clearTextboxes()
        {
            txtAgencyComission.Text = "";
            txtDescription.Text = "";
            txtName.Text = "";
            txtPackagePrice.Text = "";
        }

        /// <summary>
        /// Button Accept
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAccept_Click(object sender, EventArgs e)
        {
            // if is and and data is valid, add a new package
            if (isAdd && isValid())
            {
                Package package = new Package()
                {
                    PkgDesc = txtDescription.Text,
                    PkgName = txtName.Text,
                    PkgStartDate = dtpStart.Value,
                    PkgEndDate = dtpEnd.Value,
                    PkgBasePrice = Math.Round(Decimal.Parse(txtPackagePrice.Text), 2),
                    PkgAgencyCommission = Math.Round(Decimal.Parse(txtAgencyComission.Text), 2)
                };

                context.Packages.Add(package);

                clearTextboxes();

                MessageBox.Show("Package successfully added. Close to see new changes");
            } 
            // if is not add, update package and validate data
            else if (!isAdd && isValid())
            {
                try
                {
                    // get package
                    Package package = context.Packages.FirstOrDefault(p => p.PackageId == id);
                    if (package == null) throw new Exception("There was an error accessing the database");

                    package.PkgDesc = txtDescription.Text;
                    package.PkgName = txtName.Text;
                    package.PkgStartDate = dtpStart.Value;
                    package.PkgEndDate = dtpEnd.Value;
                    package.PkgBasePrice = Math.Round(Decimal.Parse(txtPackagePrice.Text), 2);
                    package.PkgAgencyCommission = Math.Round(Decimal.Parse(txtAgencyComission.Text), 2);

                    context.Packages.Update(package);
                    
                    MessageBox.Show("Package updated");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Sql Server Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            
            context.SaveChanges();
        }

        /// <summary>
        /// Button Exit
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Checks if data is valid
        /// </summary>
        /// <returns></returns>
        private bool isValid()
        {
            Validation validation = new Validation();
            bool success = true;

            //Validate all data
            try
            {
                if (Validation.IsSentence(txtName) &&
                    Validation.IsDecimal(txtPackagePrice) &&
                Validation.IsDecimal(txtAgencyComission) &&
                Validation.CheckDate(dtpStart) &&
                Validation.CheckDate(dtpEnd) && 
                Validation.IsSentence(txtDescription))      
                {
                    if (dtpStart.Value > dtpEnd.Value) throw new Exception("End date cannot be greater than start date");
                }
                else
                {
                    //Failed
                    success = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                success = false;
            }

            return success;
        }
    }
}
