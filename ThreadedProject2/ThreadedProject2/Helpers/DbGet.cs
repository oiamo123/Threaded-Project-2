using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThreadedProject2.Models;

namespace ThreadedProject2.Helpers
{
    internal class DbGet
    {
        int supLastId = 0;
        int packProdLastId = 0;

        /// <summary>
        /// Get packages
        /// </summary>
        /// <param name="id">Optional id parameter to query by PackageId</param>
        /// <returns></returns>
        public List<Models.Package> GetPackages(int id = -1)
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
        public List<Product> GetProducts(int id = -1)
        {
            using (Models.TravelExpertsContext context = new TravelExpertsContext())
            {
                if (id == -1)
                {
                    var products = context.Products.Select(p => p);
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
        public List<Supplier> GetSuppliers(int id = -1)
        {
            using (Models.TravelExpertsContext context = new TravelExpertsContext())
            {
                if (id == -1)
                {
                    var suppliers = context.Suppliers.Select(p => p);
                    return suppliers.ToList();
                }
                else
                {
                    var suppliers = context.Suppliers.Where(p => p.SupplierId == id);
                    return suppliers.ToList();
                }
            } 
        }

        /// <summary>
        /// Get Product suppliers
        /// </summary>
        /// <param name="id">Optional id parameter to query by productid</param>
        /// <returns></returns>
        public List<ProductsSupplier> GetProductSuppliers(int id = -1)
        {
            using (Models.TravelExpertsContext context = new TravelExpertsContext())
            {
                if (id == -1)
                {
                    var prodSuppliers = context.ProductsSuppliers.Select(p => p);
                    return prodSuppliers.ToList();
                }
                else
                {
                    var prodSuppliers = context.ProductsSuppliers.Where(p => p.ProductSupplierId == id);
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
        public List<SupplierContact> GetSupplierContacts(int id, bool useLast = false)
        {
            using (Models.TravelExpertsContext context = new TravelExpertsContext())
            {
                if (!useLast) supLastId = id;
                return context.SupplierContacts.Where(p => p.SupplierId == (useLast ? supLastId : id)).ToList();
            }
        }

        /// <summary>
        /// Get package product suppliers
        /// </summary>
        /// <param name="lstData">Listbox lstdata to get Package ID</param>
        /// <param name="useLast">To show all Package product supplies, false, else to reference only previous package, true. references the id of the previous menu selection</param>
        /// <returns></returns>
        public List<ProductsSupplier> GetPackageProductSupplies(ListBox lstData, bool useLast = false)
        {
            using (Models.TravelExpertsContext context = new TravelExpertsContext())
            {
                if (!useLast)
                {
                    int packId = Id.GetId(lstData);
                    packProdLastId = packId;
                }
                var package = context.Packages
                                 .Include(p => p.ProductSuppliers)
                                 .SingleOrDefault(p => p.PackageId == (useLast ? packProdLastId : Id.GetId(lstData)));

                return package.ProductSuppliers.ToList();
            }
                
        }
    }
}
