using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThreadedProject2.Models;
using ThreadedProject2.Helpers;

// Author: Gavin

namespace ThreadedProject2
{
    internal class StringFormats
    {
        /// <summary>
        /// Returns string for Products Suppliers
        /// </summary>
        /// <param name="p">ProductSupplier to create the string from</param>
        /// <returns></returns>
        static public string FormatProductsSupplier(ProductsSupplier p)
        {
            var product = DB.Get.Products(p.ProductId).FirstOrDefault();
            var supplier = DB.Get.Suppliers(p.SupplierId).FirstOrDefault();

            return $"{p.ProductSupplierId.ToString().PadRight(6)}" + 
                $"{product.ProdName.PadRight(21)}" +
                $"{char.ToUpper(supplier.SupName[0]) + supplier.SupName.Substring(1).ToLower()}";
        }

        /// <summary>
        /// Returns string for Products
        /// </summary>
        /// <param name="p">Product to create the string from</param>
        /// <returns></returns>
        static public string FormatProducts(Product p)
        {
            return $"{p.ProductId.ToString().PadRight(6)}{p.ProdName}";
        }

        /// <summary>
        /// Returns string for Suppliers
        /// </summary>
        /// <param name="p">Supplier to create the string from</param>
        /// <returns></returns>
        static public string FormatSuppliers(Supplier p)
        {
            return $"{p.SupplierId.ToString().PadRight(6)}" +
                $"{char.ToUpper(p.SupName[0]) + p.SupName.Substring(1).ToLower()}";
        }

        /// <summary>
        /// Returns string for Packages
        /// </summary>
        /// <param name="p">Package to create the string from</param>
        /// <returns></returns>
        static public string FormatPackages(Package p)
        {
            return $"{p.PackageId.ToString().PadRight(6)}{p.PkgName.PadRight(22)}{p.PkgStartDate.ToString("dd/MM/yyyy").PadRight(12)}" +
                    $"{p.PkgEndDate.ToString("dd/MM/yyyy").PadRight(12)}{p.PkgDesc.PadRight(48)}" +
                    $"{Math.Round(p.PkgBasePrice, 2).ToString("c").PadRight(12)}" +
                    $"{Math.Round(p.PkgAgencyCommission, 2).ToString("c")}";
        }

        /// <summary>
        /// Returns string for Supplier Contacts
        /// </summary>
        /// <param name="i">SupplierContact to create the string from</param>
        /// <returns></returns>
        static public string FormatSupplierContacts(SupplierContact i)
        {
            return $"{i.SupplierContactId.ToString().PadRight(6)}" +
                $"{(i.SupConFirstName ??= "Unavailable").PadRight(15)}" +
                $"{(i.SupConLastName ??= "Unavailable").PadRight(15)}" +
                $"{(i.SupConEmail ??= "Unavailable").PadRight(33)}" +
                $"{(i.SupConFax ??= "Unavailable").PadRight(12)}" +
                $"{($"{i.SupConAddress ??= ""} {i.SupConPostal ??= ""} {i.SupConCity ??= ""}").PadRight(50)}";
        }

        /// <summary>
        /// Format String To Uppercase First Letter
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        static public string FormatString(string str)
        {
            string str2 = "";

            foreach (var word in str.Split(" "))
            {
                str2 += $@" {Char.ToUpper(word[0]) + word.Substring(1).ToLower()}";
            }

            return str2.Trim();
        }

        /// <summary>
        /// Format phone to correct format
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        static public string FormatPhone(string str)
        {
            string numbers = "";

            foreach (char c in str.ToCharArray())
            {
                if (Char.IsDigit(c)) numbers += c;
            }

            return numbers.Trim();
        }
    }
}
