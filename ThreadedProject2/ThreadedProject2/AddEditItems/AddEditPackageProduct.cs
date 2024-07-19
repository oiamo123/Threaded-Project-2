using ThreadedProject2.Helpers;
using ThreadedProject2.Models;

namespace ThreadedProject2
{
    public partial class AddEditPackageProduct : Form
    {
        //new database context
        Models.TravelExpertsContext context = new TravelExpertsContext();

        //ID to get data provided from main form using Id.GetId(lstData)
        private int id;

        //isAdd bool for add or edit controller
        private bool isAdd;

        /// <summary>
        /// Opens AddEditPackageProduct form with id parameter to add or edit data
        /// </summary>
        /// <param name="i">Parameter to know if adding or editing based on value</param>
        public AddEditPackageProduct(int i = -1)
        {
            //Initialize form parts
            InitializeComponent();
            SetForm(i);
        }

        /// <summary>
        /// Sets form state based on id
        /// </summary>
        /// <param name="i"></param>
        private void SetForm(int i)
        {
            //TODO: Add logic for supplier form
            //set id of data to modify form
            id = i;
            //Set text of form based on id
            if (id == -1)
            {
                //TODO: Change to interpolated string "Add {type}" w/ type being defined in main form
                //set form Text and isAdd state
                this.Text = @"Add Product";
                isAdd = true;
            }
            else
            {
                this.Text = @"Edit Product";
                isAdd = false;
            }

            //disable other controls that are not needed
            //Should only enable when add/editing Supplier or Product Supplier
            //TODO: Consider making dynamic method for this
            lblSupplier.Enabled = false;
            lblSupplier.Visible = false;
            cboSupplier.Enabled = false;
            cboSupplier.Visible = false;
            txtSupplier.Enabled = false;
            txtSupplier.Visible = false;
            btnNewSupplier.Enabled = false;
            btnNewSupplier.Visible = false;
            btnNewProduct.Enabled = false;
            btnNewProduct.Visible = false;
        }

        //On form load display selected data, if anything was selected
        private void AddEditPackageProduct_Load(object sender, EventArgs e)
        {
            //if id is not -1 aka product was selected, display selected data in fields
            try
            {
                //If id is not -1 aka product was selected
                if (id != -1)
                {
                    //Get product by that id
                    Product? product = DB.Get.Products(id).FirstOrDefault();
                    //Then display data
                    txtProduct.Text = product?.ProdName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Sql Server Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            try
            {
                //If adding data and entry is valid
                if (isAdd && isValid())
                {
                    //Create new Product object
                    Product product = new Product
                    {
                        //Set data
                        ProdName = txtProduct.Text
                    };
                    //Add to database
                    context.Products.Add(product);
                    context.SaveChanges();
                    MessageBox.Show("Product Added", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //Close form
                    DialogResult = DialogResult.OK;
                }

                //If editing data and entry is valid
                else if (!isAdd && isValid())
                {
                    //Get product by id where the id is the same as the one in the form
                    Product? product = context.Products.FirstOrDefault(p => p.ProductId == id);
                    //If product was not found
                    if (product == null)
                    {
                        //Throw exception
                        throw new Exception("There was an error accessing the database");
                    }

                    //Set updated data
                    product.ProdName = txtProduct.Text;
                    //Update database
                    context.SaveChanges();
                    MessageBox.Show("Product Updated", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //Close form
                    DialogResult = DialogResult.OK;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Sql Server Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Validates the data in the text fields
        /// </summary>
        /// <returns>True if all the data is valid, false otherwise</returns>
        private bool isValid()
        {
            Validation validation = new Validation();
            bool success = true;

            try
            {
                if (!Validation.IsSentence(txtProduct.Text, "Product") &&
                    !Validation.CheckLength(txtProduct, 50) &&
                    Validation.IsPresent(txtProduct))
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