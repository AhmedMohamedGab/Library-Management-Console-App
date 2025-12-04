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

        public bool BorrowBook(int memberId, int bookId)
        {
            throw new NotImplementedException();
        }

        public bool ReturnBook(int loanId)
        {
            throw new NotImplementedException();
        }

        public List<Loan> GetActiveLoans()
        {
            throw new NotImplementedException();
        }

        public List<Loan> GetAllLoans()
        {
            throw new NotImplementedException();
        }
    }
}
