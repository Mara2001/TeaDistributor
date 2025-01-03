using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TeaDistributor.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TeaCustomers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeaCustomers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TeaInvoices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeaInvoices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TeaRegions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    District = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Characteristics = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeaRegions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TeaSuppliers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeaSuppliers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TeaTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeaTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TeaOrders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: true),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvoiceId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeaOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeaOrders_TeaCustomers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "TeaCustomers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TeaOrders_TeaInvoices_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "TeaInvoices",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TeaItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeId = table.Column<int>(type: "int", nullable: false),
                    RegionId = table.Column<int>(type: "int", nullable: false),
                    Quality = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SupplierId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SteepingTime = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeaItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeaItems_TeaRegions_RegionId",
                        column: x => x.RegionId,
                        principalTable: "TeaRegions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeaItems_TeaSuppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "TeaSuppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeaItems_TeaTypes_TypeId",
                        column: x => x.TypeId,
                        principalTable: "TeaTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeaBatches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeaId = table.Column<int>(type: "int", nullable: true),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    DiscountedPrice = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeaBatches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeaBatches_TeaItems_TeaId",
                        column: x => x.TeaId,
                        principalTable: "TeaItems",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TeaOrderDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: true),
                    BatchId = table.Column<int>(type: "int", nullable: true),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeaOrderDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeaOrderDetails_TeaBatches_BatchId",
                        column: x => x.BatchId,
                        principalTable: "TeaBatches",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TeaOrderDetails_TeaOrders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "TeaOrders",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TeaBatches_TeaId",
                table: "TeaBatches",
                column: "TeaId");

            migrationBuilder.CreateIndex(
                name: "IX_TeaItems_RegionId",
                table: "TeaItems",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_TeaItems_SupplierId",
                table: "TeaItems",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_TeaItems_TypeId",
                table: "TeaItems",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TeaOrderDetails_BatchId",
                table: "TeaOrderDetails",
                column: "BatchId");

            migrationBuilder.CreateIndex(
                name: "IX_TeaOrderDetails_OrderId",
                table: "TeaOrderDetails",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_TeaOrders_CustomerId",
                table: "TeaOrders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_TeaOrders_InvoiceId",
                table: "TeaOrders",
                column: "InvoiceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TeaOrderDetails");

            migrationBuilder.DropTable(
                name: "TeaBatches");

            migrationBuilder.DropTable(
                name: "TeaOrders");

            migrationBuilder.DropTable(
                name: "TeaItems");

            migrationBuilder.DropTable(
                name: "TeaCustomers");

            migrationBuilder.DropTable(
                name: "TeaInvoices");

            migrationBuilder.DropTable(
                name: "TeaRegions");

            migrationBuilder.DropTable(
                name: "TeaSuppliers");

            migrationBuilder.DropTable(
                name: "TeaTypes");
        }
    }
}
