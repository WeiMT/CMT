//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataAccess.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Article
    {
        public long Id { get; set; }
        public int Type { get; set; }
        public string Title { get; set; }
        public string TitlePicUrl { get; set; }
        public Nullable<System.DateTime> IssueDt { get; set; }
        public Nullable<long> VendorId { get; set; }
        public Nullable<int> ViewCount { get; set; }
        public Nullable<int> ReviewCount { get; set; }
        public Nullable<int> IsRecommend { get; set; }
        public string Content { get; set; }
        public Nullable<System.DateTime> RecommendDt { get; set; }
        public Nullable<int> Status { get; set; }
    }
}