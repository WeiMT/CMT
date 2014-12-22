using System;

namespace User.Service.Helpers
{
    public static class LngLatDistanceHelper
    {
        private const double EarthRadius = 6378.137;//地球半径

        private static double Rad(double d)
        {
            return d * Math.PI / 180.0;
        }

        public static double GetDistance(double lng1, double lat1, double lng2, double lat2)
        {
            double radLat1 = Rad(lat1);
            double radLat2 = Rad(lat2);
            double a = radLat1 - radLat2;
            double b = Rad(lng1) - Rad(lng2);

            double s = 2 * Math.Asin(Math.Sqrt(Math.Pow(Math.Sin(a / 2), 2) +
             Math.Cos(radLat1) * Math.Cos(radLat2) * Math.Pow(Math.Sin(b / 2), 2)));
            s = s * EarthRadius;
            s = Math.Round(s * 10000) / 10000;
            return s;
        } 
    }
}