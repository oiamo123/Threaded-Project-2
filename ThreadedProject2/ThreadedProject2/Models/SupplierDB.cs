using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadedProject2.Models
{
    internal class SupplierDB
    {
        /// <summary>
        /// Get Suppliers
        /// </summary>
        /// <returns></returns>
        public static List<Supplier> GetSuppliers()
        {
            using (TravelExpertsContext db = new TravelExpertsContext())
            {
                try
                {
                    return db.Suppliers.OrderBy(s => s.SupName).ToList();
                }
                catch (SqlException)
                {
                    return new List<Supplier>();
                }
            }
        }

        /// <summary>
        /// Get Supplier
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Supplier? GetSupplier(int id)
        {
            using (TravelExpertsContext db = new TravelExpertsContext())
            {
                return db.Suppliers.Find(id);
            }
        }

        /// <summary>
        /// adds a new record to the Supplier table
        /// </summary>
        /// <param name="supplier">supplier data to add</param>
        public static void AddSupplier(Supplier supplier)
        {
            using (TravelExpertsContext db = new TravelExpertsContext())
            {
                if (supplier != null)
                {
                    db.Suppliers.Add(supplier);
                    db.SaveChanges();
                }
            }
        }

        /// <summary>
        /// Remove Supplier
        /// </summary>
        /// <param name="id"></param>
        public static void RemoveSupplier(int id)
        {
            using (TravelExpertsContext db = new TravelExpertsContext())
            {
                Supplier? supplier = db.Suppliers.Find(id);
                if (supplier != null)
                {
                    db.Suppliers.Remove(supplier);
                    db.SaveChanges();
                }
            }
        }

        /// <summary>
        /// Modify Supplier
        /// </summary>
        /// <param name="id"></param>
        /// <param name="newSupplier"></param>
        public static void ModifySupplier(int id, Supplier newSupplier)
        {
            using (TravelExpertsContext db = new TravelExpertsContext())
            {
                Supplier? supplier = db.Suppliers.Find(id);
                if (supplier != null)
                {
                    supplier.SupplierId = newSupplier.SupplierId;
                    supplier.SupName = newSupplier.SupName;
                    db.SaveChanges();
                }

            }
        }
    }
}
