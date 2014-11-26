using Newtonsoft.Json;

namespace User.Service.Sdk.AutoNavi.Dto.Store
{
    public class UpdateDataRequest
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
        /// 设置是以请求中的经纬度参数（_location）还是地址参数（_address）来计算最终的坐标值。 
        /// 可选值： 
        /// 1：经纬度；格式示例：104.394729,31.125698 
        /// 2：地址
        /// </summary>
        [JsonProperty("loctype")]
        public int LocType { get; set; }

        /// <summary>
        /// 1. 格式：json 
        /// 2. 更新规则：        
        /// 1）更新字段值：只更新请求中上传的字段值，未上传的字段保留原值，且系统字段中_id,_createtime,_updatetime三个字段不能被更新。        
        /// 示例：
        /// data={"_id":"3","_location":"113.484733,37.837432"}，则本次请求仅更新_location字段值，其他字段如_name，_address等其他用户自定义字段将保持原值。        
        /// 2）清空字段值：赋值null实现，仅能对用户自定义字段值进行清空操作，云图系统字段（_id,_name,_address,_location,_createtime,_updatetime)不能执行清空。        
        /// 清空自定义字段示例：
        /// data={"_id":"3","Ctype":null} //Ctype字段为用户的自定义字段
        /// </summary>
        [JsonProperty("data")]
        public Data UpdateData { get; set; }

        public class Data
        {
            /// <summary>
            /// 数据id
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
            /// 支持点数据 
            /// 规则：经度,纬度，经纬度支持到小数点后6位 
            /// 格式示例：104.394729,31.125698
            /// </summary>
            [JsonProperty("_location")]
            public string Location { get; set; }

            /// <summary>
            /// 坐标类型
            /// 可选值： autonavi gps
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
            /// 支持多个标签，以;为分隔符
            /// </summary>
            public string CarServiceTag { get; set; }

            /// <summary>
            /// 用户服务标签
            /// 支持多个标签，以;为分隔符
            /// </summary>
            public string UserServiceTag { get; set; }

            /// <summary>
            /// 图片Url
            /// </summary>
            public string PicUrl { get; set; }
        }
    }
}