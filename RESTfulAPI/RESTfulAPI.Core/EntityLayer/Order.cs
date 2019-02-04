// =======================================================
// Author: Davain Pablo Edwards
// Email:  core8@gmx.net
// Web:    
// =======================================================

using System;


namespace RESTfulAPI.Core.EntityLayer
{
    // MySql northwind db orders table
    public class Order
    {

        public Int32? Id { get; set; }

        public Int32? Employee_Id { get; set; }  // ~ MySql INT datatype
        public Int32? Customer_Id { get; set; }
        public DateTime? Order_Date { get; set; } // ~ MySql DATETIM datatype
        public DateTime? Shipped_Date { get; set; } // ~ MySql DATETIME datatype 
        public Int32? Shipper_Id { get; set; }
        public String Ship_Name { get; set; } // ~ MySql VARCHAR datatype 
        public String Ship_Address { get; set; }
        public String Ship_City { get; set; }
        public String Ship_State_Province { get; set; }
        public String Ship_Zip_Postal_Code { get; set; }
        public String Ship_Country_Region { get; set; }
        public Decimal? Shipping_Fee { get; set; } // ~ MySql DECIMAL datatype
        public Decimal? Taxes { get; set; } // ~ MySql DECIMAL datatype 
        public String Payment_Type { get; set; } 
        public DateTime? Paid_Date { get; set; } // ~ MySql DATETIME datatype
        public String Notes { get; set; } 
        public Double? Tax_Rate { get; set; } // ~ MySql DOUBLE datatype 
        public SByte? Tax_Status_Id { get; set; } // C# SByte ~ MySql TINYINT 
        public SByte? Status_Id { get; set; } // C# SByte ~ MySql TINYINT


    }
}
