using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domain.Migrations
{
    public partial class NewBase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders_Status",
                columns: table => new
                {
                    Id_status = table.Column<int>(type: "int", nullable: false),
                    Orders_status = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Is_deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Orders_S__9D83DA2AEC11BCD2", x => x.Id_status);
                });

            migrationBuilder.CreateTable(
                name: "Specifications",
                columns: table => new
                {
                    Id_specification = table.Column<int>(type: "int", nullable: false),
                    Name_spec = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Spec_value = table.Column<int>(type: "int", nullable: false),
                    Is_deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Specific__E5171905E05BAD1A", x => x.Id_specification);
                });

            migrationBuilder.CreateTable(
                name: "Users_roles",
                columns: table => new
                {
                    Id_role = table.Column<int>(type: "int", nullable: false),
                    Name_role = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Is_deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Users_ro__46CA8DBE9D0570E7", x => x.Id_role);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id_category = table.Column<int>(type: "int", nullable: false),
                    Name_category = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Id_specification = table.Column<int>(type: "int", nullable: false),
                    Is_deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Categori__4E840CE5168E0E5D", x => x.Id_category);
                    table.ForeignKey(
                        name: "FK_Categories_Specifications",
                        column: x => x.Id_specification,
                        principalTable: "Specifications",
                        principalColumn: "Id_specification");
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id_user = table.Column<int>(type: "int", nullable: false),
                    User_Login = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    User_password = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Reg_date = table.Column<DateTime>(type: "date", nullable: false),
                    Is_deleted = table.Column<bool>(type: "bit", nullable: false),
                    Id_role = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Users__B607F2489A4FBC29", x => x.Id_user);
                    table.ForeignKey(
                        name: "FK_Users_Users_roles",
                        column: x => x.Id_role,
                        principalTable: "Users_roles",
                        principalColumn: "Id_role");
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id_prod = table.Column<int>(type: "int", nullable: false),
                    Prod_count = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,10)", nullable: true),
                    Prod_description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Id_category = table.Column<int>(type: "int", nullable: false),
                    Is_deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Products__5FFE1E8EB1E2286E", x => x.Id_prod);
                    table.ForeignKey(
                        name: "FK_Products_Categories",
                        column: x => x.Id_category,
                        principalTable: "Categories",
                        principalColumn: "Id_category");
                });

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    Id_cart = table.Column<int>(type: "int", nullable: false),
                    Id_user = table.Column<int>(type: "int", nullable: false),
                    Id_prod = table.Column<int>(type: "int", nullable: false),
                    Prod_count = table.Column<int>(type: "int", nullable: false),
                    Is_deleted = table.Column<bool>(type: "bit", nullable: false),
                    Cart_date = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Carts__54938089EEA7A415", x => x.Id_cart);
                    table.ForeignKey(
                        name: "FK_Carts_Products",
                        column: x => x.Id_prod,
                        principalTable: "Products",
                        principalColumn: "Id_prod");
                    table.ForeignKey(
                        name: "FK_Carts_Users",
                        column: x => x.Id_user,
                        principalTable: "Users",
                        principalColumn: "Id_user");
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id_order = table.Column<int>(type: "int", nullable: false),
                    Id_user = table.Column<int>(type: "int", nullable: false),
                    Id_prod = table.Column<int>(type: "int", nullable: false),
                    Id_status = table.Column<int>(type: "int", nullable: false),
                    Order_date = table.Column<DateTime>(type: "date", nullable: false),
                    Prod_count = table.Column<int>(type: "int", nullable: false),
                    Is_deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Orders__33F95B5C9CD2C543", x => x.Id_order);
                    table.ForeignKey(
                        name: "FK_Orders_Orders_Status",
                        column: x => x.Id_status,
                        principalTable: "Orders_Status",
                        principalColumn: "Id_status");
                    table.ForeignKey(
                        name: "FK_Orders_Products",
                        column: x => x.Id_prod,
                        principalTable: "Products",
                        principalColumn: "Id_prod");
                    table.ForeignKey(
                        name: "FK_Orders_Users",
                        column: x => x.Id_user,
                        principalTable: "Users",
                        principalColumn: "Id_user");
                });

            migrationBuilder.CreateTable(
                name: "Spec_products",
                columns: table => new
                {
                    Id_spec_product = table.Column<int>(type: "int", nullable: false),
                    Id_prod = table.Column<int>(type: "int", nullable: false),
                    Id_specification = table.Column<int>(type: "int", nullable: false),
                    Spec_value = table.Column<int>(type: "int", nullable: false),
                    Is_deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Spec_pro__8EE4795589FE2179", x => x.Id_spec_product);
                    table.ForeignKey(
                        name: "FK_Spec_products_Products",
                        column: x => x.Id_prod,
                        principalTable: "Products",
                        principalColumn: "Id_prod");
                    table.ForeignKey(
                        name: "FK_Spec_products_Specifications",
                        column: x => x.Id_specification,
                        principalTable: "Specifications",
                        principalColumn: "Id_specification");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Carts_Id_prod",
                table: "Carts",
                column: "Id_prod");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_Id_user",
                table: "Carts",
                column: "Id_user");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_Id_specification",
                table: "Categories",
                column: "Id_specification");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_Id_prod",
                table: "Orders",
                column: "Id_prod");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_Id_status",
                table: "Orders",
                column: "Id_status");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_Id_user",
                table: "Orders",
                column: "Id_user");

            migrationBuilder.CreateIndex(
                name: "IX_Products_Id_category",
                table: "Products",
                column: "Id_category");

            migrationBuilder.CreateIndex(
                name: "IX_Spec_products_Id_prod",
                table: "Spec_products",
                column: "Id_prod");

            migrationBuilder.CreateIndex(
                name: "IX_Spec_products_Id_specification",
                table: "Spec_products",
                column: "Id_specification");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Id_role",
                table: "Users",
                column: "Id_role");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Spec_products");

            migrationBuilder.DropTable(
                name: "Orders_Status");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Users_roles");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Specifications");
        }
    }
}
