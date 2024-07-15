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

namespace ThreadedProject2
{
    public partial class AddEditPackage : Form
    {
        Models.TravelExpertsContext context = new Models.TravelExpertsContext();
        DbGet dbGet = new DbGet();
        private int id { get; set; }
        private bool isAdd { get; set; }

        public AddEditPackage(int i = -1)
        {
            InitializeComponent();
            id = i;
            this.Text = id == -1 ? "Add Package" : "Edit Package";
            isAdd = id == -1 ? true : false;
        }

        private void AddEditPackage_Load(object sender, EventArgs e)
        {
            if (id != -1)
            {
                Package? package = dbGet.GetPackages(id).FirstOrDefault();
                txtAgencyComission.Text = package.PkgAgencyCommission.ToString();
                txtPackagePrice.Text = package.PkgBasePrice.ToString();
                txtDescription.Text = package.PkgDesc;
                txtName.Text = package.PkgName;
                dtpStart.Value = package.PkgStartDate;
                dtpEnd.Value = package.PkgEndDate;
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            clearTextboxes();
        }

        private void clearTextboxes()
        {
            txtAgencyComission.Text = "";
            txtDescription.Text = "";
            txtName.Text = "";
            txtPackagePrice.Text = "";
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
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
                context.Add(package);
                clearTextboxes();
            } 
            else if (!isAdd && isValid())
            {
                try
                {
                    //Package package = dbGet.GetPackages(id).FirstOrDefault();
                    Package package = context.Packages.FirstOrDefault(p => p.PackageId == id);
                    if (package == null) throw new Exception("There was an error accessing the database");

                    package.PkgDesc = txtDescription.Text;
                    package.PkgName = txtName.Text;
                    package.PkgStartDate = dtpStart.Value;
                    package.PkgEndDate = dtpEnd.Value;
                    package.PkgBasePrice = Math.Round(Decimal.Parse(txtPackagePrice.Text), 2);
                    package.PkgAgencyCommission = Math.Round(Decimal.Parse(txtAgencyComission.Text), 2);
                    context.Packages.Update(package);
                    context.SaveChanges();
                    Debug.WriteLine(package);
                    MessageBox.Show("Package updated");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Sql Server Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }

            
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool isValid()
        {
            Validation validation = new Validation();
            bool success = true;

            try
            {
                if (Validation.IsSentence(txtName.Text, "Name") &&
                    Validation.IsDecimal(txtPackagePrice.Text, "Package price") &&
                Validation.IsDecimal(txtAgencyComission.Text, "Agency commission") &&
                Validation.CheckDate(dtpStart, "State date") &&
                Validation.CheckDate(dtpEnd, "End date") && 
                Validation.IsSentence(txtDescription.Text, "Description"))      
                {
                    if (dtpStart.Value > dtpEnd.Value) throw new Exception("End date cannot be greater than start date");
                }
                else
                {
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
