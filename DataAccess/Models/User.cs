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
    
    public partial class User
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string NickName { get; set; }
        public string Cellphone { get; set; }
        public int Type { get; set; }
        public string Email { get; set; }
        public Nullable<System.DateTime> LatestLoginDt { get; set; }
        public string LatestLoginIp { get; set; }
        public string Password { get; set; }
        public System.DateTime RecCreateDt { get; set; }
        public int RecStatus { get; set; }
        public string AvatarUrl { get; set; }
    }
}
