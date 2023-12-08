using Newton_Bibliotek_Alina.Data;
using Newton_Bibliotek_Alina.Models;

namespace Newton_Bibliotek_Alina
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Library:");
            DataAccess dataAccess = new();

            //dataAccess.Seed();

            //dataAccess.GetAvailableBooks();
            // dataAccess.ReturnBook(4);
            //dataAccess.GetAvailableBooks();
            // dataAccess.BorrowBook(8,4);   // 8 is the book (Harry Potter -2000 year) , 4 is the borrower 
            //dataAccess.ReturnBook(8);

        }
    }
}