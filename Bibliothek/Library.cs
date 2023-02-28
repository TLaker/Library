using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliothek
{
    internal class Library
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Address Address { get; set; }
        public List<Medium> Medias { get; set; }

        public Library(int id, string name, Address address, List<Medium> medias)
        {
            Id = id;
            Name = name;
            Address = address;
            Medias = medias;
        }


    }
}
