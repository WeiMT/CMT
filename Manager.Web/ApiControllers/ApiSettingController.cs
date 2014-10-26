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
        public dynamic GetCarTypes(int skip, int take)
        {
            using (var ctx = new CarHealthEntities())
            {
                var total = ctx.CarTypes.Count();

                var carTypes = ctx.CarTypes.OrderBy(x=>x.BrandFirstLetter).Skip(skip).Take(take).ToList();

                return new
                {
                    total = total,
                    data = carTypes
                };
            }
        }
    }
}
