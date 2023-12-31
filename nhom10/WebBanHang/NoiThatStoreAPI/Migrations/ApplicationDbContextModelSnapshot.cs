﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NoiThatStoreAPI.Models;

#nullable disable

namespace NoiThatStoreAPI.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("NoiThatStoreAPI.Models.Admin", b =>
                {
                    b.Property<long?>("ADMINID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long?>("ADMINID"));

                    b.Property<string>("PASS")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("TEN_TK")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("ADMINID");

                    b.HasIndex("TEN_TK")
                        .IsUnique();

                    b.ToTable("Admin");
                });

            modelBuilder.Entity("NoiThatStoreAPI.Models.HoaDon", b =>
                {
                    b.Property<long?>("MAHD")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long?>("MAHD"));

                    b.Property<decimal>("GIABAN")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("LOAIHD")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("MAKH_id")
                        .IsRequired()
                        .HasColumnType("bigint");

                    b.Property<DateTime>("NGAYHD")
                        .HasColumnType("datetime2");

                    b.HasKey("MAHD");

                    b.HasIndex("MAKH_id");

                    b.ToTable("HoaDon");
                });

            modelBuilder.Entity("NoiThatStoreAPI.Models.HoaDonCT", b =>
                {
                    b.Property<long?>("MAHD")
                        .HasColumnType("bigint");

                    b.Property<long?>("MASP")
                        .HasColumnType("bigint");

                    b.Property<decimal>("DONGIA")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("SL")
                        .HasColumnType("int");

                    b.Property<long?>("id")
                        .HasColumnType("bigint");

                    b.HasKey("MAHD", "MASP");

                    b.HasIndex("MASP");

                    b.ToTable("HoaDonCT");
                });

            modelBuilder.Entity("NoiThatStoreAPI.Models.KhachHang", b =>
                {
                    b.Property<long?>("MAKH_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long?>("MAKH_id"));

                    b.Property<string>("EMAIL")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("GIOITINH")
                        .HasColumnType("bit");

                    b.Property<string>("HOLOT")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("SDT")
                        .HasColumnType("int");

                    b.Property<string>("TEN")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("MAKH_id");

                    b.ToTable("KhachHang");
                });

            modelBuilder.Entity("NoiThatStoreAPI.Models.NhaCungCap", b =>
                {
                    b.Property<long?>("NCC_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long?>("NCC_ID"));

                    b.Property<string>("DIACHI")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("EMAIL")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("SDT")
                        .HasColumnType("int");

                    b.Property<string>("TEN")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("NCC_ID");

                    b.ToTable("NhaCungCap");
                });

            modelBuilder.Entity("NoiThatStoreAPI.Models.SanPham", b =>
                {
                    b.Property<long?>("MASP")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long?>("MASP"));

                    b.Property<string>("CHATLIEU")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<double>("GiaBan")
                        .HasColumnType("float");

                    b.Property<string>("HINHANH")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("LOAI")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("MoTa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("NCC_ID")
                        .IsRequired()
                        .HasColumnType("bigint");

                    b.Property<string>("TENSP")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("TONKHO")
                        .HasColumnType("int");

                    b.HasKey("MASP");

                    b.HasIndex("NCC_ID");

                    b.ToTable("SanPham");
                });

            modelBuilder.Entity("NoiThatStoreAPI.Models.HoaDon", b =>
                {
                    b.HasOne("NoiThatStoreAPI.Models.KhachHang", "KhachHang")
                        .WithMany("HoaDon")
                        .HasForeignKey("MAKH_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("KhachHang");
                });

            modelBuilder.Entity("NoiThatStoreAPI.Models.HoaDonCT", b =>
                {
                    b.HasOne("NoiThatStoreAPI.Models.HoaDon", "HoaDon")
                        .WithMany("HoaDonCT")
                        .HasForeignKey("MAHD")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NoiThatStoreAPI.Models.SanPham", "SanPham")
                        .WithMany("HoaDonCT")
                        .HasForeignKey("MASP")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("HoaDon");

                    b.Navigation("SanPham");
                });

            modelBuilder.Entity("NoiThatStoreAPI.Models.SanPham", b =>
                {
                    b.HasOne("NoiThatStoreAPI.Models.NhaCungCap", "NhaCungCap")
                        .WithMany("SanPham")
                        .HasForeignKey("NCC_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("NhaCungCap");
                });

            modelBuilder.Entity("NoiThatStoreAPI.Models.HoaDon", b =>
                {
                    b.Navigation("HoaDonCT");
                });

            modelBuilder.Entity("NoiThatStoreAPI.Models.KhachHang", b =>
                {
                    b.Navigation("HoaDon");
                });

            modelBuilder.Entity("NoiThatStoreAPI.Models.NhaCungCap", b =>
                {
                    b.Navigation("SanPham");
                });

            modelBuilder.Entity("NoiThatStoreAPI.Models.SanPham", b =>
                {
                    b.Navigation("HoaDonCT");
                });
#pragma warning restore 612, 618
        }
    }
}
