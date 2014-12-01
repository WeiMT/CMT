using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DataAccess.Models;

namespace Manager.Web.ApiControllers
{
    public class VendorTagController : ApiController
    {
        [HttpGet]
        [ActionName("GetVendorTagSourceByGroupName")]
        public dynamic GetVendorTagSourceByGroupName(string groupName)
        {
            using (var ctx = new CarHealthEntities())
            {
                var tags = ctx.VendorTagSources.Where(x=>x.RecStatus == 1).Where(x => x.GroupName == groupName).ToList();

                return tags;
            }
        }

        [HttpGet]
        [ActionName("GetVendorTagSourceById")]
        public dynamic GetVendorTagSourceById(long id)
        {
            using (var ctx = new CarHealthEntities())
            {
                var tag = ctx.VendorTagSources.FirstOrDefault(x => x.Id == id);

                return tag;
            }
        }

        [HttpPost]
        [ActionName("AddVendorTagSource")]
        public dynamic AddVendorTagSource()
        {
            var form = Request.Content.ReadAsFormDataAsync().Result;

            using (var ctx = new CarHealthEntities())
            {
                var tag = new VendorTagSource();

                tag.GroupName = form["GroupName"];
                tag.Name = form["Name"];
                tag.ShortName = form["ShortName"];
                tag.Memo = form["Memo"];
                tag.PicUrl = form["PicUrl"];
                tag.RecCreateDt = DateTime.Now;
                tag.RecStatus = 1;

                ctx.VendorTagSources.Add(tag);

                ctx.SaveChanges();

                return tag;
            }
        }

        [HttpPost]
        [ActionName("UpdateVendorTagSource")]
        public dynamic UpdateVendorTagSource()
        {
            var form = Request.Content.ReadAsFormDataAsync().Result;

            using (var ctx = new CarHealthEntities())
            {
                var id = form["Id"].ToInt64OrDefault();

                var tag = ctx.VendorTagSources.FirstOrDefault(x => x.Id == id);
                if (tag != null)
                {
                    tag.GroupName = form["GroupName"];
                    tag.Name = form["Name"];
                    tag.ShortName = form["ShortName"];
                    tag.Memo = form["Memo"];
                    tag.PicUrl = form["PicUrl"];

                    ctx.SaveChanges();

                    return tag;
                }
            }

            return null;
        }

        [HttpPost]
        [ActionName("DeleteVendorTagSource")]
        public dynamic DeleteVendorTagSource()
        {
            var form = Request.Content.ReadAsFormDataAsync().Result;

            using (var ctx = new CarHealthEntities())
            {
                var id = form["Id"].ToInt64OrDefault();

                var tag = ctx.VendorTagSources.FirstOrDefault(x => x.Id == id);
                if (tag != null)
                {
                    tag.RecStatus = 2;

                    ctx.SaveChanges();

                    return true;
                }
            }
            return false;
        }
    }
}
