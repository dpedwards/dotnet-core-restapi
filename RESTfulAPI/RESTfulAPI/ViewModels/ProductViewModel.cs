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
    public class ProductViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        [IgnoreDataMember]
        public Int32? Id { get; set; } // ~ MySql INT datatype

        /// <summary>
        /// 
        /// </summary>
        public String Supplier_Ids { get; set; }  // ~ MySql LONGTEXT datatype

        /// <summary>
        /// 
        /// </summary>
        public String Product_Code { get; set; } // ~ MySql VARCHAR datatype

        /// <summary>
        /// 
        /// </summary>
        public String Product_Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public String Description { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Decimal? Standard_Cost { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Decimal? List_Price { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Int32? Reorder_Level { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Int32? Target_Level { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public String Quantity_Per_Unit { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Boolean Discontinued { get; set; } // ~ MySql TINYINT 1 datatype 

        /// <summary>
        /// 
        /// </summary>
        public Int32? Minimum_Reorder_Quantity { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public String Category { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Byte[] Attachments { get; set; } // ~ MySql LONGBLOB datatype
    }
}
