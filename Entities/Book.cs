using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagement.Entities
{
    internal class Book
    {
        public string ISBN { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Category { get; set; }
        public bool IsAvailable { get; set; } = true;
    }
}
