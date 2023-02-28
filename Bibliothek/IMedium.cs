using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliothek
{
    internal interface IMedium
    {
        int Id { get; }
        string Description { get; }
        double Cost { get; }
        bool IsBorrowable { get; }
        int BorrowableDays { get; }


    }
}
