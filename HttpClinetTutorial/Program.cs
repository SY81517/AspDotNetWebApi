using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace HttpClientTutorial
{
    class Person
    {
        public string Name { get; set; }
        public string Occupation { get; set; }
    }

    class Program
    {
        private static DemoWebRequest _demoHttpGet = new DemoWebRequest();
        private static JsonWebRequest _jsonWebRequest = new JsonWebRequest();

        static void Main( string[] args )
        {
            //Console.WriteLine(_demoHttpGet.GetPostResponseString().GetAwaiter().GetResult());
            _jsonWebRequest.Hoge().GetAwaiter().GetResult();
        }

        static void ShowHttpStatus()
        {
            _demoHttpGet.ShowStatus().GetAwaiter().GetResult();
            Console.WriteLine();
        }

        static void ShowHTMLCode()
        {
            Console.WriteLine($"{_demoHttpGet.GetResource().GetAwaiter().GetResult()}");
            Console.WriteLine();
        }

        static void ShowResponseHeader()
        {
            Console.WriteLine(_demoHttpGet.GetResponse().GetAwaiter().GetResult());
        }

    }
}
