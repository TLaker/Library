using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliothek
{
    internal interface ICustomer
    {
        int Id { get; set; }
        string Forename { get; set; }
        string Surname { get; set; }
        Address Address { get; set; }
        List<Medium> Media { get; set; }

        void PrintMedia();
        void AddMedium(Medium medium);
        void BorrowMediumByTitle(string title, Library library, DateTime fromDateTime, DateTime tillDateTime);
        Medium AskForMedium(string title);
        void ReturnMediumByTitle(string title);


    }
}
