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
    public class PurchaseOrderDetailViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        [IgnoreDataMember]
        public Int32? Id { get; set; } // ~ MySql INT datatype

        /// <summary>
        /// 
        /// </summary>
        public Int32? Purchase_Order_Id { get; set; }

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
        public Decimal? Unit_Cost { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime? Date_Received { get; set; } // ~ MySql DATETIME datatype 

        /// <summary>
        /// 
        /// </summary>
        public Boolean Posted_To_Inventory { get; set; } // ~ MySql TINYINT 1 datatype

        /// <summary>
        /// 
        /// </summary>
        public Int32? Inventory_Id { get; set; }


    }
}
