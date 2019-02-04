// =======================================================
// Author: Davain Pablo Edwards
// Email:  core8@gmx.net
// Web:    
// =======================================================

using System;

namespace RESTfulAPI.Core.EntityLayer
{
    // MySql Northwind db inventory_transactions table 
    public class InventoryTransaction
    {
        public Int32? Id { get; set; }

        public SByte? Transaction_Type { get; set; } // ~ MySql TINYINT datatype
        public DateTime? Transaction_Created_Date { get; set; } // ~ MySql DATETIME datatype
        public DateTime? Transaction_Modified_Date { get; set; }
        public Int32? Product_Id { get; set; } // ~ MySql INT datatype
        public Int32? Quantity { get; set; }
        public Int32? Purchase_Order_Id { get; set; }
        public Int32? Customer_Order_Id { get; set; }
        public String Comments { get; set; } // ~ MySql VARCHAR datatype


        


    }
}
