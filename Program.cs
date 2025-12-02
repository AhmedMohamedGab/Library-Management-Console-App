using LibraryManagement.Data;
using LibraryManagement.Services;
using LibraryManagement.UI;

namespace LibraryManagement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IDataStore dataStore = new DataStore();
            IBookService bookService = new BookService(dataStore);
            IMemberService memberService = new MemberService(dataStore);
            ILoanService loanService = new LoanService(dataStore);

            Menu menu = new Menu(bookService, memberService, loanService);
            menu.Start();
        }
    }
}
