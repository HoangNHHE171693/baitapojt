using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BaiTapOceanTech.Migrations
{
    /// <inheritdoc />
    public partial class FixStatusCer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "EmployeeCertificates",
                type: "int",
                maxLength: 100,
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "EmployeeCertificates");
        }
    }
}
