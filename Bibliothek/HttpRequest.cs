using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliothek
{
    internal class HttpRequest
    {

        readonly HttpClient _client = new();

        public async Task<string> GetTest()
        {
            var contentUrl = new Uri("https://localhost:7135/api/Main/test");
            var response = await _client.GetStringAsync(contentUrl);
            return response;
        }


        //Makes an http request to the LibraryAPI
        public async Task<string> MakeRequest(string libraryName, int mediumId)
        {
            var contentUrl = new Uri($"https://localhost:7135/api/Main/{libraryName}/{mediumId}");
            var response = await _client.GetAsync(contentUrl);
            var data = await response.Content.ReadAsStringAsync();
            return data;
        }
    }
}
