﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Pras.DAL.Context;

namespace Pras.DAL.Migrations
{
    [DbContext(typeof(PrasDbContext))]
    [Migration("20220511103317_CharactersCreated")]
    partial class CharactersCreated
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Pras.DAL.Entities.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Pras.DAL.Entities.Audio", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created");

                    b.Property<bool>("IsNovelty");

                    b.Property<string>("Path");

                    b.Property<string>("Summary");

                    b.Property<string>("Title");

                    b.Property<int>("Type");

                    b.HasKey("Id");

                    b.ToTable("Audios");
                });

            modelBuilder.Entity("Pras.DAL.Entities.Character", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<string>("Path");

                    b.Property<Guid?>("SpeakerId");

                    b.Property<Guid?>("SpeakerId1");

                    b.HasKey("Id");

                    b.HasIndex("SpeakerId");

                    b.HasIndex("SpeakerId1");

                    b.ToTable("Characters");
                });

            modelBuilder.Entity("Pras.DAL.Entities.Information", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created");

                    b.Property<string>("MetaDescription");

                    b.Property<string>("MetaTitle");

                    b.Property<string>("Text");

                    b.Property<string>("Title");

                    b.Property<int>("Type");

                    b.HasKey("Id");

                    b.ToTable("Informations");
                });

            modelBuilder.Entity("Pras.DAL.Entities.News", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created");

                    b.Property<string>("MetaDescription");

                    b.Property<string>("MetaTitle");

                    b.Property<string>("Text");

                    b.Property<string>("Title");

                    b.Property<string>("Url");

                    b.HasKey("Id");

                    b.ToTable("News");
                });

            modelBuilder.Entity("Pras.DAL.Entities.Person", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Image");

                    b.Property<string>("ImageSmall");

                    b.Property<string>("Name");

                    b.Property<int>("Order");

                    b.Property<string>("Position");

                    b.Property<string>("Socials");

                    b.Property<string>("Summary");

                    b.HasKey("Id");

                    b.ToTable("People");
                });

            modelBuilder.Entity("Pras.DAL.Entities.Review", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created")
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<string>("Image");

                    b.Property<string>("Name");

                    b.Property<string>("Text");

                    b.HasKey("Id");

                    b.ToTable("Reviews","db_owner");
                });

            modelBuilder.Entity("Pras.DAL.Entities.Service", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Link");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("Pras.DAL.Entities.Settings", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("About");

                    b.Property<string>("Address");

                    b.Property<string>("Block1Link");

                    b.Property<string>("Block1Subtitle");

                    b.Property<string>("Block1Title");

                    b.Property<string>("Block2Link");

                    b.Property<string>("Block2Subtitle");

                    b.Property<string>("Block2Title");

                    b.Property<string>("Block3Link");

                    b.Property<string>("Block3Subtitle");

                    b.Property<string>("Block3Title");

                    b.Property<string>("Block4Link");

                    b.Property<string>("Block4Subtitle");

                    b.Property<string>("Block4Title");

                    b.Property<string>("Block5Link");

                    b.Property<string>("Block5Subtitle");

                    b.Property<string>("Block5Title");

                    b.Property<string>("Block6Link");

                    b.Property<string>("Block6Subtitle");

                    b.Property<string>("Block6Title");

                    b.Property<string>("Contacts");

                    b.Property<DateTime>("Created");

                    b.Property<string>("FullContacts");

                    b.Property<string>("Logo");

                    b.Property<string>("LogoSubtitle");

                    b.Property<string>("MetaDescription");

                    b.Property<string>("MetaTitle");

                    b.Property<string>("Partners");

                    b.Property<string>("Partnership");

                    b.Property<string>("Phones");

                    b.Property<string>("Principles");

                    b.Property<string>("Projects");

                    b.Property<string>("Shedule");

                    b.Property<string>("Socials");

                    b.HasKey("Id");

                    b.ToTable("Settings","db_owner");
                });

            modelBuilder.Entity("Pras.DAL.Entities.Speaker", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("CanDirect");

                    b.Property<string>("Comment");

                    b.Property<string>("Country");

                    b.Property<DateTime>("Created");

                    b.Property<int>("Currency");

                    b.Property<string>("Demo");

                    b.Property<string>("DemoAdvertising");

                    b.Property<string>("DemoVoiceOver");

                    b.Property<int>("Gender");

                    b.Property<string>("Image");

                    b.Property<string>("Industries");

                    b.Property<bool>("IsNovelty");

                    b.Property<bool>("IsVip");

                    b.Property<string>("Languages");

                    b.Property<string>("Name");

                    b.Property<string>("Nationality");

                    b.Property<string>("Params");

                    b.Property<string>("Portfolio");

                    b.Property<string>("Price30");

                    b.Property<string>("Price90");

                    b.Property<int>("PriceCategory");

                    b.Property<string>("PricePage");

                    b.Property<int>("Rating");

                    b.Property<int>("Status");

                    b.Property<string>("Summary");

                    b.Property<float>("Terms");

                    b.Property<int>("Type");

                    b.Property<string>("Url");

                    b.Property<DateTime?>("VacationEndDate");

                    b.Property<DateTime?>("VacationStartDate");

                    b.Property<string>("Videos");

                    b.Property<string>("VoiceAge");

                    b.Property<string>("VoiceDescription");

                    b.Property<string>("Voices");

                    b.Property<string>("WorkTypes");

                    b.Property<string>("WorkingDays");

                    b.Property<string>("WorkingHours");

                    b.HasKey("Id");

                    b.ToTable("Speakers");
                });

            modelBuilder.Entity("Pras.DAL.Entities.Video", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created");

                    b.Property<string>("Path");

                    b.Property<string>("Summary");

                    b.Property<string>("Title");

                    b.Property<int>("Type");

                    b.HasKey("Id");

                    b.ToTable("Videos");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Pras.DAL.Entities.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Pras.DAL.Entities.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Pras.DAL.Entities.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Pras.DAL.Entities.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Pras.DAL.Entities.Character", b =>
                {
                    b.HasOne("Pras.DAL.Entities.Speaker")
                        .WithMany("Characters")
                        .HasForeignKey("SpeakerId");

                    b.HasOne("Pras.DAL.Entities.Speaker", "Speaker")
                        .WithMany()
                        .HasForeignKey("SpeakerId1");
                });
#pragma warning restore 612, 618
        }
    }
}
