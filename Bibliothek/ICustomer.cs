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
        void ReturnMedium(Medium medium, Library library);
    }
}
