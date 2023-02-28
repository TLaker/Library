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
        string Type { get; }
        double Cost { get; }
        bool IsBorrowed { get; }
        bool IsReserved { get; }
        DateTime BorrowedTill { get; }


        
    }
}
