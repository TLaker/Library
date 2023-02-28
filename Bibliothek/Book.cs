using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliothek
{
    internal class Book : Medium
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int SizeOfPages { get; set; }

        public Book(int id, string title, string author, int sizeOfPages, string description, double cost, bool isBorrowable, int borrowableDays) : base(id, description, cost, isBorrowable, borrowableDays)
        {
            Title = title;
            Author = author;
            SizeOfPages = sizeOfPages;
        }


    }
}
