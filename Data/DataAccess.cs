﻿using Microsoft.Identity.Client;
using Newton_Bibliotek_Alina.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Security.Authentication.ExtendedProtection;
using System.Text;
using System.Threading.Tasks;


namespace Newton_Bibliotek_Alina.Data
{
    internal class DataAccess
    {


        public void Seed()
        {
            using (Context context = new Context())
            {
                //Context context = new Context();
                Book book1 = new();
                book1.Title = "The Adventures of Tom Sawyer";
                book1.ISBN = "10:0-385-48602-8";
                book1.ReleaseYear = 1876;
                book1.IsLoaned = true;
                book1.Rating = 4;

                Book book2 = new();
                book2.Title = "Winnetou";
                book2.ISBN = "13:978-0-307-98702-1";
                book2.ReleaseYear = 1842;
                book2.IsLoaned = false;
                book2.Rating = 5;

                Book book3 = new();
                book3.Title = "The Little Prince";
                book3.ISBN = "13:978-0-9791860-3-0";
                book3.ReleaseYear = 1943;
                book3.Rating = 4;

                Book book4 = book3;
                book4.Title = book3.Title;
                book4.ISBN = book3.ISBN;
                book4.ReleaseYear = book3.ReleaseYear;
                book4.Rating = 5;

                Author author1 = new Author();
                author1.Name = "Mark Twain";
                Author author2 = new Author();
                author2.Name = "Karl May";
                Author author3 = new Author();
                author3.Name = "Antoine de Saint-Exupéry";
                Author author4 = author3;

                Borrower borrower1 = new Borrower();
                borrower1.FirstName = "Alina";
                borrower1.LastName = "Mititelu";
                borrower1.LibraryCardNumber = "254906AM54";
                borrower1.PIN = 15790;
               // book3.IsLoaned = true;

                Borrower borrower2 = new Borrower();
                borrower2.FirstName = "Sven";
                borrower2.LastName = "Andersson";
                borrower2.LibraryCardNumber = "55678SV04";
                borrower2.PIN = 47845;

                Borrower borrower3 = new Borrower();
                borrower3.FirstName = "Ewa";
                borrower3.LastName = "Paseri";
                borrower3.LibraryCardNumber = "58124EP19";
                borrower3.PIN = 45346;

                Borrower borrower4 = new Borrower();
                borrower4.FirstName = "Andresi";
                borrower4.LastName = "Milovici";
                borrower4.LibraryCardNumber = "5648AM98";
                borrower4.PIN = 76123;

                DateTime now = DateTime.Now;
                BookLoan bookLoan1 = new BookLoan();
                bookLoan1.BorrowedDate = now;
                bookLoan1.ReturnDate = now.AddDays(10);
                bookLoan1.Borrower = borrower1;
                bookLoan1.Books.Add(book1);

                BookLoan bookLoan2 = new BookLoan();
                bookLoan2.BorrowedDate = now;
                bookLoan2.ReturnDate = now.AddDays(10);
                bookLoan2.Borrower = borrower2;
                bookLoan2.Books.Add(book2);


                BookLoan bookLoan3 = new BookLoan();
                bookLoan3.BorrowedDate = now;
                bookLoan3.ReturnDate = now.AddDays(10);
                bookLoan3.Borrower= borrower3;
                bookLoan3.Books.Add(book3);

                BookLoan bookLoan4 = new BookLoan();
                bookLoan4.BorrowedDate = now;
                bookLoan4.ReturnDate = now.AddDays(10);
                bookLoan4.Borrower= borrower4;
                bookLoan4.Books.Add(book4);
                
                

                context.Books.AddRange(new List<Book>{ book1, book2, book3 });
                context.Borrowers.AddRange(new List<Borrower> { borrower1, borrower2, borrower3 });
                context.Authors.AddRange(new List<Author> { author1, author2, author3 });
                context.BookLoans.AddRange(new List<BookLoan> { bookLoan1,bookLoan2,bookLoan3});
                context.SaveChanges();
            }
           
        }

        public void BorrowBook(int bookId, int borrowerId)
        {
            using (Context context = new Context())
            {
                Book book = context.Books.Find(bookId);
                Borrower borrower = context.Borrowers.Find(borrowerId);

                if (book != null && borrower != null && !book.IsLoaned)
                {
                    //Set the book as loned
                    book.IsLoaned = true;

                    // Add a new loaned book
                    BookLoan bookLoan = new BookLoan
                    {
                        BorrowerId = borrowerId,
                        BorrowedDate = DateTime.Now
                    };
                    context.BookLoans.Add(bookLoan);

                    context.SaveChanges();
                }
            }

        }
        public void ReturnBook(int bookId)
        {
            using (Context context = new Context())
            {
                Book book = context.Books.Find(bookId);

                if (book != null && book.IsLoaned)
                {
                    // when the book is returned, set it to false
                    book.IsLoaned = false;

                    

                  // return the date of return
                    BookLoan? bookLoan = book.BookLoans.FirstOrDefault(bl => bl.ReturnDate == null);
                    if (bookLoan != null)
                    {
                        bookLoan.ReturnDate = DateTime.Now.AddDays(10);
                    }

                    context.SaveChanges();
                    
                }
            }
        }
        public void DeleteBorrower(int borrowerId)
        {
            //Context context = new Context();
            using (Context context = new Context())
            {
                Borrower ? borrower = context.Borrowers.Find(borrowerId);

                if (borrower != null)
                {
                    // Delete all the entries about a borrower
                    List<BookLoan> bookLoans = context.BookLoans.Where(bl => bl.BorrowerId == borrowerId).ToList();
                    context.BookLoans.RemoveRange(bookLoans);

                    // Delete the borrower
                    context.Borrowers.Remove(borrower);

                    context.SaveChanges();
                }
            }
        }
        public void DeleteBook(int bookId)
        {
            using (Context context = new Context())
            {
                Book ?book = context.Books.Find(bookId);

                if (book != null)
                {
                    // Delete everything about the book
                    List<BookLoan> bookLoans = context.BookLoans.Where(bl => bl.BorrowerId == bookId).ToList();
                    context.BookLoans.RemoveRange(bookLoans);

                    // Remove the book
                    context.Books.Remove(book);

                    context.SaveChanges();
                }
            }
        }
        public void DeleteAuthor(int authorId)
        {
            using (Context context = new Context())
            {
                Author? author = context.Authors.Find(authorId);

                if (author != null)
                {
                    // Delete all the books of the authir
                    List<Book> books = context.Books.Where(b => b.Authors.Any(a => a.AuthorId == authorId)).ToList();
                    foreach (var book in books)
                    {
                        // delete all the borrowed books from the author
                        List<BookLoan> bookLoans = context.BookLoans.Where(bl => bl.BorrowerId == book.BookId).ToList();
                        context.BookLoans.RemoveRange(bookLoans);

                        // Delete the book
                        context.Books.Remove(book);
                    }

                    // delete the author
                    context.Authors.Remove(author);

                    context.SaveChanges();
                }
            }
        }
    }
}
