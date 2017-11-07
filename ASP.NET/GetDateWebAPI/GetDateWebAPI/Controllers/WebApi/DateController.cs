using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GetDateWebAPI.Controllers.WebApi
{
    public class DateController : ApiController
    {
        public string Get()
        {
            return DateTime.Now.ToString();
        }
    }
}
