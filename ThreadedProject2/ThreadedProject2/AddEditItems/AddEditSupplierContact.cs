using ThreadedProject2.Models;

namespace ThreadedProject2
{
    public partial class AddEditSupplierContact : Form
    {
        //new database context
        Models.TravelExpertsContext context = new TravelExpertsContext();

        //SelectedItemId to get data provided from main form using Id.GetId(lstData)
        private int selectedItemId;

        //isAdd bool for add or edit controller
        private bool isAdd;


        public AddEditSupplierContact(int selectedItemId = -1)
        {
            InitializeComponent();
            SetForm(selectedItemId);
        }

        /// <summary>
        /// Sets form state based on selectedItem
        /// </summary>
        /// <param name="selectedItem"></param>
        private void SetForm(int selectedItem)
        {
            //set selectedItem of data to modify form
            this.selectedItemId = selectedItem;
            //set form legend aka groupbox
            grpSCDetails.Text = $@"Supplier Contact Details";

            //Set text of form based on selectedItem
            if (selectedItem == -1)
            {
                //set form Text and isAdd state
                this.Text = $@"Add Supplier Contact";
                isAdd = true;
            }
            else
            {
                //Set form and isAdd state
                this.Text = $@"Edit Supplier Contact";
                isAdd = false;
            }
        }

        private void AddEditSupplierContact_Load(object sender, EventArgs e)
        {
            /* //if selectedItemId is not -1 aka product was selected, display selected data in fields
             try
             {
                 //If selectedItemId is not -1 aka product was selected
                 if (selectedItemId != -1)
                 {
                     SupplierContact? supplierContact = DB.Get.SupplierContacts(selectedItemId).FirstOrDefault();
                     txtSCSupplierID.Text = supplierContact?.SupplierContactId.ToString();


                     var affiliation = DB.Get.Affiliations();
                     cboAffilation.DataSource = affiliation;
                     cboAffilation.DisplayMember = "AffilitationId";
                     cboAffilation.ValueMember = "AffilitationId";
                     cboAffilation.SelectedValue = SupplierContact.AffiliationId;
                 } //When Adding and cbo controls are enables(Still loads even when not displayed??)
                 else
                 {
                     var affiliation = DB.Get.Affiliations();
                     cboAffilation.DataSource = affiliation;
                     cboAffilation.DisplayMember = "AffilitationId";
                     cboAffilation.ValueMember = "AffilitationId";
                 }
             }
             catch (Exception ex)
             {
                 MessageBox.Show(ex.Message, "Sql Server Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
             }*/
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
        }
    }
}