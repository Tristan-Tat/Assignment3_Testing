using Assignment3_Connection.Models;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace Assignment3_Testing
{
    public class RESTClient
    {

        HttpClient client;

        public RESTClient() 
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7105/api/REST/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task insertProduct(Product product) 
        {
            String path = "Insert";
            var res = await client.PostAsJsonAsync(path, product);
            Console.Write(res);
        }




        public async Task updateProduct(Product product) 
        {
            String path = "Update";
            var res = await client.PutAsJsonAsync(path, product);
        }

        public async Task deleteProduct(int id) 
        {
            String path = "Delete";
            var res = await client.PostAsJsonAsync(path, id);
        }
    }
}
