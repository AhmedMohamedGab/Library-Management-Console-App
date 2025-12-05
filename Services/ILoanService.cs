using System;
using System.Collections.Generic;
using System.Text;
using LibraryManagement.Entities;

namespace LibraryManagement.Services
{
    internal interface ILoanService
    {
        bool BorrowBook(int memberId, string bookId);
        bool ReturnBook(int loanId);
        List<Loan> GetActiveLoans();
        List<Loan> GetAllLoans();
    }
}
