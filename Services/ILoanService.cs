using System;
using System.Collections.Generic;
using System.Text;
using LibraryManagement.Entities;

namespace LibraryManagement.Services
{
    internal interface ILoanService
    {
        void BorrowBook(int bookId, int memberId);
        void ReturnBook(int loanId);
        Loan? GetLoanById(int id);
        List<Loan> GetActiveLoans();
        List<Loan> GetAllLoans();
    }
}
