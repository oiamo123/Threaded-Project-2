using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ThreadedProject2.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PackageProductsSupplier",
                columns: table => new
                {
                    PackageId = table.Column<int>(type: "int", nullable: false),
                    ProductSupplierId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PackageProductsSupplier", x => new { x.PackageId, x.ProductSupplierId });
                });

            migrationBuilder.CreateTable(
                name: "Packages",
                columns: table => new
                {
                    PackageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PkgName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PkgStartDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    PkgEndDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    PkgDesc = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PkgBasePrice = table.Column<decimal>(type: "money", nullable: false),
                    PkgAgencyCommission = table.Column<decimal>(type: "money", nullable: false, defaultValue: 0m)
                },
                constraints: table =>
                {
                    table.PrimaryKey("aaaaaPackages_PK", x => x.PackageId)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProdName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("aaaaaProducts_PK", x => x.ProductId)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    SupplierId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SupName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("aaaaaSuppliers_PK", x => x.SupplierId)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "Products_Suppliers",
                columns: table => new
                {
                    ProductSupplierId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: true, defaultValue: 0),
                    SupplierId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("aaaaaProducts_Suppliers_PK", x => x.ProductSupplierId)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "Products_Suppliers_FK00",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId");
                    table.ForeignKey(
                        name: "Products_Suppliers_FK01",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "SupplierId");
                });

            migrationBuilder.CreateTable(
                name: "SupplierContacts",
                columns: table => new
                {
                    SupplierContactId = table.Column<int>(type: "int", nullable: false),
                    SupConFirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SupConLastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SupConCompany = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    SupConAddress = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    SupConCity = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    SupConProv = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    SupConPostal = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    SupConCountry = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    SupConBusPhone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SupConFax = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SupConEmail = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    SupConURL = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    AffiliationId = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    SupplierId = table.Column<int>(type: "int", nullable: true, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("aaaaaSupplierContacts_PK", x => x.SupplierContactId)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "SupplierContacts_FK01",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "SupplierId");
                });

            migrationBuilder.CreateTable(
                name: "Packages_Products_Suppliers",
                columns: table => new
                {
                    PackageId = table.Column<int>(type: "int", nullable: false),
                    ProductSupplierId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("aaaaaPackages_Products_Suppliers_PK", x => new { x.PackageId, x.ProductSupplierId })
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "Packages_Products_Supplie_FK00",
                        column: x => x.PackageId,
                        principalTable: "Packages",
                        principalColumn: "PackageId");
                    table.ForeignKey(
                        name: "Packages_Products_Supplie_FK01",
                        column: x => x.ProductSupplierId,
                        principalTable: "Products_Suppliers",
                        principalColumn: "ProductSupplierId");
                });

            migrationBuilder.CreateIndex(
                name: "PackagesPackages_Products_Suppliers",
                table: "Packages_Products_Suppliers",
                column: "PackageId");

            migrationBuilder.CreateIndex(
                name: "Products_SuppliersPackages_Products_Suppliers",
                table: "Packages_Products_Suppliers",
                column: "ProductSupplierId");

            migrationBuilder.CreateIndex(
                name: "ProductSupplierId",
                table: "Packages_Products_Suppliers",
                column: "ProductSupplierId");

            migrationBuilder.CreateIndex(
                name: "ProductId",
                table: "Products",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "Product Supplier ID",
                table: "Products_Suppliers",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "ProductId",
                table: "Products_Suppliers",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "ProductsProducts_Suppliers1",
                table: "Products_Suppliers",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "ProductSupplierId",
                table: "Products_Suppliers",
                column: "ProductSupplierId");

            migrationBuilder.CreateIndex(
                name: "SuppliersProducts_Suppliers1",
                table: "Products_Suppliers",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "AffiliationsSupCon",
                table: "SupplierContacts",
                column: "AffiliationId");

            migrationBuilder.CreateIndex(
                name: "SuppliersSupCon",
                table: "SupplierContacts",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "SupplierId",
                table: "Suppliers",
                column: "SupplierId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PackageProductsSupplier");

            migrationBuilder.DropTable(
                name: "Packages_Products_Suppliers");

            migrationBuilder.DropTable(
                name: "SupplierContacts");

            migrationBuilder.DropTable(
                name: "Packages");

            migrationBuilder.DropTable(
                name: "Products_Suppliers");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Suppliers");
        }
    }
}
