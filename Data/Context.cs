using EntityFrameworkCore.EncryptColumn.Extension;
using EntityFrameworkCore.EncryptColumn.Interfaces;
using EntityFrameworkCore.EncryptColumn.Util;
using Microsoft.EntityFrameworkCore;
using Newton_Bibliotek_Alina.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;


namespace Newton_Bibliotek_Alina.Data
{
    internal class Context : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Borrower> Borrowers { get; set; }
        public DbSet<BookLoan> BookLoans { get; set; }


        private readonly IEncryptionProvider _provider;
        public Context()
        {

            this._provider = new GenerateEncryptionProvider("adw5hdfidi3232vgkj34ftqrr34ump9f");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<BookLoan>()
          .HasOne(bl => bl.Borrowers)
          .WithMany(b => b.BookLoans)
           .HasForeignKey(bl => bl.BorrowerId)
          .OnDelete(DeleteBehavior.NoAction);

            base.OnModelCreating(modelBuilder);

            modelBuilder.UseEncryption(this._provider);
        }
       
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost; Database=Newton Bibliotek Alina; Trusted_Connection=True; Trust Server Certificate =Yes; User Id=NewtonLibrary; password=NewtonLibrary");
        }
       
       


    }
}
