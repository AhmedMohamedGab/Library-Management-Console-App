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
                Console.WriteLine("2. List All Books");
                Console.WriteLine("3. Search Books");
                Console.WriteLine("4. Remove Book");
                Console.WriteLine("5. Back To Main Menu");
                Console.WriteLine("======================");

                Console.Write("Choose an option: ");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddBookUI();
                        break;
                    case "2":
                        ListBooksUI();
                        break;
                    case "3":
                        SearchBooksUI();
                        break;
                    case "4":
                        RemoveBookUI();
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

            var newBook = new Book { Title = title, Author = author, Category = category };
            bool success = _bookService.AddBook(newBook);
            Console.WriteLine(success
            ? "Book added successfully."
            : "Failed to add book. It may already exist or data was invalid.");

            Pause();
        }

        private void ListBooksUI()
        {
            Console.Clear();
            Console.WriteLine("====== Books List ======");

            var books = _bookService.GetAllBooks();

            if (books.Count == 0)
            {
                Console.WriteLine("No books found.");
            }
            else
            {
                foreach (var book in books)
                {
                    Console.WriteLine($"{book.Id} | {book.Title} by {book.Author} | Category: {book.Category}");
                }
            }

            Pause();
        }

        private void SearchBooksUI()
        {
            Console.Clear();
            Console.WriteLine("====== Search Books ======");
            Console.Write("Enter a keyword to search (title, author, or category): ");
            string term = Console.ReadLine() ?? "";

            var results = _bookService.SearchBooks(term);

            if (results.Count == 0)
            {
                Console.WriteLine("No matching books found.");
            }
            else
            {
                Console.WriteLine("Results:");
                foreach (var book in results)
                {
                    Console.WriteLine($"{book.Id} | {book.Title} by {book.Author} | Category: {book.Category}");
                }
            }

            Pause();
        }

        private void RemoveBookUI()
        {
            Console.Clear();
            Console.WriteLine("====== Remove Book ======");

            Console.Write("ID: ");
            bool success = int.TryParse(Console.ReadLine() ?? "", out int id);

            if (!success)
            {
                Console.WriteLine("Failed to remove book. This ID is invalid.");
                Pause();
                return;
            }

            success = _bookService.RemoveBook(id);
            Console.WriteLine(success
            ? "Book removed successfully."
            : "Failed to remove book. This ID is invalid.");

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
                Console.WriteLine("3. Back To Main Menu");
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
            // TODO: Ask for name & phone → Call _memberService.AddMember(...)
            Pause();
        }

        private void ListMembersUI()
        {
            // TODO: Display members from _memberService.GetAllMembers()
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
