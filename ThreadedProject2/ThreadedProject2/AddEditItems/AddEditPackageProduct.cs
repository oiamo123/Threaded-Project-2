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

        public AddEditPackageProduct(List<string> views, bool isAdd, ListBox lstData)
        {
            InitializeComponent();
            this.views = views;
            this.isAdd = isAdd;
            this.context = new TravelExpertsContext();
            this.lstData = lstData;
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

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (views.Last() == "product supplies" || views.Last() == "package product supplies")
            {
                // inititiate products and supplier
                Product product;
                Supplier supplier;

                // if txtProduct/txtSupplier are visible, add a new product and/or supplier
                // otherwise cbo is being used and product/supplier already exists
                if (txtProduct.Visible == true)
                {
                    AddProduct(); // add new product
                    product = context.Products.OrderBy(p => p.ProductId).Last(); // get new added product
                }
                else
                {
                    product = context.Products.Where(p => p.ProdName == cboProduct.SelectedItem).FirstOrDefault();
                }

                if (txtSupplier.Visible == true)
                {
                    AddSupplier(); // add new supplier
                    supplier = context.Suppliers.OrderBy(s => s.SupplierId).Last(); // get new added supplier
                }
                else
                {
                    supplier = context.Suppliers.Where(s => s.SupName == cboSupplier.SelectedItem).FirstOrDefault();
                }

                if (isAdd)
                {
                    // productSupply, query for existing product supply before adding a new one
                    ProductsSupplier prodSupply;
                    ProductsSupplier existingProdSupply = context.ProductsSuppliers.Where(ps => ps.Supplier == supplier && ps.Product == product).FirstOrDefault();

                    // if productsupply doesn't already exist, create a new one
                    if (existingProdSupply == null)
                    {
                        prodSupply = new ProductsSupplier()
                        {
                            Product = product,
                            Supplier = supplier,
                            SupplierId = supplier.SupplierId,
                            ProductId = product.ProductId
                        };

                        context.ProductsSuppliers.Add(prodSupply);
                        context.SaveChanges();
                    }
                    else
                    {
                        prodSupply = existingProdSupply;
                    }

                    // if view is package product supplies, add product supply to package product supplies and to product supplies
                    if (views.Last() == "package product supplies")
                    {
                        (List<ProductsSupplier> prodSuppliers, int packageId) = DB.Get.PackageProductSupplies(lstData, true);
                        Package package = context.Packages.Where(p => p.PackageId == packageId).FirstOrDefault();
                        if (!package.ProductSuppliers.Any(ps => ps == prodSupply)) prodSupply.Packages.Add(package);
                        if (!context.ProductsSuppliers.Any(ps => ps == prodSupply)) package.ProductSuppliers.Add(prodSupply);
                    }    
                }
                // if form is not isAdd, update product supply
                else
                {
                    var prodSupply = DB.Get.ProductSuppliers(Id.GetId(lstData)).FirstOrDefault();

                    prodSupply.Supplier = supplier;
                    prodSupply.SupplierId = supplier.SupplierId;
                    prodSupply.Product = product;
                    prodSupply.ProductId = product.ProductId;

                    context.ProductsSuppliers.Update(prodSupply);
                }

                MessageBox.Show("Task completed succesfully. Exit to see new changes.");
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
            if (Validation.IsSentence(txtProduct.Text, "Product"))
            {
                string name = "";

                foreach (var str in txtProduct.Text.Split(" "))
                {
                    str.Trim();
                    name += $@" {Char.ToUpper(str[0]) + str.Substring(1).ToLower()}";
                }

                var product = new Product()
                {
                    ProdName = name.Trim()
                };

                var products = DB.Get.Products();

                if (!products.Any(p => p.ProdName.ToLower().Trim().Equals(product.ProdName.ToLower().Trim())))
                {
                    if (isAdd || txtProduct.Visible == true)
                    {
                        context.Products.Add(product); // if isAdd, add the supplier else update the supplier
                    }
                    else
                    {
                        product = context.Products.Where(p => p.ProdName == GetSelectedProductName()).FirstOrDefault();
                        product.ProdName = name.Trim();
                        context.Products.Update(product);
                    }
                    
                    context.SaveChanges();
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
            if (Validation.IsSentence(txtSupplier.Text, "Suppliers"))
            {
                string name = "";

                // reformat string from "company name" to "Company Name"
                foreach (var str in txtSupplier.Text.Split(" "))
                {
                    str.Trim();
                    name += $@" {Char.ToUpper(str[0]) + str.Substring(1).ToLower()}";
                }

                Supplier supplier;

                // if is add, add new product, else update supplier data
                if (isAdd)
                {
                    supplier = new Supplier()
                    {
                        SupName = name.Trim()
                    };
                }
                else
                {
                    supplier = DB.Get.Suppliers(Id.GetId(lstData)).FirstOrDefault();
                    supplier.SupName = txtSupplier.Text;
                }

                var suppliers = DB.Get.Suppliers();

                // verify that supplier does not already exist
                if (!suppliers.Any(s => s.SupName.ToLower().Trim().Equals(supplier.SupName.ToLower().Trim())))
                {
                    if (isAdd || txtSupplier.Visible == true)
                    {
                        context.Suppliers.Add(supplier); // if isAdd, add the supplier else update the supplier
                    }
                    else
                    {
                        supplier = context.Suppliers.Where(p => p.SupName == GetSelectedSupplierName()).FirstOrDefault();
                        supplier.SupName = name.Trim();
                        context.Suppliers.Update(supplier);
                    }

                    context.SaveChanges();
                }
                else
                {
                    MessageBox.Show("This supplier already exists");
                }
            }
        }
    }
}
