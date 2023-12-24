using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NoiThatStore.Migrations
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
            migrationBuilder.Sql("CREATE UNIQUE INDEX IX_Admin_TEN_TK ON Admin(TEN_TK);");


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
                name: "Orders",
                columns: table => new
                {
                    OrderID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Line1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Line2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Line3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Zip = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GiftWrap = table.Column<bool>(type: "bit", nullable: false),
                    Shipped = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderID);
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
                    LOAIHD = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KhachHangMAKH_id = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoaDon", x => x.MAHD);
                    table.ForeignKey(
                        name: "FK_HoaDon_KhachHang_KhachHangMAKH_id",
                        column: x => x.KhachHangMAKH_id,
                        principalTable: "KhachHang",
                        principalColumn: "MAKH_id");
                });

            migrationBuilder.CreateTable(
                name: "SanPham",
                columns: table => new
                {
                    MASP = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NCC_ID = table.Column<long>(type: "bigint", nullable: true),
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
                        principalColumn: "NCC_ID");
                });

            migrationBuilder.CreateTable(
                name: "CartLine",
                columns: table => new
                {
                    CartLineID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SanPhamMASP = table.Column<long>(type: "bigint", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    OrderID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartLine", x => x.CartLineID);
                    table.ForeignKey(
                        name: "FK_CartLine_Orders_OrderID",
                        column: x => x.OrderID,
                        principalTable: "Orders",
                        principalColumn: "OrderID");
                    table.ForeignKey(
                        name: "FK_CartLine_SanPham_SanPhamMASP",
                        column: x => x.SanPhamMASP,
                        principalTable: "SanPham",
                        principalColumn: "MASP",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HoaDonCT",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MAHD = table.Column<long>(type: "bigint", nullable: false),
                    MASP = table.Column<long>(type: "bigint", nullable: false),
                    SL = table.Column<int>(type: "int", nullable: false),
                    DONGIA = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    HoaDonMAHD = table.Column<long>(type: "bigint", nullable: true),
                    SanPhamMASP = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoaDonCT", x => x.id);
                    table.ForeignKey(
                        name: "FK_HoaDonCT_HoaDon_HoaDonMAHD",
                        column: x => x.HoaDonMAHD,
                        principalTable: "HoaDon",
                        principalColumn: "MAHD");
                    table.ForeignKey(
                        name: "FK_HoaDonCT_SanPham_SanPhamMASP",
                        column: x => x.SanPhamMASP,
                        principalTable: "SanPham",
                        principalColumn: "MASP");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CartLine_OrderID",
                table: "CartLine",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "IX_CartLine_SanPhamMASP",
                table: "CartLine",
                column: "SanPhamMASP");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDon_KhachHangMAKH_id",
                table: "HoaDon",
                column: "KhachHangMAKH_id");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDonCT_HoaDonMAHD",
                table: "HoaDonCT",
                column: "HoaDonMAHD");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDonCT_SanPhamMASP",
                table: "HoaDonCT",
                column: "SanPhamMASP");

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
                name: "CartLine");

            migrationBuilder.DropTable(
                name: "HoaDonCT");

            migrationBuilder.DropTable(
                name: "Orders");

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
