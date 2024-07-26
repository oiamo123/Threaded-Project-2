using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ThreadedProject2.Models;
using ThreadedProject2.Helpers;

namespace ThreadedProject2
{
    public partial class AddEditSupplierContact : Form
    {
        TravelExpertsContext context = new TravelExpertsContext();
        private int id { get; set; }

        public AddEditSupplierContact(int id = 0)
        {
            InitializeComponent();
            this.id = id;
        }

        private void AddEditSupplierContact_Load(object sender, EventArgs e)
        {
            if (id != 0)
            {
                SupplierContact contact = DB.Get.SupplierContacts(id).FirstOrDefault();
                UpdateTextBoxes(contact);
            }
        }

        private void UpdateTextBoxes(SupplierContact contact)
        {
            txtSCID.Text = contact.SupplierContactId.ToString();
            txtSCSupplierID.Text = contact.SupplierId.ToString();
            txtSCFirstName.Text = contact.SupConFirstName;
            txtSCLastName.Text = contact.SupConLastName;
            txtSCAddress.Text = contact.SupConAddress;
            txtSCCity.Text = contact.SupConCity;
            txtSCProvince.Text = contact.SupConProv;
            txtSCPostalCode.Text = contact.SupConPostal;
            txtSCCountry.Text = contact.SupConCountry;
            txtSCCountry.Text = contact.SupConCompany;
            txtSCBusinessPhone.Text = contact.SupConBusPhone;
            txtSCEmail.Text = contact.SupConEmail;
            txtSCURL.Text = contact.SupConUrl;
            txtSCFax.Text = contact.SupConFax;
        }
    }
}
