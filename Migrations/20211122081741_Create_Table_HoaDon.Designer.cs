﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NetCoreDemo.Data;

namespace NetCoreDemo.Migrations
{
    [DbContext(typeof(NetCoreDbContext))]
    [Migration("20211122081741_Create_Table_HoaDon")]
    partial class Create_Table_HoaDon
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.11");

            modelBuilder.Entity("NetCoreDemo.Models.Employee", b =>
                {
                    b.Property<string>("EmployeeID")
                        .HasColumnType("TEXT");

                    b.Property<string>("EmployeeName")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.HasKey("EmployeeID");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("NetCoreDemo.Models.LopHoc", b =>
                {
                    b.Property<string>("LopHocID")
                        .HasColumnType("TEXT");

                    b.Property<string>("LopHocName")
                        .HasColumnType("TEXT");

                    b.Property<string>("StudentID")
                        .HasColumnType("TEXT");

                    b.HasKey("LopHocID");

                    b.HasIndex("StudentID");

                    b.ToTable("LopHocs");
                });

            modelBuilder.Entity("NetCoreDemo.Models.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Genre")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Price")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("NetCoreDemo.Models.Person", b =>
                {
                    b.Property<string>("PersonID")
                        .HasColumnType("TEXT");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PersonName")
                        .HasColumnType("TEXT");

                    b.HasKey("PersonID");

                    b.ToTable("Persons");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Person");
                });

            modelBuilder.Entity("NetCoreDemo.Models.Product", b =>
                {
                    b.Property<string>("ProductID")
                        .HasColumnType("TEXT");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ProductName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Quantity")
                        .HasColumnType("TEXT");

                    b.Property<string>("UnitPrice")
                        .HasColumnType("TEXT");

                    b.HasKey("ProductID");

                    b.ToTable("Products");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Product");
                });

            modelBuilder.Entity("NetCoreDemo.Models.QuanLyNV", b =>
                {
                    b.Property<string>("MaPhong")
                        .HasColumnType("TEXT");

                    b.Property<string>("EmployeeID")
                        .HasColumnType("TEXT");

                    b.Property<string>("TenPhongBan")
                        .HasColumnType("TEXT");

                    b.HasKey("MaPhong");

                    b.HasIndex("EmployeeID");

                    b.ToTable("QuanLyNVs");
                });

            modelBuilder.Entity("NetCoreDemo.Models.Student", b =>
                {
                    b.Property<string>("StudentID")
                        .HasColumnType("TEXT");

                    b.Property<string>("Address")
                        .HasColumnType("TEXT");

                    b.Property<string>("StudentName")
                        .HasColumnType("TEXT");

                    b.HasKey("StudentID");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("NetCoreDemo.Models.DonHang", b =>
                {
                    b.HasBaseType("NetCoreDemo.Models.Person");

                    b.Property<string>("DiaChi")
                        .HasColumnType("TEXT");

                    b.Property<string>("MaDonHang")
                        .HasColumnType("TEXT");

                    b.Property<string>("SoDienThoai")
                        .HasColumnType("TEXT");

                    b.ToTable("Persons");

                    b.HasDiscriminator().HasValue("DonHang");
                });

            modelBuilder.Entity("NetCoreDemo.Models.HoaDon", b =>
                {
                    b.HasBaseType("NetCoreDemo.Models.Product");

                    b.Property<string>("MaHoaDon")
                        .HasColumnType("TEXT");

                    b.Property<string>("TongTien")
                        .HasColumnType("TEXT");

                    b.ToTable("Products");

                    b.HasDiscriminator().HasValue("HoaDon");
                });

            modelBuilder.Entity("NetCoreDemo.Models.LopHoc", b =>
                {
                    b.HasOne("NetCoreDemo.Models.Student", "Student")
                        .WithMany("LopHocs")
                        .HasForeignKey("StudentID");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("NetCoreDemo.Models.QuanLyNV", b =>
                {
                    b.HasOne("NetCoreDemo.Models.Employee", "Employee")
                        .WithMany("QuanLyNVs")
                        .HasForeignKey("EmployeeID");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("NetCoreDemo.Models.Employee", b =>
                {
                    b.Navigation("QuanLyNVs");
                });

            modelBuilder.Entity("NetCoreDemo.Models.Student", b =>
                {
                    b.Navigation("LopHocs");
                });
#pragma warning restore 612, 618
        }
    }
}
