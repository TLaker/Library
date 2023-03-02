using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliothek
{
    internal interface ILibrary
    {
        int Id { get; }
        string Name { get; }
        Address Address { get; }
        List<Medium> Media { get; }

        void BorrowFromTill(Medium medium, Customer customer, DateTime fromDateTime, DateTime tillDateTime);
        void ReturnMedium(Medium medium);
    }
}
