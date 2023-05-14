using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShareRegister.Data.Migrations
{
    /// <inheritdoc />
    public partial class updatedbanksmapping : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Address_Surburb",
                table: "Banks",
                newName: "Surburb");

            migrationBuilder.RenameColumn(
                name: "Address_Street",
                table: "Banks",
                newName: "Street");

            migrationBuilder.RenameColumn(
                name: "Address_PostalCode",
                table: "Banks",
                newName: "PostalCode");

            migrationBuilder.RenameColumn(
                name: "Address_Country",
                table: "Banks",
                newName: "Country");

            migrationBuilder.RenameColumn(
                name: "Address_City",
                table: "Banks",
                newName: "City");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Surburb",
                table: "Banks",
                newName: "Address_Surburb");

            migrationBuilder.RenameColumn(
                name: "Street",
                table: "Banks",
                newName: "Address_Street");

            migrationBuilder.RenameColumn(
                name: "PostalCode",
                table: "Banks",
                newName: "Address_PostalCode");

            migrationBuilder.RenameColumn(
                name: "Country",
                table: "Banks",
                newName: "Address_Country");

            migrationBuilder.RenameColumn(
                name: "City",
                table: "Banks",
                newName: "Address_City");
        }
    }
}
