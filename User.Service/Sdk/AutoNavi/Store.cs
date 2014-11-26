using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using User.Service.Sdk.AutoNavi.Dto.Store;

namespace User.Service.Sdk.AutoNavi
{
    /// <summary>
    /// 云存储 Rest Api 接口
    /// </summary>
    public class YuntuStore
    {
        /// <summary>
        /// 创建表
        /// 创建一个存储用户数据的表，等同于在数据管理台手工创建一个地图（一张云图）。
        /// http://lbs.amap.com/yuntu/reference/cloudstorage/#yuntureference_createtable
        /// </summary>
        /// <param name="tableName">
        /// 表的名称
        /// 支持任意中英文字符、数字、下划线
        /// </param>
        /// <returns>
        /// 返回结果，定义参照上面sdk链接
        /// {            
        ///     "info":"OK", 
        ///     "status":1, 
        ///     "tableid":"53a4093fe4b0a4a84f9b66cf" 
        /// }
        /// </returns>
        public static JObject CreateTable(string tableName)
        {
            var httpClient = new HttpClient();

            var parameters = new Dictionary<string, string>();
            parameters.Add("key",Keys.RestApiKey);
            parameters.Add("name", tableName);
            parameters.Add("sig", SignBuilder.Build(parameters, Keys.RestApiSignKey));

            var content = new FormUrlEncodedContent(parameters);
            var response = httpClient.PostAsync("http://yuntuapi.amap.com/datamanage/table/create", content).Result;
            if (response.StatusCode != HttpStatusCode.OK)
            {
                return null;
            }

            var jsonObj = response.Content.ReadAsAsync<JObject>().Result;

            return jsonObj;
        }

        /// <summary>
        /// 创建单条数据
        /// 向指定tableid的数据表中插入一条新数据。
        /// http://lbs.amap.com/yuntu/reference/cloudstorage/#yuntureference_creatdata
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public static CreateDataResponse CreateData(CreateDataRequest request)
        {
            request.Key = Keys.RestApiKey;

            var parameters = new Dictionary<string, string>();
            parameters.Add("key",request.Key);
            parameters.Add("tableid",request.TableId);
            parameters.Add("loctype",request.LocType.ToString());
            parameters.Add("data", JsonConvert.SerializeObject(request.CreateData));
            parameters.Add("sig", SignBuilder.Build(parameters, Keys.RestApiSignKey));

            var httpClient = new HttpClient();

            var content = new FormUrlEncodedContent(parameters);
            var response = httpClient.PostAsync("http://yuntuapi.amap.com/datamanage/data/create", content).Result;
            if (response.StatusCode != HttpStatusCode.OK)
            {
                return null;
            }

            var jsonObj = response.Content.ReadAsAsync<CreateDataResponse>().Result;

            return jsonObj;
        }

        /// <summary>
        /// 更新一条数据
        /// 指定tableid的数据表中更新一条数据。
        /// http://lbs.amap.com/yuntu/reference/cloudstorage/#yuntureference_updatedata
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public static UpdateDataResponse UpdateData(UpdateDataRequest request)
        {
            request.Key = Keys.RestApiKey;

            var parameters = new Dictionary<string, string>();
            parameters.Add("key", request.Key);
            parameters.Add("tableid", request.TableId);
            parameters.Add("loctype", request.LocType.ToString());
            parameters.Add("data", JsonConvert.SerializeObject(request.UpdateData));
            parameters.Add("sig", SignBuilder.Build(parameters, Keys.RestApiSignKey));

            var httpClient = new HttpClient();

            var content = new FormUrlEncodedContent(parameters);
            var response = httpClient.PostAsync("http://yuntuapi.amap.com/datamanage/data/update", content).Result;
            if (response.StatusCode != HttpStatusCode.OK)
            {
                return null;
            }

            var jsonObj = response.Content.ReadAsAsync<UpdateDataResponse>().Result;

            return jsonObj;
        }

        /// <summary>
        /// 删除数据（单条/批量）
        /// 删除指定tableid的数据表中的数据，一次请求限制删除1-50条数据。
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public static DeleteDataResponse DeleteData(DeleteDataRequest request)
        {
            request.Key = Keys.RestApiKey;

            var parameters = new Dictionary<string, string>();
            parameters.Add("key", request.Key);
            parameters.Add("tableid", request.TableId);
            parameters.Add("ids", request.Ids);
            parameters.Add("sig", SignBuilder.Build(parameters, Keys.RestApiSignKey));

            var httpClient = new HttpClient();

            var content = new FormUrlEncodedContent(parameters);
            var response = httpClient.PostAsync("http://yuntuapi.amap.com/datamanage/data/delete", content).Result;
            if (response.StatusCode != HttpStatusCode.OK)
            {
                return null;
            }

            var jsonObj = response.Content.ReadAsAsync<DeleteDataResponse>().Result;

            return jsonObj;
        }
    }
}