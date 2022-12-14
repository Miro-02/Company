// <auto-generated />
using System;
using CompanyNemetschek.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CompanyNemetschek.Migrations
{
    [DbContext(typeof(CompanyNemetschekContext))]
    [Migration("20220829161436_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CompanyNemetschek.Models.Company", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int>("MEarnings")
                        .HasColumnType("int");

                    b.Property<int>("MExpenses")
                        .HasColumnType("int");

                    b.Property<string>("MName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Company");
                });

            modelBuilder.Entity("CompanyNemetschek.Models.Human", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MAdress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MFirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MLastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MPosition")
                        .HasColumnType("int");

                    b.Property<int>("MSalary")
                        .HasColumnType("int");

                    b.Property<DateTime>("MStartingDate")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.ToTable("Human");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Human");
                });

            modelBuilder.Entity("CompanyNemetschek.Models.TeamLead", b =>
                {
                    b.HasBaseType("CompanyNemetschek.Models.Human");

                    b.HasDiscriminator().HasValue("TeamLead");
                });
#pragma warning restore 612, 618
        }
    }
}
