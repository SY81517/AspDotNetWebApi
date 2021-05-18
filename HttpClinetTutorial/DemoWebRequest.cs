using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Text;
using Newtonsoft.Json;

namespace HttpClientTutorial
{
    public class DemoWebRequest
    {
        private static HttpClient _client = new HttpClient();

        private static readonly string GoogleWebSite = "https://www.google.co.jp/";
        private static readonly string SampleWebSite = "http://webcode.me";
        /// <summary>
        /// WebサイトへGET要求を送信して、ステータスコードを表示する
        /// </summary>
        /// <returns></returns>
        public async Task ShowStatus()
        {
            var result = await _client.GetAsync(SampleWebSite);
            Console.WriteLine($"Http Status:{result.StatusCode}");
        }

        /// <summary>
        /// HTMLコードを取得する
        /// </summary>
        /// <returns></returns>
        public async Task<string> GetResource()
        {
            var resultString = await _client.GetStringAsync(SampleWebSite);
            return resultString;
        }

        /// <summary>
        /// HTTP GETメソットの応答ヘッダを取得する
        /// </summary>
        /// <returns></returns>
        public async Task<HttpResponseMessage> GetResponse()
        {
            return await _client.SendAsync(new HttpRequestMessage(HttpMethod.Head, GoogleWebSite));
        }

        /// <summary>
        /// Post要求後に応答コンテクストを返す
        /// </summary>
        /// <returns></returns>
        public async Task<string> GetPostResponseString()
        {
            var person = new Person()
            {
                Name = "John Doe",
                Occupation = "gardener"
            };
            var json = JsonConvert.SerializeObject(person);
            var data = new StringContent(json, Encoding.UTF8, mediaType:"application/json");
            var url = "https://httpbin.org/post";
            var response = await _client.PostAsync(url, data);
            return response.Content.ReadAsStringAsync().Result;
        }
    }

    public class JsonWebRequest
    {
        private static HttpClient _client = new HttpClient();

        public void Initialize()
        {

            _client.DefaultRequestHeaders.Add("User-Agent", "C# console program");
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task Hoge()
        {
            try
            {
                //System.InvalidOperationException: 無効な要求 URI が指定されました。要求 URI が絶対 URI であるか、BaseAddress を設定する必要があります。
                //_client.BaseAddress = new Uri("https://api.github.com/user/emails");
                //var response = await _client.GetAsync(_client.BaseAddress);

                //System.InvalidOperationException: 無効な要求 URI が指定されました。要求 URI が絶対 URI であるか、BaseAddress を設定する必要があります。
                //            _client.BaseAddress = new Uri("https://api.github.com/");
                //var url = "user/emails";
                //var response = await _client.GetAsync(url);

                var response = await _client.GetAsync("https://api.github.com/user/emails");
                response.EnsureSuccessStatusCode();
                var resp = await response.Content.ReadAsStringAsync();
                List<Contributor> contributors = JsonConvert.DeserializeObject<List<Contributor>>(resp);
                contributors?.ForEach(Console.WriteLine);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }

    public class Contributor
    {
        public string Login { get; set; }
        public short Contributions { get; set; }
    }
}
