using System;
using System.Collections.Generic;
using System.Text;
using LibraryManagement.Entities;

namespace LibraryManagement.Services
{
    internal interface IBookService
    {
        List<Book> SearchBooks(string keyword);
        bool AddBook(Book book);
        List<Book> GetAllBooks();
    }
}
