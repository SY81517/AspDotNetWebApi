﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;


namespace ConsoleHttpClientApp
{
    class Program
    {
        /// <summary>
        /// HTTPクライアント
        /// </summary>
        /// <remarks>
        /// 1度だけインスタンス化し、アプリケーション全体で使い回す
        /// </remarks>
        private static readonly HttpClient Client = new HttpClient();

        static void Main( string[] args )
        {
            RunAsync().GetAwaiter().GetResult();
        }

        /// <summary>
        /// 初期化
        /// </summary>
        static void Setting()
        {
            Client.BaseAddress = new Uri("http://localhost:54443/api/values");
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        static async Task RunAsync()
        {
            Setting();
            var stopwatch = new Stopwatch();
            var recordTimeSpans = new List<TimeSpan>();
            for (var i = 0; i < 10; i++)
            {
                var result = AppResult.Ok;
                stopwatch.Reset();
                stopwatch.Start();
                try
                {
                    // GET api/values
                    var resource = await GetAllAsync(Client.BaseAddress);
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.ToString());
                    result = AppResult.Ng;
                }
                finally
                {
                    stopwatch.Stop();
                    recordTimeSpans.Add(stopwatch.Elapsed);
                    var resultStr = $"i={i},Time={stopwatch.Elapsed.Seconds:00}.{stopwatch.Elapsed.Milliseconds:000}[sec],Result={result}";
                    Console.WriteLine(resultStr);
                }
            }

            var doubleAverageTicks = recordTimeSpans.Average(timeSpan => timeSpan.Ticks);
            var longAverageTicks = Convert.ToInt64(doubleAverageTicks);
            var average = new TimeSpan(longAverageTicks);
            Console.WriteLine($"Average={average.Seconds:00}.{average.Milliseconds:000}[sec]");
        }

        /// <summary>
        /// GET APIをコール
        /// </summary>
        /// <param name="path">RI</param>
        /// <returns></returns>
        static async Task<IEnumerable<string>> GetAllAsync(Uri uri)
        {
            IEnumerable<string> resource = null;
            // Get要求
            var response = await Client.GetAsync(uri);
            //if (response.IsSuccessStatusCode)
            //{
            //    //リソース取得
            //    resource = await response.Content.ReadAsAsync<IEnumerable<string>>();
            //}
            return resource;
        }
    }

    public enum AppResult
    {
        Ok,
        Ng
    }
}
