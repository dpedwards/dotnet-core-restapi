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
    public class InventoryTransactionViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        [IgnoreDataMember]
        public Int32? Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public SByte? Transaction_Type { get; set; } // ~ MySql TINYINT datatype

        /// <summary>
        /// 
        /// </summary>
        public DateTime? Transaction_Created_Date { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime? Transaction_Modified_Date { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Int32? Product_Id { get; set; } // ~ MySql INT

        /// <summary>
        /// 
        /// </summary>
        public Int32? Quantity { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Int32? Purchase_Order_Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Int32? Customer_Order_Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public String Comments { get; set; } // ~ MySql VARCHAR 
    }
}
