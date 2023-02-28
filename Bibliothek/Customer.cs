using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliothek
{
    internal class Customer
    {
        public int Id { get; set; }
        public string Forename { get; set; }
        public string Surname { get; set; }
        public Address Address { get; set; }
        
        public Customer(int id, string forename, string surname, Address address)
        {
            Id = id;
            Forename = forename;
            Surname = surname;
            Address = address;
        }


    }
}
