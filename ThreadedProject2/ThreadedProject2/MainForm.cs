using Microsoft.EntityFrameworkCore;
using Microsoft.SqlServer.Server;
using System.Diagnostics;
using System.IO.Packaging;
using System.Text.RegularExpressions;
using ThreadedProject2.Helpers;
using ThreadedProject2.Models;

namespace ThreadedProject2
{
    public partial class MainForm : Form
    {
        Models.TravelExpertsContext context = new Models.TravelExpertsContext();

        public delegate string FormatItemDelegate<T>(T item);

        List<string> views = new List<string>();

        public MainForm()
        {
            InitializeComponent();
        }

        // When form loads list packages
        private void Form1_Load(object sender, EventArgs e)
        {
            ListPackages(true);
        }

        // When packages button is clicked, list Packages and disable buttons
        public void btnPackages_Click(object sender, EventArgs e)
        {
            views.Clear();
            ListPackages(true);
            disableButtons(false);
        }

        // When products button is clicked, List products and disable buttons
        private void btnProducts_Click(object sender, EventArgs e)
        {
            views.Clear();
            ListProducts(true);
            disableButtons(false);
        }

        // when Suppliers button is clicked, list suppliers and disable buttons
        private void btnSuppliers_Click(object sender, EventArgs e)
        {
            views.Clear();
            ListSuppliers(true);
            disableButtons(false);
        }

        // when productssupliers button is clicked, list product suppliers and disable buttons
        private void btnProductSuppliers_Click(object sender, EventArgs e)
        {
            views.Clear();
            ListProductSuppliers(true);
            disableButtons(false);
        }

        // List packages. Calls Update list box
        // If bool is true, add's "packages" views list
        private void ListPackages(bool val)
        {
            if (val) views.Add("packages");
            UpdateListBox($"{"Id".PadRight(6)}{"Name".PadRight(22)}" +
                $"{"Start Date".PadRight(12)}{"End Date".PadRight(12)}" +
                $"{"Description".PadRight(48)}{"Base Price".PadRight(12)}" +
                $"{"Agency Com.".PadRight(12)}", StringFormats.FormatPackages, DB.Get.Packages());
        }

        // List products. Calls Update list box
        // If bool is true, add's "products" to views list
        private void ListProducts(bool val)
        {
            if (val) views.Add("products");
            UpdateListBox($"{"Id".PadRight(6)}Product Name", StringFormats.FormatProducts, DB.Get.Products());
        }

        // List suppliers. Calls Update list box
        // If bool is true, add's "suppliers" to views list
        private void ListSuppliers(bool val)
        {
            if (val) views.Add("suppliers");
            UpdateListBox($"{"Id".PadRight(6)}Supplier Name", StringFormats.FormatSuppliers, DB.Get.Suppliers());

        }

        // Lists product suppliers. Calls Update list box
        // If bool is true, add's "product suppliers" to views list
        private void ListProductSuppliers(bool val, int id = -1)
        {
            if (val) views.Add("product supplies");
            UpdateListBox($"{"Id".PadRight(6)}{"Product".PadRight(21)}{"Supplier"}", StringFormats.FormatProductsSupplier, DB.Get.ProductSuppliers(id));
        }

        // Lists Suppliers contacts. Calls Update list box
        // If bool is true, add's "supplier contacts" to views list
        private void ListSupplierContact(bool val, bool useLast = false)
        {
            int id = -1;
            if (views.Last().Equals("product supplies") || views.Last().Equals("package product supplies")) id = DB.Get.ProductSuppliers(Id.GetId(lstData)).FirstOrDefault().SupplierId;
            if (views.Last().Equals("suppliers")) id = Id.GetId(lstData);

            if (val) views.Add("supplier contacts");
            
            UpdateListBox($"{"Id".PadRight(6)}{"First Name".PadRight(15)}{"LastName".PadRight(15)}{"Email".PadRight(33)}{"Fax".PadRight(12)}{"Address".PadRight(50)}", StringFormats.FormatSupplierContacts, DB.Get.SupplierContacts(id, useLast));
        }

        // List packages product supplies. Calls Update list box
        // If bool is true, add's "package product suppliers" to views list
        private void ListPackageProductSuppliers(bool val, bool useLast = false)
        {
            if (val) views.Add("package product supplies");
            UpdateListBox($"{"Id".PadRight(6)}{"Product".PadRight(21)}{"Supplier"}", StringFormats.FormatProductsSupplier, DB.Get.PackageProductSupplies(lstData, useLast));
        }

        // disables/enables more, less, edit and remove buttons
        private void disableButtons(bool val)
        {
            enableMoreLess(val, val);
            enableEditRemove(val);
        }

        // disables/enables more and less buttons
        private void enableMoreLess(bool val1, bool val2)
        {
            btnMore.Visible = val1;
            btnLess.Visible = val2;
        }

        // disables / enables edit and remove buttons
        private void enableEditRemove(bool val)
        {
            btnEdit.Visible = val;
            btnRemove.Visible = val;
        }

        // Checks what the current view is when List Box is clicked. Will show correct buttons based on view
        private void lstData_MouseClick(object sender, MouseEventArgs e)
        {
            if (lstData.SelectedItem != null)
            {
                disableButtons(true);
                if (views.Last().Equals("products"))
                {
                    enableMoreLess(false, false);
                }
            }
        }

        // checks the view when more button is clicked to display correct data\
        // checks to ensure first row is not selected
        private void btnMore_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(lstData.SelectedItem.ToString().Substring(0, 6).TrimEnd(), out int val)) throw new Exception("First row cannot be selected");
                if (views.Last().Equals("packages") && lstData.SelectedItem != null)
                {
                    ListPackageProductSuppliers(true);
                }
                else
                {
                    ListSupplierContact(true);
                }

                enableEditRemove(false);
                enableMoreLess(false, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            Debug.WriteLine(views);
        }

        // when button less is clicked, remove last view from views list.
        // Lists correct data based on last item in views list
        private void btnLess_Click(object sender, EventArgs e)
        { 
            if (views.Count() > 1) views.Remove(views.Last());
            enableEditRemove(false);
            enableMoreLess(false, true);
            if (views.Last() == "packages")
            {
                ListPackages(false);
            }
            else if (views.Last() == "suppliers")
            {
                ListSuppliers(false);
            }
            else if (views.Last() == "product supplies")
            {
                ListProductSuppliers(false);
            }
            else if (views.Last() == "package product supplies")
            {
                ListPackageProductSuppliers(false, true);
            }
        }

        // When remove button is clicked, check the current view, get id,
        // query correct model, remove item and relist appropriate data
        private void btnRemove_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Are you sure you would like to remove this?", "Remove item", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (res == DialogResult.Yes)
            {
                if (views.Last().Equals("packages"))
                {
                    var package = context.Packages.Where(p => p.PackageId == Id.GetId(lstData)).FirstOrDefault();

                    DB.Remove.Package(package.PackageId);

                    ListPackages(false);
                }

                if (views.Last().Equals("products"))
                {
                    DialogResult prodRes = DialogResult.None;

                    // get product
                    var product = DB.Get.Products(Id.GetId(lstData)).FirstOrDefault();

                    // check to see if product is connected to any product supplies
                    var productSupplies = context.ProductsSuppliers.Where(p => p.ProductId == product.ProductId).ToList();

                    // check to see if product is connected to any package product supplies
                    var packageProductSupplies = context.Packages.Include(p => p.ProductSuppliers.Where(ps => ps.ProductId == product.ProductId)).ToList();

                    string warningMessage = "Are you sure you want to continue?";
                    if (productSupplies.Count() > 0 || packageProductSupplies.Count() > 0)
                    {
                        if (packageProductSupplies.Count() > 0) warningMessage += " This product is associated with a packages product supplies.";
                        if (productSupplies.Count() > 0) warningMessage += " This contact is assosciated with a product supply.";

                        prodRes = MessageBox.Show(warningMessage, "Remove Supplier", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        prodRes = DialogResult.OK;
                    }

                    // remove product supplies from package product supplies, product supply is also removed
                    DB.Remove.PackageProductSupply(context, packageProductSupplies);

                    DB.Remove.Products(product.ProductId);

                    ListProducts(false);
                }

                if (views.Last().Equals("suppliers"))
                {
                    DialogResult supRes = DialogResult.None;

                    // get supplier
                    List<Supplier> supplier = DB.Get.Suppliers(Id.GetId(lstData)).ToList();

                    using (var context = new Models.TravelExpertsContext())
                    {
                        // get supplier contacts
                        List<SupplierContact> supplierContacts = context.SupplierContacts.Where(p => p.SupplierId == supplier.First().SupplierId).ToList();

                        // get all products suppliers with same supplierid
                        List<ProductsSupplier> productSupplies = context.ProductsSuppliers.Where(p => p.SupplierId == supplier.First().SupplierId).ToList();

                        var packages = context.Packages.Include(p => p.ProductSuppliers.Where(p => p.SupplierId == supplier.First().SupplierId)).ToList();

                        // If Supplier contacts count > 0, confirm removal
                        string warningMessage = "Are you sure you want to continue?";
                        if (supplierContacts.Count > 0 || packages.Any(p => p.ProductSuppliers.Count != 0))
                        {
                            if (supplierContacts.Count > 0) warningMessage += " This will also remove all associated contacts.";
                            if (packages.Any(p => p.ProductSuppliers.Count != 0)) warningMessage += " This contact is assosciated with a packages product supplies.";

                            supRes = MessageBox.Show(warningMessage, "Remove Supplier", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            supRes = DialogResult.OK;
                        }

                        // remove product supplies from packages
                        if (packages.Any(p => p.ProductSuppliers.Count != 0)) DB.Remove.PackageProductSupply(context, packages);
                        
                        // remove product supply
                        DB.Remove.ProductSupplies(productSupplies);

                        // remove supplier contacts from supplier
                        if (supplierContacts.Count > 0)
                        DB.Remove.SupplierContacts(supplierContacts);

                        // remove supplier
                        DB.Remove.Suppliers(supplier);

                        ListSuppliers(false);
                    }
                }

                if (views.Last().Equals("product supplies"))
                {
                    // get product supplier
                    var prodSupplier = DB.Get.ProductSuppliers(Id.GetId(lstData)).ToList();
                    var packages = context.Packages.Include(p => p.ProductSuppliers.Where(p => p.ProductSupplierId == prodSupplier.FirstOrDefault().ProductSupplierId)).ToList();

                    // remove product supplier from any associated packages and product supplies
                    if (packages.All(package => package.ProductSuppliers.Count() == 0))
                    {
                        DB.Remove.ProductSupplies(prodSupplier);
                    }
                    else
                    {
                        DB.Remove.PackageProductSupply(context, packages);
                    }

                    // list product suppliers
                    ListProductSuppliers(false);
                }
                if (views.Last().Equals("package product supplies"))
                {   // get all packages where product supplier id = id
                    var packages = context.Packages.Include(p => p.ProductSuppliers.Where(ps => ps.ProductSupplierId == Id.GetId(lstData))).ToList();
                    
                    // get product supply
                    var productSupply = DB.Get.ProductSuppliers(Id.GetId(lstData));
                    
                    // remove product supply from all packages
                    DB.Remove.PackageProductSupply(context, packages);
                    
                    // remove product supply
                    DB.Remove.ProductSupplies(productSupply);

                    ListPackageProductSuppliers(false, true);
                }
                if (views.Last().Equals("supplier contacts"))
                {
                    // get supplier contact id
                    var supContact = context.SupplierContacts.Where(s => s.SupplierContactId == Id.GetId(lstData)).ToList();

                    // remove supplier contact
                    DB.Remove.SupplierContacts(supContact);

                    // list supplier contacts
                    ListSupplierContact(false, true);
                }
            }
        }

        // String array of views/Types
        public static readonly string[] Types =
            ["Product", "Supplier", "Product Supplier", "Supplier Contact", "Package"];

        // Default value indicating no selection
        private int mainId = -1;

        // when button add is clicked, check view to open correct dialog.
        // list appropriate data once it is clicked
        private void btnAdd_Click(object sender, EventArgs e)
        {
            switch (views.Last())
            {
                case "packages":
                {
                    Form form = new AddEditPackage();
                    form.ShowDialog();
                    ListPackages(false);
                    break;
                }
                case "supplier contacts":
                    break;
                case "suppliers":
                {
                    SupplierAddModifyForm form = new SupplierAddModifyForm();
                    form.SetAddMode();
                    form.ShowDialog();
                    ListSuppliers(false);
                    break;
                }
                //If using AddEditPackageProduct
                //Using Erin Form^^
                // if (views.Last() == "suppliers")
                // {
                //     //set type to main form
                //     AddEditPackageProduct form = new AddEditPackageProduct(Types[1], mainId);
                //     form.ShowDialog();
                //     ListProducts(false);
                // }
                case "products":
                {
                    //set type to main form
                    AddEditPackageProduct form = new AddEditPackageProduct(Types[0], mainId);
                    form.ShowDialog();
                    ListProducts(false);
                    break;
                }
                case "product supplies":
                {
                    AddEditPackageProduct form = new AddEditPackageProduct(Types[2], mainId);
                    form.ShowDialog();
                    ListProductSuppliers(false);
                    break;
                }
            }
        }

        // When edit button is clicked, check view, open appropriate form,
        // and then relist appropriate data after item has been edited.
        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstData.SelectedItem == null) throw new Exception("You must select an item in order to edit it");
                if (views.Last() == "packages")
                {
                    Form form = new AddEditPackage(Id.GetId(lstData));
                    form.ShowDialog();
                    ListPackages(false);
                }

                if (views.Last() == "products")
                {
                    AddEditPackageProduct form = new AddEditPackageProduct(Types[0], Id.GetId(lstData));
                    form.ShowDialog();
                    ListProducts(false);
                }

                if (views.Last() == "product supplies")
                {
                    AddEditPackageProduct form = new AddEditPackageProduct(Types[2], Id.GetId(lstData));
                    form.ShowDialog();
                    ListProductSuppliers(false);
                }

                if (views.Last() == "supplier contacts")
                {
                }

                if (views.Last() == "suppliers")
                {
                    SupplierAddModifyForm form = new SupplierAddModifyForm();
                    List<Supplier> s = DB.Get.Suppliers();
                    form.SetEditMode(s[lstData.SelectedIndex-1]);
                    form.ShowDialog();
                    ListSuppliers(false);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // clears list box
        private void clearListBox()
        {
            lstData.Items.Clear();
        }

        // Updates list box. 
        // string head: string for first row/ description
        // FormatItemDelegate: Method gets passed in to format data. Check StringFormats in Helpers to see formats
        // list: takes a list ie Packages
        private void UpdateListBox<T>(string head, FormatItemDelegate<T> formatBody, List<T> list)
        {
            clearListBox();
            lstData.Items.Add(head);
            foreach (var i in list)
            {
                lstData.Items.Add(formatBody(i));
            }
        }
    }
}