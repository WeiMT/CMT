using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace User.Service.Sdk.AutoNavi.Dto.Store
{
    public class CreateTableResponse
    {
        /// <summary>
        /// 返回状态 
        /// 取值规则：
        /// 1：成功；
        /// 0：失败，未知原因；
        /// -11：失败，已存在相同名称表
        /// -21：失败，已创建表达到最大数据
        /// -99: 失败，网络通讯失败
        /// </summary>
        [JsonProperty("status")]
        public int Status { get; set; }

        /// <summary>
        /// status = 1，info返回“ok”
        /// status = 0，info返回错误说明
        /// </summary>
        [JsonProperty("info")]
        public string Info { get; set; }

        /// <summary>
        /// 生成的数据表的唯一标识
        /// </summary>
        [JsonProperty("tableid")]
        public string TableId { get; set; }
    }
}