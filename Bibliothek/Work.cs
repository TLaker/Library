using Newtonsoft.Json;
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
        public static List<Medium> libList = new List<Medium>();
        public static Library her = new Library(11101, "Herforder Bibliothek", new Address("Bahnhofstraße", 4, "Herford", "Nordrhein-Westfalen", 32049), libList);
        public static Library col = new Library(11102, "Kölner Stadtbibliothek", new Address("Schlauer Weg", 18, "Köln", "Nordrhein-Westfalen", 50667), libList);
        public static List<Medium> customerList = new List<Medium>();
        public static Customer customerElza = new Customer(10001, "Elza", "Walker", new Address("University-street", 17, "Raccoon City", "Washington", 12345), customerList);
        public static Employee employeeAlex = new Employee(11001, "Alexander", "Marcus", her);
        public static Employee employeeAnne = new Employee(11002, "Annette", "Birkin", col);
        public static Medium newMedium = new Movie(0, "The last of us", "Greg Spence", 400, "A man and a woman try to survive in a zombie infested apocalyptic world", "Action", 119.99, null);
        
        public async Task DoWork()
        {

            //her.BorrowFromTill(her.Media.First<Medium>(x => x.Title == "Resident Evil"), customer, DateTime.Now, DateTime.Now.AddDays(14));
            //her.BorrowFromTill(her.Media.First<Medium>(x => x.Title == "Rick and Morty"), customer, DateTime.Now.AddDays(4), DateTime.Now.AddDays(18));
            //her.BorrowFromTill(her.Media.First<Medium>(x => x.Title == "Silent Hill"), customer, DateTime.Now.AddDays(6), DateTime.Now.AddDays(13));
            //Console.WriteLine($"\nCustomer {customer.Forename} is returning a medium to library {her.Name}");
            //customer.ReturnMedium(customer.Media.First<Medium>(x => x.Title == "Resident Evil"), her);
            //Console.WriteLine($"\nCustomer {customer.Forename}s updated list:");
            //customer.PrintMedia();
            //Console.WriteLine($"\nAdding new medium to library {her.Name}");
            //employee.AddMediumToLibrary(newMedium);
            //Console.WriteLine($"\nMedia available in updated library {her.Name}:");
            //her.PrintMedia();
            //try
            //{
            //    Console.WriteLine($"\nBorrowing a medium from library {her.Name}");
            //    her.BorrowFromTill(her.AskForMedium("The last of us"), customer, DateTime.Now, DateTime.Now.AddDays(7));
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}
            //Console.WriteLine($"\nCustomer {customer.Forename}s updated list:");
            //customer.PrintMedia();
            //Console.WriteLine($"\nMedia available in updated library {her.Name}:");
            //her.PrintMedia();


            var request = new HttpRequest();
            await GetBasicData();

            customerElza.BorrowMediumByTitle("Resident Evil", her, DateTime.Now, DateTime.Now.AddDays(7));
            customerElza.BorrowMediumByTitle("Metro 2033", col, DateTime.Now, DateTime.Now.AddDays(14));
            customerElza.BorrowMediumByTitle("Silent Hill", her, DateTime.Now.AddDays(4), DateTime.Now.AddDays(11));

            her.PrintMedia();
            col.PrintMedia();
            customerElza.PrintMedia();

            customerElza.ReturnMediumByTitle("Resident Evil");
            customerElza.PrintMedia();
        }

        public async Task GetBasicData()
        {
            var request = new HttpRequest();
            var response = await request.MakeRequest(her.Name, 100);
            var result = JsonConvert.DeserializeObject<Book>(response);
            employeeAlex.AddMediumToLibrary(result);
            response = await request.MakeRequest(her.Name, 101);
            var result2 = JsonConvert.DeserializeObject<Movie>(response);
            employeeAlex.AddMediumToLibrary(result2);
            response = await request.MakeRequest(her.Name, 102);
            result = JsonConvert.DeserializeObject<Book>(response);
            employeeAlex.AddMediumToLibrary(result);
            response = await request.MakeRequest(her.Name, 103);
            result2 = JsonConvert.DeserializeObject<Movie>(response);
            employeeAlex.AddMediumToLibrary(result2);
            response = await request.MakeRequest(col.Name, 100);
            result = JsonConvert.DeserializeObject<Book>(response);
            employeeAnne.AddMediumToLibrary(result);
            response = await request.MakeRequest(col.Name, 101);
            result2 = JsonConvert.DeserializeObject<Movie>(response);
            employeeAnne.AddMediumToLibrary(result2);
            response = await request.MakeRequest(col.Name, 102);
            result = JsonConvert.DeserializeObject<Book>(response);
            employeeAnne.AddMediumToLibrary(result);
            response = await request.MakeRequest(col.Name, 103);
            result2 = JsonConvert.DeserializeObject<Movie>(response);
            employeeAnne.AddMediumToLibrary(result2);
        }
    }
}
