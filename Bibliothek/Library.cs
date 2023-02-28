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

        public void RemoveMedium(Medium medium)
        {
            if (Media.Contains(medium))
            {
                Media.Remove(medium);
            }
        }


    }
}
