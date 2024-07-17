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
        DbGet dbGet = new DbGet();
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
            ListPackages(true);
            disableButtons(false);
        }

        // When products button is clicked, List products and disable buttons
        private void btnProducts_Click(object sender, EventArgs e)
        {
            ListProducts(true);
            disableButtons(false);
        }

        // when Suppliers button is clicked, list suppliers and disable buttons
        private void btnSuppliers_Click(object sender, EventArgs e)
        {
            ListSuppliers(true);
            disableButtons(false);
        }

        // when productssupliers button is clicked, list product suppliers and disable buttons
        private void btnProductSuppliers_Click(object sender, EventArgs e)
        {
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
                $"{"Agency Com.".PadRight(12)}", StringFormats.FormatPackages, dbGet.GetPackages());
        }

        // List products. Calls Update list box
        // If bool is true, add's "products" to views list
        private void ListProducts(bool val)
        {
            if (val) views.Add("products");
            UpdateListBox($"{"Id".PadRight(6)}Product Name", StringFormats.FormatProducts, dbGet.GetProducts());
        }

        // List suppliers. Calls Update list box
        // If bool is true, add's "suppliers" to views list
        private void ListSuppliers(bool val)
        {
            if (val) views.Add("suppliers");
            UpdateListBox($"{"Id".PadRight(6)}Supplier Name", StringFormats.FormatSuppliers, dbGet.GetSuppliers());

        }

        // Lists product suppliers. Calls Update list box
        // If bool is true, add's "product suppliers" to views list
        private void ListProductSuppliers(bool val, int id = -1)
        {
            if (val) views.Add("product supplies");
            UpdateListBox($"{"Sup. Id".PadRight(8)}{"Product Id".PadRight(12)}{"Id".PadRight(6)}", StringFormats.FormatProductsSupplier, dbGet.GetProductSuppliers(id));
        }

        // Lists Suppliers contacts. Calls Update list box
        // If bool is true, add's "supplier contacts" to views list
        private void ListSupplierContact(bool val, bool useLast = false)
        {
            if (val) views.Add("supplier contacts");
            UpdateListBox($"{"Id".PadRight(6)}{"First Name".PadRight(15)}{"LastName".PadRight(15)}{"Email".PadRight(33)}{"Fax".PadRight(12)}{"Address".PadRight(50)}", StringFormats.FormatSupplierContacts, dbGet.GetSupplierContacts(lstData, useLast));
        }

        // List packages product supplies. Calls Update list box
        // If bool is true, add's "package product suppliers" to views list
        private void ListPackageProductSuppliers(bool val, bool useLast = false)
        {
            if (val) views.Add("package product supplies");
            UpdateListBox($"{"Sup. Id".PadRight(8)}{"Product Id".PadRight(12)}{"Id".PadRight(6)}", StringFormats.FormatProductsSupplier, dbGet.GetPackageProductSupplies(lstData, useLast));
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
                enableEditRemove(true);
                if (views.Last().Equals("packages") || views.Last().Equals("suppliers") || views.Last().Equals("package product supplies"))
                {
                    enableEditRemove(true);
                    enableMoreLess(true, true);
                }
                else if (views.Last().Equals("product supplies"))
                {
                    enableEditRemove(false);
                    enableMoreLess(true, true);
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
                    Models.Package package = dbGet.GetPackages(Id.GetId(lstData)).FirstOrDefault();
                    context.Packages.Remove(package);
                    context.SaveChanges();
                    ListPackages(false);
                }
                if (views.Last().Equals("products"))
                {
                    Product product = dbGet.GetProducts(Id.GetId(lstData)).FirstOrDefault();
                    context.Products.Remove(product);
                    context.SaveChanges();
                    ListProducts(false);
                }
                if (views.Last().Equals("suppliers"))
                {
                    Supplier supplier = dbGet.GetSuppliers(Id.GetId(lstData)).FirstOrDefault();
                    context.Suppliers.Remove(supplier);
                    context.SaveChanges();
                    ListSuppliers(false);
                }
                if (views.Last().Equals("product supplies"))
                {
                    ProductsSupplier prodSupplier = dbGet.GetProductSuppliers(Id.GetId(lstData)).FirstOrDefault();
                    context.ProductsSuppliers.Remove(prodSupplier);
                    context.SaveChanges();
                    ListProductSuppliers(false);
                }
                if (views.Last().Equals("supplier contacts"))
                {
                    var supContact = context.SupplierContacts.AsNoTracking().FirstOrDefault(p => p.SupplierContactId == Id.GetId(lstData));
                    context.SupplierContacts.Remove(supContact);
                    context.SaveChanges();
                    ListSupplierContact(false, true);
                }
            }
        }

        // when button add is clicked, check view to open correct dialog.
        // list appropriate data once it is clicked
        private void btnAdd_Click(object sender, EventArgs e)
        {
            //TODO: Consider Switch statement
            if (views.Last() == "packages")
            {
                Form form = new AddEditPackage();
                form.ShowDialog();
                ListPackages(false);
            }
            if (views.Last() == "supplier contacts")
            {

            }
            if (views.Last() == "suppliers")
            {
                SupplierAddModifyForm form = new SupplierAddModifyForm();
                form.SetAddMode();
                form.ShowDialog();
                ListSuppliers(false);
            }
            if (views.Last() == "products")
            {
                Form form = new AddEditPackageProduct();
                form.ShowDialog();
                ListProducts(false);
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
                    Form form = new AddEditPackageProduct(Id.GetId(lstData));
                    form.ShowDialog();
                    ListProducts(false);
                }
                if (views.Last() == "product supplies")
                {
                    Form form = new AddEditPackageProduct(Id.GetId(lstData));
                    //TODO: Add this to second form to allow more dynamic editing
                    // form.type = "product supplies";
                    form.ShowDialog();
                    ListProducts(false);
                }
                
                if (views.Last() == "supplier contacts")
                {

                }
                if(views.Last() == "suppliers")
                {
                    SupplierAddModifyForm form = new SupplierAddModifyForm();
                    List<Supplier> s = dbGet.GetSuppliers();
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
