using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using eCommerceApp.Context;

namespace eCommerceApp.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("eCommerceApp.Entities.CartItem", b =>
                {
                    b.Property<int>("CartId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CustomerId");

                    b.Property<decimal?>("Price");

                    b.Property<int?>("ProductId");

                    b.Property<int?>("Quantity");

                    b.Property<decimal?>("UnitPrice");

                    b.HasKey("CartId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("ProductId");

                    b.ToTable("CartItem");
                });

            modelBuilder.Entity("eCommerceApp.Entities.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CategoryName");

                    b.HasKey("CategoryId");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("eCommerceApp.Entities.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address1");

                    b.Property<string>("Address2");

                    b.Property<string>("City");

                    b.Property<string>("CustomerName")
                        .IsRequired();

                    b.Property<DateTime?>("DateEntered");

                    b.Property<string>("EmailAddress");

                    b.Property<string>("LastName");

                    b.Property<int>("PostalCode");

                    b.HasKey("CustomerId");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("eCommerceApp.Entities.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CustomerId");

                    b.Property<DateTime?>("OrderDate");

                    b.Property<decimal>("OrderTotal");

                    b.HasKey("OrderId");

                    b.HasIndex("CustomerId");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("eCommerceApp.Entities.OrderLine", b =>
                {
                    b.Property<int>("OrderLineId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("OrderId");

                    b.Property<decimal?>("Price");

                    b.Property<int?>("ProductId");

                    b.Property<int?>("Quantity");

                    b.Property<decimal?>("UnityPrice");

                    b.HasKey("OrderLineId");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderLine");
                });

            modelBuilder.Entity("eCommerceApp.Entities.Picture", b =>
                {
                    b.Property<int>("PictureId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FileName")
                        .HasMaxLength(100);

                    b.Property<int?>("ProductId");

                    b.HasKey("PictureId");

                    b.HasIndex("ProductId");

                    b.ToTable("Picture");
                });

            modelBuilder.Entity("eCommerceApp.Entities.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CategoryId");

                    b.Property<byte[]>("ImagePath");

                    b.Property<int?>("PictureId");

                    b.Property<string>("ProductDetails");

                    b.Property<string>("ProductName")
                        .IsRequired();

                    b.Property<decimal>("UnitPrice");

                    b.Property<int?>("UnitsInStock");

                    b.HasKey("ProductId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("eCommerceApp.Entities.SubCategory", b =>
                {
                    b.Property<int>("SubCategoryId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CategoryId");

                    b.Property<string>("SubCategoryName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("SubCategoryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("SubCategory");
                });

            modelBuilder.Entity("eCommerceApp.Entities.CartItem", b =>
                {
                    b.HasOne("eCommerceApp.Entities.Customer", "Customers")
                        .WithMany("CartItems")
                        .HasForeignKey("CustomerId");

                    b.HasOne("eCommerceApp.Entities.Product", "Products")
                        .WithMany("CartItems")
                        .HasForeignKey("ProductId");
                });

            modelBuilder.Entity("eCommerceApp.Entities.Order", b =>
                {
                    b.HasOne("eCommerceApp.Entities.Customer", "Customers")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("eCommerceApp.Entities.OrderLine", b =>
                {
                    b.HasOne("eCommerceApp.Entities.Order", "Orders")
                        .WithMany("OrderLines")
                        .HasForeignKey("OrderId");

                    b.HasOne("eCommerceApp.Entities.Product", "Products")
                        .WithMany("OrderLines")
                        .HasForeignKey("ProductId");
                });

            modelBuilder.Entity("eCommerceApp.Entities.Picture", b =>
                {
                    b.HasOne("eCommerceApp.Entities.Product")
                        .WithMany("Pictures")
                        .HasForeignKey("ProductId");
                });

            modelBuilder.Entity("eCommerceApp.Entities.Product", b =>
                {
                    b.HasOne("eCommerceApp.Entities.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId");
                });

            modelBuilder.Entity("eCommerceApp.Entities.SubCategory", b =>
                {
                    b.HasOne("eCommerceApp.Entities.Category", "Category")
                        .WithMany("SubCategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
