using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagement.Entities
{
    internal class Loan
    {
        public int Id { get; set; }
        public int MemberId { get; set; }
        public string BookId { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
}
