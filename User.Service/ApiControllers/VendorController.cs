using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json.Linq;

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

        /// <summary>
        /// 获取商户查询类型选项
        /// </summary>
        ///<param name="reqData">
        /// { "CityName" : "南昌" }
        /// </param>
        /// <returns>
        /// {
        ///     //0为成功，其它为失败
        ///     ResultCode = "1",
        ///     //失败时显示，失败原因
        ///     ResultMsg = "",
        ///     
        /// }
        /// </returns>
        [AllowAnonymous]
        [HttpPost]
        [ActionName("GetAllConditionItem")]
        public dynamic GetAllConditionItem(JObject reqData)
        {

            return new
            {
                ResultCode = "0",
                ResultMsg = "",

                ResultBody = new
                {
                    ServiceTypes = new[]
                    {
                        new { Name = "洗车", Value = "1", Sort = "1", Quantity = "58" }, 
                        new { Name = "保养", Value = "2", Sort = "5", Quantity = "32" },
                        new { Name = "维修", Value = "3", Sort = "9", Quantity = "230"  },
                    },
                    AreaTypes = new[]
                    {
                        new { Name = "东湖区", Value = "360102", Sort = "1" },
                        new { Name = "西湖区", Value = "360103", Sort = "2" }, 
                        new { Name = "青山湖区", Value = "360105", Sort = "3" },
                    },
                    OrderTypes = new[]
                    {
                        new { Name = "按距离排序", Value = "1", Sort = "1" }, 
                        new { Name = "按好评排序", Value = "2", Sort = "2" }, 
                        new { Name = "按交易排序", Value = "3", Sort = "3" },
                    },
                }
            };
        }


        /// <summary>
        /// 获取商户列表选项
        /// </summary>
        ///<param name="reqData">
        /// { 
        ///     "ServiceTypeValue" : "0",  // 0 不限 1 洗车 2 保养 3 维修
        ///     "AreaTypeValue" : "0", // 0 不限 
        ///     "OrderTypeValue" : "0", // 0 默认智能排序 1 按距离排序 2 按好评排序 3 按交易数排序
        ///     "Position" :    //
        ///     {
        ///         "Longitude" : "12.3401",
        ///         "Latitude" : "56.7801"
        ///     },
        ///     "Pager" : 
        ///     {
        ///         "Start" : "0",
        ///         "Limit" : "5"
        ///     }
        /// }
        /// </param>
        /// <returns>
        /// {
        ///     //0为成功，其它为失败
        ///     ResultCode = "1",
        ///     //失败时显示，失败原因
        ///     ResultMsg = "",
        ///     
        /// }
        /// </returns>
        [AllowAnonymous]
        [HttpPost]
        [ActionName("GetVendorList")]
        public dynamic GetVendorList(JObject reqData)
        {
            //var picRoot = ConfigurationManager.AppSettings["PicUrl"];

            return new
            {
                ResultCode = "0",
                ResultMsg = "",

                ResultBody = new
                {
                    Vendors = new[]
                    {
                        new
                        {
                            Name = "国宾汽车养护中心",
                            PicUrl = "http://120.24.87.49:8001/default.png",
                            Tags = new []{ "折扣", "会员卡"},
                            ServiceItems = new []{ "洗车", "打蜡", "贴膜"},
                            Comment = "294",    // 好评数
                            Volume = "53"   // 交易数量
                        },
                        new
                        {
                            Name = "马牌轮胎（红谷滩店）",
                            PicUrl = "http://120.24.87.49:8001/default.png",
                            Tags = new []{ "折扣", "会员卡"},
                            ServiceItems = new []{ "洗车", "打蜡", "贴膜"},
                            Comment = "294",    // 好评数
                            Volume = "53"   // 交易数量
                        },
                        new
                        {
                            Name = "驰耐普汽车美容养护中心",
                            PicUrl = "http://120.24.87.49:8001/default.png",
                            Tags = new []{ "折扣", "会员卡"},
                            ServiceItems = new []{ "洗车", "打蜡", "贴膜"},
                            Comment = "294",    // 好评数
                            Volume = "53"   // 交易数量
                        },
                        new
                        {
                            Name = "森田汽车维修护理中心",
                            PicUrl = "http://120.24.87.49:8001/default.png",
                            Tags = new []{ "折扣", "会员卡"},
                            ServiceItems = new []{ "洗车", "打蜡", "贴膜"},
                            Comment = "294",    // 好评数
                            Volume = "53"   // 交易数量
                        },
                    }
                }
            };
        }

    }
}
