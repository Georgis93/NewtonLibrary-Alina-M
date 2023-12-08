using Newton_Bibliotek_Alina.Data;
using Newton_Bibliotek_Alina.Models;
using System.Data;

namespace Newton_Bibliotek_Alina
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Library:");
            DataAccess dataAccess = new();

            //dataAccess.Seed();
            //dataAccess.BorrowBook(3, 1);
            //dataAccess.GetAvailableBooks();
             dataAccess.ReturnBook(3);
            //dataAccess.GetAvailableBooks();
            // dataAccess.BorrowBook(8,4);   // 8 is the book (Harry Potter -2000 year) , 4 is the borrower 
            //dataAccess.ReturnBook(8);

        }
    }
}