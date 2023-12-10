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
             dataAccess.ReturnBook(3);
          
           
         

        }
    }
}