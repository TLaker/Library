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
        public string Description { get; set; }
        public double Cost { get; set; }
        public bool IsBorrowable { get; set; }
        public int BorrowableDays { get; set; }

        public Medium(int id,string description, double cost, bool isBorrowable, int borrowableDays)
        {
            Id = id;
            Description = description;
            Cost = cost;
            IsBorrowable = isBorrowable;
            BorrowableDays = borrowableDays;
        }
    }
}
