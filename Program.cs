using Newton_Bibliotek_Alina.Data;

namespace Newton_Bibliotek_Alina
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Library");

            DataAccess dataAccess = new DataAccess();
            dataAccess.Seed();
        }
    }
}