﻿// <auto-generated />
using System;
using FinFlow.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FinFlow.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241229131421_Attachments")]
    partial class Attachments
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FinFlow.Models.AttachmentModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TransactionID")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("createdAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("TransactionID");

                    b.ToTable("Attachments");
                });

            modelBuilder.Entity("FinFlow.Models.BudgetModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Amount")
                        .HasPrecision(16, 2)
                        .HasColumnType("decimal(16,2)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("remindon")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Budgets");
                });

            modelBuilder.Entity("FinFlow.Models.CategoryModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("ItemsModelId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ItemsModelId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Housing"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Utilities"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Groceries"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Transportation"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Healthcare"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Debt and Savings"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Personal Care"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Entertainment"
                        },
                        new
                        {
                            Id = 9,
                            Name = "Education"
                        },
                        new
                        {
                            Id = 10,
                            Name = "Miscellaneous"
                        });
                });

            modelBuilder.Entity("FinFlow.Models.ExpenseModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Amount")
                        .HasPrecision(16, 2)
                        .HasColumnType("decimal(16,2)");

                    b.Property<int?>("BudgetID")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ItemId")
                        .HasColumnType("int");

                    b.Property<string>("Notes")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Quantity")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("BudgetID");

                    b.HasIndex("ItemId");

                    b.ToTable("Expenses");
                });

            modelBuilder.Entity("FinFlow.Models.IncomeCategoryModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("IncomeModelId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IncomeModelId");

                    b.ToTable("IncomeCategories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Salary"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Freelance"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Investments"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Bonus"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Commissions"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Gifts"
                        });
                });

            modelBuilder.Entity("FinFlow.Models.IncomeModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Amount")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<int?>("incCategoryID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("incCategoryID");

                    b.ToTable("Incomes");
                });

            modelBuilder.Entity("FinFlow.Models.ItemsModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

                    b.Property<int?>("ExpenseModelId")
                        .HasColumnType("int");

                    b.Property<string>("Measurement")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("ExpenseModelId");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("FinFlow.Models.PaymentTypeModel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("PaymentTypes");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Name = "Cash"
                        },
                        new
                        {
                            ID = 2,
                            Name = "Credit Card"
                        },
                        new
                        {
                            ID = 3,
                            Name = "Debit Card"
                        },
                        new
                        {
                            ID = 4,
                            Name = "Bank Transfer"
                        },
                        new
                        {
                            ID = 5,
                            Name = "Mobile Money"
                        },
                        new
                        {
                            ID = 6,
                            Name = "Cheque"
                        },
                        new
                        {
                            ID = 7,
                            Name = "Cryptocurrency"
                        },
                        new
                        {
                            ID = 8,
                            Name = "Digital Wallets"
                        },
                        new
                        {
                            ID = 9,
                            Name = "Prepaid Card"
                        },
                        new
                        {
                            ID = 10,
                            Name = "Online Payment Gateways"
                        });
                });

            modelBuilder.Entity("FinFlow.Models.TransTypeModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TransactionType");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Income"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Expense"
                        });
                });

            modelBuilder.Entity("FinFlow.Models.TransactionModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Amount")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("AttachmentModelId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int?>("LinkedEntityId")
                        .HasColumnType("int");

                    b.Property<int?>("PaymentTypeID")
                        .HasColumnType("int");

                    b.Property<string>("RefNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TransTypesId")
                        .HasColumnType("int");

                    b.Property<int?>("TypeID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AttachmentModelId");

                    b.HasIndex("PaymentTypeID")
                        .IsUnique()
                        .HasFilter("[PaymentTypeID] IS NOT NULL");

                    b.HasIndex("TransTypesId");

                    b.HasIndex("TypeID")
                        .IsUnique()
                        .HasFilter("[TypeID] IS NOT NULL");

                    b.ToTable("Transactions");
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
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

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

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

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

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

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
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

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
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("FinFlow.Models.AttachmentModel", b =>
                {
                    b.HasOne("FinFlow.Models.TransactionModel", "Transaction")
                        .WithMany("Attachments")
                        .HasForeignKey("TransactionID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Transaction");
                });

            modelBuilder.Entity("FinFlow.Models.CategoryModel", b =>
                {
                    b.HasOne("FinFlow.Models.ItemsModel", null)
                        .WithMany("Categories")
                        .HasForeignKey("ItemsModelId");
                });

            modelBuilder.Entity("FinFlow.Models.ExpenseModel", b =>
                {
                    b.HasOne("FinFlow.Models.BudgetModel", "Budget")
                        .WithMany("expenses")
                        .HasForeignKey("BudgetID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("FinFlow.Models.ItemsModel", "Item")
                        .WithMany()
                        .HasForeignKey("ItemId");

                    b.Navigation("Budget");

                    b.Navigation("Item");
                });

            modelBuilder.Entity("FinFlow.Models.IncomeCategoryModel", b =>
                {
                    b.HasOne("FinFlow.Models.IncomeModel", null)
                        .WithMany("IncomeCategories")
                        .HasForeignKey("IncomeModelId");
                });

            modelBuilder.Entity("FinFlow.Models.IncomeModel", b =>
                {
                    b.HasOne("FinFlow.Models.IncomeCategoryModel", "incomeCategory")
                        .WithMany("incomes")
                        .HasForeignKey("incCategoryID");

                    b.Navigation("incomeCategory");
                });

            modelBuilder.Entity("FinFlow.Models.ItemsModel", b =>
                {
                    b.HasOne("FinFlow.Models.CategoryModel", "Category")
                        .WithMany("Items")
                        .HasForeignKey("CategoryId");

                    b.HasOne("FinFlow.Models.ExpenseModel", null)
                        .WithMany("items")
                        .HasForeignKey("ExpenseModelId");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("FinFlow.Models.TransactionModel", b =>
                {
                    b.HasOne("FinFlow.Models.AttachmentModel", null)
                        .WithMany("Transactions")
                        .HasForeignKey("AttachmentModelId");

                    b.HasOne("FinFlow.Models.PaymentTypeModel", "PaymentType")
                        .WithOne("Transaction")
                        .HasForeignKey("FinFlow.Models.TransactionModel", "PaymentTypeID");

                    b.HasOne("FinFlow.Models.TransTypeModel", "TransTypes")
                        .WithMany()
                        .HasForeignKey("TransTypesId");

                    b.HasOne("FinFlow.Models.TransTypeModel", "TransType")
                        .WithOne("Transaction")
                        .HasForeignKey("FinFlow.Models.TransactionModel", "TypeID");

                    b.Navigation("PaymentType");

                    b.Navigation("TransType");

                    b.Navigation("TransTypes");
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
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
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

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FinFlow.Models.AttachmentModel", b =>
                {
                    b.Navigation("Transactions");
                });

            modelBuilder.Entity("FinFlow.Models.BudgetModel", b =>
                {
                    b.Navigation("expenses");
                });

            modelBuilder.Entity("FinFlow.Models.CategoryModel", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("FinFlow.Models.ExpenseModel", b =>
                {
                    b.Navigation("items");
                });

            modelBuilder.Entity("FinFlow.Models.IncomeCategoryModel", b =>
                {
                    b.Navigation("incomes");
                });

            modelBuilder.Entity("FinFlow.Models.IncomeModel", b =>
                {
                    b.Navigation("IncomeCategories");
                });

            modelBuilder.Entity("FinFlow.Models.ItemsModel", b =>
                {
                    b.Navigation("Categories");
                });

            modelBuilder.Entity("FinFlow.Models.PaymentTypeModel", b =>
                {
                    b.Navigation("Transaction");
                });

            modelBuilder.Entity("FinFlow.Models.TransTypeModel", b =>
                {
                    b.Navigation("Transaction");
                });

            modelBuilder.Entity("FinFlow.Models.TransactionModel", b =>
                {
                    b.Navigation("Attachments");
                });
#pragma warning restore 612, 618
        }
    }
}
