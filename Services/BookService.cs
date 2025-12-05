using System;
using System.Collections.Generic;
using System.Text;
using LibraryManagement.Data;
using LibraryManagement.Entities;

namespace LibraryManagement.Services
{
    internal class BookService : IBookService
    {
        private readonly IDataStore _store;
        private const string FileName = "books.json";

        public BookService(IDataStore store)
        {
            _store = store;
        }

        public List<Book> SearchBooks(string keyword)
        {
            var books = _store.Load<Book>(FileName);
            var results = books.FindAll(b => b.ISBN.Contains(keyword) ||
                                             b.Title.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                                             b.Author.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                                             b.Category.Contains(keyword, StringComparison.OrdinalIgnoreCase));

            return results;
        }

        public bool AddBook(string isbn, string title, string author, string category)
        {
            if (isbn == "" || title == "" || author == "" || category == "") return false;

            var books = _store.Load<Book>(FileName);

            var searchedBook = books.Find(b => b.ISBN == isbn);
            if (searchedBook != null) return false;

            var newBook = new Book { ISBN = isbn, Title = title, Author = author, Category = category };
            books.Add(newBook);
            _store.Save<Book>(FileName, books);

            return true;
        }

        public bool RemoveBook(string ISBN)
        {
            var books = _store.Load<Book>(FileName);
            var bookToRemove = books.Find(b => b.ISBN == ISBN);
            if (bookToRemove == null) return false;
            books.Remove(bookToRemove);
            _store.Save<Book>(FileName, books);
            return true;
        }

        public List<Book> GetAvailableBooks()
        {
            var books = _store.Load<Book>(FileName);
            var availableBooks = books.FindAll(b => b.IsAvailable);

            return availableBooks;
        }

        public List<Book> GetAllBooks()
        {
            var books = _store.Load<Book>(FileName);

            return books;
        }
    }
}
