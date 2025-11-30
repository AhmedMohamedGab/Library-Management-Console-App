using System;
using System.Collections.Generic;
using System.Text;
using LibraryManagement.Entities;

namespace LibraryManagement.Services
{
    internal interface IBookService
    {
        void AddBook(Book book);
        void RemoveBook(int id);
        Book? GetBookById(int id);
        List<Book> GetAllBooks();
        List<Book> SearchBooks(string keyword);
    }
}
