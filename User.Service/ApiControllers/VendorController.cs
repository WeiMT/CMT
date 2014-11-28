using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace User.Service.ApiControllers
{
    public class VendorController : ApiController
    {
        /// <summary>
        /// 获取商户信息明细
        /// </summary>
        /// <param name="vendorId"></param>
        /// <returns></returns>
        [HttpGet]
        [ActionName("GetVendorDetail")]
        public dynamic GetVendorDetail(long vendorId)
        {
            return null;
        }

        /// <summary>
        /// 获取用户评价
        /// </summary>
        /// <param name="vendorId"></param>
        /// <returns></returns>
        public dynamic GetVendorEvaluate(long vendorId)
        {
            return null;
        }


    }
}
