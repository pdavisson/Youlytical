using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CRM.migrations.CRMdb
{
    public partial class BuildContactsv1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "crmContacts",
                columns: table => new
                {
                    ContactID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    Prefix = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Suffix = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    SpouseFirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SpouseLastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastUpdate_DateTimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_crmContacts", x => x.ContactID);
                });

            migrationBuilder.CreateTable(
                name: "crmAddresses",
                columns: table => new
                {
                    pID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContactID = table.Column<int>(type: "int", nullable: false),
                    PhoneType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Primary = table.Column<bool>(type: "bit", nullable: false),
                    CreateDateTimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_crmAddresses", x => x.pID);
                    table.ForeignKey(
                        name: "FK_crmAddresses_crmContacts_ContactID",
                        column: x => x.ContactID,
                        principalTable: "crmContacts",
                        principalColumn: "ContactID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "crmEmails",
                columns: table => new
                {
                    eID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContactID = table.Column<int>(type: "int", nullable: false),
                    EmailType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Primary = table.Column<bool>(type: "bit", nullable: false),
                    CreateDateTimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_crmEmails", x => x.eID);
                    table.ForeignKey(
                        name: "FK_crmEmails_crmContacts_ContactID",
                        column: x => x.ContactID,
                        principalTable: "crmContacts",
                        principalColumn: "ContactID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "crmPhoneNumbers",
                columns: table => new
                {
                    aID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContactID = table.Column<int>(type: "int", nullable: false),
                    AddressType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Address1 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Address2 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    State = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Zip = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Country = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Province = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Primary = table.Column<bool>(type: "bit", nullable: false),
                    CreateDateTimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_crmPhoneNumbers", x => x.aID);
                    table.ForeignKey(
                        name: "FK_crmPhoneNumbers_crmContacts_ContactID",
                        column: x => x.ContactID,
                        principalTable: "crmContacts",
                        principalColumn: "ContactID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_crmAddresses_ContactID",
                table: "crmAddresses",
                column: "ContactID");

            migrationBuilder.CreateIndex(
                name: "IX_crmEmails_ContactID",
                table: "crmEmails",
                column: "ContactID");

            migrationBuilder.CreateIndex(
                name: "IX_crmPhoneNumbers_ContactID",
                table: "crmPhoneNumbers",
                column: "ContactID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "crmAddresses");

            migrationBuilder.DropTable(
                name: "crmEmails");

            migrationBuilder.DropTable(
                name: "crmPhoneNumbers");

            migrationBuilder.DropTable(
                name: "crmContacts");
        }
    }
}
