﻿// <auto-generated />
using System;
using DiplomaProject.Backend.DataLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DiplomaProject.Backend.DataLayer.Migrations
{
    [DbContext(typeof(PostgreSqlContext))]
    [Migration("20230121231045_Company-deleted")]
    partial class Companydeleted
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("DiplomaProject.Backend.Common.Models.Entity.Client", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateOnly>("BirthdayDate")
                        .HasColumnType("date");

                    b.Property<int>("BonusCount")
                        .HasColumnType("integer");

                    b.Property<string>("CompanyName")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("clients", (string)null);
                });

            modelBuilder.Entity("DiplomaProject.Backend.Common.Models.Entity.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<Guid>("ClientId")
                        .HasColumnType("uuid");

                    b.Property<DateOnly>("Date")
                        .HasColumnType("date");

                    b.Property<bool>("OnDelivery")
                        .HasColumnType("boolean");

                    b.Property<Guid>("ServiceId")
                        .HasColumnType("uuid");

                    b.Property<int?>("Status")
                        .HasColumnType("integer");

                    b.Property<TimeOnly>("Time")
                        .HasColumnType("time without time zone");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("ServiceId");

                    b.ToTable("orders", (string)null);
                });

            modelBuilder.Entity("DiplomaProject.Backend.Common.Models.Entity.Promotion", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("BeginDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CompanyName")
                        .HasColumnType("text");

                    b.Property<decimal>("CompanyPercent")
                        .HasColumnType("numeric");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("DiscountPercent")
                        .HasColumnType("numeric");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsCorporate")
                        .HasColumnType("boolean");

                    b.Property<Guid>("ServiceId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("ServiceId");

                    b.ToTable("promotions", (string)null);
                });

            modelBuilder.Entity("DiplomaProject.Backend.Common.Models.Entity.Service", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<Guid>("ShopId")
                        .HasColumnType("uuid");

                    b.Property<string>("TypeService")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ShopId");

                    b.ToTable("services", (string)null);
                });

            modelBuilder.Entity("DiplomaProject.Backend.Common.Models.Entity.Shop", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("DiscountPercent")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("shop", (string)null);
                });

            modelBuilder.Entity("DiplomaProject.Backend.Common.Models.Entity.ShopUser", b =>
                {
                    b.Property<Guid>("ShopId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("ShopId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("shop_user", (string)null);
                });

            modelBuilder.Entity("DiplomaProject.Backend.Common.Models.Entity.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("users", (string)null);
                });

            modelBuilder.Entity("DiplomaProject.Backend.Common.Models.Entity.Client", b =>
                {
                    b.HasOne("DiplomaProject.Backend.Common.Models.Entity.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("DiplomaProject.Backend.Common.Models.Entity.Order", b =>
                {
                    b.HasOne("DiplomaProject.Backend.Common.Models.Entity.Client", "Client")
                        .WithMany("Orders")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DiplomaProject.Backend.Common.Models.Entity.Service", "Service")
                        .WithMany("Orders")
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("Service");
                });

            modelBuilder.Entity("DiplomaProject.Backend.Common.Models.Entity.Promotion", b =>
                {
                    b.HasOne("DiplomaProject.Backend.Common.Models.Entity.Service", "Service")
                        .WithMany("Promotions")
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Service");
                });

            modelBuilder.Entity("DiplomaProject.Backend.Common.Models.Entity.Service", b =>
                {
                    b.HasOne("DiplomaProject.Backend.Common.Models.Entity.Shop", "Shop")
                        .WithMany()
                        .HasForeignKey("ShopId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Shop");
                });

            modelBuilder.Entity("DiplomaProject.Backend.Common.Models.Entity.ShopUser", b =>
                {
                    b.HasOne("DiplomaProject.Backend.Common.Models.Entity.Shop", "Shop")
                        .WithMany("ShopUsers")
                        .HasForeignKey("ShopId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DiplomaProject.Backend.Common.Models.Entity.User", "User")
                        .WithMany("ShopUsers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Shop");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DiplomaProject.Backend.Common.Models.Entity.Client", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("DiplomaProject.Backend.Common.Models.Entity.Service", b =>
                {
                    b.Navigation("Orders");

                    b.Navigation("Promotions");
                });

            modelBuilder.Entity("DiplomaProject.Backend.Common.Models.Entity.Shop", b =>
                {
                    b.Navigation("ShopUsers");
                });

            modelBuilder.Entity("DiplomaProject.Backend.Common.Models.Entity.User", b =>
                {
                    b.Navigation("ShopUsers");
                });
#pragma warning restore 612, 618
        }
    }
}
