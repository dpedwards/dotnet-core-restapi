// =======================================================
// Author: Davain Pablo Edwards
// Email:  core8@gmx.net
// Web:    
// =======================================================

using System;

namespace RESTfulAPI.Core.EntityLayer
{

    // MySql Northwind db products table
    public class Product
    {

        public Int32? Id { get; set; } // ~ MySql INT datatype

        public String Supplier_Ids { get; set; }  // ~ MySql LONGTEXT datatype
        public String Product_Code { get; set; } // ~ MySql VARCHAR datatype
        public String Product_Name { get; set; }
        public String Description { get; set; }
        public Decimal? Standard_Cost { get; set; }
        public Decimal? List_Price { get; set; }
        public Int32? Reorder_Level { get; set; }
        public Int32? Target_Level { get; set; }
        public String Quantity_Per_Unit { get; set; }
        public Boolean Discontinued { get; set; } // ~ MySql TINYINT 1 datatype 
        public Int32? Minimum_Reorder_Quantity { get; set; }
        public String Category { get; set; }
        public Byte[] Attachments { get; set; } // ~ MySql LONGBLOB datatype

    }
}
