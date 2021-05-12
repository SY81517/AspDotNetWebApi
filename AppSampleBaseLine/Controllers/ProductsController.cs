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
            //Configuration.Services.GetTraceWriter().Info(Request, "ProductsController", "Get the list of products.");
            Configuration.Services.GetTraceWriter().Info(Request, "ProductsController", "Get the list of products.");
            return Ok();
        }
    }
}
