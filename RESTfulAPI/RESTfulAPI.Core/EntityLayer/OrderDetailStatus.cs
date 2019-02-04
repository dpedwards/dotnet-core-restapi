// =======================================================
// Author: Davain Pablo Edwards
// Email:  core8@gmx.net
// Web:    
// =======================================================

using System;


namespace RESTfulAPI.Core.EntityLayer
{

    // MySql Northwind db order_details_status table
    public class OrderDetailStatus
    {

        public Int32? Id { get; set; } // ~ MySql INT datatype

        public String Status_Name { get; set; } // ~ MySql VARCHAR  datatype 

    }
}
