using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShareRegister.Data.Migrations
{
    /// <inheritdoc />
    public partial class Updatedcompanyownedentitytablenames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Banks_TelephoneNumbers");

            migrationBuilder.DropTable(
                name: "Companies_TelephoneNumbers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Companies",
                table: "Companies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Banks",
                table: "Banks");

            migrationBuilder.RenameTable(
                name: "Companies",
                newName: "CompanyEmails");

            migrationBuilder.RenameTable(
                name: "Banks",
                newName: "BankAddresses");

            migrationBuilder.RenameIndex(
                name: "IX_Companies_Name",
                table: "CompanyEmails",
                newName: "IX_CompanyEmails_Name");

            migrationBuilder.RenameIndex(
                name: "IX_Companies_CompanyCode",
                table: "CompanyEmails",
                newName: "IX_CompanyEmails_CompanyCode");

            migrationBuilder.AddColumn<Guid>(
                name: "Address_AddressId",
                table: "CompanyEmails",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "Email_Id",
                table: "CompanyEmails",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "Address_AddressId",
                table: "BankAddresses",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CompanyEmails",
                table: "CompanyEmails",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BankAddresses",
                table: "BankAddresses",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "BankTelephoneNumbers",
                columns: table => new
                {
                    BankId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TelephoneNumberType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankTelephoneNumbers", x => new { x.BankId, x.Id });
                    table.ForeignKey(
                        name: "FK_BankTelephoneNumbers_BankAddresses_BankId",
                        column: x => x.BankId,
                        principalTable: "BankAddresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                        name: "FK_CompanyTelephoneNumbers_CompanyEmails_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "CompanyEmails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BankTelephoneNumbers");

            migrationBuilder.DropTable(
                name: "CompanyTelephoneNumbers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CompanyEmails",
                table: "CompanyEmails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BankAddresses",
                table: "BankAddresses");

            migrationBuilder.DropColumn(
                name: "Address_AddressId",
                table: "CompanyEmails");

            migrationBuilder.DropColumn(
                name: "Email_Id",
                table: "CompanyEmails");

            migrationBuilder.DropColumn(
                name: "Address_AddressId",
                table: "BankAddresses");

            migrationBuilder.RenameTable(
                name: "CompanyEmails",
                newName: "Companies");

            migrationBuilder.RenameTable(
                name: "BankAddresses",
                newName: "Banks");

            migrationBuilder.RenameIndex(
                name: "IX_CompanyEmails_Name",
                table: "Companies",
                newName: "IX_Companies_Name");

            migrationBuilder.RenameIndex(
                name: "IX_CompanyEmails_CompanyCode",
                table: "Companies",
                newName: "IX_Companies_CompanyCode");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Companies",
                table: "Companies",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Banks",
                table: "Banks",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Banks_TelephoneNumbers",
                columns: table => new
                {
                    BankId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TelephoneNumberType = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banks_TelephoneNumbers", x => new { x.BankId, x.Id });
                    table.ForeignKey(
                        name: "FK_Banks_TelephoneNumbers_Banks_BankId",
                        column: x => x.BankId,
                        principalTable: "Banks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Companies_TelephoneNumbers",
                columns: table => new
                {
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TelephoneNumberType = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies_TelephoneNumbers", x => new { x.CompanyId, x.Id });
                    table.ForeignKey(
                        name: "FK_Companies_TelephoneNumbers_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }
    }
}
