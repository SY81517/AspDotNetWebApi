using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MessageBindeTest.Controllers
{
    [RoutePrefix("api/test")]
    public class TestController : ApiController
    {
        [HttpPost]
        [Route("takeit")]
        public void TakeIT(MyObject o)
        {
            Console.WriteLine();
        }
    }

    public class MyObject
    {
        public string V1 { get; set; }
        public string V2 { get; set; }
    }
}
