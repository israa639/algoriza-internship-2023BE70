﻿// <auto-generated />
using System;
using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DomainLayer.Migrations
{
    [DbContext(typeof(Entities))]
    [Migration("20231210172444_init666")]
    partial class init666
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("DomainLayer.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("DoctorId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("ImageData")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<int?>("gender")
                        .HasColumnType("int");

                    b.Property<string>("patientId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("role")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "b2e46542-6907-4148-a730-219309c6fa32",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "fb0c7274-3435-4439-9000-bd3b4cad4006",
                            Email = "admin@email.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "admin@email.com",
                            PasswordHash = "AQAAAAEAACcQAAAAEBK7e2AmxtxfnGXcAhMhlofOIG6JJT68lK0g+FjHmGMgfb6gHn8jSGwiB6OOADCfEA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "13fe6207-af93-42a1-a06b-0a95c3769213",
                            TwoFactorEnabled = false,
                            role = 0
                        });
                });

            modelBuilder.Entity("DomainLayer.Models.Appointment", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("day")
                        .HasColumnType("int");

                    b.Property<string>("doctorId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal>("price")
                        .HasColumnType("decimal(18,4)");

                    b.HasKey("Id");

                    b.HasIndex("doctorId");

                    b.ToTable("Appointments");
                });

            modelBuilder.Entity("DomainLayer.Models.Booking", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("appointmentId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("bookingTime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("patientId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("appointmentId");

                    b.HasIndex("patientId");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("DomainLayer.Models.Doctor", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("applicationUserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("numOfRequests")
                        .HasColumnType("int");

                    b.Property<int>("specializationId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("applicationUserId")
                        .IsUnique();

                    b.HasIndex("specializationId");

                    b.ToTable("Doctors");
                });

            modelBuilder.Entity("DomainLayer.Models.Patient", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("applicationUserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("applicationUserId")
                        .IsUnique();

                    b.ToTable("patients");
                });

            modelBuilder.Entity("DomainLayer.Models.Specialization", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnOrder(1);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ArabicName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("requestsNum")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("specializations");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ArabicName = "قلب",
                            Name = "cardiology",
                            requestsNum = 0
                        },
                        new
                        {
                            Id = 2,
                            ArabicName = "جراحة",
                            Name = "Surgery",
                            requestsNum = 0
                        },
                        new
                        {
                            Id = 3,
                            ArabicName = "نفسية",
                            Name = "Psychiatry",
                            requestsNum = 0
                        },
                        new
                        {
                            Id = 4,
                            ArabicName = "مناعة",
                            Name = "Immunology",
                            requestsNum = 0
                        },
                        new
                        {
                            Id = 5,
                            ArabicName = "جراحة مخ",
                            Name = "brain surgery",
                            requestsNum = 0
                        },
                        new
                        {
                            Id = 7,
                            ArabicName = "مخ واعصاب",
                            Name = "Brain ",
                            requestsNum = 0
                        },
                        new
                        {
                            Id = 9,
                            ArabicName = "جلدية",
                            Name = "Dermatology",
                            requestsNum = 0
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "0711e7b6-da25-4abb-a5a7-feee8ba1b50d",
                            ConcurrencyStamp = "9bba7962-cf7b-4f37-b81d-50d590a8da0e",
                            Name = "Admin",
                            NormalizedName = "admin"
                        },
                        new
                        {
                            Id = "2b85294d-886c-43f1-9f85-5032cc5683b6",
                            ConcurrencyStamp = "ceec487f-4610-473f-af52-74c2d270609e",
                            Name = "Doctor",
                            NormalizedName = "doctor"
                        },
                        new
                        {
                            Id = "8307a8f9-f72b-4e9e-ac4c-da6e0c8098ef",
                            ConcurrencyStamp = "e7b901c2-dd5c-4611-89c4-4cc3ce9da578",
                            Name = "Patient",
                            NormalizedName = "patient"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = "b2e46542-6907-4148-a730-219309c6fa32",
                            RoleId = "0711e7b6-da25-4abb-a5a7-feee8ba1b50d"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("DomainLayer.Models.Appointment", b =>
                {
                    b.HasOne("DomainLayer.Models.Doctor", "doctor")
                        .WithMany("appointments")
                        .HasForeignKey("doctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("doctor");
                });

            modelBuilder.Entity("DomainLayer.Models.Booking", b =>
                {
                    b.HasOne("DomainLayer.Models.Appointment", "appointment")
                        .WithMany("slots")
                        .HasForeignKey("appointmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DomainLayer.Models.Patient", "patient")
                        .WithMany("Bookings")
                        .HasForeignKey("patientId");

                    b.Navigation("appointment");

                    b.Navigation("patient");
                });

            modelBuilder.Entity("DomainLayer.Models.Doctor", b =>
                {
                    b.HasOne("DomainLayer.Models.ApplicationUser", "applicationUser")
                        .WithOne("doctor")
                        .HasForeignKey("DomainLayer.Models.Doctor", "applicationUserId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.HasOne("DomainLayer.Models.Specialization", "specialization")
                        .WithMany("doctors")
                        .HasForeignKey("specializationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("applicationUser");

                    b.Navigation("specialization");
                });

            modelBuilder.Entity("DomainLayer.Models.Patient", b =>
                {
                    b.HasOne("DomainLayer.Models.ApplicationUser", "applicationUser")
                        .WithOne("patient")
                        .HasForeignKey("DomainLayer.Models.Patient", "applicationUserId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("applicationUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("DomainLayer.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("DomainLayer.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DomainLayer.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("DomainLayer.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DomainLayer.Models.ApplicationUser", b =>
                {
                    b.Navigation("doctor")
                        .IsRequired();

                    b.Navigation("patient")
                        .IsRequired();
                });

            modelBuilder.Entity("DomainLayer.Models.Appointment", b =>
                {
                    b.Navigation("slots");
                });

            modelBuilder.Entity("DomainLayer.Models.Doctor", b =>
                {
                    b.Navigation("appointments");
                });

            modelBuilder.Entity("DomainLayer.Models.Patient", b =>
                {
                    b.Navigation("Bookings");
                });

            modelBuilder.Entity("DomainLayer.Models.Specialization", b =>
                {
                    b.Navigation("doctors");
                });
#pragma warning restore 612, 618
        }
    }
}
