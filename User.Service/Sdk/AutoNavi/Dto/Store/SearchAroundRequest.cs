using System.ComponentModel;
using Newtonsoft.Json;

namespace User.Service.Sdk.AutoNavi.Dto.Store
{
    public class SearchAroundRequest
    {
        /// <summary>
        /// 含义：数据表唯一标识
        /// 必须：必填
        /// </summary>
        [JsonProperty("tableid")]
        public string TableId { get; set; }

        /// <summary>
        /// 含义：搜索关键词,支持0-9数字，大小写字母（a-z,A-Z）以及所有中文字符
        /// 说明：1.检索范围：对建立【文本索引字段】对应列内容进行模糊检索； 
        ///      2.系统默认为_name（点名称）和_address（点地址）建立文本索引，若您期望在更多字段值里检索关键字，请在云图数据管理台，添加更多索引字段，详见 添加文本索引（keywords） 
        ///      3.一次请求最多返回1000条数据。
        /// 必须：可选
        /// 默认值：无
        /// </summary>
        [JsonProperty("keywords")]
        public string KeyWords { get; set; }

        /// <summary>
        /// 含义：中心点坐标
        /// 说明：经度和纬度用","分割 
        ///      经纬度小数点后不得超过6位。
        /// 必须：必填
        /// </summary>
        [JsonProperty("center")]
        public string Center { get; set; }

        /// <summary>
        /// 含义：查询半径
        /// 说明：取值范围[0,50000]，单位：米。若超出取值范围按默认值
        /// 必须：可选
        /// 默认值：3000
        /// </summary>
        [JsonProperty("radius")]
        public string Radius { get; set; }

        /// <summary>
        /// 含义：过滤条件
        /// 说明：筛选条件： 
        ///      支持对建立了排序筛选索引的字段进行筛选（请在 数据管理台 中为字段建立排序筛选索引） 
        ///      系统默认为：_id，_name，_address，_updatetime，_createtime建立排序筛选索引，其中_updatetime,_createtime暂时只支持排序）； 
        ///      支持多个筛选条件，多个筛选条件之间使用“+”代表与关系； 
        ///      支持对文本字段的精确匹配； 
        ///      支持对整数和小数字段的连续区间筛选。 
        ///      规则： 
        ///      filter=key1:value1+key2:[value2,value3] 
        ///      示例： 
        ///      filter=type:酒店+star:[3,5] 
        ///      （等同于SQL语句的： 
        ///      WHERE type = "酒店" 
        ///      AND star BETWEEN 3 AND 5）
        /// 必须：可选
        /// 默认值：无
        /// </summary>
        [JsonProperty("filter")]
        public string Filter { get; set; }

        /// <summary>
        /// 含义：排序规则
        /// 说明：1、支持按系统预设的： 
        ///         _distance：坐标与中心点距离排序(仅支持升序sortrule=_distance:1)； 
        ///         _weight：权重排序(仅支持降序sortrule=_ weight:0)； 
        ///         示例：按距离排序 
        ///         sortrule=_distance 
        ///      2、支持按建立了排序筛选索引的整数或小数字段进行排序（请在 数据管理台 中管理排序筛选索引） 
        ///         sortrule=字段名:1 （升序）； 
        ///         sortrule=字段名:0 （降序）； 
        ///         若不填升降序，则默认按升序排列。 
        ///         示例： 
        ///         按年龄age字段升序排序 
        ///         sortrule=age:1
        /// 必须：可选
        /// 默认值：1、当keywords存在时：默认按_weight权重排序； 
        ///        2、当keywords不存在时，默认按_distance距离排序；
        /// </summary>
        [JsonProperty("sortrule")]
        public string SortRule { get; set; }

        /// <summary>
        /// 含义：每页记录数
        /// 说明：最大每页记录数为100
        /// 必须：可选
        /// 默认值：20
        /// </summary>
        [JsonProperty("limit")]
        public string Limit { get; set; }

        /// <summary>
        /// 含义：当前页数
        /// 说明：>=1
        /// 必须：可选
        /// 默认值：1
        /// </summary>
        [JsonProperty("page")]
        public string Page { get; set; }
    }
}