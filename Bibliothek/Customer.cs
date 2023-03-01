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
                        $"\nType: {item.Type},\nCost: {item.Cost}\n");
                }
                else if (obj.GetType() == typeof(Movie))
                {
                    Movie item = (Movie)obj;
                    Console.WriteLine($"Id: {item.Id},\nTitle: {item.Title},\nRegisseur: {item.Regisseur},\nLength: {item.PlayLengthMinutes},\nDescription: {item.Description}," +
                        $"\nType: {item.Type},\nCost: {item.Cost}\n");
                }
            }
        }

        public void AddMedium(Medium medium)
        {
            if(!Media.Contains(medium))
                Media.Add(medium);
        }

        public void ReturnMedium(Medium medium, Library library)
        {
            if (Media.Contains(medium))
            {
                library.ReturnMedium(medium);
                Media.Remove(medium);
            }
            else
            {
                throw new Exception($"List does not contain Medium {medium.Id}");
            }
        }
    }
}
