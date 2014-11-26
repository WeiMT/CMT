using Newtonsoft.Json;

namespace User.Service.Sdk.AutoNavi.Dto.Store
{
    public class DeleteDataRequest
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
        /// 删除的数据_id
        /// 一次请求限制1-50条数据，多个_id用逗号隔开
        /// </summary>
        [JsonProperty("ids")]
        public string Ids { get; set; }
    }
}