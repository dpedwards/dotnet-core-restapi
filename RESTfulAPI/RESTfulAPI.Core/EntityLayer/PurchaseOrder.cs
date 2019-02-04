// =======================================================
// Author: Davain Pablo Edwards
// Email:  core8@gmx.net
// Web:    
// =======================================================

using System;


namespace RESTfulAPI.Core.EntityLayer
{
    // MySql Northwind db purchase_orders table
    public class PurchaseOrder
    {

        public Int32? Id { get; set; } // ~ MySql INT datatype

        public Int32? Supplier_Id { get; set; }
        public Int32? Created_By { get; set; }
        public DateTime? Submitted_Date { get; set; } // ~ MySql DATETIME datataype
        public DateTime? Creation_Date { get; set; }
        public Int32? Status_Id { get; set; }
        public DateTime? Expected_Date { get; set; }
        public Decimal? Shipping_Fee { get; set; } // ~ MySql DECIMAL datatype
        public Decimal? Taxes { get; set; }
        public DateTime? Payment_Date { get; set; }
        public Decimal? Payment_Amount { get; set; }
        public String Payment_Method { get; set; } // ~ MySql VARCHAR datatype
        public String Notes { get; set; }
        public Int32? Approved_By { get; set; }
        public DateTime? Approved_Date { get; set; }
        public Int32? Submitted_By { get; set; }

    }
}
