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
    public class OrderDetailViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        [IgnoreDataMember]
        public Int32? Id { get; set; }  // ~ MySql INT datatype

        /// <summary>
        /// 
        /// </summary>
        public Int32? Order_Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Int32? Product_Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Decimal? Quantity { get; set; } // ~ MySql DECIMAL datatype 

        /// <summary>
        /// 
        /// </summary>
        public Decimal? Unit_Price { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Double? Discount { get; set; } // ~ MySql DOUBLE datatype 

        /// <summary>
        /// 
        /// </summary>
        public Int32? Status_Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime? Date_Allocated { get; set; } // ~ MySql DATETIME datatype

        /// <summary>
        /// 
        /// </summary>
        public Int32? Purchase_Order_Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Int32? Inventory_Id { get; set; }

    }
}
