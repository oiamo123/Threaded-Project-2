using Microsoft.EntityFrameworkCore;
using ThreadedProject2.Helpers;
using ThreadedProject2.Models;

namespace ThreadedProject2
{
    public partial class AddEditPackageProduct : Form
    {
        // views list
        private List<string> views;

        // determines if form is edit or add
        private bool isAdd;

        // travel experts context
        private TravelExpertsContext context;

        // listbox data
        private ListBox lstData;

        private int lastId;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="views"></param>
        /// <param name="isAdd"></param>
        /// <param name="lstData"></param>
        /// <param name="lastId"></param>
        public AddEditPackageProduct(List<string> views, bool isAdd, ListBox lstData, int lastId)
        {
            InitializeComponent();
            this.views = views;
            this.isAdd = isAdd;
            this.context = new TravelExpertsContext();
            this.lstData = lstData;
            this.lastId = lastId;
        }

        // on load, set inputs for correct view ie "add product", only allow text input and disable supplier
        private void AddEditPackageProduct_Load(object sender, EventArgs e)
        {
            SetInputs();
        }

        // enables/disables text boxes
        private void EnableText(bool isEnabled)
        {
            txtProduct.Visible = isEnabled;
            txtSupplier.Visible = isEnabled;

            cboProduct.Visible = !isEnabled;
            cboSupplier.Visible = !isEnabled;
        }

        // disables inputs
        private void DisableInputs(bool productEnabled, bool supplierEnabled)
        {
            txtProduct.Enabled = productEnabled;
            btnNewProduct.Enabled = productEnabled;
            txtSupplier.Enabled = supplierEnabled;
            btnNewSupplier.Enabled = supplierEnabled;
        }

        // to set inputs
        private void SetInputs()
        {
            EnableText(true);

            switch (views.Last())
            {
                // if view is package product supplies or product supplies, enable cbo and load suppliers and products into 
                // cbo's
                case "package product supplies":
                case "product supplies":
                    DisableInputs(true, true);
                    EnableText(false);
                    LoadSuppliers();
                    LoadProducts();
                    break;
                // disable product input
                case "suppliers":
                    DisableInputs(false, true);
                    btnNewSupplier.Enabled = false;
                    if (!isAdd)
                    {
                        txtSupplier.Text = GetSelectedSupplierName();
                    }
                    break;
                // disable supplier input
                case "products":
                    DisableInputs(true, false);
                    btnNewProduct.Enabled = false;
                    if (!isAdd)
                    {
                        txtProduct.Text = GetSelectedProductName();
                    }
                    break;
                default:
                    break;
            }
        }

        // loads products into cboProducts
        private void LoadProducts()
        {
            var products = DB.Get.Products();
            foreach (var product in products)
            {
                cboProduct.Items.Add(product.ProdName);
                if (!isAdd && product.ProdName == GetSelectedProductName())
                {
                    cboProduct.SelectedItem = product.ProdName;
                }
            }
            if (isAdd) cboProduct.SelectedItem = products.First().ProdName;
        }

        // loads suppliers into cboSuppliers
        private void LoadSuppliers()
        {
            var suppliers = DB.Get.Suppliers();
            foreach (var supplier in suppliers)
            {
                cboSupplier.Items.Add(supplier.SupName);
                if (!isAdd && supplier.SupName == GetSelectedSupplierName())
                {
                    cboSupplier.SelectedItem = supplier.SupName;
                }
            }
            if (isAdd) cboSupplier.SelectedItem = suppliers.First().SupName;
        }

        // get's the selected products product name when using the cbo
        private string GetSelectedProductName()
        {
            var productSupplier = DB.Get.ProductSuppliers(Id.GetId(lstData)).FirstOrDefault();
            if (views.Last() == "products")
            {
                return DB.Get.Products(Id.GetId(lstData)).FirstOrDefault().ProdName;
            }
            else
            {
                return DB.Get.Products(productSupplier.ProductId).FirstOrDefault().ProdName;
            }
        }

        // get's the select suppliers supplier name when using the cbo
        private string GetSelectedSupplierName()
        {
            var productSupplier = DB.Get.ProductSuppliers(Id.GetId(lstData)).FirstOrDefault();
            if (views.Last() == "suppliers")
            {
                return DB.Get.Suppliers(Id.GetId(lstData)).FirstOrDefault().SupName;
            }
            else
            {
                return DB.Get.Suppliers(productSupplier.SupplierId).FirstOrDefault().SupName;
            }
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
        /// Button Accept
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (views.Last() == "product supplies" || views.Last() == "package product supplies")
            {
                Product product;
                Supplier supplier;

                //Check which product/supplier are visible
                if (txtProduct.Visible)
                {
                    AddProduct();
                    product = context.Products.OrderByDescending(p => p.ProductId).FirstOrDefault(); // Get the newly added product
                }
                else
                {
                    product = context.Products.FirstOrDefault(p => p.ProdName == cboProduct.SelectedItem.ToString());
                }

                if (txtSupplier.Visible)
                {
                    AddSupplier();
                    supplier = context.Suppliers.OrderByDescending(s => s.SupplierId).FirstOrDefault(); // Get the newly added supplier
                }
                else
                {
                    supplier = context.Suppliers.FirstOrDefault(s => s.SupName == cboSupplier.SelectedItem.ToString());
                }

                //Add productsupply
                if (isAdd)
                {
                    ProductsSupplier prodSupply;
                    var existingProdSupply = context.ProductsSuppliers
                        .FirstOrDefault(ps => ps.SupplierId == supplier.SupplierId && ps.ProductId == product.ProductId);

                    //Product Supply doesnt exist yet
                    if (existingProdSupply == null)
                    {
                        prodSupply = new ProductsSupplier
                        {
                            Product = product,
                            Supplier = supplier,
                            SupplierId = supplier.SupplierId,
                            ProductId = product.ProductId
                        };

                        context.ProductsSuppliers.Add(prodSupply);
                        context.SaveChanges();
                    }
                    //Already exists
                    else
                    {
                        prodSupply = existingProdSupply;
                    }

                    if (views.Last() == "package product supplies")
                    {
                        var prodSuppliers = DB.Get.PackageProductSupplies(lastId);

                        var package = context.Packages
                            .Include(p => p.ProductSuppliers) // Ensure related data is loaded
                            .FirstOrDefault(p => p.PackageId == lastId);

                        if (package == null)
                        {
                            // Handle the case where the package is not found
                            return;
                        }

                        //Add Product Supplier
                        if (!package.ProductSuppliers.Any(ps => ps.SupplierId == supplier.SupplierId && ps.ProductId == product.ProductId))
                        {
                            package.ProductSuppliers.Add(prodSupply);
                        }

                        context.SaveChanges();
                    }
                }
                else
                {
                    var prodSupply = context.ProductsSuppliers.Find(Id.GetId(lstData));

                    if (prodSupply != null)
                    {
                        prodSupply.Supplier = supplier;
                        prodSupply.SupplierId = supplier.SupplierId;
                        prodSupply.Product = product;
                        prodSupply.ProductId = product.ProductId;

                        context.ProductsSuppliers.Update(prodSupply);
                        context.SaveChanges();
                    }
                }

                MessageBox.Show("Task completed successfully. Exit to see new changes.");
            }
            // if view is product, add new product
            else if (views.Last() == "products")
            {
                AddProduct();
                MessageBox.Show("Task completed successfully. Exit to see new changes");
            }
            // if view is suppliers, add new supplier
            else if (views.Last() == "suppliers")
            {
                AddSupplier();
                MessageBox.Show("Task completed successfully. Exit to see new changes");
            }

            // save changes
            context.SaveChanges();
        }

        // when new button next to product is clicked, toggle text box
        private void btnNewProduct_Click(object sender, EventArgs e)
        {
            ToggleNewItem(btnNewProduct, txtProduct, cboProduct);
        }

        // when new button next to supplier is clicked, toggle text box
        private void btnNewSupplier_Click(object sender, EventArgs e)
        {
            ToggleNewItem(btnNewSupplier, txtSupplier, cboSupplier);
        }

        // changes the button text, and toggles textbox/combobox
        private void ToggleNewItem(Button button, TextBox textBox, ComboBox comboBox)
        {
            button.Text = button.Text == "New" ? "Option" : "New";
            bool isVisible = textBox.Visible;

            textBox.Visible = !isVisible;
            comboBox.Visible = isVisible;
        }

        // adds a new product
        private void AddProduct()
        {
            if (Validation.IsSentence(txtProduct))
            {
                string name = StringFormats.FormatString(txtProduct.Text);

                var product = new Product
                {
                    ProdName = name.Trim()
                    // Do not set ProductId; let SQL Server handle it automatically
                };

                var products = DB.Get.Products();

                if (!products.Any(p => p.ProdName.ToLower().Trim().Equals(product.ProdName.ToLower().Trim())))
                {
                    if (!isAdd)
                    {
                        product = context.Products.FirstOrDefault(p => p.ProdName == GetSelectedProductName());
                        if (product != null)
                        {
                            product.ProdName = name.Trim();
                            context.Products.Update(product);
                        }
                    }
                    else
                    {
                        context.Products.Add(product); // Add product without setting ProductId
                    }

                    context.SaveChanges(); // Save changes after adding or updating
                }
                else
                {
                    MessageBox.Show("This product already exists");
                }
            }
        }

        // adds a new supplier
        private void AddSupplier()
        {
            // validate supplier textbox
            if (Validation.IsSentence(txtSupplier))
            {
                string name = StringFormats.FormatString(txtSupplier.Text);

                Supplier supplier;

                // if is add, add new product, else update supplier data

                supplier = new Supplier()
                {
                    SupplierId = context.Suppliers.OrderByDescending(p => p.SupplierId).FirstOrDefault().SupplierId + 1,
                    SupName = name.Trim()
                };

                var suppliers = DB.Get.Suppliers();

                // verify that supplier does not already exist
                if (!suppliers.Any(s => s.SupName.ToLower().Trim().Equals(supplier.SupName.ToLower().Trim())))
                {
                    if (!isAdd)
                    {
                        supplier = context.Suppliers.Where(p => p.SupName == GetSelectedSupplierName()).FirstOrDefault();
                        supplier.SupName = name.Trim();
                        context.Suppliers.Update(supplier);
                    }
                    else
                    {
                        context.Suppliers.Add(supplier); // if isAdd, add the supplier else update the supplier
                    }

                    context.SaveChanges();
                }
                else
                {
                    MessageBox.Show("This supplier already exists");
                }
            }
        }

        /// <summary>
        /// Product Keypress
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboProduct_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        /// <summary>
        /// Supplier Keypress
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboSupplier_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}
