// =======================================================
// Author: Davain Pablo Edwards
// Email:  core8@gmx.net
// Web:    
// =======================================================

using System;

namespace RESTfulAPI.Core.EntityLayer
{
    // MySql Northwind db invoices table 
    public class Invoice
    {
        public Int32? Id { get; set; }
        public Int32? Order_Id { get; set; } // ~ MySql INT datatype
        public DateTime? Invoice_Date { get; set; } // ~ MySql DATETIME datatype
        public DateTime? Due_Date { get; set; }
        public Decimal? Tax { get; set; } // ~ MySql DECIMAL datatype
        public Decimal? Shipping { get; set; }
        public Decimal? Amount_Due { get; set; }


    }
}
