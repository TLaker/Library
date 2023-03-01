using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Bibliothek
{
    internal class Work
    {
        //Example data
        public static List<Medium> libList = new List<Medium>()
        {
            new Book(100, "Tales from Raccoon City", "Dmitry Lukhanenko", 319, "Various stories that happend in Raccoon City", "Novel", 29.99),
            new Movie(101, "Resident Evil", "Paul W. S. Anderson", 100, "Movie based on the game 'Resident Evil'", "Horror", 19.99),
            new Book(102, "Rick and Morty", "Justin Roiland", 159, "An old mad scientist and his nephew have several adventures with a portal gun", "Comic", 24.99),
            new Movie(103, "Silent Hill", "Christophe Gans", 127, "A woman loses her daughter in an abandoned town and tries to survive while searching for her", "Horror", 19.99)
        };
        public static Library lib = new Library(11001, "Herforder Bibliothek", new Address("Bahnhofstraße", 4, "Herford", "Nordrhein-Westfalen", 32049), libList);
        public static List<Medium> customerList = new List<Medium>();
        public static Customer customer = new Customer(10001, "Elza", "Walker", new Address("University-street", 17, "Raccoon City", "Washington", 12345), customerList);
        
        public void DoWork()
        {
            customer.AddMedium(lib.Media.First<Medium>(x => x.Title == "Resident Evil"));
            customer.AddMedium(lib.Media.First<Medium>(x => x.Title == "Rick and Morty"));
            Console.WriteLine("Customers list:");
            customer.PrintMedia();
            Console.WriteLine("\n\nMedia available in library:");
            lib.PrintMedia();
            customer.ReturnMedium(customer.Media.First<Medium>(x => x.Title == "Resident Evil"), lib);
            Console.WriteLine("Customers updated list:");
            customer.PrintMedia();
        }
    }
}
