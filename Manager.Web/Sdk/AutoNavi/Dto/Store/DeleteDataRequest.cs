using Newtonsoft.Json;

namespace Manager.Web.Sdk.AutoNavi.Dto.Store
{
    public class DeleteDataRequest
    {
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