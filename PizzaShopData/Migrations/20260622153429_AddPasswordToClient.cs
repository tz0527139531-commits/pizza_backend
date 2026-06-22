using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaShopData.Migrations
{
    /// <inheritdoc />
    public partial class AddPasswordToClient : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "TotalPrice",
                table: "orders",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "clients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalPrice",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "clients");
        }
    }
}
