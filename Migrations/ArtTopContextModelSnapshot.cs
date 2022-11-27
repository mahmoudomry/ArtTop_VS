﻿// <auto-generated />
using System;
using ArtTop.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ArtTop.Migrations
{
    [DbContext(typeof(ArtTopContext))]
    partial class ArtTopContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ArtTop.Areas.Identity.Data.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("FullName")
                        .HasColumnType("longtext");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("longtext");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("ArtTop.Models.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Image")
                        .HasColumnType("longtext");

                    b.Property<string>("Link")
                        .HasColumnType("longtext");

                    b.Property<string>("TitleAr")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("TitleEn")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Client", (string)null);
                });

            modelBuilder.Entity("ArtTop.Models.Feature", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ArabicTitle")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("EnglishTitle")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Icon")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Feature", (string)null);
                });

            modelBuilder.Entity("ArtTop.Models.NewsLetter", b =>
                {
                    b.Property<string>("Email")
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("Created_at")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Email");

                    b.ToTable("NewsLetter", (string)null);
                });

            modelBuilder.Entity("ArtTop.Models.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ArabicDetails")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ArabicTitle")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("CoverImage")
                        .HasColumnType("longtext");

                    b.Property<string>("EnglishDetails")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("EnglishTitle")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int?>("ServiceId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ServiceId");

                    b.ToTable("Project", (string)null);
                });

            modelBuilder.Entity("ArtTop.Models.Service", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ArabicDetails")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ArabicTitle")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("CoverImage")
                        .HasColumnType("longtext");

                    b.Property<string>("EnglishDetails")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("EnglishTitle")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Icon")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Service", (string)null);
                });

            modelBuilder.Entity("ArtTop.Models.SiteSetting", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("BookingDescAr")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("BookingDescEn")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("BookingTitleAr")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("BookingTitleEn")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("CopyRight")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("FeatureDescAr")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("FeatureDescEn")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("FeatureImg1")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("FeatureImg2")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("FeatureTitleAr")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("FeatureTitleEn")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("HeaderLogo")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Maarooflogo")
                        .HasColumnType("longtext");

                    b.Property<string>("ProjectTitleAr")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ProjectTitleEn")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ServiceDescAr")
                        .HasColumnType("longtext");

                    b.Property<string>("ServiceDescEn")
                        .HasColumnType("longtext");

                    b.Property<string>("ServiceTitleAr")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ServiceTitleEn")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("SiteDescAr")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("SiteDescEn")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("SiteTitleAr")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("SiteTitleEn")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("VATlogo")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("SiteSetting", (string)null);
                });

            modelBuilder.Entity("ArtTop.Models.Slider", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ArabicDetails")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ArabicTitle")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("CoverImage")
                        .HasColumnType("longtext");

                    b.Property<string>("EnglishDetails")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("EnglishTitle")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("IsActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Slider", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("RoleId")
                        .HasColumnType("varchar(255)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("longtext");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("ArtTop.Models.Project", b =>
                {
                    b.HasOne("ArtTop.Models.Service", "Service")
                        .WithMany()
                        .HasForeignKey("ServiceId");

                    b.Navigation("Service");
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
                    b.HasOne("ArtTop.Areas.Identity.Data.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("ArtTop.Areas.Identity.Data.ApplicationUser", null)
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

                    b.HasOne("ArtTop.Areas.Identity.Data.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("ArtTop.Areas.Identity.Data.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
