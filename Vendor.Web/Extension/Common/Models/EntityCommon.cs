using System;

namespace Vendor.Web.Extension.Common.Models
{
    public class EntityCommon
    {
        /// <summary>
        /// 创建者Id
        /// </summary>
        public int? CreateId { get; set; }

        /// <summary>
        /// 创建者名称
        /// </summary>
        public string CreateBy { get; set; }

        /// <summary>
        /// 创建日期
        /// </summary>
        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// 修改者Id
        /// </summary>
        public int? ModifyId { get; set; }

        /// <summary>
        /// 修改者名称
        /// </summary>
        public string ModifyBy { get; set; }

        /// <summary>
        /// 修改者日期
        /// </summary>
        public DateTime? ModifyTime { get; set; }
    }
}
