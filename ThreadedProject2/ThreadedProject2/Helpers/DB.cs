using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThreadedProject2.Models;

// Author: Gavin

namespace ThreadedProject2.Helpers
{
    public class DB
    {
        static public class Get
        {
            static int supConLastId = 0;
            static int packProdLastId = 0;
            static int packLastId = 0;
            static int supLastId = 0;

            /// <summary>
            /// Get packages
            /// </summary>
            /// <param name="id">Optional id parameter to query by PackageId</param>
            /// <returns></returns>
            static public List<Models.Package> Packages(int id = -1)
            {
                using (Models.TravelExpertsContext context = new TravelExpertsContext())
                {
                    if (id == -1)
                    {
                        var packages = context.Packages.Select(p => p);
                        return packages.ToList();
                    }
                    else
                    {
                        var packages = context.Packages.Where(p => p.PackageId == id);
                        return packages.ToList();
                    }
                }
            }

            /// <summary>
            /// Get products
            /// </summary>
            /// <param name="id">Optional id parameter to query by ProductId</param>
            /// <returns></returns>
            static public List<Product> Products(int id = -1)
            {
                using (Models.TravelExpertsContext context = new TravelExpertsContext())
                {
                    if (id == -1)
                    {
                        var products = context.Products.Select(p => p).OrderBy(p => p.ProductId);
                        return products.ToList();
                    }
                    else
                    {
                        var products = context.Products.Where(p => p.ProductId == id);
                        return products.ToList();
                    }
                }
            }

            /// <summary>
            /// Get Suppliers
            /// </summary>
            /// <param name="id">Optional id parameter to query by supplier id</param>
            /// <returns></returns>
            static public List<Supplier> Suppliers(int id = -1)
            {
                using (Models.TravelExpertsContext context = new TravelExpertsContext())
                {
                    List<Supplier> suppliers;
                    if (id == -1)
                    {
                        suppliers = context.Suppliers.Select(p => p).OrderBy(p => p.SupName).ToList();
                    }
                    else
                    {
                        suppliers = context.Suppliers.Where(p => p.SupplierId == id).ToList();
                    }

                    return suppliers;
                }
            }

            /// <summary>
            /// Get Product suppliers
            /// </summary>
            /// <param name="id">Optional id parameter to query by productid</param>
            /// <returns></returns>
            static public List<ProductsSupplier> ProductSuppliers(int id = -1)
            {
                using (Models.TravelExpertsContext context = new TravelExpertsContext())
                {
                    if (id == -1)
                    {
                        var prodSuppliers = context.ProductsSuppliers.Select(p => p).OrderBy(p => p.ProductSupplierId);
                        return prodSuppliers.ToList();
                    }
                    else
                    {
                        var prodSuppliers = context.ProductsSuppliers.Where(p => p.ProductSupplierId == id).OrderBy(p => p.ProductSupplierId);
                        return prodSuppliers.ToList();
                    }
                }
            }

            /// <summary>
            /// Get Supplier contacts
            /// </summary>
            /// <param name="lstData">ListBox lstdata to get supplier id</param>
            /// <param name="useLast">To show all supplier contacts, false, else to reference only previous supplier, true reference the id of the previous menu selection</param>
            /// <returns></returns>
            static public List<SupplierContact> SupplierContacts(int id)
            {
                using (Models.TravelExpertsContext context = new TravelExpertsContext())
                {
                    var supplierContacts = context.SupplierContacts.Where(p => p.SupplierId == id).ToList();

                    return supplierContacts;
                }
            }

            /// <summary>
            /// Get package product suppliers
            /// </summary>
            /// <param name="lstData">Listbox lstdata to get Package ID</param>
            /// <param name="useLast">To show all Package product supplies, false, else to reference only previous package, true. references the id of the previous menu selection</param>
            /// <returns></returns>
            static public List<ProductsSupplier> PackageProductSupplies(int id)
            {
                using (Models.TravelExpertsContext context = new TravelExpertsContext())
                {

                    var package = context.Packages
                                     .Include(p => p.ProductSuppliers)
                                     .SingleOrDefault(p => p.PackageId == id);

                    return package.ProductSuppliers.ToList();
                }

            }
        }

        public class Remove
        {
            /// <summary>
            /// Removes package
            /// </summary>
            /// <param name="package">package to remove</param>
            static public void Package(Package package)
            {
                try
                {
                    using (Models.TravelExpertsContext context = new Models.TravelExpertsContext())
                    {
                        context.Packages.Remove(package);
                        context.SaveChanges();
                    }
                }
                catch (Microsoft.EntityFrameworkCore.DbUpdateException ex)
                {
                    MessageBox.Show("This package is currently associated with a booking. At this time you are unable to remove it.");
                }
            }

            /// <summary>
            /// Removes Product Supplies
            /// </summary>
            /// <param name="productSuppliers">List of product suppliers to remove</param>
            static public void ProductSupplies(List<ProductsSupplier> productSuppliers)
            {
                using (Models.TravelExpertsContext context = new Models.TravelExpertsContext())
                {
                    foreach (var ps in productSuppliers)
                    {
                        context.ProductsSuppliers.Remove(ps);
                    }

                    try
                    {
                        context.SaveChanges();
                    }
                    catch (Microsoft.EntityFrameworkCore.DbUpdateException)
                    {
                        MessageBox.Show("This product supplier is currently assosciated with a booking. At this time you cannot remove it", "Database Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            /// <summary>
            /// Removes Suppliers
            /// </summary>
            /// <param name="suppliers">List of Suppliers to remove</param>
            static public void Suppliers(List<Supplier> suppliers)
            {
                using (Models.TravelExpertsContext context = new Models.TravelExpertsContext())
                {
                    foreach (var s in suppliers)
                    {
                        context.Suppliers.Remove(s);
                    }
                    try
                    {
                        context.SaveChanges();
                    }
                    catch (Microsoft.EntityFrameworkCore.DbUpdateException)
                    {
                        MessageBox.Show("This supplier is currently assosciated with a booking. At this time you cannot remove it", "Database Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            /// <summary>
            /// Removes Products
            /// </summary>
            /// <param name="id">Product id to remove</param>
            static public void Products(int id)
            {
                using (Models.TravelExpertsContext context = new Models.TravelExpertsContext())
                {
                    var product = context.Products.Where(p => p.ProductId == id).FirstOrDefault();
                    context.Products.Remove(product);
                    try
                    {
                        context.SaveChanges();
                    }
                    catch (Microsoft.EntityFrameworkCore.DbUpdateException)
                    {
                        MessageBox.Show("This product is currently assosciated with a booking. At this time you cannot remove it", "Database Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            /// <summary>
            /// Removes package product supplies
            /// </summary>
            /// <param name="packages">List of package product supplies to remove</param>
            static public void PackageProductSupply(TravelExpertsContext context, List<Package> packages)
            { 
                
                    foreach (var package in packages)
                    {
                        foreach (var ps in context.ProductsSuppliers)
                        {
                            if (package.ProductSuppliers.Any(x => x.ProductSupplierId == ps.ProductSupplierId))
                            {
                                package.ProductSuppliers.Remove(ps);
                            }
                        }
                    }
                    try
                    {
                        context.SaveChanges();
                    }
                    catch (Microsoft.EntityFrameworkCore.DbUpdateException)
                    {
                        MessageBox.Show("This package product supply is currently assosciated with a booking. At this time you cannot remove it", "Database Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                
                    
            }

            /// <summary>
            /// Removes suppliers contacts
            /// </summary>
            /// <param name="supplierContacts">List of supplier contacts to remove</param>
            static public void SupplierContacts(List<SupplierContact> supplierContacts)
            {
                using (Models.TravelExpertsContext context = new Models.TravelExpertsContext())
                {
                    foreach (var s in supplierContacts)
                    {
                        context.SupplierContacts.Remove(s);
                    }

                    context.SaveChanges();
                }
            }
        }
    }
}
