using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using DataAccess.Models;

namespace ToolConsole
{
    class Program
    {
        private static HttpClient client = new HttpClient();

        static void Main(string[] args)
        {
            //GetCarTypePic();

            //var inputb = Encoding.ASCII.GetBytes("123456");
            //var inputb = new byte[]{0x76,0x3A,0xFC,0x53,0x7F,0x78,0x76,0xC2,0xD0,0xB5,0x9F,0xDB,0x68,0xD7,0x62,0xE9 ,0x0C,0xEF,0xD2,0x22,0xBB,0x35,0x8D,0x0D,0x69,0x31,0x86,0x7C,0xE2,0x65,0x38,0x64,0x9B,0xE3,0x57,0x9A,0x40,0x04,0x48,0x3E,0xA5,0xD8,0x4D,0x00,0x50,0x63,0xF7,0x6F,0xB1,0xCE,0x7E,0x5F,0x2F,0x93,0x3B,0x5E,0xD7,0x57,0xA7,0x18,0x18,0x2F,0x38,0x3C,0x4D,0x58,0x29,0x1A,0x6A,0x5D,0x8D,0x07,0xC0,0x81,0xF6,0x68,0x06,0x03,0x15,0x39,0x09,0x33,0x62,0xD8,0x54,0x88,0x3A,0x88,0x74,0xF7,0xB9,0x19,0x92,0x5D,0xAB,0xC7,0x4C,0x17,0x3E,0x21,0x62,0xF0,0x7E,0x67,0x80,0xE3,0x11,0xFF,0x0A,0xEF,0x05,0x9A,0xE6,0x20,0x30,0x3D,0xEC,0xB6,0x28,0x9E,0x97,0xF7,0x2C,0x01,0x87,0x23,0xC4,0x71};
            //byte[] output =new byte[32];

            //DllImportCl.sm3_crypt_hash(inputb, output, inputb.Length);

            //Console.WriteLine(BitConverter.ToString(output).Replace("-","").ToLower());

            //var result =
            //    MD5Sign(
            //        "customerName=风中的猪&customerId=avp009io09&mobilePhone=18070037888&timestamp=2014-10-22T14:45:07",
            //        "8934e7d15453e97507ef794cf7b0519d");

            //Console.WriteLine(result);

            //CopyDataFromSqlServer2MySql();

            //AliyunOssCors();

            //CopyDataFromSqlServer2MySql();

            //GetAdminDivisions();

            //ProcessAdminDivisions();

            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            for (int n = 0; n < 50; n++)
            {
                sw.Reset();
                sw.Start();

                var dis = GetDistance(115.883408, 28.683199, 115.888338, 28.676728);

                sw.Stop();

                Console.WriteLine(dis + "耗时：" + sw.ElapsedMilliseconds + "||" + sw.ElapsedTicks);

                sw.Reset();
                sw.Start();

                dis = GetDistance(115.883408, 28.683199, 115.892903, 28.68775);

                sw.Stop();

                Console.WriteLine(dis + "耗时：" + sw.ElapsedMilliseconds + "||" + sw.ElapsedTicks);
            }                       

            Console.ReadKey();

        }

        //private static void AliyunOssCors()
        //{
        //    var ossClient = new OssClient("http://oss-cn-qingdao.aliyuncs.com","XoXv5sH7MgJxcncn", "ofmaSR89yerptS9s0ne4mzp21zDCZ0");
        //    var corsReq = new SetBucketCorsRequest("bkcdn");
        //    var corsRule = new CORSRule();
        //    corsRule.AddAllowedOrigin("*");
        //    corsRule.AddAllowedMethod("GET");

        //    corsReq.AddCORSRule(corsRule);

        //    ossClient.SetBucketCors(corsReq);
        //}

        static string MD5Sign(string prestr, string key = "", string _input_charset = "utf-8")
            {
                StringBuilder sb = new StringBuilder(32);

                prestr = prestr + key;

                MD5 md5 = new MD5CryptoServiceProvider();
                byte[] t = md5.ComputeHash(Encoding.GetEncoding(_input_charset).GetBytes(prestr));
                for (int i = 0; i < t.Length; i++)
                {
                    sb.Append(t[i].ToString("x").PadLeft(2, '0'));
                }

                return sb.ToString();
            }

        private static void CopyDataFromSqlServer2MySql()
        {
            List<CarType> carTypes;

            using (var sqlCtx = new CarHealthEntities1())
            {
                carTypes = sqlCtx.CarTypes.ToList();
            }

            var count = carTypes.Count;
            var pageSize = 2000;
            var maxPage = carTypes.Count / pageSize + (carTypes.Count % pageSize == 0 ? 0 : 1);

            Console.WriteLine("总数据量 :" + count);

            for (int i = 0; i < maxPage; i++)
            {
                var pCarTypes = carTypes.Skip(i * pageSize).Take(pageSize);

                var iShowdow = i;
                var pCarTypesShowdow = pCarTypes;
                var j = 0;

                new Thread(() =>
                {
                    Console.WriteLine("开始插入 " + (iShowdow * pageSize));

                    using (var mySqlCtx = new DataAccess.Models.CarHealthEntities())
                    {
                        foreach (var carType in pCarTypesShowdow)
                        {
                            j++;
                            var myCarType = new DataAccess.Models.CarType();

                            myCarType.BrandFirstLetter = carType.BrandFirstLetter;
                            myCarType.BrandName = carType.BrandName;
                            myCarType.MfgrName = carType.MfgrName;
                            myCarType.CarTypeName = carType.CarTypeName;
                            myCarType.CarTypeYear = carType.CarTypeYear;
                            myCarType.Specification = carType.Specification;
                            myCarType.BrandCountry = carType.BrandCountry;
                            myCarType.Technology = carType.Technology;
                            myCarType.Grade = carType.Grade;
                            myCarType.GasDisplacement = carType.GasDisplacement;
                            myCarType.GearBox = carType.GearBox;
                            myCarType.RecCreateDt = DateTime.Now;
                            myCarType.RecStatus = 1;

                            mySqlCtx.CarTypes.Add(myCarType);

                            mySqlCtx.SaveChanges();
                        }

                        Console.WriteLine("插入完成 " + j);
                    }
                }).Start();
            }

        }

        private static void GetCarTypePic()
        {
            Console.WriteLine("开始下载网页...");

            var encoding = Encoding.GetEncoding("gb2312");


            var htmlBytes = client.GetByteArrayAsync("http://car.autohome.com.cn/zhaoche/pinpai/").Result;

            var htmlStr = encoding.GetString(htmlBytes);

            Console.WriteLine("网页下载完成...");

            Console.WriteLine("正在分析网页...");

            //<dt><p><a href="http://car.autohome.com.cn/price/brand-157.html" class="pic" target="_blank"><img src="http://car1.autoimg.cn/logo/brand/50/129702914033140193.jpg"></a></p><p><a href="http://car.autohome.com.cn/price/brand-157.html" target="_blank">Dacia</a></p></dt>

            //var regPatten = "<dt><p><a href=\"(\\w+)\" class=\"pic\" target=\"_blank\"><img src=\"(\\w+)\"></a></p><p><a href=\"(\\w+)\" target=\"_blank\">(\\w+)</a></p></dt>";

            var regPatten =
                "<dt><p><a href=\"([^>]+)\" class=\"pic\" target=\"_blank\"><img src=\"([^>]+)\"></a></p><p><a href=\"([^>]+)\" target=\"_blank\">([^>]+)</a></p></dt>";

            Regex.Replace(htmlStr, regPatten, new MatchEvaluator(GetImgAndText), RegexOptions.Compiled | RegexOptions.IgnoreCase);

            Console.WriteLine("处理完成...");
        }

        private static string GetImgAndText(Match match)
        {
            var gp = match.Groups;

            var imgurl = gp[2].Value;
            var brandname = gp[4].Value;

            Task<Stream> streamAsync = client.GetStreamAsync(imgurl);

            Stream result = streamAsync.Result;
            using (Stream fileStream = File.Create("brandpic\\" + brandname + ".jpg"))
            {
                result.CopyTo(fileStream);

                Console.WriteLine("已下载图片 " + brandname + "...");
            }



            return "";
        }

        public static void GetAdminDivisions()
        {
            using (var ctx = new CarHealthEntities())
            {
                var lines = File.ReadLines("AdminDivision.txt");

                var writer = File.CreateText("Admin1.txt");

                foreach (var line in lines)
                {
                    if (!string.IsNullOrEmpty(line))
                    {
                        var reg = new Regex(@"(\d{6})\s*(\w*)");
                        var match = reg.Match(line);
                        if (match.Success)
                        {
                            var code = match.Groups[1].Value;
                            var name = match.Groups[2].Value;

                            var division = new AdminDivision
                            {
                                Code = code,
                                Name = name
                            };

                            ctx.AdminDivisions.Add(division);

                            Console.WriteLine(code + " :: " + name);
                        }
                    }
                }

                writer.Close();

                ctx.SaveChanges();

                Console.WriteLine("完成，按任意键退出");
                Console.ReadKey();
            }            
        }

        public static void ProcessAdminDivisions()
        {
            using (var ctx = new CarHealthEntities())
            {
                //var cities = ctx.AdminDivisions.Where(x => x.Code.EndsWith("00") && x.Name == "市辖区").ToList();

                //cities.ForEach(x =>
                //{
                //    var city = ctx.AdminDivisions.First(y => y.Code == x.Code.Substring(0, 2) + "0000");
                //    Console.WriteLine(city.Code + " :: " + city.Name);
                //    Console.WriteLine(x.Code + " :: " + x.Name);
                //});

                //var divisions = ctx.AdminDivisions.Where(x => x.Name.IndexOf("直辖") > 0).ToList();

                //divisions.ForEach(x =>
                //{
                //    var city = ctx.AdminDivisions.First(y => y.Code == x.Code.Substring(0, 2) + "0000");
                //    Console.WriteLine(city.Code + " :: " + city.Name);
                //    Console.WriteLine(x.Code + " :: " + x.Name);
                //});

                var counties = ctx.AdminDivisions.Where(x => x.Level == 3 && String.IsNullOrEmpty(x.Province)).ToList();

                counties.ForEach(x =>
                {
                    var pcode = x.Code.Substring(0, 2) + "0000";
                    var province = ctx.AdminDivisions.First(y => y.Level == 1 && y.Code == pcode);

                    var ccode = x.Code.Substring(0, 4) + "00";
                    var city = ctx.AdminDivisions.First(y => y.Level == 2 && y.Code == ccode);

                    x.Province = province.Name;
                    x.City = city.Name;
                    x.County = x.Name;

                    Console.WriteLine(x.Code + " :: " + x.Name);
                });

                ctx.SaveChanges();
            }

            Console.ReadKey();
        }

        private const double EARTH_RADIUS = 6378.137;//地球半径
        private static double rad(double d)
        {
            return d * Math.PI / 180.0;
        }

        public static double GetDistance(double lng1, double lat1, double lng2, double lat2)
        {
            double radLat1 = rad(lat1);
            double radLat2 = rad(lat2);
            double a = radLat1 - radLat2;
            double b = rad(lng1) - rad(lng2);

            double s = 2 * Math.Asin(Math.Sqrt(Math.Pow(Math.Sin(a / 2), 2) +
             Math.Cos(radLat1) * Math.Cos(radLat2) * Math.Pow(Math.Sin(b / 2), 2)));
            s = s * EARTH_RADIUS;
            s = Math.Round(s * 10000) / 10000;
            return s;
        }
    }
}
