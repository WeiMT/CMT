using System;
using System.Collections.Generic;
using System.Net.Http.Formatting;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace User.Service.Sdk.AutoNavi
{
    public class SignBuilder
    {
        public static string Build(Dictionary<string, string> claims, string signKey)
        {
            var kvs = from c in claims orderby c.Key select c.Key + "=" + c.Value;

            var encypStr = kvs.StringJoin("&") + signKey;

            var m5 = new MD5CryptoServiceProvider();

            //使用UTF8编码方式把字符串转化为字节数组．
            byte[] inputBye = Encoding.UTF8.GetBytes(encypStr);

            byte[] outputBye = m5.ComputeHash(inputBye);

            string retStr = BitConverter.ToString(outputBye);
            retStr = retStr.Replace("-", "").ToLower();

            return retStr;
        }
    }
}