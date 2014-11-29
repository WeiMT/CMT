using System;
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
        /// <returns></returns>
        public static CreateTableResponse CreateTable(string tableName)
        {
            var parameters = new Dictionary<string, string>();
            parameters.Add("key",Keys.RestApiKey);
            parameters.Add("name", tableName);
            parameters.Add("sig", SignBuilder.Build(parameters, Keys.RestApiSignKey));

            try
            {
                var httpClient = new HttpClient();

                var content = new FormUrlEncodedContent(parameters);
                var response = httpClient.PostAsync("http://yuntuapi.amap.com/datamanage/table/create", content).Result;
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    return new CreateTableResponse
                    {
                        Status = -99,
                        Info = "失败，网络通讯失败"
                    };
                }

                var jsonObj = response.Content.ReadAsAsync<CreateTableResponse>().Result;

                return jsonObj;
            }
            catch (Exception ex)
            {
                return new CreateTableResponse
                {
                    Status = -99,
                    Info = "失败，网络通讯失败"
                };
            }
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
            var parameters = new Dictionary<string, string>();
            parameters.Add("key",Keys.RestApiKey);
            parameters.Add("tableid",request.TableId);
            parameters.Add("loctype","1");
            parameters.Add("data", JsonConvert.SerializeObject(request.CreateData));
            parameters.Add("sig", SignBuilder.Build(parameters, Keys.RestApiSignKey));

            try
            {
                var httpClient = new HttpClient();

                var content = new FormUrlEncodedContent(parameters);
                var response = httpClient.PostAsync("http://yuntuapi.amap.com/datamanage/data/create", content).Result;
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    return new CreateDataResponse
                    {
                        Status = -99,
                        Info = "失败，网络通讯失败"
                    };
                }

                var jsonObj = response.Content.ReadAsAsync<CreateDataResponse>().Result;

                return jsonObj;
            }
            catch (Exception ex)
            {
                return new CreateDataResponse
                {
                    Status = -99,
                    Info = "失败，网络通讯失败"
                };
            }
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
            var parameters = new Dictionary<string, string>();
            parameters.Add("key", Keys.RestApiKey);
            parameters.Add("tableid", request.TableId);
            parameters.Add("loctype", "1");
            parameters.Add("data", JsonConvert.SerializeObject(request.UpdateData));
            parameters.Add("sig", SignBuilder.Build(parameters, Keys.RestApiSignKey));

            try
            {
                var httpClient = new HttpClient();

                var content = new FormUrlEncodedContent(parameters);
                var response = httpClient.PostAsync("http://yuntuapi.amap.com/datamanage/data/update", content).Result;
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    return new UpdateDataResponse
                    {
                        Status = -99,
                        Info = "失败，网络通讯失败"
                    };
                }

                var jsonObj = response.Content.ReadAsAsync<UpdateDataResponse>().Result;

                return jsonObj;
            }
            catch (Exception ex)
            {
                return new UpdateDataResponse
                {
                    Status = -99,
                    Info = "失败，网络通讯失败"
                };
            }
        }

        /// <summary>
        /// 更新商户数据中的交易数
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public static UpdateDataDealCountResponse UpdateDataDealCount(UpdateDataDealCountRequest request)
        {
            var parameters = new Dictionary<string, string>();
            parameters.Add("key", Keys.RestApiKey);
            parameters.Add("tableid", request.TableId);
            parameters.Add("loctype", "1");
            parameters.Add("data", JsonConvert.SerializeObject(request.UpdateData));
            parameters.Add("sig", SignBuilder.Build(parameters, Keys.RestApiSignKey));

            try
            {
                var httpClient = new HttpClient();

                var content = new FormUrlEncodedContent(parameters);
                var response = httpClient.PostAsync("http://yuntuapi.amap.com/datamanage/data/update", content).Result;
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    return new UpdateDataDealCountResponse
                    {
                        Status = -99,
                        Info = "失败，网络通讯失败"
                    };
                }

                var jsonObj = response.Content.ReadAsAsync<UpdateDataDealCountResponse>().Result;

                return jsonObj;
            }
            catch (Exception ex)
            {
                return new UpdateDataDealCountResponse
                {
                    Status = -99,
                    Info = "失败，网络通讯失败"
                };
            }
        }

        /// <summary>
        /// 更新商户数据中的好评数
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public static UpdateDataPraiseCountResponse UpdateDataPraiseCount(UpdateDataPraiseCountRequest request)
        {
            var parameters = new Dictionary<string, string>();
            parameters.Add("key", Keys.RestApiKey);
            parameters.Add("tableid", request.TableId);
            parameters.Add("loctype", "1");
            parameters.Add("data", JsonConvert.SerializeObject(request.UpdateData));
            parameters.Add("sig", SignBuilder.Build(parameters, Keys.RestApiSignKey));

            try
            {
                var httpClient = new HttpClient();

                var content = new FormUrlEncodedContent(parameters);
                var response = httpClient.PostAsync("http://yuntuapi.amap.com/datamanage/data/update", content).Result;
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    return new UpdateDataPraiseCountResponse
                    {
                        Status = -99,
                        Info = "失败，网络通讯失败"
                    };
                }

                var jsonObj = response.Content.ReadAsAsync<UpdateDataPraiseCountResponse>().Result;

                return jsonObj;
            }
            catch (Exception ex)
            {
                return new UpdateDataPraiseCountResponse
                {
                    Status = -99,
                    Info = "失败，网络通讯失败"
                };
            }
        }

        /// <summary>
        /// 删除数据（单条/批量）
        /// 删除指定tableid的数据表中的数据，一次请求限制删除1-50条数据。
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public static DeleteDataResponse DeleteData(DeleteDataRequest request)
        {
            var parameters = new Dictionary<string, string>();
            parameters.Add("key", Keys.RestApiKey);
            parameters.Add("tableid", request.TableId);
            parameters.Add("ids", request.Ids);
            parameters.Add("sig", SignBuilder.Build(parameters, Keys.RestApiSignKey));

            try
            {
                var httpClient = new HttpClient();

                var content = new FormUrlEncodedContent(parameters);
                var response = httpClient.PostAsync("http://yuntuapi.amap.com/datamanage/data/delete", content).Result;
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    return new DeleteDataResponse
                    {
                        Status = -99,
                        Info = "失败，网络通讯失败"
                    };
                }

                var jsonObj = response.Content.ReadAsAsync<DeleteDataResponse>().Result;

                return jsonObj;
            }
            catch (Exception ex)
            {
                return new DeleteDataResponse
                {
                    Status = -99,
                    Info = "失败，网络通讯失败"
                };
            }
        }
    }
}