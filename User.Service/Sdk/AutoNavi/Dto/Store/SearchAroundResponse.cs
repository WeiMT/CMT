using System.Collections.Generic;
using Newtonsoft.Json;

namespace User.Service.Sdk.AutoNavi.Dto.Store
{
    public class SearchAroundResponse
    {
        /// <summary>
        /// 返回状态
        /// 值为0或1 ; 1：成功；0：失败；-99：失败，网络通讯失败
        /// </summary>
        [JsonProperty("status")]
        public int Status { get; set; }

        /// <summary>
        /// 返回的状态信息
        /// status = 1，info返回“ok” ; status = 0，info返回错误信息；status=-99，失败，网络通讯失败
        /// </summary>
        [JsonProperty("info")]
        public string Info { get; set; }

        /// <summary>
        /// 返回结果总数目
        /// </summary>
        [JsonProperty("count")]
        public int Count { get; set; }

        /// <summary>
        /// 数据集合
        /// </summary>
        public List<Data> Datas { get; set; } 

        public class Data
        {
            /// <summary>
            /// 数据id
            /// 数据唯一标识
            /// </summary>
            [JsonProperty("_id")]
            public string Id { get; set; }

            /// <summary>
            /// 数据名称
            /// </summary>
            [JsonProperty("_name")]
            public string Name { get; set; }

            /// <summary>
            /// 坐标
            /// </summary>
            [JsonProperty("_location")]
            public string Location { get; set; }

            /// <summary>
            /// 地址
            /// </summary>
            [JsonProperty("_address")]
            public string Address { get; set; }

            /// <summary>
            /// 商户Id
            /// </summary>
            public int VendorId { get; set; }

            /// <summary>
            /// 交易数
            /// </summary>
            public int DealCount { get; set; }

            /// <summary>
            /// 好评数
            /// </summary>
            public int PraiseCount { get; set; }

            /// <summary>
            /// 分类标签
            /// 支持多个标签，以空格为分隔符
            /// </summary>
            public string Category { get; set; }

            /// <summary>
            /// 车辆服务标签
            /// 支持多个标签，以空格为分隔符
            /// </summary>
            public string CarServiceTag { get; set; }

            /// <summary>
            /// 车辆服务标签Id
            /// 支持多个标签Id，以空格为分隔符
            /// </summary>
            public string CarServiceTagId { get; set; }

            /// <summary>
            /// 用户服务标签
            /// 支持多个标签，以空格为分隔符
            /// </summary>
            public string UserServiceTag { get; set; }

            /// <summary>
            /// 用户服务标签Id
            /// 支持多个标签Id，以空格为分隔符
            /// </summary>
            public string UserServiceTagId { get; set; }

            /// <summary>
            /// 图片Url
            /// </summary>
            public string PicUrl { get; set; }

            /// <summary>
            /// 距中心点距离
            /// </summary>
            [JsonProperty("_distance")]
            public int Distance { get; set; }

            /// <summary>
            /// 创建时间
            /// </summary>
            [JsonProperty("_createtime")]
            public string CreateTime { get; set; }

            /// <summary>
            /// 更新时间
            /// </summary>
            [JsonProperty("_updatetime")]
            public string UpdateTime { get; set; }
        }
    }
}