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

        private void BorrowTill(Medium medium, DateTime dateTime)
        {
            medium.BorrowedTill = dateTime;
            medium.IsBorrowed = true;
        }

        public void BorrowFromTill(Medium medium, DateTime fromDateTime, DateTime tillDateTime)
        {
            if (CanBeBorrowed(medium, tillDateTime))
            {
                if (DateTime.Now < fromDateTime)
                {
                    BorrowTill(medium, tillDateTime);
                    medium.IsReserved = true;
                }
                else
                {
                    BorrowTill(medium, tillDateTime);
                    medium.IsReserved = false;
                }
            }
        }

        public void ReturnMedium(Medium medium)
        {
            if (!Media.Contains(medium))
            {
                medium.IsBorrowed = false;
                medium.IsReserved = false;
                Media.Add(medium);
            }
        }

        public void RemoveMedium(Medium medium, Customer customer)
        {
            if (Media.Contains(medium))
            {
                customer.AddMedium(medium);
                Media.Remove(medium);
            }
            else
            {
                throw new Exception($"List does not contain Medium {medium.Id}");
            }
        }

        
    }
}
