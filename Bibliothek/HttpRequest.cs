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
    }
}
