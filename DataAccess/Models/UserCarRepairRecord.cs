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
    
    public partial class UserCarRepairRecord
    {
        public long Id { get; set; }
        public long UserCarId { get; set; }
        public int IsManul { get; set; }
        public Nullable<long> VendorId { get; set; }
        public Nullable<System.DateTime> RepairDt { get; set; }
        public string RepairPlace { get; set; }
        public Nullable<int> Type { get; set; }
        public string Memo { get; set; }
        public Nullable<decimal> Cost { get; set; }
        public System.DateTime RecCreateDt { get; set; }
        public int RecStatus { get; set; }
    }
}