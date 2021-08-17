﻿// <auto-generated />
using System;
using LegoApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LegoApi.Migrations
{
    [DbContext(typeof(LegoApiContext))]
    partial class LegoApiContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LegoApi.Models.Conge", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("EstPayee")
                        .HasColumnType("bit");

                    b.Property<int>("Raison")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Conges");
                });

            modelBuilder.Entity("LegoApi.Models.Employe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int>("ServiceId")
                        .HasColumnType("int");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("Id");

                    b.HasIndex("ServiceId");

                    b.ToTable("Employes");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Employe");
                });

            modelBuilder.Entity("LegoApi.Models.EmployeConge", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CongeID")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateDebut")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2021, 8, 17, 3, 22, 38, 317, DateTimeKind.Local).AddTicks(6821));

                    b.Property<int>("Duree")
                        .HasColumnType("int");

                    b.Property<int>("EmployeId")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("CongeID");

                    b.HasIndex("EmployeId");

                    b.ToTable("EmployeConges");
                });

            modelBuilder.Entity("LegoApi.Models.Service", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Locale")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("ID");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("LegoApi.Models.ContentManager", b =>
                {
                    b.HasBaseType("LegoApi.Models.Employe");

                    b.Property<string>("Application")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Langue")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("NbFollowers")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("ContentManager");
                });

            modelBuilder.Entity("LegoApi.Models.Developpeur", b =>
                {
                    b.HasBaseType("LegoApi.Models.Employe");

                    b.Property<int>("Experience")
                        .HasColumnType("int");

                    b.Property<string>("Langage")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Post")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasDiscriminator().HasValue("Developpeur");
                });

            modelBuilder.Entity("LegoApi.Models.Employe", b =>
                {
                    b.HasOne("LegoApi.Models.Service", "Service")
                        .WithMany("Employes")
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Service");
                });

            modelBuilder.Entity("LegoApi.Models.EmployeConge", b =>
                {
                    b.HasOne("LegoApi.Models.Conge", "Conge")
                        .WithMany("EmployeConges")
                        .HasForeignKey("CongeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LegoApi.Models.Employe", "Employe")
                        .WithMany("EmployeConges")
                        .HasForeignKey("EmployeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Conge");

                    b.Navigation("Employe");
                });

            modelBuilder.Entity("LegoApi.Models.Conge", b =>
                {
                    b.Navigation("EmployeConges");
                });

            modelBuilder.Entity("LegoApi.Models.Employe", b =>
                {
                    b.Navigation("EmployeConges");
                });

            modelBuilder.Entity("LegoApi.Models.Service", b =>
                {
                    b.Navigation("Employes");
                });
#pragma warning restore 612, 618
        }
    }
}
