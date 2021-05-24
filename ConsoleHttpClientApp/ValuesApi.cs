using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ConsoleHttpClientApp
{
    public class ValuesApi
    {
        /// <summary>
        /// HTTPクライアント
        /// </summary>
        /// <remarks>
        /// staticメンバーにして、アプリケーション全体で使い回す
        /// </remarks>
        private static readonly HttpClient Client = new HttpClient();

        private static readonly string ApiUri = "http://localhost:54443/api/values";

        public async Task GetAsync()
        {
            try
            {
                // GET api/values
                var resource = await Client.GetAsync(ApiUri);
                resource.EnsureSuccessStatusCode();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            Console.WriteLine("GET SUCCESS");
        }

        public async Task PutAsync()
        {
            try
            {
                var testInput = "TestMessage";
                var jsonString = JsonConvert.SerializeObject(testInput);
                var data = new StringContent(jsonString, Encoding.UTF8, mediaType: "application/json");
                var response = await Client.PutAsync("http://localhost:54443/api/values/5", data);
                response.EnsureSuccessStatusCode();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            Console.WriteLine("PUT SUCCESS");
        }
    }
}
