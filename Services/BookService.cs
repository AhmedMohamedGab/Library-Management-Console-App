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
            var searchedBooks = new List<Book>();

            foreach (var book in books)
            {
                if (book.Title.Contains(keyword) || book.Author.Contains(keyword) || book.Category.Contains(keyword))
                {
                    searchedBooks.Add(book);
                }
            }

            return searchedBooks;
        }

        public bool AddBook(Book book)
        {
            if (book.Title == "" || book.Author == "" || book.Category == "") return false;

            var books = _store.Load<Book>(FileName);

            foreach (var searchedBook in books)
            {
                if (searchedBook.Title == book.Title && searchedBook.Author == book.Author) return false;
            }

            book.Id = books.Count + 1;
            books.Add(book);
            _store.Save<Book>(FileName, books);

            return true;
        }

        public List<Book> GetAllBooks()
        {
            var books = _store.Load<Book>(FileName);

            return books;
        }
    }
}
