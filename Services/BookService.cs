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
        public void AddBook(Book book)
        {
            throw new NotImplementedException();
        }

        public List<Book> GetAllBooks()
        {
            throw new NotImplementedException();
        }

        public Book? GetBookById(int id)
        {
            throw new NotImplementedException();
        }

        public void RemoveBook(int id)
        {
            throw new NotImplementedException();
        }

        public List<Book> SearchBooks(string keyword)
        {
            throw new NotImplementedException();
        }
    }
}
