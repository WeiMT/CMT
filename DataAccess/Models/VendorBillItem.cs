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
    
    public partial class VendorBillItem
    {
        public long Id { get; set; }
        public long BillId { get; set; }
        public long OrderItemId { get; set; }
        public Nullable<decimal> Cost { get; set; }
        public Nullable<decimal> RealCost { get; set; }
        public Nullable<int> IsDiscount { get; set; }
        public System.DateTime RecCreateDt { get; set; }
        public int RecStaus { get; set; }
    }
}