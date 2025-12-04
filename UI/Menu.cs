using System;
using System.Collections.Generic;
using System.Text;
using LibraryManagement.Entities;
using LibraryManagement.Services;

namespace LibraryManagement.UI
{
    internal class Menu
    {
        private readonly IBookService _bookService;
        private readonly IMemberService _memberService;
        private readonly ILoanService _loanService;

        public Menu(IBookService bookService, IMemberService memberService, ILoanService loanService)
        {
            _bookService = bookService;
            _memberService = memberService;
            _loanService = loanService;
        }

        public void Start()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("===== Library Management System =====");
                Console.WriteLine("1. Manage Books");
                Console.WriteLine("2. Manage Members");
                Console.WriteLine("3. Manage Loans");
                Console.WriteLine("4. Exit");
                Console.WriteLine("=====================================");

                Console.Write("Choose an option: ");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        BooksMenu();
                        break;
                    case "2":
                        MembersMenu();
                        break;
                    case "3":
                        LoansMenu();
                        break;
                    case "4":
                        Console.WriteLine("Exiting...");
                        return;
                    default:
                        Console.WriteLine("Invalid option.");
                        Pause();
                        break;
                }
            }
        }

        // ============================================================
        // BOOKS MENU
        // ============================================================

        private void BooksMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("===== Books Menu =====");
                Console.WriteLine("1. Add Book");
                Console.WriteLine("2. List Available Books");
                Console.WriteLine("3. List All Books");
                Console.WriteLine("4. Search Books");
                Console.WriteLine("5. Remove Book");
                Console.WriteLine("6. Back To Main Menu");
                Console.WriteLine("======================");

                Console.Write("Choose an option: ");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddBookUI();
                        break;
                    case "2":
                        ListAvailableBooksUI();
                        break;
                    case "3":
                        ListAllBooksUI();
                        break;
                    case "4":
                        SearchBooksUI();
                        break;
                    case "5":
                        RemoveBookUI();
                        break;
                    case "6":
                        return;
                    default:
                        Console.WriteLine("Invalid option.");
                        Pause();
                        break;
                }
            }
        }

        private void AddBookUI()
        {
            Console.Clear();
            Console.WriteLine("====== Add Book ======");

            Console.Write("Title: ");
            string title = Console.ReadLine() ?? "".Trim();
            Console.Write("Author: ");
            string author = Console.ReadLine() ?? "".Trim();
            Console.Write("Category: ");
            string category = Console.ReadLine() ?? "".Trim();
            Console.Write("ISBN: ");
            string isbn = Console.ReadLine() ?? "".Trim();

            var newBook = new Book { ISBN = isbn, Title = title, Author = author, Category = category };
            bool success = _bookService.AddBook(newBook);
            Console.WriteLine(success
            ? "Book added successfully."
            : "Failed to add book. It may already exist or data was invalid.");

            Pause();
        }

        private void ListAvailableBooksUI()
        {
            Console.Clear();
            Console.WriteLine("====== Available Books List ======");

            var availableBooks = _bookService.GetAvailableBooks();

            if (availableBooks.Count == 0) Console.WriteLine("No books found.");
            else
            {
                for (int i = 0; i < availableBooks.Count; i++)
                {
                    Console.WriteLine($"{i + 1} | {availableBooks[i].Title} by {availableBooks[i].Author}" +
                        $" | Category: {availableBooks[i].Category} | ISBN: {availableBooks[i].ISBN}");
                }
            }

            Pause();
        }

        private void ListAllBooksUI()
        {
            Console.Clear();
            Console.WriteLine("====== All Books List ======");

            var allBooks = _bookService.GetAllBooks();

            if (allBooks.Count == 0) Console.WriteLine("No books found.");
            else
            {
                for (int i = 0; i < allBooks.Count; i++)
                {
                    Console.WriteLine($"{i + 1} | {allBooks[i].Title} by {allBooks[i].Author}" +
                        $" | Category: {allBooks[i].Category} | ISBN: {allBooks[i].ISBN}");
                }
            }

            Pause();
        }

        private void SearchBooksUI()
        {
            Console.Clear();
            Console.WriteLine("====== Search Books ======");
            Console.Write("Enter a keyword to search (title, author, category, or ISBN): ");
            string keyword = Console.ReadLine() ?? "";

            var results = _bookService.SearchBooks(keyword);

            if (results.Count == 0) Console.WriteLine("No matching books found.");
            else
            {
                Console.WriteLine("Results:");
                for (int i = 0; i < results.Count; i++)
                {
                    Console.WriteLine($"{i + 1} | {results[i].Title} by {results[i].Author}" +
                        $" | Category: {results[i].Category} | ISBN: {results[i].ISBN}");
                }
            }

            Pause();
        }

        private void RemoveBookUI()
        {
            Console.Clear();
            Console.WriteLine("====== Remove Book ======");

            Console.Write("ISBN: ");
            string ISBN = Console.ReadLine() ?? "";

            bool success = _bookService.RemoveBook(ISBN);
            Console.WriteLine(success
            ? "Book removed successfully."
            : "Failed to remove book. This ISBN is invalid.");

            Pause();
        }

        // ============================================================
        // MEMBERS MENU
        // ============================================================

        private void MembersMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("===== Members Menu =====");
                Console.WriteLine("1. Add Member");
                Console.WriteLine("2. List All Members");
                Console.WriteLine("3. Search Members");
                Console.WriteLine("4. Back To Main Menu");
                Console.WriteLine("========================");

                Console.Write("Choose an option: ");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddMemberUI();
                        break;
                    case "2":
                        ListMembersUI();
                        break;
                    case "3":
                        SearchMembersUI();
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("Invalid option.");
                        Pause();
                        break;
                }
            }
        }

        private void AddMemberUI()
        {
            Console.Clear();
            Console.WriteLine("====== Add Member ======");

            Console.Write("Name: ");
            string name = Console.ReadLine() ?? "";

            Console.Write("Phone: ");
            string phone = Console.ReadLine() ?? "";

            var newMember = new Member { Name = name, Phone = phone };
            bool success = _memberService.AddMember(newMember);
            Console.WriteLine(success
            ? "Member added successfully."
            : "Failed to add member. He/She may already exist or data was invalid.");

            Pause();
        }

        private void ListMembersUI()
        {
            Console.Clear();
            Console.WriteLine("====== Members List ======");

            var members = _memberService.GetAllMembers();

            if (members.Count == 0) Console.WriteLine("No members found.");
            else
            {
                foreach (var member in members)
                {
                    Console.WriteLine($"{member.Id} | {member.Name} | {member.Phone}");
                }
            }

            Pause();
        }

        private void SearchMembersUI()
        {
            Console.Clear();
            Console.WriteLine("====== Search Members ======");
            Console.Write("Enter a keyword to search (name or phone): ");
            string keyword = Console.ReadLine() ?? "";

            var results = _memberService.SearchMembers(keyword);

            if (results.Count == 0) Console.WriteLine("No matching members found.");
            else
            {
                Console.WriteLine("Results:");
                foreach (var member in results)
                {
                    Console.WriteLine($"{member.Id} | {member.Name} | {member.Phone}");
                }
            }

            Pause();
        }

        // ============================================================
        // LOANS MENU
        // ============================================================

        private void LoansMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("===== Loans Menu =====");
                Console.WriteLine("1. Borrow Book");
                Console.WriteLine("2. Return Book");
                Console.WriteLine("3. List Active Loans");
                Console.WriteLine("4. List All Loans");
                Console.WriteLine("5. Back To Main Menu");
                Console.WriteLine("======================");

                Console.Write("Choose an option: ");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        BorrowBookUI();
                        break;
                    case "2":
                        ReturnBookUI();
                        break;
                    case "3":
                        ListActiveLoansUI();
                        break;
                    case "4":
                        ListAllLoansUI();
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Invalid option.");
                        Pause();
                        break;
                }
            }
        }

        private void BorrowBookUI()
        {
            // TODO: Ask for Book ID & Member ID → Call _loanService.BorrowBook(...)
            Pause();
        }

        private void ReturnBookUI()
        {
            // TODO: Ask for Loan ID → Call _loanService.ReturnBook(...)
            Pause();
        }

        private void ListActiveLoansUI()
        {
            // TODO: Display loans with _loanService.GetActiveLoans()
            Pause();
        }

        private void ListAllLoansUI()
        {
            // TODO: Display all loans with _loanService.GetAllLoans()
            Pause();
        }

        // ============================================================
        // Helper
        // ============================================================

        private void Pause()
        {
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }
}
