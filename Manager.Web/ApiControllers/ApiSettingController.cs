using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DataAccess.Models;
using Manager.Web.Common.Extensions;

namespace Manager.Web.ApiControllers
{
    public class ApiSettingController : ApiController
    {
        [HttpGet]
        [ActionName("GetCarTypes")]
        public dynamic GetCarTypes(int skip, int take)
        {
            var sortField = Request.RequestUri.ParseQueryString()["sort[0][field]"];
            var sortDir = Request.RequestUri.ParseQueryString()["sort[0][dir]"];

            using (var ctx = new CarHealthEntities())
            {
                var total = ctx.CarTypes.Count();

                IQueryable<CarType> carTypes;

                if (String.IsNullOrEmpty(sortField) || String.IsNullOrEmpty(sortDir))
                {
                    carTypes = ctx.CarTypes.OrderBy(x => x.Id);
                }
                else
                {
                    carTypes = ctx.CarTypes.OrderBy(sortField, sortDir == "desc");
                }

                carTypes = carTypes.Skip(skip).Take(take);

                return new
                {
                    total = total,
                    data = carTypes.ToList()
                };
            }
        }

        [HttpPost]
        [ActionName("UpdateCarType")]
        public dynamic UpdateCarType()
        {
            var form = Request.Content.ReadAsFormDataAsync().Result;

            using (var ctx = new CarHealthEntities())
            {
                var id = form["Id"].ToInt64OrDefault(-1);

                var carType = ctx.CarTypes.FirstOrDefault(x => x.Id == id);
                if (carType != null)
                {
                    carType.BrandFirstLetter = form["BrandFirstLetter"];
                    carType.BrandName = form["BrandName"];
                    carType.MfgrName = form["MfgrName"];
                    carType.CarTypeName = form["CarTypeName"];
                    carType.CarTypeYear = form["CarTypeYear"];
                    carType.Specification = form["Specification"];
                    carType.BrandCountry = form["BrandCountry"];
                    carType.Technology = form["Technology"];
                    carType.Grade = form["Grade"];
                    carType.GasDisplacement = form["GasDisplacement"];
                    carType.GearBox = form["GearBox"];

                    ctx.SaveChanges();

                    return carType;
                }

                return null;
            }            
        }

        [HttpPost]
        [ActionName("DeleteCarType")]
        public dynamic DeleteCarType()
        {
            var form = Request.Content.ReadAsFormDataAsync().Result;

            using (var ctx = new CarHealthEntities())
            {
                var id = form["Id"].ToInt64OrDefault(-1);

                var carType = ctx.CarTypes.FirstOrDefault(x => x.Id == id);
                if (carType != null)
                {
                    ctx.CarTypes.Remove(carType);

                    ctx.SaveChanges();

                    return true;
                }

                return false;
            }            
        }
    }
}
