using EntityFrameworkCore.EncryptColumn.Attribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Newton_Bibliotek_Alina.Models
{
    internal class Borrower
    { 
        public int BorrowerId { get; set; }   
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string LibraryCardNumber { get; set; }

        [EncryptColumn]
        public int PIN { get; set; }
       public ICollection<BookLoan> BookLoans { get; set; } = new List<BookLoan>();

        public Borrower()
        {
            
        }

    }
}
