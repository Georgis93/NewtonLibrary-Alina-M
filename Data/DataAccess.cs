using Newton_Bibliotek_Alina.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
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

                Book book2 = new();
                book2.Title = "Winnetou";
                book2.ISBN = "13:978-0-307-98702-1";
                book2.ReleaseYear = 1842;
                book2.IsLoaned = false;

                Book book3 = new();
                book3.Title = "The Little Prince";
                book3.ISBN = "13:978-0-9791860-3-0";
                book3.ReleaseYear = 1943;


                Author author1 = new Author();
                author1.Name = "Mark Twain";
                Author author2 = new Author();
                author2.Name = "Karl May";
                Author author3 = new Author();
                author3.Name = "Antoine de Saint-Exupéry";

                Borrower customer1 = new Borrower();
                customer1.FirstName = "Alina";
                customer1.LastName = "Mititelu";
                customer1.LibraryCardNumber = "254906AM54";
                customer1.PIN = 15790;
                book3.IsLoaned = true;

                Borrower customer2 = new Borrower();
                customer2.FirstName = "Sven";
                customer2.LastName = "Andersson";
                customer2.LibraryCardNumber = "55678SV04";
                customer2.PIN = 47845;

                Borrower customer3 = new Borrower();
                customer3.FirstName = "Ewa";
                customer3.LastName = "Paseri";
                customer3.LibraryCardNumber = "58124EP19";
                customer3.PIN = 00346;


                context.Books.Add(book1);
                context.Books.Add(book2);
                context.Books.Add(book3);

                context.Borrowers.Add(customer1);
                context.Borrowers.Add(customer2);
                context.Borrowers.Add(customer3);

                context.Authors.Add(author1);
                context.Authors.Add(author2);
                context.Authors.Add(author3);

                context.SaveChanges();
            }
        }

    }
}
