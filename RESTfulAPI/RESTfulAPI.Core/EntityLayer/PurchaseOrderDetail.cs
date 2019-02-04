// =======================================================
// Author: Davain Pablo Edwards
// Email:  core8@gmx.net
// Web:    
// =======================================================

using System;


namespace RESTfulAPI.Core.EntityLayer
{
    // MySql Northwind db purchase_order_details table
    public class PurchaseOrderDetail
    {

        public Int32? Id { get; set; } // ~ MySql INT datatype

        public Int32? Purchase_Order_Id { get; set; }
        public Int32? Product_Id { get; set; }
        public Decimal? Quantity { get; set; } // ~ MySql DECIMAL datatype
        public Decimal? Unit_Cost { get; set; } 
        public DateTime? Date_Received { get; set; } // ~ MySql DATETIME datatype 
        public Boolean Posted_To_Inventory { get; set; } // ~ MySql TINYINT 1 datatype
        public Int32? Inventory_Id { get; set; } 
        
    }
}
