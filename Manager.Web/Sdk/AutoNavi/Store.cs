using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using Manager.Web.Sdk.AutoNavi.Dto.Store;
using Newtonsoft.Json;

namespace Manager.Web.Sdk.AutoNavi
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
        /// http://lbs.amap.com/yuntu/reference/cloudstorage/#yuntureference_updatedata
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
        /// http://lbs.amap.com/yuntu/reference/cloudstorage/#yuntureference_updatedata
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
        /// http://lbs.amap.com/yuntu/reference/cloudstorage/#yuntureference_deletedata
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

        /// <summary>
        /// 周边检索
        /// 在指定tableid的数据表内，搜索指定中心点和半径范围内，符合筛选条件的位置数据
        /// http://lbs.amap.com/yuntu/reference/cloudsearch/#yuntureference_roundsearch
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public static SearchAroundResponse SearchAround(SearchAroundRequest request)
        {
            var parameters = new Dictionary<string, string>();
            parameters.Add("key",Keys.RestApiKey);
            parameters.Add("tableid",request.TableId);
            if (!String.IsNullOrEmpty(request.KeyWords))
            {
                parameters.Add("keywords", request.KeyWords);
            }
            parameters.Add("center", request.Center);
            if (!String.IsNullOrEmpty(request.Radius))
            {
                parameters.Add("radius", request.Radius);
            }
            if (!String.IsNullOrEmpty(request.Filter))
            {
                parameters.Add("filter", request.Filter);
            }
            if (!String.IsNullOrEmpty(request.SortRule))
            {
                parameters.Add("sortrule",request.SortRule);
            }
            if (!String.IsNullOrEmpty(request.Limit))
            {
                parameters.Add("limit", request.Limit);
            }
            if (!String.IsNullOrEmpty(request.Page))
            {
                parameters.Add("page",request.Page);
            }
            parameters.Add("sig", SignBuilder.Build(parameters, Keys.RestApiSignKey));

            var url = "http://yuntuapi.amap.com/datasearch/around?" +
                      parameters.Select(x => x.Key + "=" + x.Value.UrlEncode()).StringJoin("&");

            try
            {
                var httpClient = new HttpClient();
                var response = httpClient.GetAsync(url).Result;

                if (response.StatusCode != HttpStatusCode.OK)
                {
                    return new SearchAroundResponse
                    {
                        Status = -99,
                        Info = "失败，网络通讯失败"
                    };
                }

                var jsonObj = response.Content.ReadAsAsync<SearchAroundResponse>().Result;

                return jsonObj;
            }
            catch (Exception ex)
            {
                return new SearchAroundResponse
                {
                    Status = -99,
                    Info = "失败，网络通讯失败"
                };
            }
        }

        /// <summary>
        /// 本地检索
        /// 本地检索是指检索指定云图tableid里，对应城市（全国/省/市/区县）范围的POI信息，返回json数据。
        /// 例如：检索存储在云图里某个Tableid里的“北京市（city）”的“水果店(keywords )”。
        /// 当检索区域是全国时，等同于对存储在云图里的数据进行全表检索。
        /// keywords是对建立了文本索引字段的对应列内容进行关键字查询；
        /// filter和sortrule是对建立筛选排序索引字段的对应列内容进行筛选和检索结果排序，请在数据管理台完成文本/筛选排序字段索引字段的添加或删除。
        /// http://lbs.amap.com/yuntu/reference/cloudsearch/#yuntureference_localsearch
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public static SearchLocalResponse SearchLocal(SearchLocalRequest request)
        {
            var parameters = new Dictionary<string, string>();
            parameters.Add("key", Keys.RestApiKey);
            parameters.Add("tableid", request.TableId);
            if (!String.IsNullOrEmpty(request.KeyWords))
            {
                parameters.Add("keywords", request.KeyWords);
            }
            parameters.Add("city", request.City);
            if (!String.IsNullOrEmpty(request.Filter))
            {
                parameters.Add("filter", request.Filter);
            }
            if (!String.IsNullOrEmpty(request.SortRule))
            {
                parameters.Add("sortrule", request.SortRule);
            }
            if (!String.IsNullOrEmpty(request.Limit))
            {
                parameters.Add("limit", request.Limit);
            }
            if (!String.IsNullOrEmpty(request.Page))
            {
                parameters.Add("page", request.Page);
            }
            parameters.Add("sig", SignBuilder.Build(parameters, Keys.RestApiSignKey));

            var url = "http://yuntuapi.amap.com/datasearch/local?" +
                      parameters.Select(x => x.Key + "=" + x.Value.UrlEncode()).StringJoin("&");

            try
            {
                var httpClient = new HttpClient();
                var response = httpClient.GetAsync(url).Result;

                if (response.StatusCode != HttpStatusCode.OK)
                {
                    return new SearchLocalResponse
                    {
                        Status = -99,
                        Info = "失败，网络通讯失败"
                    };
                }

                var jsonObj = response.Content.ReadAsAsync<SearchLocalResponse>().Result;

                return jsonObj;
            }
            catch (Exception ex)
            {
                return new SearchLocalResponse
                {
                    Status = -99,
                    Info = "失败，网络通讯失败"
                };
            }
        }
    }
}