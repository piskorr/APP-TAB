﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace TabApp.Migrations
{
    [DbContext(typeof(dbContext))]
    [Migration("20210912205907_DbChanges2")]
    partial class DbChanges2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.9");

            modelBuilder.Entity("TabApp.Models.Invoice", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("InvoiceDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("NIP")
                        .HasColumnType("TEXT");

                    b.Property<int?>("PersonID")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("RepairID")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.HasIndex("PersonID");

                    b.HasIndex("RepairID")
                        .IsUnique();

                    b.ToTable("Invoice");
                });

            modelBuilder.Entity("TabApp.Models.Item", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<int?>("PersonID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SerialNumber")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.HasIndex("PersonID");

                    b.ToTable("Item");
                });

            modelBuilder.Entity("TabApp.Models.LoginCredentials", b =>
                {
                    b.Property<int>("ID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("TEXT");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("LoginCredentials");
                });

            modelBuilder.Entity("TabApp.Models.Message", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("AddresseeID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Content")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<int?>("SenderID")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.HasIndex("AddresseeID");

                    b.HasIndex("SenderID");

                    b.ToTable("Message");
                });

            modelBuilder.Entity("TabApp.Models.Person", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(9)
                        .HasColumnType("TEXT");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("Person");
                });

            modelBuilder.Entity("TabApp.Models.PickupCode", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Value")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("PickupCodes");
                });

            modelBuilder.Entity("TabApp.Models.PriceList", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<int>("Price")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.ToTable("PriceList");
                });

            modelBuilder.Entity("TabApp.Models.Repair", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("AdmissionDate")
                        .HasColumnType("TEXT");

                    b.Property<int?>("Cost")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("IssueDate")
                        .HasColumnType("TEXT");

                    b.Property<int?>("ItemID")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("PickupCodeID")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("RepairStatusID")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Warranty")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.HasIndex("ItemID");

                    b.HasIndex("PickupCodeID")
                        .IsUnique();

                    b.HasIndex("RepairStatusID");

                    b.ToTable("Repair");
                });

            modelBuilder.Entity("TabApp.Models.RepairStatus", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Status")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("RepairStatus");
                });

            modelBuilder.Entity("TabApp.Models.Service", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("PartsCost")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("PersonID")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("PriceListID")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("RepairID")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("WarrantyDate")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.HasIndex("PersonID");

                    b.HasIndex("PriceListID");

                    b.HasIndex("RepairID");

                    b.ToTable("Service");
                });

            modelBuilder.Entity("TabApp.Models.Worker", b =>
                {
                    b.Property<int>("PersonID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("AccountNumber")
                        .IsRequired()
                        .HasMaxLength(26)
                        .HasColumnType("TEXT");

                    b.Property<int>("Earnings")
                        .HasColumnType("INTEGER");

                    b.Property<string>("JobPosition")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("TEXT");

                    b.Property<string>("PESEL")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("TEXT");

                    b.HasKey("PersonID");

                    b.ToTable("Worker");
                });

            modelBuilder.Entity("TabApp.Models.Invoice", b =>
                {
                    b.HasOne("TabApp.Models.Person", "Person")
                        .WithMany("Invoice")
                        .HasForeignKey("PersonID");

                    b.HasOne("TabApp.Models.Repair", "Repair")
                        .WithOne("Invoice")
                        .HasForeignKey("TabApp.Models.Invoice", "RepairID");

                    b.Navigation("Person");

                    b.Navigation("Repair");
                });

            modelBuilder.Entity("TabApp.Models.Item", b =>
                {
                    b.HasOne("TabApp.Models.Person", "Person")
                        .WithMany("Item")
                        .HasForeignKey("PersonID");

                    b.Navigation("Person");
                });

            modelBuilder.Entity("TabApp.Models.LoginCredentials", b =>
                {
                    b.HasOne("TabApp.Models.Person", "Person")
                        .WithOne("LoginCredentials")
                        .HasForeignKey("TabApp.Models.LoginCredentials", "ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Person");
                });

            modelBuilder.Entity("TabApp.Models.Message", b =>
                {
                    b.HasOne("TabApp.Models.Person", "Addressee")
                        .WithMany("ReciveMessage")
                        .HasForeignKey("AddresseeID");

                    b.HasOne("TabApp.Models.Person", "Sender")
                        .WithMany("SendMessage")
                        .HasForeignKey("SenderID");

                    b.Navigation("Addressee");

                    b.Navigation("Sender");
                });

            modelBuilder.Entity("TabApp.Models.Repair", b =>
                {
                    b.HasOne("TabApp.Models.Item", "Item")
                        .WithMany("Repair")
                        .HasForeignKey("ItemID");

                    b.HasOne("TabApp.Models.PickupCode", "PickupCode")
                        .WithOne("Repair")
                        .HasForeignKey("TabApp.Models.Repair", "PickupCodeID");

                    b.HasOne("TabApp.Models.RepairStatus", "RepairStatus")
                        .WithMany("Repair")
                        .HasForeignKey("RepairStatusID");

                    b.Navigation("Item");

                    b.Navigation("PickupCode");

                    b.Navigation("RepairStatus");
                });

            modelBuilder.Entity("TabApp.Models.Service", b =>
                {
                    b.HasOne("TabApp.Models.Person", "Person")
                        .WithMany("Service")
                        .HasForeignKey("PersonID");

                    b.HasOne("TabApp.Models.PriceList", "PriceList")
                        .WithMany("Service")
                        .HasForeignKey("PriceListID");

                    b.HasOne("TabApp.Models.Repair", "Repair")
                        .WithMany("Service")
                        .HasForeignKey("RepairID");

                    b.Navigation("Person");

                    b.Navigation("PriceList");

                    b.Navigation("Repair");
                });

            modelBuilder.Entity("TabApp.Models.Worker", b =>
                {
                    b.HasOne("TabApp.Models.Person", "Person")
                        .WithOne("Worker")
                        .HasForeignKey("TabApp.Models.Worker", "PersonID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Person");
                });

            modelBuilder.Entity("TabApp.Models.Item", b =>
                {
                    b.Navigation("Repair");
                });

            modelBuilder.Entity("TabApp.Models.Person", b =>
                {
                    b.Navigation("Invoice");

                    b.Navigation("Item");

                    b.Navigation("LoginCredentials");

                    b.Navigation("ReciveMessage");

                    b.Navigation("SendMessage");

                    b.Navigation("Service");

                    b.Navigation("Worker");
                });

            modelBuilder.Entity("TabApp.Models.PickupCode", b =>
                {
                    b.Navigation("Repair");
                });

            modelBuilder.Entity("TabApp.Models.PriceList", b =>
                {
                    b.Navigation("Service");
                });

            modelBuilder.Entity("TabApp.Models.Repair", b =>
                {
                    b.Navigation("Invoice");

                    b.Navigation("Service");
                });

            modelBuilder.Entity("TabApp.Models.RepairStatus", b =>
                {
                    b.Navigation("Repair");
                });
#pragma warning restore 612, 618
        }
    }
}
