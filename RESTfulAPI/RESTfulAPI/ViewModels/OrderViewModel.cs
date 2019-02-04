// =======================================================
// Author: Davain Pablo Edwards
// Email:  core8@gmx.net
// Web:    
// =======================================================

using System;
using System.Runtime.Serialization;

namespace RESTfulAPI.ViewModels
{

    /// <summary>
    /// 
    /// </summary>
    public class OrderViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        [IgnoreDataMember]
        public Int32? Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Int32? Employee_Id { get; set; }  // ~ MySql INT datatype

        /// <summary>
        /// 
        /// </summary>
        public Int32? Customer_Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime? Order_Date { get; set; } // ~ MySql DATETIM datatype

        /// <summary>
        /// 
        /// </summary>
        public DateTime? Shipped_Date { get; set; } // ~ MySql DATETIME datatype 

        /// <summary>
        /// 
        /// </summary>
        public Int32? Shipper_Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public String Ship_Name { get; set; } // ~ MySql VARCHAR datatype 

        /// <summary>
        /// 
        /// </summary>
        public String Ship_Address { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public String Ship_City { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public String Ship_State_Province { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public String Ship_Zip_Postal_Code { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public String Ship_Country_Region { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Decimal? Shipping_Fee { get; set; } // ~ MySql DECIMAL datatype

        /// <summary>
        /// 
        /// </summary>
        public Decimal? Taxes { get; set; } // ~ MySql DECIMAL datatype 

        /// <summary>
        /// 
        /// </summary>
        public String Payment_Type { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime? Paid_Date { get; set; } // ~ MySql DATETIME datatype

        /// <summary>
        /// 
        /// </summary>
        public String Notes { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Double? Tax_Rate { get; set; } // ~ MySql DOUBLE datatype 

        /// <summary>
        /// 
        /// </summary>
        public SByte? Tax_Status_Id { get; set; } // C# SByte ~ MySql TINYINT 

        /// <summary>
        /// 
        /// </summary>
        public SByte? Status_Id { get; set; } // C# SByte ~ MySql TINYINT

    }
}
