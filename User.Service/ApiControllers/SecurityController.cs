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
        /// <returns></returns>
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
        /// <returns></returns>
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
    }
}