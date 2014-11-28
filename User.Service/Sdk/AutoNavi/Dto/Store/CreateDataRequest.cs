﻿using Newtonsoft.Json;
using WebApiContrib.Formatting.Jsonp;

namespace User.Service.Sdk.AutoNavi.Dto.Store
{
    public class CreateDataRequest
    {
        /// <summary>
        /// 客户唯一标识
        /// 用户申请，由高德地图API后台自动分配
        /// </summary>
        [JsonProperty("key")]
        public string Key { get; set; }

        /// <summary>
        /// 数据表唯一标识
        /// </summary>
        [JsonProperty("tableid")]
        public string TableId { get; set; }

        /// <summary>
        /// 定位方式
        /// 设置是以请求中的经纬度参数（_location）还是地址参数（_address） 
        /// 来计算最终的坐标值。 
        /// 可选值： 
        /// 1：经纬度；格式示例：104.394729,31.125698 
        /// 2：地址；标准格式示例：北京市朝阳区望京阜通东大街6号院3号楼
        /// </summary>
        [JsonProperty("loctype")]
        public int LocType { get; set; }

        /// <summary>
        /// 新增的数据
        /// </summary>
        [JsonProperty("data")]
        public Data CreateData { get; set; }
        
        public class Data
        {
            /// <summary>
            /// 数据名称
            /// </summary>
            [JsonProperty("_name")]
            public string Name { get; set; }

            /// <summary>
            /// 坐标
            /// 支持点数据 
            /// 规则：经度,纬度，经纬度支持到小数点后6位 格式示例：104.394729,31.125698
            /// </summary>
            [JsonProperty("_location")]
            public string Location { get; set; }

            /// <summary>
            /// 坐标类型
            /// 选值：autonavi；gps
            /// </summary>
            [JsonProperty("coordtype")]
            public string CoordType { get; set; }

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
            /// 分类
            /// </summary>
            public string Category { get; set; }

            /// <summary>
            /// 车辆服务标签
            /// 支持多个标签，以空格为分隔符
            /// </summary>
            public string CarServiceTag { get; set; }

            /// <summary>
            /// 用户服务标签
            /// 支持多个标签，以空格为分隔符
            /// </summary>
            public string UserServiceTag { get; set; }

            /// <summary>
            /// 图片Url
            /// </summary>
            public string PicUrl { get; set; }
        }
    }
}