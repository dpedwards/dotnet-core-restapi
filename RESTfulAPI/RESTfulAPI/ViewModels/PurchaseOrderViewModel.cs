// =======================================================
// Author: Davain Pablo Edwards
// Email:  core8@gmx.net
// Web:    
// =======================================================

using System;
using System.Runtime.Serialization;

namespace RESTfulAPI.ViewModels
{
    /// <summary>
    /// 
    /// </summary>
    public class PurchaseOrderViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        [IgnoreDataMember]
        public Int32? Id { get; set; } // ~ MySql INT datatype

        /// <summary>
        /// 
        /// </summary>
        public Int32? Supplier_Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Int32? Created_By { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime? Submitted_Date { get; set; } // ~ MySql DATETIME datataype

        /// <summary>
        /// 
        /// </summary>
        public DateTime? Creation_Date { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Int32? Status_Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime? Expected_Date { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Decimal? Shipping_Fee { get; set; } // ~ MySql DECIMAL datatype

        /// <summary>
        /// 
        /// </summary>
        public Decimal? Taxes { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime? Payment_Date { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Decimal? Payment_Amount { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public String Payment_Method { get; set; } // ~ MySql VARCHAR datatype

        /// <summary>
        /// 
        /// </summary>
        public String Notes { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Int32? Approved_By { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime? Approved_Date { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Int32? Submitted_By { get; set; }

    }
}
