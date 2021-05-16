using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using  System.Web.Http.Tracing;

namespace AppSampleBaseLine.Controllers
{
    [Route("api/products")]
    public class ProductsController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get()
        {
            return Ok();
        }
    }
}
