﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Newton_Bibliotek_Alina.Data;

#nullable disable

namespace Newton_Bibliotek_Alina.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AuthorBook", b =>
                {
                    b.Property<int>("AuthorsAuthorId")
                        .HasColumnType("int");

                    b.Property<int>("BooksBookId")
                        .HasColumnType("int");

                    b.HasKey("AuthorsAuthorId", "BooksBookId");

                    b.HasIndex("BooksBookId");

                    b.ToTable("AuthorBook");
                });

            modelBuilder.Entity("BookBookLoan", b =>
                {
                    b.Property<int>("BookLoansBookLoanId")
                        .HasColumnType("int");

                    b.Property<int>("BooksBookId")
                        .HasColumnType("int");

                    b.HasKey("BookLoansBookLoanId", "BooksBookId");

                    b.HasIndex("BooksBookId");

                    b.ToTable("BookBookLoan");
                });

            modelBuilder.Entity("Newton_Bibliotek_Alina.Models.Author", b =>
                {
                    b.Property<int>("AuthorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AuthorId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AuthorId");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("Newton_Bibliotek_Alina.Models.Book", b =>
                {
                    b.Property<int>("BookId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BookId"));

                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<bool>("IsLoaned")
                        .HasColumnType("bit");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<int>("ReleaseYear")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BookId");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("Newton_Bibliotek_Alina.Models.BookLoan", b =>
                {
                    b.Property<int>("BookLoanId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BookLoanId"));

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("BorrowedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("BorrowerId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ReturnDate")
                        .HasColumnType("datetime2");

                    b.HasKey("BookLoanId");

                    b.HasIndex("BorrowerId");

                    b.ToTable("BookLoans");
                });

            modelBuilder.Entity("Newton_Bibliotek_Alina.Models.Borrower", b =>
                {
                    b.Property<int>("BorrowerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BorrowerId"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LibraryCardNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PIN")
                        .HasColumnType("int");

                    b.HasKey("BorrowerId");

                    b.ToTable("Borrowers");
                });

            modelBuilder.Entity("AuthorBook", b =>
                {
                    b.HasOne("Newton_Bibliotek_Alina.Models.Author", null)
                        .WithMany()
                        .HasForeignKey("AuthorsAuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Newton_Bibliotek_Alina.Models.Book", null)
                        .WithMany()
                        .HasForeignKey("BooksBookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BookBookLoan", b =>
                {
                    b.HasOne("Newton_Bibliotek_Alina.Models.BookLoan", null)
                        .WithMany()
                        .HasForeignKey("BookLoansBookLoanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Newton_Bibliotek_Alina.Models.Book", null)
                        .WithMany()
                        .HasForeignKey("BooksBookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Newton_Bibliotek_Alina.Models.BookLoan", b =>
                {
                    b.HasOne("Newton_Bibliotek_Alina.Models.Borrower", "Borrowers")
                        .WithMany("BookLoans")
                        .HasForeignKey("BorrowerId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Borrowers");
                });

            modelBuilder.Entity("Newton_Bibliotek_Alina.Models.Borrower", b =>
                {
                    b.Navigation("BookLoans");
                });
#pragma warning restore 612, 618
        }
    }
}
