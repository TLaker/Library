using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliothek
{
    internal class Customer : ICustomer
    {
        public int Id { get; set; }
        public string Forename { get; set; }
        public string Surname { get; set; }
        public Address Address { get; set; }
        public List<Medium> Media { get; set; }
        
        public Customer(int id, string forename, string surname, Address address, List<Medium> media)
        {
            Id = id;
            Forename = forename;
            Surname = surname;
            Address = address;
            Media = media;
        }

        public void PrintMedia()
        {
            foreach (var obj in Media)
            {
                if (obj.GetType() == typeof(Book))
                {
                    Book item = (Book)obj;
                    Console.WriteLine($"Id: {item.Id},\nTitle: {item.Title},\nAuthor: {item.Author},\nPages: {item.SizeOfPages},\nDescription: {item.Description}," + 
                        $"\nType: {item.Type},\nCost: {item.Cost},\nis owned by: {item.OwnedBy.Name}\n");
                }
                else if (obj.GetType() == typeof(Movie))
                {
                    Movie item = (Movie)obj;
                    Console.WriteLine($"Id: {item.Id},\nTitle: {item.Title},\nRegisseur: {item.Regisseur},\nLength: {item.PlayLengthMinutes},\nDescription: {item.Description}," +
                        $"\nType: {item.Type},\nCost: {item.Cost},\nis owned by: {item.OwnedBy.Name}\n");
                }
            }
        }

        //Not for direct use!
        public void AddMedium(Medium medium)
        {
            if(!Media.Contains(medium))
                Media.Add(medium);
        }

        //Lends or reserves a medium to the customer
        public void BorrowMediumByTitle(string title, Library library, DateTime fromDateTime, DateTime tillDateTime)
        {
            try
            {
                var medium = library.AskForMedium(title);
                library.BorrowFromTill(medium, this, fromDateTime, tillDateTime);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        //Checks if a medium with the same title has been borrowed by the customer
        public Medium AskForMedium(string title)
        {
            foreach (var medium in Media)
            {
                if (medium.Title == title) return medium;
            }
            throw new NotImplementedException("The customer did not borrow this title");
        }

        //Returns the medium to its belonging library
        public void ReturnMediumByTitle(string title)
        {
            try
            {
                var medium = AskForMedium(title);
                medium.OwnedBy.ReturnMedium(medium);
                Media.Remove(medium);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
