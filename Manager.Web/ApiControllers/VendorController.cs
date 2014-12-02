using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Manager.Web.ApiControllers
{
    public class VendorController : ApiController
    {
        [HttpGet]
        [ActionName("GetVendors")]
        public dynamic GetVendors()
        {
            return null;
        }
    }
}
