using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliothek
{
    internal class Medium : IMedium
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public double Cost { get; set; }
        public bool IsBorrowed { get; set; }
        public bool IsReserved { get; set; }
        public DateTime BorrowedTill { get; set; }

        public Medium(int id, string title, string description, string type, double cost)
        {
            Id = id;
            Title = title;
            Description = description;
            Type = type;
            Cost = cost;
            IsBorrowed = false;
            IsReserved = false;
            BorrowedTill = DateTime.MinValue;
        }


    }
}
