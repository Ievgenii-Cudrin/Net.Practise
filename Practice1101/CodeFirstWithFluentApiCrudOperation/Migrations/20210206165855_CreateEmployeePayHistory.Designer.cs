﻿// <auto-generated />
using System;
using CodeFirstWithFluentApiCrudOperation.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CodeFirstWithFluentApiCrudOperation.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20210206165855_CreateEmployeePayHistory")]
    partial class CreateEmployeePayHistory
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("CodeFirstWithFluentApiCrudOperation.Entities.Employee", b =>
                {
                    b.Property<int>("BusinessEntityID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("JobTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LoginID")
                        .HasColumnType("int");

                    b.Property<int>("NationalIDNumber")
                        .HasColumnType("int");

                    b.Property<int>("OrganizationLevel")
                        .HasColumnType("int");

                    b.Property<int>("PersonID")
                        .HasColumnType("int");

                    b.HasKey("BusinessEntityID");

                    b.HasIndex("LoginID")
                        .IsUnique();

                    b.HasIndex("NationalIDNumber")
                        .IsUnique();

                    b.HasIndex("PersonID");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("CodeFirstWithFluentApiCrudOperation.Entities.EmployeePayHistory", b =>
                {
                    b.Property<int>("EmployeePayHistoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("PayFrequency")
                        .HasColumnType("int");

                    b.Property<int>("Rate")
                        .HasColumnType("int");

                    b.Property<DateTime>("RateChangeDate")
                        .HasColumnType("datetime2");

                    b.HasKey("EmployeePayHistoryId");

                    b.ToTable("EmployeePayHistory");
                });

            modelBuilder.Entity("CodeFirstWithFluentApiCrudOperation.Entities.JobCandidate", b =>
                {
                    b.Property<int>("JobCandidateID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("BusinessEntityID")
                        .HasColumnType("int");

                    b.Property<string>("Resume")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("JobCandidateID");

                    b.HasIndex("BusinessEntityID");

                    b.ToTable("JobCandidate");
                });

            modelBuilder.Entity("CodeFirstWithFluentApiCrudOperation.Entities.Person", b =>
                {
                    b.Property<int>("PersonID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PersonType")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PersonID");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("CodeFirstWithFluentApiCrudOperation.Entities.SalesPerson", b =>
                {
                    b.Property<int>("SalesPersonID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("BusinessEntityID")
                        .HasColumnType("int");

                    b.Property<int>("SalesQuota")
                        .HasColumnType("int");

                    b.HasKey("SalesPersonID");

                    b.HasIndex("BusinessEntityID");

                    b.ToTable("SalesPerson");
                });

            modelBuilder.Entity("CodeFirstWithFluentApiCrudOperation.Entities.Employee", b =>
                {
                    b.HasOne("CodeFirstWithFluentApiCrudOperation.Entities.Person", "Person")
                        .WithMany("Employees")
                        .HasForeignKey("PersonID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Person");
                });

            modelBuilder.Entity("CodeFirstWithFluentApiCrudOperation.Entities.JobCandidate", b =>
                {
                    b.HasOne("CodeFirstWithFluentApiCrudOperation.Entities.Employee", "Employee")
                        .WithMany("JobCandidates")
                        .HasForeignKey("BusinessEntityID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("CodeFirstWithFluentApiCrudOperation.Entities.SalesPerson", b =>
                {
                    b.HasOne("CodeFirstWithFluentApiCrudOperation.Entities.Employee", "Employee")
                        .WithMany("SalesPersons")
                        .HasForeignKey("BusinessEntityID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("CodeFirstWithFluentApiCrudOperation.Entities.Employee", b =>
                {
                    b.Navigation("JobCandidates");

                    b.Navigation("SalesPersons");
                });

            modelBuilder.Entity("CodeFirstWithFluentApiCrudOperation.Entities.Person", b =>
                {
                    b.Navigation("Employees");
                });
#pragma warning restore 612, 618
        }
    }
}
