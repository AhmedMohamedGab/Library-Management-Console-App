using System;
using System.Collections.Generic;
using System.Text;
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
                Console.WriteLine("1. Books");
                Console.WriteLine("2. Members");
                Console.WriteLine("3. Loans");
                Console.WriteLine("4. Exit");
                Console.WriteLine("====================================");

                Console.Write("Choose an option: ");
                string choice = Console.ReadLine();

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
                string choice = Console.ReadLine();

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
            // TODO: Ask for Title, Author, Category → Call _bookService.AddBook(...)
            Pause();
        }

        private void ListBooksUI()
        {
            // TODO: Display books from _bookService.GetAllBooks()
            Pause();
        }

        private void SearchBooksUI()
        {
            // TODO: Ask for keyword → Call _bookService.SearchBooks(...)
            Pause();
        }

        private void RemoveBookUI()
        {
            // TODO: Ask for ID → Call _bookService.RemoveBook(id)
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
                string choice = Console.ReadLine();

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
                Console.WriteLine("=======================");

                Console.Write("Choose an option: ");
                string choice = Console.ReadLine();

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
