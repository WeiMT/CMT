using System.Collections.Generic;
using System.Web.Mvc;

namespace Vendor.Web.Extension.ViewEngine
{
    public class ExtendedRazorViewEngine : RazorViewEngine
    {
        public void AddViewLocationFormat(string paths)
        {
            var existingPaths = new List<string>(ViewLocationFormats);
            existingPaths.Add(paths);
            ViewLocationFormats = existingPaths.ToArray();
        }

        public void AddPartialViewLocationFormat(string paths)
        {
            var existingPaths = new List<string>(PartialViewLocationFormats);
            existingPaths.Add(paths);
            PartialViewLocationFormats = existingPaths.ToArray();
        }
    }
}