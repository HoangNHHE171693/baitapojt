using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hoangnhhe171693.Migrations
{
    /// <inheritdoc />
    public partial class Database : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Tinh",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Status = table.Column<int>(type: "int", maxLength: 100, nullable: false),
                    PostalCode = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedDate = table.Column<DateTime>(type: "datetime(6)", maxLength: 100, nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime(6)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tinh", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Huyen",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Status = table.Column<int>(type: "int", maxLength: 100, nullable: false),
                    IdTinh = table.Column<int>(type: "int", nullable: false),
                    PostalCode = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedDate = table.Column<DateTime>(type: "datetime(6)", maxLength: 100, nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime(6)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Huyen", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Huyen_Tinh_IdTinh",
                        column: x => x.IdTinh,
                        principalTable: "Tinh",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Xa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Status = table.Column<int>(type: "int", maxLength: 100, nullable: false),
                    IdHuyen = table.Column<int>(type: "int", nullable: false),
                    PostalCode = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedDate = table.Column<DateTime>(type: "datetime(6)", maxLength: 100, nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime(6)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Xa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Xa_Huyen_IdHuyen",
                        column: x => x.IdHuyen,
                        principalTable: "Huyen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Code = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Status = table.Column<int>(type: "int", maxLength: 100, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime(6)", maxLength: 100, nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime(6)", maxLength: 100, nullable: false),
                    IdTinh = table.Column<int>(type: "int", nullable: false),
                    IdHuyen = table.Column<int>(type: "int", nullable: false),
                    IdXa = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Huyen_IdHuyen",
                        column: x => x.IdHuyen,
                        principalTable: "Huyen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employees_Tinh_IdTinh",
                        column: x => x.IdTinh,
                        principalTable: "Tinh",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employees_Xa_IdXa",
                        column: x => x.IdXa,
                        principalTable: "Xa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Certificate",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Status = table.Column<int>(type: "int", maxLength: 100, nullable: false),
                    IssueDate = table.Column<DateTime>(type: "datetime(6)", maxLength: 100, nullable: false),
                    ExpiredDate = table.Column<DateTime>(type: "datetime(6)", maxLength: 100, nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    IdTinh = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Certificate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Certificate_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Certificate_Tinh_IdTinh",
                        column: x => x.IdTinh,
                        principalTable: "Tinh",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Certificate_EmployeeId",
                table: "Certificate",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Certificate_IdTinh",
                table: "Certificate",
                column: "IdTinh");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_Code",
                table: "Employees",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_IdHuyen",
                table: "Employees",
                column: "IdHuyen");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_IdTinh",
                table: "Employees",
                column: "IdTinh");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_IdXa",
                table: "Employees",
                column: "IdXa");

            migrationBuilder.CreateIndex(
                name: "IX_Huyen_IdTinh",
                table: "Huyen",
                column: "IdTinh");

            migrationBuilder.CreateIndex(
                name: "IX_Huyen_PostalCode",
                table: "Huyen",
                column: "PostalCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tinh_PostalCode",
                table: "Tinh",
                column: "PostalCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Xa_IdHuyen",
                table: "Xa",
                column: "IdHuyen");

            migrationBuilder.CreateIndex(
                name: "IX_Xa_PostalCode",
                table: "Xa",
                column: "PostalCode",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Certificate");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Xa");

            migrationBuilder.DropTable(
                name: "Huyen");

            migrationBuilder.DropTable(
                name: "Tinh");
        }
    }
}
