using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliothek
{
    internal class Employee
    {
        public int Id { get; set; }
        public string Forename { get; set; }
        public string Surname { get; set; }
        public string Library { get; set; }

        public Employee(int id, string forename, string surname, string library)
        {
            Id = id;
            Forename = forename;
            Surname = surname;
            Library = library;
        }


    }
}
