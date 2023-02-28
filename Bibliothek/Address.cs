using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliothek
{
    internal class Address
    {
        public string Street { get; private set; }
        public int HouseNumber { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public int PostalCode { get; private set; }

        public Address(string street, int houseNumber, string city, string state, int postalCode)
        {
            Street = street;
            HouseNumber = houseNumber;
            City = city;
            State = state;
            if(postalCode <= 99999 && postalCode >= 1000)
                PostalCode = postalCode;
        }
    }
}
