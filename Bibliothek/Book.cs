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

        public Book(int id, string title, string author, int sizeOfPages, string description, string type, double cost, bool isBorrowed, DateTime borrowedTill) : base(id, description, type, cost, isBorrowed, borrowedTill)
        {
            Title = title;
            Author = author;
            SizeOfPages = sizeOfPages;
        }


    }
}
