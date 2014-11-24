using System.Linq;
using System.Net.Http;
using DataAccess.Models;

namespace User.Service.Models
{
    public class AzUser
    {
        /// <summary>
        /// 用户表的ID
        /// </summary>
        public long UserId { get; set; }

        public DataAccess.Models.User User { get; set; }

        public static void SetInApi(HttpRequestMessage request, long userId)
        {
            var azUser = new AzUser
            {
                UserId = userId
            };

            using (var ctx = new CarHealthEntities())
            {
                var user = ctx.Users.FirstOrDefault(x => x.Id == userId);

                azUser.User = user;
            }

            request.Properties["AzUser"] = azUser;
        }

        public static AzUser GetInApi(HttpRequestMessage request)
        {
            var azUser = (AzUser)request.Properties["AzUser"];

            return azUser;
        }
    }
}