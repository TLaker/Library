using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliothek
{
    internal interface ILibrary
    {
        int Id { get; }
        string Name { get; }
        Address Address { get; }
        List<Medium> Medias { get; }


    }
}
