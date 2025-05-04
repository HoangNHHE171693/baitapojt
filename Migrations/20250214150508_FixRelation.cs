using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BaiTapOceanTech.Migrations
{
    /// <inheritdoc />
    public partial class FixRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Certificate_Employees_EmployeeId",
                table: "Certificate");

            migrationBuilder.DropIndex(
                name: "IX_Certificate_EmployeeId",
                table: "Certificate");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "Certificate");

            migrationBuilder.DropColumn(
                name: "ExpiredDate",
                table: "Certificate");

            migrationBuilder.DropColumn(
                name: "IssueDate",
                table: "Certificate");

            migrationBuilder.AddColumn<int>(
                name: "ActiveCertificateCount",
                table: "Employees",
                type: "int",
                maxLength: 10,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TotalCertificateCount",
                table: "Employees",
                type: "int",
                maxLength: 10,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "EmployeeCertificates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IssueDate = table.Column<DateTime>(type: "datetime(6)", maxLength: 100, nullable: false),
                    ExpiredDate = table.Column<DateTime>(type: "datetime(6)", maxLength: 100, nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    CertificateId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeCertificates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeCertificates_Certificate_CertificateId",
                        column: x => x.CertificateId,
                        principalTable: "Certificate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeCertificates_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeCertificates_CertificateId",
                table: "EmployeeCertificates",
                column: "CertificateId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeCertificates_EmployeeId",
                table: "EmployeeCertificates",
                column: "EmployeeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeCertificates");

            migrationBuilder.DropColumn(
                name: "ActiveCertificateCount",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "TotalCertificateCount",
                table: "Employees");

            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "Certificate",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "ExpiredDate",
                table: "Certificate",
                type: "datetime(6)",
                maxLength: 100,
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "IssueDate",
                table: "Certificate",
                type: "datetime(6)",
                maxLength: 100,
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_Certificate_EmployeeId",
                table: "Certificate",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Certificate_Employees_EmployeeId",
                table: "Certificate",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
