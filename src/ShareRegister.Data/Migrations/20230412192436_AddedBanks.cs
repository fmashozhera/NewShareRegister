using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShareRegister.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedBanks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Companies_Address_AddressId",
                table: "Companies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Address",
                table: "Address");

            migrationBuilder.RenameTable(
                name: "Address",
                newName: "Addresses");

            migrationBuilder.AddColumn<Guid>(
                name: "BankId",
                table: "TelephoneNumber",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Addresses",
                table: "Addresses",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Banks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BankCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Banks_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TelephoneNumber_BankId",
                table: "TelephoneNumber",
                column: "BankId");

            migrationBuilder.CreateIndex(
                name: "IX_Banks_AddressId",
                table: "Banks",
                column: "AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_Addresses_AddressId",
                table: "Companies",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TelephoneNumber_Banks_BankId",
                table: "TelephoneNumber",
                column: "BankId",
                principalTable: "Banks",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Companies_Addresses_AddressId",
                table: "Companies");

            migrationBuilder.DropForeignKey(
                name: "FK_TelephoneNumber_Banks_BankId",
                table: "TelephoneNumber");

            migrationBuilder.DropTable(
                name: "Banks");

            migrationBuilder.DropIndex(
                name: "IX_TelephoneNumber_BankId",
                table: "TelephoneNumber");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Addresses",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "BankId",
                table: "TelephoneNumber");

            migrationBuilder.RenameTable(
                name: "Addresses",
                newName: "Address");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Address",
                table: "Address",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_Address_AddressId",
                table: "Companies",
                column: "AddressId",
                principalTable: "Address",
                principalColumn: "Id");
        }
    }
}
