// =======================================================
// Author: Davain Pablo Edwards
// Email:  core8@gmx.net
// Web:    
// =======================================================

using System;


namespace RESTfulAPI.Core.EntityLayer
{
    // MySql Northwind db inventory_transaction_types table
    public class InventoryTransactionType
    {

        public Int32? Id { get; set; } // ~ MySql TINYINT datatype 
        public String Type_Name { get; set; } // ~ MySql VARCHAR datatype 

    }
}
