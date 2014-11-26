using Newtonsoft.Json;

namespace User.Service.Sdk.AutoNavi.Dto.Store
{
    public class CreateDataResponse
    {
        /// <summary>
        /// 返回状态 
        /// 取值规则：1：成功；0：失败
        /// </summary>
        [JsonProperty("status")]
        public int Status { get; set; }

        /// <summary>
        /// status = 1，info返回“ok”
        /// status = 0，info返回参见:
        /// </summary>
        [JsonProperty("info")]
        public string Info { get; set; }

        /// <summary>
        /// 成功创建的数据id
        /// </summary>
        [JsonProperty("_id")]
        public string Id { get; set; }
    }
}