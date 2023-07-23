﻿// <auto-generated />
using System;
using LibBook.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LibBook.Infrastructure.Migrations
{
    [DbContext(typeof(BookDbContext))]
    partial class BookDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("LibBook.Domain.AuthorAgg.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("LibBook.Domain.AuthorBook", b =>
                {
                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.HasKey("AuthorId", "BookId");

                    b.HasIndex("BookId");

                    b.ToTable("AuthorBooks");
                });

            modelBuilder.Entity("LibBook.Domain.BookAgg.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("ISBN")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("PublisherId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("TranslatorId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("LibBook.Domain.BookCategoryAgg.BookCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("BookCategories", (string)null);
                });

            modelBuilder.Entity("LibBook.Domain.BorrowAgg.Borrow", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmployeeId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("IdealReturnDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("MemberID")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ReturnDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ReturnEmployeeID")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Borrows", (string)null);
                });

            modelBuilder.Entity("LibBook.Domain.LendAgg.Lend", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmployeeId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("IdealReturnDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("MemberId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ReturnDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ReturnEmployeeId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Lends", (string)null);
                });

            modelBuilder.Entity("LibBook.Domain.PublisherAgg.Publisher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Publishers");
                });

            modelBuilder.Entity("LibBook.Domain.PublisherBook", b =>
                {
                    b.Property<int>("PublisherId")
                        .HasColumnType("int");

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.HasKey("PublisherId", "BookId");

                    b.HasIndex("BookId");

                    b.ToTable("PublisherBooks");
                });

            modelBuilder.Entity("LibBook.Domain.TranslatorAgg.Translator", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Translators");
                });

            modelBuilder.Entity("LibBook.Domain.TranslatorBook", b =>
                {
                    b.Property<int>("TranslatorId")
                        .HasColumnType("int");

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.HasKey("TranslatorId", "BookId");

                    b.HasIndex("BookId");

                    b.ToTable("TranslatorBooks");
                });

            modelBuilder.Entity("LibBook.Domain.AuthorBook", b =>
                {
                    b.HasOne("LibBook.Domain.AuthorAgg.Author", "Author")
                        .WithMany("AuthorBooks")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LibBook.Domain.BookAgg.Book", "Book")
                        .WithMany("AuthorBooks")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Book");
                });

            modelBuilder.Entity("LibBook.Domain.BookAgg.Book", b =>
                {
                    b.HasOne("LibBook.Domain.BookCategoryAgg.BookCategory", "Category")
                        .WithMany("Books")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("LibBook.Domain.LendAgg.Lend", b =>
                {
                    b.OwnsMany("LibBook.Domain.LendAgg.LendItem", "Items", b1 =>
                        {
                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int");

                            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b1.Property<int>("Id"));

                            b1.Property<int>("BookId")
                                .HasColumnType("int");

                            b1.Property<int>("Count")
                                .HasColumnType("int");

                            b1.Property<DateTime>("CreationDate")
                                .HasColumnType("datetime2");

                            b1.Property<int>("LendId")
                                .HasColumnType("int");

                            b1.HasKey("Id");

                            b1.HasIndex("LendId");

                            b1.ToTable("LendItems", (string)null);

                            b1.WithOwner("Lend")
                                .HasForeignKey("LendId");

                            b1.Navigation("Lend");
                        });

                    b.Navigation("Items");
                });

            modelBuilder.Entity("LibBook.Domain.PublisherBook", b =>
                {
                    b.HasOne("LibBook.Domain.BookAgg.Book", "Book")
                        .WithMany("PublisherBooks")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LibBook.Domain.PublisherAgg.Publisher", "Publisher")
                        .WithMany("PublisherBooks")
                        .HasForeignKey("PublisherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("Publisher");
                });

            modelBuilder.Entity("LibBook.Domain.TranslatorBook", b =>
                {
                    b.HasOne("LibBook.Domain.BookAgg.Book", "Book")
                        .WithMany("TranslatorBooks")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LibBook.Domain.TranslatorAgg.Translator", "Translator")
                        .WithMany("TranslatorBooks")
                        .HasForeignKey("TranslatorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("Translator");
                });

            modelBuilder.Entity("LibBook.Domain.AuthorAgg.Author", b =>
                {
                    b.Navigation("AuthorBooks");
                });

            modelBuilder.Entity("LibBook.Domain.BookAgg.Book", b =>
                {
                    b.Navigation("AuthorBooks");

                    b.Navigation("PublisherBooks");

                    b.Navigation("TranslatorBooks");
                });

            modelBuilder.Entity("LibBook.Domain.BookCategoryAgg.BookCategory", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("LibBook.Domain.PublisherAgg.Publisher", b =>
                {
                    b.Navigation("PublisherBooks");
                });

            modelBuilder.Entity("LibBook.Domain.TranslatorAgg.Translator", b =>
                {
                    b.Navigation("TranslatorBooks");
                });
#pragma warning restore 612, 618
        }
    }
}
