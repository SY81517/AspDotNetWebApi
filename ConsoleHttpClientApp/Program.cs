using System;

namespace ConsoleHttpClientApp
{
    class Program
    {
        private static readonly ValuesApi _valuesApi = new ValuesApi();

        static void Main( string[] args )
        {
            Console.WriteLine("Start ");
            _valuesApi.GetAsync().GetAwaiter().GetResult();
            _valuesApi.PutAsync().GetAwaiter().GetResult();
            Console.WriteLine("End");
        }

    }

}
