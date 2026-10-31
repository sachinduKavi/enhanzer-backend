using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Location_Details",
                columns: table => new
                {
                    Location_Code = table.Column<string>(type: "varchar(20)", nullable: false),
                    Location_Name = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Stock_Handle = table.Column<int>(type: "int", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "varchar(15)", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location_Details", x => x.Location_Code);
                });

            migrationBuilder.CreateTable(
                name: "Purchase_Bill",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created_At = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Created_By = table.Column<string>(type: "varchar(100)", nullable: false),
                    Total_Items = table.Column<int>(type: "int", nullable: false),
                    Total_Qty = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchase_Bill", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Purchase_Bill_Item",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Purchase_Bill_Id = table.Column<int>(type: "int", nullable: false),
                    Item_Name = table.Column<string>(type: "varchar(50)", nullable: false),
                    Batch_Code = table.Column<string>(type: "varchar(20)", nullable: false),
                    Standard_Cost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Standard_Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Margin = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Qty = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Free_Qty = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    Total_Cost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Total_Selling = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchase_Bill_Item", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Purchase_Bill_Item_Location_Details_Batch_Code",
                        column: x => x.Batch_Code,
                        principalTable: "Location_Details",
                        principalColumn: "Location_Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Purchase_Bill_Item_Purchase_Bill_Purchase_Bill_Id",
                        column: x => x.Purchase_Bill_Id,
                        principalTable: "Purchase_Bill",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Purchase_Bill_Item_Batch_Code",
                table: "Purchase_Bill_Item",
                column: "Batch_Code");

            migrationBuilder.CreateIndex(
                name: "IX_Purchase_Bill_Item_Purchase_Bill_Id",
                table: "Purchase_Bill_Item",
                column: "Purchase_Bill_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Purchase_Bill_Item");

            migrationBuilder.DropTable(
                name: "Location_Details");

            migrationBuilder.DropTable(
                name: "Purchase_Bill");
        }
    }
}
