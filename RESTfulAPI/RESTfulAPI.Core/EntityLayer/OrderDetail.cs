// =======================================================
// Author: Davain Pablo Edwards
// Email:  core8@gmx.net
// Web:    
// =======================================================

using System;

namespace RESTfulAPI.Core.EntityLayer
{

    // MySql Northwind db order_detail table 
    public class OrderDetail
    {

        public Int32? Id { get; set; }  // ~ MySql INT datatype

        public Int32? Order_Id { get; set; } 
        public Int32? Product_Id { get; set; }
        public Decimal? Quantity { get; set; } // ~ MySql DECIMAL datatype 
        public Decimal? Unit_Price { get; set; }
        public Double? Discount { get; set; } // ~ MySql DOUBLE datatype 
        public Int32? Status_Id { get; set; } 
        public DateTime? Date_Allocated { get; set; } // ~ MySql DATETIME datatype
        public Int32? Purchase_Order_Id { get; set; }
        public Int32? Inventory_Id { get; set; }

    }
}
