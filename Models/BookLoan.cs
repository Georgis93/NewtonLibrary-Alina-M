using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Newton_Bibliotek_Alina.Models
{
    internal class BookLoan
    {
        public int BookLoanId { get; set; }
        public int BookId { get; set; }
        public int BorrowerId { get; set; }
        public DateTime? BorrowedDate {  get; set; }
        public DateTime? ReturnedDate { get; set; }

        public Book Book { get; set; }
        public Borrower Borrower { get; set; }

        public BookLoan()
        {
            
        }
    }
}
