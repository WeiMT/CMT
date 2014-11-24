using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.Net.Http;
using System.Runtime.Caching;
using System.Web.Http;
using DataAccess.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using User.Service.Helpers;

namespace User.Service.ApiControllers
{
    public class SecurityController :ApiController
    {
        private const string TokenSignKey = "jasidjfaois09080m5tyuit";
        private const string TokenEncryptKey = "ythgbinhuimkdiny";

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
        //            IsAnonymous = 1,
        //            Token = encryptToken
        //        };
        //    }
        //}

        /// <summary>
        /// 发送注册验证码，验证码有效期10分钟
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        [ActionName("SendSmsRegisterCode")]
        public dynamic SendSmsRegisterCode(JObject reqData)
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
                var rd = new Random(DateTime.Now.Millisecond + (10*i));
                verifyCode += rd.Next(0, 9);
            }

            MemoryCache.Default.Set(cellphone, verifyCode, DateTimeOffset.Now.AddMinutes(10));

            var httpClient = new HttpClient();
            var sms = new
            {
                userName = "itdept",
                password = "123456",
                phoneNumber = cellphone,
                content = "您的注册码为" + verifyCode,
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
        /// 注册用户
        /// 注册成功后，客户端应该保存注册后的令牌
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        [ActionName("Register")]
        public dynamic Register(JObject reqData)
        {
            return null;
        }

        /// <summary>
        /// 注册用户登录
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        [ActionName("Login")]
        public dynamic Login()
        {
            return null;
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