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
            // dataAccess.BorrowBook(8, 3); // Låna en bok
            // dataAccess.ReturnBook(8);       // Lämna tillbaka en bok


            //dataAccess.AddBookToDatabase("The Little Prince", 3); // Lägg till bok i databasen
            // dataAccess.DeleteBook(9);  // Ta bort en book från databasen 

           // dataAccess.AddAuthorToDatabase("Karl May"); // 
            //dataAccess.DeleteAuthor(9); // 

            //dataAccess.AddBorrowerToDatabase("Alina", "Mititelu", "254906AM54");
            //dataAccess.DeleteBorrower(9); // Ta bort borrower med ID 

            //dataAccess.DeleteBook(3);      // Ta bort book med ID 
            dataAccess.DeleteAuthor(11);    // Ta bort author med ID 





        }
    }
}