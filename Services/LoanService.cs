using System;
using System.Collections.Generic;
using System.Text;
using LibraryManagement.Data;
using LibraryManagement.Entities;

namespace LibraryManagement.Services
{
    internal class LoanService : ILoanService
    {
        private readonly IDataStore _store;
        private const string FileName = "loans.json";

        public LoanService(IDataStore store)
        {
            _store = store;
        }

        public bool BorrowBook(int memberId, string bookId)
        {
            var members = _store.Load<Member>("members.json");
            var member = members.Find(m => m.Id == memberId);
            var books = _store.Load<Book>("books.json");
            var book = books.Find(b => b.ISBN == bookId);

            if (member == null || book == null || !book.IsAvailable) return false;

            var loans = _store.Load<Loan>(FileName);

            var loan = new Loan
            {
                Id = loans.Count + 1,
                MemberId = memberId,
                BookId = bookId,
                BorrowDate = DateTime.Now
            };

            book.IsAvailable = false;
            _store.Save("books.json", books);
            loans.Add(loan);
            _store.Save(FileName, loans);

            return true;
        }

        public bool ReturnBook(int loanId)
        {
            var loans = _store.Load<Loan>(FileName);
            var loanToReturn = loans.Find(l => l.Id == loanId && l.ReturnDate == null);

            if (loanToReturn == null) return false;

            var books = _store.Load<Book>("books.json");
            var bookToReturn = books.Find(b => b.ISBN == loanToReturn.BookId);

            if (bookToReturn == null) return false;

            bookToReturn.IsAvailable = true;
            _store.Save("books.json", books);

            loanToReturn.ReturnDate = DateTime.Now;
            _store.Save(FileName, loans);

            return true;
        }

        public List<Loan> GetActiveLoans()
        {
            var loans = _store.Load<Loan>(FileName);
            var activeLoans = loans.FindAll(l => l.ReturnDate == null);

            return activeLoans;
        }

        public List<Loan> GetAllLoans()
        {
            var loans = _store.Load<Loan>(FileName);

            return loans;
        }
    }
}
