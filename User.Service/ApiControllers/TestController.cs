using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using User.Service.Sdk.AutoNavi;
using User.Service.Sdk.AutoNavi.Dto.Store;

namespace User.Service.ApiControllers
{
    [AllowAnonymous]
    public class TestController : ApiController
    {
        [HttpGet]
        [ActionName("YuntuCreateData")]
        public dynamic YuntuCreateData()
        {
            var request = new CreateDataRequest
            {
                TableId = Tables.VendorTableId,
                CreateData = new CreateDataRequest.Data
                {
                    Name = "南昌八一洗车店",
                    Category = "洗车",
                    Address = "南昌八一大道545号",
                    CarServiceTag = "清洗 贴膜",
                    UserServiceTag = "折 卡",
                    Location = "115.90353,28.683058",
                    DealCount = 1,
                    PraiseCount = 0,
                    VendorId = 12,
                    PicUrl = "http://"
                }
            };

            var response = YuntuStore.CreateData(request);

            return response;
        }

        [HttpGet]
        [ActionName("YuntuUpdateData")]
        public dynamic YuntuUpdateData()
        {
            var request = new UpdateDataRequest
            {
                TableId = Tables.VendorTableId,
                UpdateData = new UpdateDataRequest.Data
                {
                    Id = "5",
                    Name = "南昌八一大道洗车店",
                    Category = "洗车",
                    Address = "福州路11号",
                    CarServiceTag = "美容 贴膜 轮胎",
                    UserServiceTag = "打折 会员卡 预约",
                    Location = "115.90353,28.683058",
                    DealCount = 2,
                    PraiseCount = 2,
                    VendorId = 12,
                    PicUrl = "http://"
                }
            };

            var response = YuntuStore.UpdateData(request);

            return response;
        }

        [HttpGet]
        [ActionName("YuntuUpdateDataDealCount")]
        public dynamic YuntuUpdateDataDealCount()
        {
            var request = new UpdateDataDealCountRequest
            {
                TableId = Tables.VendorTableId,
                UpdateData = new UpdateDataDealCountRequest.Data
                {
                    Id="5",
                    DealCount = 12
                }
            };

            var response = YuntuStore.UpdateDataDealCount(request);

            return response;
        }

        [HttpGet]
        [ActionName("YuntuUpdateDataPraiseCount")]
        public dynamic YuntuUpdateDataPraiseCount()
        {
            var request = new UpdateDataPraiseCountRequest
            {
                TableId = Tables.VendorTableId,
                UpdateData = new UpdateDataPraiseCountRequest.Data
                {
                    Id = "5",
                    PraiseCount = 12
                }
            };

            var response = YuntuStore.UpdateDataPraiseCount(request);

            return response;
        }

        [HttpGet]
        [ActionName("YuntuDeleteData")]
        public dynamic YuntuDeleteData()
        {
            var request = new DeleteDataRequest
            {
                TableId = Tables.VendorTableId,
                Ids = "5"
            };

            var response = YuntuStore.DeleteData(request);

            return response;
        }

        [HttpGet]
        [ActionName("YuntuSearchLocal")]
        public dynamic YuntuSearchLocal()
        {
            var request = new SearchLocalRequest
            {
                TableId = Tables.VendorTableId,
                City = "全国",
                KeyWords = "八一",
                Filter = "",
                SortRule = "",
                Limit = "",
                Page = ""
            };

            var response = YuntuStore.SearchLocal(request);

            return response;
        }

        [HttpGet]
        [ActionName("YuntuSearchAround")]
        public dynamic YuntuSearchAround()
        {
            var request = new SearchAroundRequest
            {
                TableId = Tables.VendorTableId,
                Center = "115.90354,28.683058",
                Radius = "3000",
                KeyWords = "",
                Filter = "",
                SortRule = "",
                Limit = "",
                Page = ""
            };

            var response = YuntuStore.SearchAround(request);

            return response;
        }
    }
}
