using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MessageBindeTest.Controllers
{
    [RoutePrefix("api/test2")]
    public class Test2Controller : ApiController
    {
        [HttpPost]
        [Route("fire")]
        public void Fire( MyData o )
        {
            Console.WriteLine();
        }
    }

    public class MyData
    {
        public string ID { get; set; }
        public  MyObject ObMyObject { get; set; }
    }
}
