using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShareRegister.Data.Migrations
{
    /// <inheritdoc />
    public partial class updatedcompanymapping : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Address_Surburb",
                table: "Companies",
                newName: "Surburb");

            migrationBuilder.RenameColumn(
                name: "Address_Street",
                table: "Companies",
                newName: "Street");

            migrationBuilder.RenameColumn(
                name: "Address_PostalCode",
                table: "Companies",
                newName: "PostalCode");

            migrationBuilder.RenameColumn(
                name: "Address_Country",
                table: "Companies",
                newName: "Country");

            migrationBuilder.RenameColumn(
                name: "Address_City",
                table: "Companies",
                newName: "City");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Surburb",
                table: "Companies",
                newName: "Address_Surburb");

            migrationBuilder.RenameColumn(
                name: "Street",
                table: "Companies",
                newName: "Address_Street");

            migrationBuilder.RenameColumn(
                name: "PostalCode",
                table: "Companies",
                newName: "Address_PostalCode");

            migrationBuilder.RenameColumn(
                name: "Country",
                table: "Companies",
                newName: "Address_Country");

            migrationBuilder.RenameColumn(
                name: "City",
                table: "Companies",
                newName: "Address_City");
        }
    }
}
