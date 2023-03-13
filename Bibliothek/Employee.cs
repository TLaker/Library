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
        public Library Library { get; set; }

        public Employee(int id, string forename, string surname, Library library)
        {
            Id = id;
            Forename = forename;
            Surname = surname;
            Library = library;
        }

        //Adds a medium to the library
        public void AddMediumToLibrary(Medium medium)
        {
            if (!Library.Media.Contains(medium))
            {
                if (IsProven(medium))
                {
                    ChangeId(medium);
                    medium.OwnedBy = Library;
                    Library.Media.Add(medium);
                }
                else
                {
                    Console.WriteLine("Couldn't add medium to library. Medium is not proven by an employee.");
                }
            }
        }

        private bool IsProven(Medium medium)
        {
            Console.WriteLine($"Is the medium {medium.Title} proven?");
            switch (Console.ReadLine())
            {
                case "Yes": return true;
                case "Y": return true;
                case "y": return true;
                default: return false;
            }
        }

        private void ChangeId(Medium medium)
        {
            if(medium.Id == 0)
            {
                medium.Id = Library.Media.Last<Medium>().Id + 1;
            }
        }
    }
}
