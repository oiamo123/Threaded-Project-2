using Microsoft.EntityFrameworkCore;
using Microsoft.SqlServer.Server;
using System.Diagnostics;
using System.IO.Packaging;
using System.Text.RegularExpressions;
using ThreadedProject2.Helpers;
using ThreadedProject2.Models;

namespace ThreadedProject2
{
    public partial class Form1 : Form
    {
        DbGet dbGet = new DbGet();
        Models.TravelExpertsContext context = new Models.TravelExpertsContext();
        public delegate string FormatItemDelegate<T>(T item);
        List<string> views = new List<string>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ListPackages(true);
        }

        public void btnPackages_Click(object sender, EventArgs e)
        {
            ListPackages(true);
            disableButtons(false);
        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            ListProducts(true);
            disableButtons(false);
        }

        private void btnSuppliers_Click(object sender, EventArgs e)
        {
            ListSuppliers(true);
            disableButtons(false);
        }

        private void btnProductSuppliers_Click(object sender, EventArgs e)
        {
            ListProductSuppliers(true);
            disableButtons(false);
        }

        private void ListPackages(bool val)
        {
            if (val) views.Add("packages");
            UpdateListBox($"{"Id".PadRight(6)}{"Name".PadRight(22)}" +
                $"{"Start Date".PadRight(12)}{"End Date".PadRight(12)}" +
                $"{"Description".PadRight(48)}{"Base Price".PadRight(12)}" +
                $"{"Agency Com.".PadRight(12)}", StringFormats.FormatPackages, dbGet.GetPackages());
        }

        private void ListProducts(bool val)
        {
            if (val) views.Add("products");
            UpdateListBox($"{"Id".PadRight(6)}Product Name", StringFormats.FormatProducts, dbGet.GetProducts());
        }

        private void ListSuppliers(bool val)
        {
            if (val) views.Add("suppliers");
            UpdateListBox($"{"Id".PadRight(6)}Supplier Name", StringFormats.FormatSuppliers, dbGet.GetSuppliers());

        }

        private void ListProductSuppliers(bool val, int id = -1)
        {
            if (val) views.Add("product supplies");
            UpdateListBox($"{"Sup. Id".PadRight(8)}{"Product Id".PadRight(12)}{"Id".PadRight(6)}", StringFormats.FormatProductsSupplier, dbGet.GetProductSuppliers(id));
        }

        private void ListSupplierContact(bool val, bool useLast = false)
        {
            if (val) views.Add("supplier contacts");
            UpdateListBox($"{"Id".PadRight(6)}{"First Name".PadRight(15)}{"LastName".PadRight(15)}{"Email".PadRight(33)}{"Fax".PadRight(12)}{"Address".PadRight(50)}", StringFormats.FormatSupplierContacts, dbGet.GetSupplierContacts(lstData, useLast));
        }

        private void ListPackageProductSuppliers(bool val, bool useLast = false)
        {
            if (val) views.Add("package product supplies");
            UpdateListBox($"{"Sup. Id".PadRight(8)}{"Product Id".PadRight(12)}{"Id".PadRight(6)}", StringFormats.FormatProductsSupplier, dbGet.GetPackageProductSupplies(lstData, useLast));
        }

        private void disableButtons(bool val)
        {
            enableMoreLess(val, val);
            enableEditRemove(val);
        }

        private void enableMoreLess(bool val1, bool val2)
        {
            btnMore.Visible = val1;
            btnLess.Visible = val2;
        }

        private void enableEditRemove(bool val)
        {
            btnEdit.Visible = val;
            btnRemove.Visible = val;
        }

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

        private void btnMore_Click(object sender, EventArgs e)
        {
            // if packages, product suppliers for that package
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
            Debug.WriteLine(views);
        }

        private void clearListBox()
        {
            lstData.Items.Clear();
        }

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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (views.Last() == "packages")
            {
                Form form = new AddEditPackage();
                form.ShowDialog();
                ListPackages(false);
            }
            if (views.Last() == "supplier contacts")
            {

            }
        }

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
                if (views.Last() == "supplier contacts")
                {

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

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
