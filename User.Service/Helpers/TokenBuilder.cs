using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace User.Service.Helpers
{
    public class TokenBuilder
    {
        //约定的Salt
        private readonly string _key = "";
        //编码格式
        private const string InputCharset = "utf-8";
        //签名方式
        private const string SignType = "MD5";

        public TokenBuilder(string key)
        {
            _key = key;
        }

        public string Build(Dictionary<string, string> keyVauePaires)
        {
            var code = Encoding.GetEncoding(InputCharset);
            var dicParam = BuildRequestPara(keyVauePaires);
            return CreateLinkStringUrlencode(dicParam, code);
        }

        public bool Verify(string token, out Dictionary<string, string> claims)
        {
            var code = Encoding.GetEncoding(InputCharset);
            claims = DecomposeLinkStringUrlencode(token, code);

            //签名结果
            string mysign = "";
            
            //过滤签名参数数组
            var sPara = FilterPara(claims);

            //获得签名结果
            mysign = BuildRequestMysign(sPara);

            return mysign == claims.FirstOrDefault(c => c.Key == "sign").Value;
        }

        /// <summary>
        /// 除去数组中的空值和签名参数并以字母a到z的顺序排序
        /// </summary>
        /// <param name="dicArrayPre">过滤前的参数组</param>
        /// <returns>过滤后的参数组</returns>
        private Dictionary<string, string> FilterPara(Dictionary<string, string> dicArrayPre)
        {
            var result = from kv in dicArrayPre orderby kv.Key select kv;

            var dicArray = new Dictionary<string, string>();
            foreach (KeyValuePair<string, string> temp in result)
            {
                if (temp.Key.ToLower() != "sign" && temp.Key.ToLower() != "sign_type" && !string.IsNullOrEmpty(temp.Value))
                {
                    dicArray.Add(temp.Key, temp.Value);
                }
            }

            return dicArray;
        }

        /// <summary>
        /// 把数组所有元素，按照“参数=参数值”的模式用“&”字符拼接成字符串
        /// </summary>
        /// <param name="dicArray">需要拼接的数组</param>
        /// <returns>拼接完成以后的字符串</returns>
        public static string CreateLinkString(Dictionary<string, string> dicArray)
        {
            var prestr = new StringBuilder();
            foreach (KeyValuePair<string, string> temp in dicArray)
            {
                prestr.Append(temp.Key + "=" + temp.Value + "&");
            }

            //去掉最後一個&字符
            int nLen = prestr.Length;
            prestr.Remove(nLen - 1, 1);

            return prestr.ToString();
        }

        public static Dictionary<string, string> DecomposeLinkString(string linkString)
        {
            string[] keyPaires = linkString.Split('&');
            var dicArray = new Dictionary<string, string>();
            foreach (string keyPaire in keyPaires)
            {
                string[] temp = keyPaire.Split('=');
                dicArray.Add(temp[0], temp[1]);
            }
            return dicArray;
        }

        /// <summary>
        /// 把数组所有元素，按照“参数=参数值”的模式用“&”字符拼接成字符串，并对参数值做urlencode
        /// </summary>
        /// <param name="dicArray">需要拼接的数组</param>
        /// <param name="code">字符编码</param>
        /// <returns>拼接完成以后的字符串</returns>
        public static string CreateLinkStringUrlencode(Dictionary<string, string> dicArray, Encoding code)
        {
            var prestr = new StringBuilder();
            foreach (KeyValuePair<string, string> temp in dicArray)
            {
                prestr.Append(temp.Key + "=" + HttpUtility.UrlEncode(temp.Value, code) + "&");
            }

            //去掉最後一個&字符
            int nLen = prestr.Length;
            prestr.Remove(nLen - 1, 1);

            return prestr.ToString();
        }

        public static Dictionary<string, string> DecomposeLinkStringUrlencode(string linkString, Encoding code)
        {
            string[] keyPaires = linkString.Split('&');
            var dicArray = new Dictionary<string, string>();
            foreach (string keyPaire in keyPaires)
            {
                string[] temp = keyPaire.Split('=');
                dicArray.Add(temp[0], HttpUtility.UrlDecode(temp[1], code));
            }
            return dicArray;
        }

        /// <summary>
        /// 生成要请求参数数组
        /// </summary>
        /// <param name="sParaTemp">请求前的参数数组</param>
        /// <returns>要请求的参数数组</returns>
        private Dictionary<string, string> BuildRequestPara(Dictionary<string, string> sParaTemp)
        {
            //签名结果
            string mysign = "";

            //过滤签名参数数组
            var sPara = FilterPara(sParaTemp);

            //获得签名结果
            mysign = BuildRequestMysign(sPara);

            //签名结果与签名方式加入请求提交参数组中
            sPara.Add("sign", mysign);
            sPara.Add("sign_type", SignType);

            return sPara;
        }

        /// <summary>
        /// 生成请求时的签名
        /// </summary>
        /// <param name="sPara">请求参数数组</param>
        /// <returns>签名结果</returns>
        private string BuildRequestMysign(Dictionary<string, string> sPara)
        {
            //把数组所有元素，按照“参数=参数值”的模式用“&”字符拼接成字符串
            string prestr = CreateLinkString(sPara);

            //把最终的字符串签名，获得签名结果
            string mysign = "";
            switch (SignType)
            {
                case "MD5":
                    mysign = MD5Sign(prestr, _key, InputCharset);
                    break;
                default:
                    mysign = "";
                    break;
            }

            return mysign;
        }

        private string MD5Sign(string prestr, string key = "", string inputCharset = "utf-8")
        {
            var sb = new StringBuilder(32);

            prestr = prestr + key;

            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] t = md5.ComputeHash(Encoding.GetEncoding(inputCharset).GetBytes(prestr));
            for (int i = 0; i < t.Length; i++)
            {
                sb.Append(t[i].ToString("x").PadLeft(2, '0'));
            }

            return sb.ToString();
        }
    }
}