using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliothek
{
    internal class Movie : Medium
    {
        public string Regisseur { get; set; }
        public int PlayLengthMinutes { get; set; }

        public Movie(int id, string title, string regisseur, int playLengthMinutes, string description, string type, double cost, Library ownedBy) : base(id, title, description, type, cost, ownedBy)
        {
            Regisseur = regisseur;
            PlayLengthMinutes = playLengthMinutes;
        }


    }
}
