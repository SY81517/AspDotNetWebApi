using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AtItSampleController.Controllers
{
    public class CustomersController : ApiController
    {
        /// <summary>
        /// Getメソッド試し1
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>文字列</returns>
        /// <remarks>
        /// Http要求
        ///  GET http://localhost:61470/api/Customers/1 HTTP/1.1
        /// </remarks>
        public string Get( int id )
        {
            return "Ok";
        }

        ///// <summary>
        ///// URLのクエリ文字列を取得する
        ///// </summary>
        ///// <param name="category">カテゴリー</param>
        ///// <param name="number">番号</param>
        ///// <returns>文字列</returns>
        ///// <remarks>
        ///// Http要求:例の通り書いたけど、NotFoundになる
        /////  GET http://localhost:61470/api/cusomers/?Category=name&Number=1 HTTP/1.1
        ///// </remarks>
        //public string Get([FromUri]MyParameter parameter)
        //{
        //    return string.Empty;
        //}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <remarks>
        /// 
        /// POST http://localhost:61470/api/Customers/1 HTTP/1.1
        /// </remarks>
        public string Post(int id)
        {
            return string.Empty;
        }

    }

    public class MyParameter
    {
        public string Category { get; set; }
        public string Number { get; set; }
    }

    public class Person
    {

    }

}
