using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliothek
{
    internal class Movie : Medium
    {
        public string Title { get; set; }
        public int PlayLengthMinutes { get; set; }

        public Movie(int id, string title, int playLengthMinutes, string description, string type, double cost, bool isBorrowable, int borrowableDays) : base(id, description, type, cost, isBorrowable, borrowableDays)
        {
            Title = title;
            PlayLengthMinutes = playLengthMinutes;
        }


    }
}
