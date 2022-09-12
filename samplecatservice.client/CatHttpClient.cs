using System.Text;
using System.Text.Json;

namespace samplecatservice.client
{
    public class CatHttpClient
    {
        private readonly HttpClient client;
        public CatHttpClient()
        {
            client = new HttpClient()
            {
                BaseAddress = new Uri("http://localhost:5160/")
            };
        }

        public async Task CreateCatsAsync(string[] cats)
        {
            foreach (var item in cats)
            {
                var cat = new grpc.CreateCatRequest
                {
                    Name = $"{item}-Rest",
                    Color = "Red"
                };
                var stringContent = new StringContent(JsonSerializer.Serialize(cat), Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync("Cats/CreateCat", stringContent);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                var catReply = JsonSerializer.Deserialize<CatResponse>(responseBody);
                Console.WriteLine(catReply.id);
            }
        }



    }
    public class CatResponse
    {
        public string id { get; set; }
        public string name { get; set; }
        public string color { get; set; }
        public DateTime createdDate { get; set; }
    }
}
