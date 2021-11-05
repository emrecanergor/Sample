﻿// <auto-generated />
using Case.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Case.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20211105091124_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Case.Domain.Entity.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryName = "Beyaz Eşya"
                        },
                        new
                        {
                            Id = 2,
                            CategoryName = "Ev Eşyası"
                        },
                        new
                        {
                            Id = 3,
                            CategoryName = "Teknoloji"
                        },
                        new
                        {
                            Id = 4,
                            CategoryName = "Bahçe"
                        });
                });

            modelBuilder.Entity("Case.Domain.Entity.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryID")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StockQuantity")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryID");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryID = 1,
                            Description = "NoFrost",
                            StockQuantity = 5,
                            Title = "Buzdolabı"
                        },
                        new
                        {
                            Id = 2,
                            CategoryID = 2,
                            Description = "Rahat",
                            StockQuantity = 6,
                            Title = "Koltuk"
                        },
                        new
                        {
                            Id = 3,
                            CategoryID = 3,
                            Description = "150mp",
                            StockQuantity = 7,
                            Title = "Kamera"
                        },
                        new
                        {
                            Id = 4,
                            CategoryID = 4,
                            Description = "200kg kapasiteli",
                            StockQuantity = 8,
                            Title = "Salıncak"
                        });
                });

            modelBuilder.Entity("Case.Domain.Entity.Product", b =>
                {
                    b.HasOne("Case.Domain.Entity.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Case.Domain.Entity.Category", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
