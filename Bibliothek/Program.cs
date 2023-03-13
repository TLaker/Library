using System;

namespace Bibliothek
{
    public class MainClass
    {
        static async Task Main()
        {
            //Borrowable medium of type book or movie with IMedium
            //Customer or staff with Address
            //Library with Address and List of borrowable media

            var work = new Work();
            await work.DoWork();

            //var httpRequest = new HttpRequest();
            //Console.WriteLine(httpRequest.GetTest().Result);
        }
    }
}