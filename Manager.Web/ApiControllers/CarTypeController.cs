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
    public class CarTypeController : ApiController
    {
        [HttpGet]
        [ActionName("GetCarTypes")]
        public dynamic GetCarTypes(int skip, int take, string brandName = "", string mfgrName = "",
            string carTypeName = "", string carTypeYear = "")
        {
            var sortField = Request.RequestUri.ParseQueryString()["sort[0][field]"];
            var sortDir = Request.RequestUri.ParseQueryString()["sort[0][dir]"];

            using (var ctx = new CarHealthEntities())
            {
                IQueryable<CarType> carTypes;

                if (String.IsNullOrEmpty(sortField) || String.IsNullOrEmpty(sortDir))
                {
                    carTypes = ctx.CarTypes.OrderBy(x => x.Id);
                }
                else
                {
                    carTypes = ctx.CarTypes.OrderBy(sortField, sortDir == "desc");
                }

                if (!String.IsNullOrEmpty(brandName))
                {
                    carTypes = carTypes.Where(x => x.BrandName == brandName);
                }
                if (!String.IsNullOrEmpty(mfgrName))
                {
                    carTypes = carTypes.Where(x => x.MfgrName == mfgrName);
                }
                if (!String.IsNullOrEmpty(carTypeName))
                {
                    carTypes = carTypes.Where(x => x.CarTypeName == carTypeName);
                }
                if (!String.IsNullOrEmpty(carTypeYear))
                {
                    carTypes = carTypes.Where(x => x.CarTypeYear == carTypeYear);
                }

                var total = carTypes.Count();
                carTypes = carTypes.Where(x => x.RecStatus == 1).Skip(skip).Take(take);

                return new
                {
                    total = total,
                    data = carTypes.ToList()
                };
            }
        }

        [HttpPost]
        [ActionName("AddCarType")]
        public dynamic AddCarType()
        {
            var form = Request.Content.ReadAsFormDataAsync().Result;

            using (var ctx = new CarHealthEntities())
            {
                var carType = new CarType();

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
                carType.RecCreateDt = DateTime.Now;
                carType.RecStatus = 1;

                ctx.CarTypes.Add(carType);

                ctx.SaveChanges();

                return carType;
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
                    carType.RecStatus = 2;

                    ctx.SaveChanges();

                    return true;
                }

                return false;
            }
        }

        [HttpGet]
        [ActionName("GetCarTypeBrandNames")]
        public dynamic GetCarTypeBrandNames()
        {
            using (var ctx = new CarHealthEntities())
            {
                var brandNames = ctx.CarTypes.Where(x => x.RecStatus == 1).Select(x => x.BrandName).Distinct().ToList();

                return brandNames.OrderBy(x => x).Select(x => new { key = x, val = x });
            }
        }

        [HttpGet]
        [ActionName("GetCarTypeMfgrNames")]
        public dynamic GetCarTypeMfgrNames(string brandName = "")
        {
            using (var ctx = new CarHealthEntities())
            {
                var mfgrNames = ctx.CarTypes.Where(x => x.RecStatus == 1).Where(x => x.BrandName == brandName).Select(x => x.MfgrName).Distinct().ToList();
                return mfgrNames.OrderBy(x => x).Select(x => new { key = x, val = x });
            }
        }

        [HttpGet]
        [ActionName("GetCarTypeNames")]
        public dynamic GetCarTypeNames(string brandName = "", string mfgrName = "")
        {
            using (var ctx = new CarHealthEntities())
            {
                var carTypeNames = ctx.CarTypes.Where(x => x.RecStatus == 1).Where(x => x.BrandName == brandName && x.MfgrName == mfgrName)
                    .Select(x => x.CarTypeName).Distinct().ToList();
                return carTypeNames.OrderBy(x => x).Select(x => new { key = x, val = x });
            }
        }

        [HttpGet]
        [ActionName("GetCarTypeYears")]
        public dynamic GetCarTypeYears(string brandName = "", string mfgrName = "", string carTypeName = "")
        {
            using (var ctx = new CarHealthEntities())
            {
                var carTypeYears = ctx.CarTypes.Where(x=>x.RecStatus == 1).Where(x => x.BrandName == brandName && x.MfgrName == mfgrName && x.CarTypeName == carTypeName)
                    .Select(x => x.CarTypeYear).Distinct().ToList();

                return carTypeYears.OrderBy(x => x).Select(x => new { key = x, val = x });
            }
        }
    }
}
