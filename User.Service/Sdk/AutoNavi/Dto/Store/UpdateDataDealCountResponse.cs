using Newtonsoft.Json;

namespace User.Service.Sdk.AutoNavi.Dto.Store
{
    public class UpdateDataDealCountResponse
    {
        /// <summary>
        /// 返回状态 
        /// 取值规则：1：成功；0：失败；-99：失败，网络通讯失败
        /// </summary>
        [JsonProperty("status")]
        public int Status { get; set; }

        /// <summary>
        /// status = 1，info返回“ok”
        /// status = 0，info返回错误说明
        /// </summary>
        [JsonProperty("info")]
        public string Info { get; set; }  
    }
}