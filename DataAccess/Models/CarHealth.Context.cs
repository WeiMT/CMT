﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class CarHealthEntities : DbContext
    {
        public CarHealthEntities()
            : base("name=CarHealthEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AdminDivision> AdminDivisions { get; set; }
        public virtual DbSet<Article> Articles { get; set; }
        public virtual DbSet<BillItemDiscount> BillItemDiscounts { get; set; }
        public virtual DbSet<CarType> CarTypes { get; set; }
        public virtual DbSet<DiscountScheme> DiscountSchemes { get; set; }
        public virtual DbSet<DiscountSchemeItem> DiscountSchemeItems { get; set; }
        public virtual DbSet<FavourableScheme> FavourableSchemes { get; set; }
        public virtual DbSet<OrderItemDiscount> OrderItemDiscounts { get; set; }
        public virtual DbSet<RepairRecordEvaluate> RepairRecordEvaluates { get; set; }
        public virtual DbSet<SystemDict> SystemDicts { get; set; }
        public virtual DbSet<SystemSetting> SystemSettings { get; set; }
        public virtual DbSet<SysVendorCarGrade> SysVendorCarGrades { get; set; }
        public virtual DbSet<SysVendorCarGradeItem> SysVendorCarGradeItems { get; set; }
        public virtual DbSet<SysVendorProductCatalog> SysVendorProductCatalogs { get; set; }
        public virtual DbSet<SysVendorProductNature> SysVendorProductNatures { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserCar> UserCars { get; set; }
        public virtual DbSet<UserCarRefuel> UserCarRefuels { get; set; }
        public virtual DbSet<UserCarRepairRecord> UserCarRepairRecords { get; set; }
        public virtual DbSet<UserCarRepairRecordItem> UserCarRepairRecordItems { get; set; }
        public virtual DbSet<UserCarRepairRecordPic> UserCarRepairRecordPics { get; set; }
        public virtual DbSet<UserFavorit> UserFavorits { get; set; }
        public virtual DbSet<Vendor> Vendors { get; set; }
        public virtual DbSet<VendorBill> VendorBills { get; set; }
        public virtual DbSet<VendorBillItem> VendorBillItems { get; set; }
        public virtual DbSet<VendorCard> VendorCards { get; set; }
        public virtual DbSet<VendorCardLog> VendorCardLogs { get; set; }
        public virtual DbSet<VendorCardType> VendorCardTypes { get; set; }
        public virtual DbSet<VendorCarGrade> VendorCarGrades { get; set; }
        public virtual DbSet<VendorCarGradeItem> VendorCarGradeItems { get; set; }
        public virtual DbSet<VendorComboCard> VendorComboCards { get; set; }
        public virtual DbSet<VendorComboCardItem> VendorComboCardItems { get; set; }
        public virtual DbSet<VendorComboCardLog> VendorComboCardLogs { get; set; }
        public virtual DbSet<VendorComboCardType> VendorComboCardTypes { get; set; }
        public virtual DbSet<VendorComboCardTypeItem> VendorComboCardTypeItems { get; set; }
        public virtual DbSet<VendorCustomer> VendorCustomers { get; set; }
        public virtual DbSet<VendorEmployee> VendorEmployees { get; set; }
        public virtual DbSet<VendorFunc> VendorFuncs { get; set; }
        public virtual DbSet<VendorOrder> VendorOrders { get; set; }
        public virtual DbSet<VendorOrderItem> VendorOrderItems { get; set; }
        public virtual DbSet<VendorPic> VendorPics { get; set; }
        public virtual DbSet<VendorProduct> VendorProducts { get; set; }
        public virtual DbSet<VendorProductCarGrade> VendorProductCarGrades { get; set; }
        public virtual DbSet<VendorProductCarGradeItem> VendorProductCarGradeItems { get; set; }
        public virtual DbSet<VendorProductCatalog> VendorProductCatalogs { get; set; }
        public virtual DbSet<VendorProductModel> VendorProductModels { get; set; }
        public virtual DbSet<VendorProductNature> VendorProductNatures { get; set; }
        public virtual DbSet<VendorService> VendorServices { get; set; }
        public virtual DbSet<VendorTag> VendorTags { get; set; }
        public virtual DbSet<VendorTagSource> VendorTagSources { get; set; }
        public virtual DbSet<VendorUser> VendorUsers { get; set; }
        public virtual DbSet<VendorUserRole> VendorUserRoles { get; set; }
        public virtual DbSet<VendorUserRoleFunc> VendorUserRoleFuncs { get; set; }
    }
}
