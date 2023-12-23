using Microsoft.Identity.Client;
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
            using Context context = new();
            Book book1 = new()
            {
                Title = "The Adventures of Tom Sawyer",
                ReleaseYear = 1876,
                Rating = 4,
                AuthorId = 1
            };

            Book book2 = new()
            {
                Title = "Winnetou Series: 1,2,3 ",
                ReleaseYear = 1842,
                IsLoaned = false,
                Rating = 5,
                AuthorId = 2
            };

            Book book3 = new()
            {
                Title = "The Little Prince",
                ReleaseYear = 1943,
                Rating = 4,
                AuthorId = 3
            };

            Book book4 = new()
            {
                Title = book3.Title,
                ReleaseYear = book3.ReleaseYear,
                Rating = 5,
                AuthorId = 4
            };

            Book book5 = new()
            {
                Title = "Harry Potter and the Philosopher's Stone",
                ReleaseYear = 1997,
                Rating = 5,
                AuthorId = 5
            };

            Book book6 = new()
            {
                Title = "Harry Potter and the Chamber of Secrets",
                ReleaseYear = 1998,
                Rating = 5,
                AuthorId = 6
            };

            Book book7 = new()
            {
                Title = "Harry Potter and the Prisoner of Azkaban",
                ReleaseYear = 1999,
                Rating = 5,
                AuthorId =7
            };

            Book book8 = new()
            {
                Title = "Harry Potter and the Goblet of Fire",
                ReleaseYear = 2000,
                Rating = 5,
                AuthorId = 8
            };


            Author author1 = new()
            {
                Name = "Mark Twain"
            };
            Author author2 = new()
            {
                Name = "Karl May"
            };
            Author author3 = new()
            {
                Name = "Antoine de Saint-Exupéry"
            };
            Author author4 = new()
            {
                Name = author3.Name
            };
            Author author5 = new()
            {
                Name = "J.K.Rowling"
            };
            Author author6 = new()
            {
                Name = author5.Name
            };
            Author author7 = new()
            {
                Name = author5.Name
            };
            Author author8 = new()
            {
                Name = author5.Name
            };

            Borrower borrower1 = new()
            {
                FirstName = "Alina",
                LastName = "Mititelu",
                LibraryCardNumber = "254906AM54",
                PIN = 15790
            };
            

            Borrower borrower2 = new()
            {
                FirstName = "Sven",
                LastName = "Andersson",
                LibraryCardNumber = "55678SV04",
                PIN = 47845
            };

            Borrower borrower3 = new()
            {
                FirstName = "Ewa",
                LastName = "Paseri",
                LibraryCardNumber = "58124EP19",
                PIN = 45346
            };

            Borrower borrower4 = new()
            {
                FirstName = "Andresi",
                LastName = "Milovici",
                LibraryCardNumber = "5648AM98",
                PIN = 76123
            };

            Borrower borrower5 = new()
            {
                FirstName = borrower2.FirstName,
                LastName = borrower2.LastName,
                LibraryCardNumber = borrower2.LibraryCardNumber,
                PIN = borrower2.PIN
            };



            context.Books.AddRange(new List<Book> { book1, book2, book3, book4, book5, book6, book7, book8 });
            context.Borrowers.AddRange(new List<Borrower> { borrower1, borrower2, borrower3, borrower4, borrower5 });
            context.Authors.AddRange(new List<Author> { author1, author2, author3, author4, author5, author6, author7, author8 });
           // context.BookLoans.AddRange(new List<BookLoan> { bookLoan1 });//bookLoan2, bookLoan3, bookLoan4, bookLoan5, bookLoan6, bookLoan7, bookLoan8 });

            context.SaveChanges();
            Console.WriteLine($"Your Libary have:  \n 1.{book1.Title} {author1.Name} \n 2.{book2.Title} {author2.Name}\n 3.{book2.Title}{author3.Name}\n 4.{book4.Title}{author4.Name}\n 5.{book5.Title}{author5.Name}\n 6.{book6.Title}{author6.Name} \n 7.{book7.Title}{author7.Name} \n 8.{book8.Title}{author8.Name} \n");
            Console.WriteLine($"Your Customer are: \n 1.{borrower1.FirstName} {borrower1.LastName}\n\n 2.{borrower2.FirstName} {borrower2.LastName}\n 3.{borrower3.FirstName} {borrower3.LastName}\n 4.{borrower4.FirstName} {borrower4.LastName}\n 5.{borrower5.FirstName},{borrower5.LastName}\n");

        }
       

        public void BorrowBook(int bookId, int borrowerId)
        {
            using (Context context = new())
            {
                Book book = context.Books.Find(bookId);
                Borrower borrower = context.Borrowers.Find(borrowerId);

                if (book != null && borrower != null && !book.IsLoaned)
                {
                    //Set the book as loned
                    book.IsLoaned = true;

                    // Add a new loaned book
                    BookLoan bookLoan = new()
                    {
                        // i added even bookId because is easier to follow which book is borrowed 
                        BorrowerId = borrowerId,
                        BorrowedDate = DateTime.Now,
                        ReturnDate = DateTime.Now.AddDays(11),  //added days that a borrower can have the book
                        BookId = bookId
                    };

                    context.BookLoans.Add(bookLoan);
                   

                    context.SaveChanges();
                    Console.WriteLine($"{book.Title} was borrowed by {borrower.FirstName}");
                }
            }

        }
        public void ReturnBook(int bookId)
        {
            using (Context context = new())
            {
                Book book = context.Books.Find(bookId);

                if (book != null && book.IsLoaned)
                {
                    // when the book is returned, set it to false
                    book.IsLoaned = false;

                    /* BookLoan bookLoan = context.BookLoans.Find(bookId);

                     if (bookLoan != null)
                     {
                         bookLoan.BorrowedDate = null;
                         bookLoan.ReturnDate = DateTime.Now;
                         //bookLoan.BorrowerId = borrowerId;
                         bookLoan.BookId = bookId;
                     }*/

                    


                    context.SaveChanges();
                    Console.WriteLine($"{book.Title} was returned");
                }
            }
        }

        public void CreateBorrow(string firstName, string lastName, string libraryCardNumber)
        {
            using (var context = new Context())
            {
                var borrower = new Borrower
                {
                    FirstName = firstName,
                    LastName = lastName,
                    LibraryCardNumber = libraryCardNumber
                };

                context.Borrowers.Add(borrower);
                context.SaveChanges();
            }
        }
        public void DeleteBorrower(int borrowerId)
        {
            //Context context = new Context();
            using (Context context = new())
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
                    Console.WriteLine($"{borrower.FirstName} {borrower.LastName} was removed from Library>! ");
                }
            }
        }
        public void CreateBook(string title, params int[] authorIds)
        {
            using (var context = new Context())
            {
                var authors = context.Authors.Where(a => authorIds.Contains(a.AuthorId)).ToList();

                var book = new Book
                {
                    Title = title,
                    Authors = authors,
                    Rating = new Random().Next(1, 5),
                    ReleaseYear = new Random().Next(1842, 2020),
                    
                };

                context.Books.Add(book);
                context.SaveChanges();
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
                    Console.WriteLine($"{book.Title} was removed from Library!");
                }
            }
        }
        public void CreateBook(string name)
        {
            using (var context = new Context())
            {
                var author =new Author
                {
                   Name = name,
                };

                context.Authors.Add(author);
                context.SaveChanges();
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
                    Console.WriteLine($"{author.Name} was removed from Library!");
                }
            }
           

           
          
        }
    }
}
