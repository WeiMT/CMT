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
    
    public partial class VendorComboCardType
    {
        public long Id { get; set; }
        public long VendorId { get; set; }
        public string Name { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<decimal> RealPrice { get; set; }
        public Nullable<int> IsCardNoLimit { get; set; }
        public Nullable<int> CardNoLimitCount { get; set; }
        public Nullable<int> IsExpireLimit { get; set; }
        public string ExpireLimit { get; set; }
        public string ApptMemo { get; set; }
        public string Memo { get; set; }
        public System.DateTime RecCreateDt { get; set; }
        public int RecStatus { get; set; }
    }
}
