using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShareRegister.Data.Migrations
{
    /// <inheritdoc />
    public partial class updatedtableconfigurations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompanyTelephoneNumbers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CompanyEmails",
                table: "CompanyEmails");

            migrationBuilder.RenameTable(
                name: "CompanyEmails",
                newName: "Companies");

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

            migrationBuilder.CreateTable(
                name: "Companies_TelephoneNumbers",
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
                    table.PrimaryKey("PK_Companies_TelephoneNumbers", x => new { x.CompanyId, x.Id });
                    table.ForeignKey(
                        name: "FK_Companies_TelephoneNumbers_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Companies_TelephoneNumbers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Companies",
                table: "Companies");

            migrationBuilder.RenameTable(
                name: "Companies",
                newName: "CompanyEmails");

            migrationBuilder.RenameIndex(
                name: "IX_Companies_Name",
                table: "CompanyEmails",
                newName: "IX_CompanyEmails_Name");

            migrationBuilder.RenameIndex(
                name: "IX_Companies_CompanyCode",
                table: "CompanyEmails",
                newName: "IX_CompanyEmails_CompanyCode");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CompanyEmails",
                table: "CompanyEmails",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "CompanyTelephoneNumbers",
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
                    table.PrimaryKey("PK_CompanyTelephoneNumbers", x => new { x.CompanyId, x.Id });
                    table.ForeignKey(
                        name: "FK_CompanyTelephoneNumbers_CompanyEmails_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "CompanyEmails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }
    }
}
