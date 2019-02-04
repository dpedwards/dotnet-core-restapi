// =======================================================
// Author: Davain Pablo Edwards
// Email:  core8@gmx.net
// Web:    
// =======================================================

using System;


namespace RESTfulAPI.Core.EntityLayer
{
    // MySql Northwind db order_status table 
    public class OrderStatus
    {

        public Int32? Id { get; set; } // ~ MySql TINYINT datatype

        public String Status_Name { get; set; } // ~ MySql VARCHAR datatype

    }
}
