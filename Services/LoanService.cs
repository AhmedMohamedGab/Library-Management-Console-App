using System;
using System.Collections.Generic;
using System.Text;
using LibraryManagement.Entities;

namespace LibraryManagement.Services
{
    internal class LoanService : ILoanService
    {
        public void BorrowBook(int bookId, int memberId)
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

        public Loan? GetLoanById(int id)
        {
            throw new NotImplementedException();
        }

        public void ReturnBook(int loanId)
        {
            throw new NotImplementedException();
        }
    }
}
