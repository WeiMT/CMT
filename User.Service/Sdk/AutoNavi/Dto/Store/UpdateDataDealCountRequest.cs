using Newtonsoft.Json;

namespace User.Service.Sdk.AutoNavi.Dto.Store
{
    public class UpdateDataDealCountRequest
    {
        /// <summary>
        /// 数据表唯一标识        
        /// </summary>
        [JsonProperty("tableid")]
        public string TableId { get; set; }

        /// <summary>
        /// 要更新的数据
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
            /// 交易数
            /// </summary>
            public int DealCount { get; set; }
        }
    }
}