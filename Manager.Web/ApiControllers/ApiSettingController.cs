using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DataAccess.Models;

namespace Manager.Web.ApiControllers
{
    public class ApiSettingController : ApiController
    {
        [HttpGet]
        public dynamic GetCarTypes()
        {
            using (var ctx = new CarHealthEntities())
            {
                var cartTypes = ctx.CarTypes.Take(100).ToList();
                return cartTypes;
            }
        }
    }
}
