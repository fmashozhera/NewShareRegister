using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShareRegister.Data.Migrations
{
    /// <inheritdoc />
    public partial class updatedtableconfigurationstorenameCompanyTelephoneNumbers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BankTelephoneNumbers_BankAddresses_BankId",
                table: "BankTelephoneNumbers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BankAddresses",
                table: "BankAddresses");

            migrationBuilder.DropColumn(
                name: "Address_AddressId",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "Email_Id",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "Address_AddressId",
                table: "BankAddresses");

            migrationBuilder.RenameTable(
                name: "BankAddresses",
                newName: "Banks");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Banks",
                table: "Banks",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "CompanyTelephoneNumbers",
                columns: table => new
                {
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TelephoneNumberType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyTelephoneNumbers", x => new { x.CompanyId, x.Id });
                    table.ForeignKey(
                        name: "FK_CompanyTelephoneNumbers_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_BankTelephoneNumbers_Banks_BankId",
                table: "BankTelephoneNumbers",
                column: "BankId",
                principalTable: "Banks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BankTelephoneNumbers_Banks_BankId",
                table: "BankTelephoneNumbers");

            migrationBuilder.DropTable(
                name: "CompanyTelephoneNumbers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Banks",
                table: "Banks");

            migrationBuilder.RenameTable(
                name: "Banks",
                newName: "BankAddresses");

            migrationBuilder.AddColumn<Guid>(
                name: "Address_AddressId",
                table: "Companies",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "Email_Id",
                table: "Companies",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "Address_AddressId",
                table: "BankAddresses",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_BankAddresses",
                table: "BankAddresses",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BankTelephoneNumbers_BankAddresses_BankId",
                table: "BankTelephoneNumbers",
                column: "BankId",
                principalTable: "BankAddresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
