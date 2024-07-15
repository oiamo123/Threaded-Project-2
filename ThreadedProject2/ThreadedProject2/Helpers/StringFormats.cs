using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThreadedProject2.Models;

namespace ThreadedProject2
{
    internal class StringFormats
    {
        static public string FormatProductsSupplier(ProductsSupplier p)
        {
            return $"{p.SupplierId.ToString().PadRight(8)}" +
                $"{p.ProductId.ToString().PadRight(12)}" +
                $"{p.ProductSupplierId.ToString().PadRight(6)}";
        }
        static public string FormatProducts(Product p)
        {
            return $"{p.ProductId.ToString().PadRight(6)}{p.ProdName}";
        }
        static public string FormatSuppliers(Supplier p)
        {
            return $"{p.SupplierId.ToString().PadRight(6)}" +
                $"{char.ToUpper(p.SupName[0]) + p.SupName.Substring(1).ToLower()}";
        }
        static public string FormatPackages(Package p)
        {
            return $"{p.PackageId.ToString().PadRight(6)}{p.PkgName.PadRight(22)}{p.PkgStartDate.ToString("dd/MM/yyyy").PadRight(12)}" +
                    $"{p.PkgEndDate.ToString("dd/MM/yyyy").PadRight(12)}{p.PkgDesc.PadRight(48)}" +
                    $"{Math.Round(p.PkgBasePrice, 2).ToString("c").PadRight(12)}" +
                    $"{Math.Round(p.PkgAgencyCommission, 2).ToString("c")}";
        }
        static public string FormatSupplierContacts(SupplierContact i)
        {   
            
            return $"{i.SupplierContactId.ToString().PadRight(6)}" +
                $"{(i.SupConFirstName ??= "Unavailable").PadRight(15)}" +
                $"{(i.SupConLastName ??= "Unavailable").PadRight(15)}" +
                $"{(i.SupConEmail ??= "Unavailable").PadRight(33)}" +
                $"{(i.SupConFax ??= "Unavailable").PadRight(12)}" +
                $"{($"{i.SupConAddress ??= ""} {i.SupConPostal ??= ""} {i.SupConCity ??= ""}").PadRight(50)}";
        }
        
    }
}
