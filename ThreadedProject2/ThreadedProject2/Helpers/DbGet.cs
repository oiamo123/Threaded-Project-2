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
                    var prodSuppliers = context.ProductsSuppliers.Where(p => p.ProductId == id);
                    return prodSuppliers.ToList();
                }
            }    
        }

        public List<SupplierContact> GetSupplierContacts(ListBox lstData, bool useLast = false)
        {
            using (Models.TravelExpertsContext context = new TravelExpertsContext())
            {
                int supId = Id.GetId(lstData);
                if (!useLast) supLastId = supId;
                return context.SupplierContacts.Where(p => p.SupplierId == (useLast ? supLastId : supId)).ToList();
            }
        }

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
