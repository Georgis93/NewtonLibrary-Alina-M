using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Newton_Bibliotek_Alina.Models
{
    internal class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }
        public int ReleaseYear { get; set; }
        public int Rating {  get; set; }
        public bool IsLoaned { get; set; }
        public int AuthorId { get; set; }
        public ICollection<Author> Authors { get; set; } = new List<Author>();
        public ICollection<BookLoan> BookLoans { get; set; }= new List<BookLoan>();
       
        public Book()
        {
            
        }
    }
}
