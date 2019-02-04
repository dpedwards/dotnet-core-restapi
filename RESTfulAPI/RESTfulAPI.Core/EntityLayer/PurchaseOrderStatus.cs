// =======================================================
// Author: Davain Pablo Edwards
// Email:  core8@gmx.net
// Web:    
// =======================================================

using System;


namespace RESTfulAPI.Core.EntityLayer
{
    // MySql Northwind db purchase_order_status
    public class PurchaseOrderStatus
    {

        public Int32? Id { get; set; } // ~ MySql INT datatype 
         
        public String Status { get; set; } // ~ MySql VARCHAR datatype

    }
}
