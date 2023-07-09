﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PharmacyMangement.DAL.Data;

namespace PharmacyManagement.API.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("PharmacyManagement.DAL.Models.Admin", b =>
                {
                    b.Property<int>("Admin_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Add_medicine")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Admin_mailid")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Admin_name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Admin_password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("User_id")
                        .HasColumnType("int");

                    b.HasKey("Admin_id");

                    b.HasIndex("User_id");

                    b.ToTable("Admins");
                });

            modelBuilder.Entity("PharmacyManagement.DAL.Models.Feedback", b =>
                {
                    b.Property<int>("Feedback_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Feedbacks")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Service_rating")
                        .HasColumnType("int");

                    b.HasKey("Feedback_id");

                    b.ToTable("Feedbacks");
                });

            modelBuilder.Entity("PharmacyManagement.DAL.Models.Medicine", b =>
                {
                    b.Property<int>("Medicine_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Medicine_name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Medicine_type")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Medicine_id");

                    b.ToTable("Medicines");
                });

            modelBuilder.Entity("PharmacyManagement.DAL.Models.Request", b =>
                {
                    b.Property<int>("Request_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Medicine_name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Medicine_type")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Request_id");

                    b.ToTable("Requests");
                });

            modelBuilder.Entity("PharmacyManagement.DAL.Models.User", b =>
                {
                    b.Property<int>("User_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("User_mailid")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("User_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("User_password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("User_id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("PharmacyManagement.DAL.Models.Admin", b =>
                {
                    b.HasOne("PharmacyManagement.DAL.Models.User", "Username_id")
                        .WithMany()
                        .HasForeignKey("User_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Username_id");
                });
#pragma warning restore 612, 618
        }
    }
}