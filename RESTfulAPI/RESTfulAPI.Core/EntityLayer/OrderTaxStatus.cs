// =======================================================
// Author: Davain Pablo Edwards
// Email:  core8@gmx.net
// Web:    
// =======================================================

using System;


namespace RESTfulAPI.Core.EntityLayer
{

    // MySql Northwind db order_tax_status table 
    public class OrderTaxStatus
    {

        public Int32? Id { get; set; }  // ~ MySql INT datatype

        public String Tax_Status_Name { get; set; } // ~ MySql VARCHAR datatype


    }
}
