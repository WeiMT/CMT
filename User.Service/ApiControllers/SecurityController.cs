using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Runtime.Caching;
using System.ServiceModel.Channels;
using System.Threading;
using System.Web;
using System.Web.Http;
using DataAccess.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using User.Service.Helpers;
using User.Service.Sdk.AutoNavi;
using User.Service.Sdk.AutoNavi.Dto.Store;

namespace User.Service.ApiControllers
{
    public class SecurityController :ApiController
    {
        ///// <summary>
        ///// 匿名注册，达到用户在尚未注册时，也能保存数据
        ///// 成功后客户端需要保存匿名令牌
        ///// </summary>
        ///// <returns></returns>
        //[AllowAnonymous]
        //[HttpPost]
        //[ActionName("AnonymousRegister")]
        //public dynamic AnonymousRegister()
        //{
        //    using (var ctx = new CarHealthEntities())
        //    {
        //        var user = new DataAccess.Models.User
        //        {
        //            Type = 1,
        //            RecCreateDt = DateTime.Now,
        //            RecStatus = 1
        //        };

        //        ctx.Users.Add(user);

        //        ctx.SaveChanges();

        //        var userId = user.Id;

        //        var dicts = new Dictionary<string, string>();
        //        dicts.Add("Id", userId.ToString());

        //        var token = new TokenBuilder(TokenSignKey).Build(dicts);
        //        var encryptToken = AesHelper.Encrypt(token, TokenEncryptKey);

        //        return new
        //        {
        //            UserType = 1,
        //            Token = encryptToken
        //        };
        //    }
        //}

        /// <summary>
        /// 发送注册/登录验证码，验证码有效期10分钟
        /// </summary>
        ///<param name="reqData">
        /// {"Cellphone":"18070037088"}
        /// </param>
        /// <returns>
        /// {
        ///     //0为成功，其它为失败
        ///     ResultCode = "1",
        ///     //失败时显示，失败原因
        ///     ResultMsg = "手机号码格式不正确"
        /// }
        /// </returns>
        [AllowAnonymous]
        [HttpPost]
        [ActionName("SendSmsRegLoginCode")]
        public dynamic SendSmsRegLoginCode(JObject reqData)
        {
            var cellphone = reqData["Cellphone"].ToObject<string>().Trim();

            if (cellphone.Length != 11)
            {
                return new
                {
                    ResultCode = "1",
                    ResultMsg = "手机号码格式不正确"
                };
            }
            
            var verifyCode = "";

            for (int i = 0; i < 6; i++)
            {
                var rd = new Random();
                verifyCode += rd.Next(0, 9);
                Thread.Sleep(1);
            }

            MemoryCache.Default.Set(cellphone, verifyCode, DateTimeOffset.Now.AddMinutes(10));

            var httpClient = new HttpClient();
            var sms = new
            {
                userName = "itdept",
                password = "123456",
                phoneNumber = cellphone,
                content = "您的验证码为" + verifyCode +",验证码有效期为10分钟",
                source = "8",
                externalId = "外部id"
            };

            httpClient.PostAsJsonAsync("http://114.215.158.18:8123/SMS/Send", sms);
            
            return new
            {
                ResultCode = "0",
                ResultMsg = "发送验证码成功"
            };
        }

        /// <summary>
        /// 注册/登录
        /// 成功后，客户端应该保存令牌
        /// </summary>
        /// <param name="reqData">
        /// {"Cellphone":"18070037088","VerifyCode":"990980"}
        /// </param>
        /// <returns>
        /// 成功时，访问令牌下发在Cookie中，AzuCookie
        /// {
        ///     //0为成功，其它为失败
        ///     ResultCode = "0",
        ///     //失败时显示失败原因
        ///     ResultMsg = "",
        ///     //成功时有值，1匿名用户，2注册用户，3VIP用户，4预注册用户；
        ///     UserType = user.Type
        /// }
        /// </returns>
        [AllowAnonymous]
        [HttpPost]
        [ActionName("RegLogin")]
        public HttpResponseMessage RegLogin(JObject reqData)
        {
            var cellphone = reqData["Cellphone"].ToObject<string>();
            var code = reqData["VerifyCode"].ToObject<string>();

            var memoCode = MemoryCache.Default.Get(cellphone);
            if (memoCode == null || code != memoCode.ToString())
            {
                var resp = new HttpResponseMessage();
                resp.Content = new ObjectContent<dynamic>(
                new
                {
                    ResultCode = "1",
                    ResultMsg = "验证码错误或已过期，请重新获取"
                },
                new JsonMediaTypeFormatter());

                return resp;
            }

            using (var ctx = new CarHealthEntities())
            {
                var user = ctx.Users.FirstOrDefault(x => x.Cellphone == cellphone);

                if (user == null)
                {
                    user = new DataAccess.Models.User
                    {
                        Cellphone = cellphone,
                        Type = 2,
                        LatestLoginDt = DateTime.Now,
                        LatestLoginIp = CommonHelper.GetClientIp(Request),
                        RecCreateDt = DateTime.Now,
                        RecStatus = 1
                    };

                    ctx.Users.Add(user);

                    ctx.SaveChanges();
                }
                else
                {
                    //预注册用户，升级为注册用户
                    if (user.Type == 4)
                    {
                        user.Type = 2;
                    }

                    user.LatestLoginDt = DateTime.Now;
                    user.LatestLoginDt = DateTime.Now;
                    user.LatestLoginIp = CommonHelper.GetClientIp(Request);
                    user.RecStatus = 1;

                    ctx.SaveChanges();
                }

                var userId = user.Id;

                var resp = new HttpResponseMessage();
                resp.Content = new ObjectContent<dynamic>(
                new
                {
                    ResultCode = "0",
                    ResultMsg = "",
                    UserType = user.Type
                },
                new JsonMediaTypeFormatter());

                var cookie = new CookieHeaderValue("AzuCookie", LocalUserTokenHelper.GenerateLocalToken(userId));                
                cookie.Domain = Request.RequestUri.Host;
                cookie.Path = "/";
                resp.Headers.AddCookies(new [] { cookie });

                return resp;
            }
        }

        /// <summary>
        /// 注销
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionName("Logout")]
        public dynamic Logout()
        {
            return null;
        }

        [AllowAnonymous]
        [HttpGet]
        public dynamic TestAMap()
        {
            YuntuCreateDataTest();

            return null;
        }

        private void YuntuCreateDataTest()
        {
            var request = new CreateDataRequest
            {
                TableId = Tables.VendorTableId,
                LocType = 1,
                CreateData = new CreateDataRequest.Data
                {
                    Name = "南昌八一洗车店",
                    Category = "洗车",
                    Address = "南昌八一大道545号",
                    CoordType = "autonavi",
                    CarServiceTag = "清洗;贴膜",
                    UserServiceTag = "折;卡",
                    Location = "115.90353,28.683058",
                    DealCount = 1,
                    PraiseCount = 0,
                    VendorId = 12,
                    PicUrl = "http://"
                }
            };

            var response = YuntuStore.CreateData(request);
        }
    }
}