using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RoutingMethodsWebApi.Controllers.WebApi
{
    public class FirstController : ApiController
    {
        public string Get()
        {
            return "Get method of First controller triggered ";
        }
    }
}
