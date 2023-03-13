using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliothek
{
    internal class Book : Medium
    {
        public string Author { get; set; }
        public int SizeOfPages { get; set; }

        public Book(int id, string title, string author, int sizeOfPages, string description, string type, double cost, Library ownedBy) : base(id, title, description, type, cost, ownedBy)
        {
            Author = author;
            SizeOfPages = sizeOfPages;
        }


    }
}
