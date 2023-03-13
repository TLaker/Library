using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Bibliothek
{
    internal class Library : ILibrary
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Address Address { get; set; }
        public List<Medium> Media { get; set; }

        public Library(int id, string name, Address address, List<Medium> media)
        {
            Id = id;
            Name = name;
            Address = address;
            Media = media;
        }

        public void PrintMedia()
        {
            foreach (var obj in Media)
            {
                if(obj.OwnedBy == this)
                {
                    if (obj.GetType() == typeof(Book))
                    {
                        Book item = (Book)obj;
                        Console.WriteLine($"Id: {item.Id},\nTitle: {item.Title},\nAuthor: {item.Author},\nPages: {item.SizeOfPages},\nDescription: {item.Description}," +
                            $"\nType: {item.Type},\nCost: {item.Cost},\nis borrowed: {item.IsBorrowed},\nis reserved: {item.IsReserved},\n{item.BorrowedTill},\nis owned by: {item.OwnedBy.Name}\n");
                    }
                    else if (obj.GetType() == typeof(Movie))
                    {
                        Movie item = (Movie)obj;
                        Console.WriteLine($"Id: {item.Id},\nTitle: {item.Title},\nRegisseur: {item.Regisseur},\nLength: {item.PlayLengthMinutes},\nDescription: {item.Description}," +
                            $"\nType: {item.Type},\nCost: {item.Cost},\nis borrowed: {item.IsBorrowed},\nis reserved: {item.IsReserved},\n{item.BorrowedTill},\nis owned by: {item.OwnedBy.Name}\n");
                    }
                }
            }
        }

        private bool CanBeBorrowed(Medium medium, DateTime dateTime)
        {
            if (!medium.IsReserved)
            {
                if (!medium.IsBorrowed)
                {
                    return true;
                }
                else if (medium.IsBorrowed && medium.BorrowedTill < dateTime)
                {
                    return true;
                }
            }
            return false;
        }

        private void BorrowTill(Medium medium, Customer customer, DateTime dateTime)
        {
            medium.BorrowedTill = dateTime;
            medium.IsBorrowed = true;
            customer.AddMedium(medium);
        }

        //Not for direct use!
        public void BorrowFromTill(Medium medium, Customer customer, DateTime fromDateTime, DateTime tillDateTime)
        {
            if (CanBeBorrowed(medium, tillDateTime))
            {
                if (DateTime.Now < fromDateTime)
                {
                    medium.IsReserved = true;
                }
                else
                {
                    medium.IsReserved = false;
                }
                BorrowTill(medium, customer, tillDateTime);
            }
            else
            {
                Console.WriteLine("Medium is already borrowed or reserved");
            }
        }

        //Checks if a medium with the same title is available in the library
        public Medium AskForMedium(string title)
        {
            foreach(var medium in Media)
            {
                if(medium.Title == title) return medium;
            }
            throw new NotImplementedException("Not available in this library");
        }

        //Not for direct use!
        public void ReturnMedium(Medium medium)
        {
            medium.IsBorrowed = false;
            medium.IsReserved = false;
            medium.BorrowedTill = DateTime.MinValue;
        }

        
    }
}
