using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NoiThatStoreAPI.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    ADMINID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TEN_TK = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PASS = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.ADMINID);
                });

            migrationBuilder.CreateTable(
                name: "KhachHang",
                columns: table => new
                {
                    MAKH_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TEN = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    HOLOT = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    EMAIL = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SDT = table.Column<int>(type: "int", nullable: false),
                    GIOITINH = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhachHang", x => x.MAKH_id);
                });

            migrationBuilder.CreateTable(
                name: "NhaCungCap",
                columns: table => new
                {
                    NCC_ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TEN = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DIACHI = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    SDT = table.Column<int>(type: "int", nullable: false),
                    EMAIL = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhaCungCap", x => x.NCC_ID);
                });

            migrationBuilder.CreateTable(
                name: "HoaDon",
                columns: table => new
                {
                    MAHD = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MAKH_id = table.Column<long>(type: "bigint", nullable: false),
                    GIABAN = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NGAYHD = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LOAIHD = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoaDon", x => x.MAHD);
                    table.ForeignKey(
                        name: "FK_HoaDon_KhachHang_MAKH_id",
                        column: x => x.MAKH_id,
                        principalTable: "KhachHang",
                        principalColumn: "MAKH_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SanPham",
                columns: table => new
                {
                    MASP = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NCC_ID = table.Column<long>(type: "bigint", nullable: false),
                    TENSP = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    LOAI = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CHATLIEU = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TONKHO = table.Column<int>(type: "int", nullable: false),
                    GiaBan = table.Column<double>(type: "float", nullable: false),
                    HINHANH = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SanPham", x => x.MASP);
                    table.ForeignKey(
                        name: "FK_SanPham_NhaCungCap_NCC_ID",
                        column: x => x.NCC_ID,
                        principalTable: "NhaCungCap",
                        principalColumn: "NCC_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HoaDonCT",
                columns: table => new
                {
                    MAHD = table.Column<long>(type: "bigint", nullable: false),
                    MASP = table.Column<long>(type: "bigint", nullable: false),
                    id = table.Column<long>(type: "bigint", nullable: true),
                    SL = table.Column<int>(type: "int", nullable: false),
                    DONGIA = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoaDonCT", x => new { x.MAHD, x.MASP });
                    table.ForeignKey(
                        name: "FK_HoaDonCT_HoaDon_MAHD",
                        column: x => x.MAHD,
                        principalTable: "HoaDon",
                        principalColumn: "MAHD",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HoaDonCT_SanPham_MASP",
                        column: x => x.MASP,
                        principalTable: "SanPham",
                        principalColumn: "MASP",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Admin_TEN_TK",
                table: "Admin",
                column: "TEN_TK",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HoaDon_MAKH_id",
                table: "HoaDon",
                column: "MAKH_id");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDonCT_MASP",
                table: "HoaDonCT",
                column: "MASP");

            migrationBuilder.CreateIndex(
                name: "IX_SanPham_NCC_ID",
                table: "SanPham",
                column: "NCC_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DropTable(
                name: "HoaDonCT");

            migrationBuilder.DropTable(
                name: "HoaDon");

            migrationBuilder.DropTable(
                name: "SanPham");

            migrationBuilder.DropTable(
                name: "KhachHang");

            migrationBuilder.DropTable(
                name: "NhaCungCap");
        }
    }
}
